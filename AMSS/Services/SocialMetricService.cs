using AMSS.Models;
using AMSS.Models.Dto.SocialMetric;
using AMSS.Repositories.IRepository;
using AMSS.Services.IService;
using AutoMapper;
using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using System.Net;
using AMSS.Utility;
using AMSS.Models.Dto.SocialYear;
using System.Linq;

namespace AMSS.Services
{
    public class SocialMetricService : BaseService, ISocialMetricService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SocialMetricService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<APIResponse<IEnumerable<SocialMetricDto>>> GetSocialMetricsByProvinceCode(GetSocialMetricByProvinceCodeRequest request)
        {
            try
            {
                var seriesCodesArray = request.SeriesCodes?.Split(',', StringSplitOptions.RemoveEmptyEntries) ?? Array.Empty<string>();

                var seriesMetricsFromDb = await _unitOfWork.SeriesMetricRepository
                                                            .GetAllAsync(u => seriesCodesArray.Contains(u.Code));
                if (seriesMetricsFromDb == null || !seriesMetricsFromDb.Any())
                {
                    return BuildErrorResponseMessage<IEnumerable<SocialMetricDto>>("Not Found Series Metric Code", HttpStatusCode.NotFound);
                }
                var provinceFromDb = await _unitOfWork.ProvinceRepository.GetAsync(u => u.Code == request.ProvinceCode);
                if (provinceFromDb == null)
                {
                    return BuildErrorResponseMessage<IEnumerable<SocialMetricDto>>(
                        "Not Found Province Code",
                        HttpStatusCode.NotFound);
                }

                var seriesMetricIds = new HashSet<Guid>(seriesMetricsFromDb.Select(s => s.Id));

                var socialMetricsFromDb = await _unitOfWork.SocialMetricRepository
                                        .GetAllAsync(u => seriesMetricIds.Contains((Guid)u.SeriesMetricId!) 
                                        && u.ProvinceId == provinceFromDb.Id, includeProperties: "SocialYears,SeriesMetric");

                var socialMetricDto = _mapper.Map<IEnumerable<SocialMetricDto>>(socialMetricsFromDb);

                return BuildSuccessResponseMessage(socialMetricDto, "Import social metric data successfully");
            }
            catch (Exception ex)
            {
                return BuildErrorResponseMessage<IEnumerable<SocialMetricDto>>(ex.Message, (HttpStatusCode)StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<APIResponse<bool>> ImportSocialMetricAsync(CreateSocialMetricDto createSocialMetric)
        {
            try
            {
                if (Path.GetExtension(createSocialMetric.File.FileName) != SD.ExcelExtension && Path.GetExtension(createSocialMetric.File.FileName) != SD.CsvExtension)
                {
                    return BuildErrorResponseMessage<bool>("File extension is invalid. Only support csv and excel file", HttpStatusCode.BadRequest);
                }

                // Read and Validate CSV, Excel records
                var (data, errorMessage) = await ReadAndValidateCsvRecords(createSocialMetric.File);

                if (data.Any())
                {
                    var seriesCodes = data
                        .Where(x => !string.IsNullOrEmpty(x.SeriesCode))
                        .Select(x => x.SeriesCode)
                        .Distinct()
                        .ToList();

                    var provinceCodes = data
                        .Where(x => !string.IsNullOrEmpty(x.ProvinceCode))
                        .Select(x => x.ProvinceCode)
                        .Distinct()
                        .ToList();

                    // Check SeriesMetric and Province is existed?
                    var existingSeries = await _unitOfWork.SeriesMetricRepository
                        .GetAllAsync(x => seriesCodes.Contains(x.Code));

                    var newSeries = data
                                    .Where(r => !existingSeries.Any(s => s.Code == r.SeriesCode))
                                    .Select(r => new SeriesMetric
                                    {
                                        Code = r.SeriesCode!,
                                        Name = r.SeriesName!,
                                        CreatedAt = DateTime.Now,
                                        UpdatedAt = DateTime.Now,
                                    })
                                    .Distinct()
                                    .ToList();

                    if (newSeries.Any())
                    {
                        await _unitOfWork.SeriesMetricRepository.CreateRangeAsync(newSeries);
                    }

                    var existingProvinces = await _unitOfWork.ProvinceRepository
                        .GetAllAsync(x => provinceCodes.Contains(x.Code));

                    var newSocialMetrics = new List<SocialMetric>();
                    var newSocialYears = new List<SocialYear>();

                    foreach (var record in data)
                    {
                        if (string.IsNullOrEmpty(record.SeriesCode) || string.IsNullOrEmpty(record.ProvinceCode)) continue;

                        // Find SeriesMetric and ProvinceId
                        var seriesMetric = existingSeries.FirstOrDefault(x => x.Code == record.SeriesCode);
                        var province = existingProvinces.FirstOrDefault(x => x.Code == record.ProvinceCode);

                        if (seriesMetric == null || province == null) continue;

                        // Check SocialMetric is existed? 
                        var existingSocialMetric = await _unitOfWork.SocialMetricRepository
                            .GetAsync(x =>
                                x.SeriesMetricId == seriesMetric.Id &&
                                x.ProvinceId == province.Id);

                        if (existingSocialMetric == null)
                        {
                            // Create new SocialMetric
                            var newSocialMetric = new SocialMetric
                            {
                                SeriesMetricId = seriesMetric.Id,
                                ProvinceId = province.Id,
                                CreatedAt = DateTime.Now,
                                UpdatedAt = DateTime.Now,
                                SocialYears = new List<SocialYear>()
                            };

                            // Create SocialYear from YearData
                            foreach (var yearData in record.YearData)
                            {
                                if (yearData.Value.HasValue)
                                {
                                    newSocialMetric.SocialYears.Add(new SocialYear
                                    {
                                        Year = yearData.Key,
                                        Value = (decimal)yearData.Value,
                                        CreatedAt = DateTime.Now,
                                        UpdatedAt = DateTime.Now,
                                    });
                                }
                            }

                            newSocialMetrics.Add(newSocialMetric);
                        }
                        else
                        {
                            // Link SocialYear to SocialMetric was existed
                            foreach (var yearData in record.YearData)
                            {
                                if (yearData.Value.HasValue)
                                {
                                    var existingSocialYear = await _unitOfWork.SocialYearRepository
                                        .GetAsync(x =>
                                            x.SocialMetricId == existingSocialMetric.Id &&
                                            x.Year == yearData.Key);

                                    if (existingSocialYear == null)
                                    {
                                        newSocialYears.Add(new SocialYear
                                        {
                                            SocialMetricId = existingSocialMetric.Id,
                                            Year = yearData.Key,
                                            Value = (decimal)yearData.Value,
                                            CreatedAt = DateTime.Now,
                                            UpdatedAt = DateTime.Now,
                                        });
                                    }
                                }
                            }
                        }
                    }

                    // Insert Sorial Metric Data
                    if (newSocialMetrics.Any())
                    {
                        await _unitOfWork.SocialMetricRepository.CreateRangeAsync(newSocialMetrics);
                    }

                    // Insert Social Year Data
                    if (newSocialYears.Any())
                    {
                        await _unitOfWork.SocialYearRepository.CreateRangeAsync(newSocialYears);
                    }

                    _unitOfWork.SaveAsync();
                }


                return BuildSuccessResponseMessage(true, "Import social metric data successfully");
            }
            catch (Exception ex)
            {
                return BuildErrorResponseMessage<bool>(ex.Message, (HttpStatusCode)StatusCodes.Status500InternalServerError);
            }
        }

        private async Task<(List<SocialMetricRecord> Data, string ErrorMessage)> ReadAndValidateCsvRecords(IFormFile file)
        {
            var reader = new StreamReader(file.OpenReadStream());
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                HeaderValidated = null,
                MissingFieldFound = null,
                ShouldSkipRecord = record => record.Record.All(string.IsNullOrWhiteSpace)
            };
            var csv = new CsvReader(reader, config);

            await csv.ReadAsync();
            csv.ReadHeader();
            var headers = csv.HeaderRecord.ToList();

            if (!SD.HeaderRecordsSocialMetricTemplate.All(headers.Contains))
                return (null!, "This file is not correct format");

            csv.Context.RegisterClassMap<SocialMetricRecordMap>();

            var records = new List<SocialMetricRecord>();

            while (await csv.ReadAsync())
            {
                var record = csv.GetRecord<SocialMetricRecord>();

                // Read Year Header
                foreach (var header in headers)
                {
                    if (int.TryParse(header, out int year))
                    {
                        var field = csv.GetField(header);

                        if (double.TryParse(field, out double value))
                        {
                            record.YearData[year] = value;
                        }
                        else
                        {
                            record.YearData[year] = null;
                        }
                    }
                }

                records.Add(record);
            }

            if (records.Count == 0)
                return (null!, "No records to progress");

            int rowNumber = 1;

            foreach (var record in records)
            {
                rowNumber++;

                var validationResult = ValidateRecord(record, rowNumber, records);
                if (!string.IsNullOrEmpty(validationResult))
                {
                    return (null, validationResult);
                }
            }

            return (records, null!);
        }

        private static string ValidateRecord(SocialMetricRecord record, int rowNumber, List<SocialMetricRecord> records)
        {
            // Check required fields
            if (string.IsNullOrWhiteSpace(record.CountryName))
                return $"Row {rowNumber}: 'Country Name' field is required.";
            if (string.IsNullOrWhiteSpace(record.CountryCode))
                return $"Row {rowNumber}: 'Country Code' field is required.";
            if (string.IsNullOrWhiteSpace(record.ProvinceName))
                return $"Row {rowNumber}: 'Province Name' field is required.";
            if (string.IsNullOrWhiteSpace(record.ProvinceCode))
                return $"Row {rowNumber}: 'Province Code' field is required.";
            if (string.IsNullOrWhiteSpace(record.SeriesName))
                return $"Row {rowNumber}: 'Series Name' field is required.";
            if (string.IsNullOrWhiteSpace(record.SeriesCode))
                return $"Row {rowNumber}: 'Series Code' field is required.";

            // Validate length of fields
            if (record.CountryName.Length > 50)
                return $"Row {rowNumber}: 'Country Name' must be between 1 and 50 characters.";
            if (record.CountryCode.Length > 2)
                return $"Row {rowNumber}: Invalid Country Code in 'Country Code' field.";
            if (record.ProvinceName.Length > 100)
                return $"Row {rowNumber}: 'Province Name' must be between 1 and 100 characters.";
            if (record.ProvinceCode.Length > 20)
                return $"Row {rowNumber}: Invalid Province Code in 'Province Code' field.";
            if (record.SeriesCode.Length > 100)
                return $"Row {rowNumber}: 'Series Code' must be between 1 and 100 characters.";
            if (record.SeriesName.Length > 150)
                return $"Row {rowNumber}: 'Series Name' must be between 1 and 150 characters.";

            record.CountryCode = record.CountryCode.ToUpperInvariant();
            return null!;
        }
    }
}
