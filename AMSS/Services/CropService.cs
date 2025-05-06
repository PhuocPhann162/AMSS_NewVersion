using AMSS.Dto.Crop;
using AMSS.Dto.FieldCrop;
using AMSS.Entities;
using AMSS.Models;
using AMSS.Repositories.IRepository;
using AMSS.Services.IService;
using AMSS.Utility;
using AutoMapper;
using CloudinaryDotNet.Actions;
using Microsoft.Data.SqlClient;
using System.Net;

namespace AMSS.Services
{
    public class CropService : BaseService, ICropService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinaryService;

        public CropService(IUnitOfWork unitOfWork, IMapper mapper, ICloudinaryService cloudinaryService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
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
            if (string.IsNullOrEmpty(id))
            {
                return BuildErrorResponseMessage<CropDto>("Oops ! Not Found Crop ID", HttpStatusCode.NotFound);
            }
            var crop = await _unitOfWork.CropRepository
                .GetAsync(u => u.Id.Equals(Guid.Parse(id)), includeProperties: "CropType,Supplier");
            var cropDto = _mapper.Map<CropDto>(crop);
            if (crop == null)
            {
                return BuildErrorResponseMessage<CropDto>("Oops ! Something wrong when get crop by id", HttpStatusCode.NotFound);
            }
            return BuildSuccessResponseMessage(cropDto, "Get Crop by Id successfully");
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

        public async Task<APIResponse<bool>> CreateCropAsync(CreateCropDto createCropDto)
        {
            if (createCropDto.File == null || createCropDto.File.Length == 0)
            {
                return BuildErrorResponseMessage<bool>("File is required", HttpStatusCode.NotFound);
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
            await _unitOfWork.CropTypeRepository.AddAsync(newCropType);

            var newCrop = _mapper.Map<Crop>(createCropDto);
            newCrop.CropTypeId = newCropType.Id;
            newCrop.CropType = newCropType;
            newCrop.CreatedAt = DateTime.Now;
            newCrop.UpdatedAt = DateTime.Now;

            if (createCropDto.File != null && createCropDto.File.Length > 0)
            {
                var uploadResult = await _cloudinaryService.UploadImageAsync(createCropDto.File);
                newCrop.Icon = uploadResult.Url;
                newCrop.PublicImageId = uploadResult.PublicId;
            }

            await _unitOfWork.CropRepository.AddAsync(newCrop);
            await _unitOfWork.SaveChangeAsync();

            return BuildSuccessResponseMessage(true, "Crop created successfully", HttpStatusCode.Created);
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

        public async Task<APIResponse<bool>> UpdateCropAsync(string id, UpdateCropDto updateCropDto)
        {

            if (updateCropDto == null || !updateCropDto.Id.Equals(Guid.Parse(id)))
            {
                return BuildErrorResponseMessage<bool>("Update crop request does not exist!", HttpStatusCode.NotFound);
            }

            var cropFromDb = await _unitOfWork.CropRepository.GetAsync(u => u.Id.Equals(Guid.Parse(id)), false);

            if (cropFromDb == null)
            {
                return BuildErrorResponseMessage<bool>("This crop does not exist!", HttpStatusCode.NotFound);
            }
            cropFromDb = _mapper.Map<Crop>(updateCropDto);
            cropFromDb.UpdatedAt = DateTime.Now;

            if (updateCropDto.File != null && updateCropDto.File.Length > 0)
            {
                var uploadResult = await _cloudinaryService.UploadImageAsync(updateCropDto.File);
                cropFromDb.Icon = uploadResult.Url;
            }
            await _unitOfWork.SaveChangeAsync();

            return BuildSuccessResponseMessage(true, "Crop updated successfully");
        }

        public async Task<APIResponse<bool>> DeleteCropAsync(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return BuildErrorResponseMessage<bool>("ID not found!", HttpStatusCode.NotFound);
                }

                var cropFromDb = await _unitOfWork.CropRepository.GetAsync(u => u.Id.Equals(Guid.Parse(id)));
                if (cropFromDb == null)
                {
                    return BuildErrorResponseMessage<bool>("This crop does not exist!", HttpStatusCode.NotFound);
                }

                await _cloudinaryService.DeleteImageAsync(cropFromDb.PublicImageId);
                int milliseconds = 2000;
                Thread.Sleep(milliseconds);

                await _unitOfWork.CropRepository.RemoveAsync(cropFromDb);
                await _unitOfWork.SaveChangeAsync();
                return BuildSuccessResponseMessage(true, "Crop deleted successfully !");
            }
            catch (Exception ex)
            {
                return BuildErrorResponseMessage<bool>(ex.Message, (HttpStatusCode)StatusCodes.Status500InternalServerError);
            }
        }
    }
}
