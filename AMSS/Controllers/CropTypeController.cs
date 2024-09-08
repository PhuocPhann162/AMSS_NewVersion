using AMSS.Enums;
using AMSS.Models;
using AMSS.Models.Dto.Crop;
using AMSS.Models.Dto.CropType;
using AMSS.Models.Dto.Field;
using AMSS.Models.Dto.Location;
using AMSS.Repositories;
using AMSS.Repositories.IRepository;
using AMSS.Utility;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace AMSS.Controllers
{
    [Route("api/cropType")]
    [ApiController]
    public class CropTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public CropTypeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _response = new APIResponse();
        }

        [HttpGet("getAllCropTypes")]
        public async Task<ActionResult<APIResponse>> GetAllCropTypes(string? searchString, int? pageNumber, int? pageSize)
        {
            try
            {
                List<CropType> lstCropTypes = await _unitOfWork.CropTypeRepository.GetAllWithDetailsAsync();
                var lstCropTypeDtos = lstCropTypes.Select(cropType => _mapper.Map<CropTypeDto>(cropType)).ToList();
                
                if (!string.IsNullOrEmpty(searchString))
                {
                    lstCropTypeDtos = lstCropTypeDtos.Where(u => u.Name.ToLower().Contains(searchString.ToLower()) || u.Code.ToLower().Contains(searchString.ToLower())).ToList();
                }

                if (pageNumber.HasValue && pageSize.HasValue)
                {
                    Pagination pagination = new()
                    {
                        CurrentPage = pageNumber,
                        PageSize = pageSize,
                        TotalRecords = lstCropTypeDtos.Count()
                    };
                    Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));

                    _response.Result = lstCropTypeDtos.Skip((int)((pageNumber - 1) * pageSize)).Take((int)pageSize);
                    _response.StatusCode = HttpStatusCode.OK;
                    return Ok(_response);
                }
                _response.Result = lstCropTypeDtos;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages.Add(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPost]
        [Authorize(Roles = nameof(Role.ADMIN))]
        public async Task<ActionResult<APIResponse>> CreateCropType([FromForm] CreateCropTypeDto createCropTypeDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (createCropTypeDto.Name == null)
                    {
                        _response.IsSuccess = false;
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        _response.ErrorMessages.Add("Name Type is required");
                        return BadRequest(_response);
                    }

                    var newCropType = _mapper.Map<CropType>(createCropTypeDto);
                    newCropType.CreatedAt = DateTime.Now;
                    newCropType.UpdatedAt = DateTime.Now;

                    await _unitOfWork.CropTypeRepository.CreateAsync(newCropType);
                    _unitOfWork.SaveAsync();
                    _response.Result = newCropType;
                    _response.StatusCode = HttpStatusCode.Created;
                    _response.SuccessMessage = "Crop type created successfully";
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("Something wrong when creating new crop type");
                    return BadRequest(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add(ex.Message);
                _response.StatusCode = HttpStatusCode.BadRequest;
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}
