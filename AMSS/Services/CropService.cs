using AMSS.Models;
using AMSS.Models.Dto.Crop;
using AMSS.Models.Dto.FieldCrop;
using AMSS.Repositories.IRepository;
using AMSS.Services.IService;
using AMSS.Utility;
using AutoMapper;
using Microsoft.Data.SqlClient;
using System.Net;

namespace AMSS.Services
{
    public class CropService : BaseService, ICropService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBlobService _blobService;
        private readonly IMapper _mapper;

        public CropService(IUnitOfWork unitOfWork, IBlobService blobService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _blobService = blobService;
            _mapper = mapper;
        }

        public async Task<APIResponse<IEnumerable<CropDto>>> GetCropsAsync()
        {
            try
            {
                IEnumerable<Crop> lstCrops = await _unitOfWork.CropRepository
                    .GetAllAsync(includeProperties: "CropType");
                var lstCropDtos = _mapper.Map<IEnumerable<CropDto>>(lstCrops);
                if (lstCrops == null)
                {
                    return BuildErrorResponseMessage<IEnumerable<CropDto>>("Failed to get all crops", HttpStatusCode.NotFound);
                }

                return BuildSuccessResponseMessage(lstCropDtos, "Get all Crops successfully");
            }
            catch (Exception ex)
            {
                return BuildErrorResponseMessage<IEnumerable<CropDto>>(ex.Message, (HttpStatusCode)StatusCodes.Status500InternalServerError);
            }
        }
        public async Task<APIResponse<CropDto>> GetCropByIdAsync(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return BuildErrorResponseMessage<CropDto>("Oops ! Not Found Crop ID", HttpStatusCode.NotFound);
                }
                Crop crop = await _unitOfWork.CropRepository
                    .GetAsync(u => u.Id.Equals(Guid.Parse(id)), includeProperties: "CropType");
                CropDto cropDto = _mapper.Map<CropDto>(crop);
                if (crop == null)
                {
                    return BuildErrorResponseMessage<CropDto>("Oops ! Something wrong when get crop by id", HttpStatusCode.NotFound);
                }
                return BuildSuccessResponseMessage(cropDto, "Get Crop by Id successfully");
            }
            catch (Exception ex)
            {
                return BuildErrorResponseMessage<CropDto>(ex.Message, (HttpStatusCode)StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<APIResponse<IEnumerable<FieldCropDto>>> GetCropsByFieldIdAsync(string fieldId)
        {
            try
            {
                var fieldCropFromDb = await _unitOfWork.FieldCropRepository
                    .GetAllAsync(u => u.FieldId.Equals(Guid.Parse(fieldId)), includeProperties: "Crop");

                if (fieldCropFromDb == null)
                {
                    return BuildErrorResponseMessage<IEnumerable<FieldCropDto>>("Oops ! Something wrong when get crop by id", HttpStatusCode.NotFound);

                }
                var fieldCropDto = _mapper.Map<IEnumerable<FieldCropDto>>(fieldCropFromDb);

                return BuildSuccessResponseMessage(fieldCropDto, "Get Crop by FieldId successfully");
            }
            catch (Exception ex)
            {
                return BuildErrorResponseMessage<IEnumerable<FieldCropDto>>(ex.Message, (HttpStatusCode)StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<APIResponse<CropDto>> CreateCropAsync(CreateCropDto createCropDto)
        {
            try
            {
                if (createCropDto.File == null || createCropDto.File.Length == 0)
                {
                    return BuildErrorResponseMessage<CropDto>("File is required", HttpStatusCode.NotFound);
                }

                var newCropType = new CropType()
                {
                    Id = Guid.NewGuid(),
                    Name = createCropDto.Name,
                    Code = GenerateCode(createCropDto.Name),
                    Type = createCropDto.CropTypeName,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                };
                await _unitOfWork.CropTypeRepository.CreateAsync(newCropType);

                var newCrop = _mapper.Map<Crop>(createCropDto);
                newCrop.CropTypeId = newCropType.Id;
                newCrop.CropType = newCropType;
                newCrop.CreatedAt = DateTime.Now;
                newCrop.UpdatedAt = DateTime.Now;

                string fileName = $"{Guid.NewGuid()}{Path.GetExtension(createCropDto.File.FileName)}";
                newCrop.Icon = await _blobService.UploadBlob(fileName, SD.SD_Storage_Container, createCropDto.File);

                await _unitOfWork.CropRepository.CreateAsync(newCrop);
                _unitOfWork.SaveAsync();

                var newCropDto = _mapper.Map<CropDto>(newCrop);
                return BuildSuccessResponseMessage(newCropDto, "Crop created successfully", HttpStatusCode.Created);
            }
            catch (SqlException ex)
            {
                return BuildErrorResponseMessage<CropDto>(ex.Message, (HttpStatusCode)StatusCodes.Status500InternalServerError);
            }
        }

        public static string GenerateCode(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return string.Empty;

            var words = name.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (words.Length == 1)
            {
                return $"{char.ToUpper(name[0])}{char.ToUpper(name[^1])}";
            }
            else
            {
                return string.Concat(words.Select(w => char.ToUpper(w[0])));
            }
        }

        public async Task<APIResponse<CropDto>> UpdateCropAsync(string id, UpdateCropDto updateCropDto)
        {
            try
            {
                if (updateCropDto == null || !updateCropDto.Id.Equals(Guid.Parse(id)))
                {
                    return BuildErrorResponseMessage<CropDto>("Update crop request does not exist!", HttpStatusCode.NotFound);
                }

                Crop cropFromDb = await _unitOfWork.CropRepository.GetAsync(u => u.Id.Equals(Guid.Parse(id)), false);

                if (cropFromDb == null)
                {
                    return BuildErrorResponseMessage<CropDto>("This crop does not exist!", HttpStatusCode.NotFound);
                }
                cropFromDb = _mapper.Map<Crop>(updateCropDto);
                cropFromDb.UpdatedAt = DateTime.Now;

                if (updateCropDto.File != null && updateCropDto.File.Length > 0)
                {
                    string fileName = $"{Guid.NewGuid()}{Path.GetExtension(updateCropDto.File.FileName)}";
                    await _blobService.DeleteBlob(cropFromDb.Icon.Split('/').Last(), SD.SD_Storage_Container);
                    cropFromDb.Icon = await _blobService.UploadBlob(fileName, SD.SD_Storage_Container, updateCropDto.File);
                }
                await _unitOfWork.CropRepository.Update(cropFromDb);
                _unitOfWork.SaveAsync();

                return BuildSuccessResponseMessage(_mapper.Map<CropDto>(cropFromDb), "Crop updated successfully");
            }
            catch (Exception ex)
            {
                return BuildErrorResponseMessage<CropDto>(ex.Message, (HttpStatusCode)StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<APIResponse<bool>> DeleteCropAsync(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return BuildErrorResponseMessage<bool>("ID not found!", HttpStatusCode.NotFound);
                }

                Crop cropFromDb = await _unitOfWork.CropRepository.GetAsync(u => u.Id.Equals(Guid.Parse(id)));
                if (cropFromDb == null)
                {
                    return BuildErrorResponseMessage<bool>("This crop does not exist!", HttpStatusCode.NotFound);
                }

                await _blobService.DeleteBlob(cropFromDb.Icon.Split('/').Last(), SD.SD_Storage_Container);
                int milliseconds = 2000;
                Thread.Sleep(milliseconds);

                await _unitOfWork.CropRepository.RemoveAsync(cropFromDb);
                _unitOfWork.SaveAsync();
                return BuildSuccessResponseMessage(true, "Crop deleted successfully !");
            }
            catch (Exception ex)
            {
                return BuildErrorResponseMessage<bool>(ex.Message, (HttpStatusCode)StatusCodes.Status500InternalServerError);
            }
        }
    }
}
