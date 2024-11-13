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
        public async Task<APIResponse<IEnumerable<SocialMetricDto>>> GetSocialMetricsByCountryCodeAsync(string countryCode)
        {
            throw new NotImplementedException();
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
            if (string.IsNullOrWhiteSpace(record.SeriesName))
                return $"Row {rowNumber}: 'Series Name' field is required.";
            if (string.IsNullOrWhiteSpace(record.SeriesCode))
                return $"Row {rowNumber}: 'Series Code' field is required.";

            // Validate length of fields
            if (record.SeriesCode.Length > 100)
                return $"Row {rowNumber}: 'Series Code' must be between 1 and 100 characters.";
            if (record.SeriesName.Length > 150)
                return $"Row {rowNumber}: 'Series Name' must be between 1 and 150 characters.";
            if (record.CountryName.Length > 50)
                return $"Row {rowNumber}: 'Country Name' must be between 1 and 50 characters.";
            if (record.CountryCode.Length > 2)
                return $"Row {rowNumber}: Invalid Country Code in 'Country Code' field.";

            record.CountryCode = record.CountryCode.ToUpperInvariant();
            return null!;
        }
    }
}
