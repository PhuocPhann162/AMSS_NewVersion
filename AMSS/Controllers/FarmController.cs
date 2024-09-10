using AMSS.Enums;
using AMSS.Models;
using AMSS.Models.Dto.Crop;
using AMSS.Models.Dto.Farm;
using AMSS.Repositories;
using AMSS.Repositories.IRepository;
using AMSS.Utility;
using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Text.Json;

namespace AMSS.Controllers
{
    [Route("api/farm")]
    [ApiController]
    [Authorize]
    public class FarmController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        protected APIResponse _response;
        private readonly IMapper _mapper;
        public FarmController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet("getAll")]
        [Authorize(Roles = nameof(Role.ADMIN))]
        public async Task<ActionResult<APIResponse>> GetAllFarms(string? searchString, int? pageNumber, int? pageSize)
        {
            try
            {
                List<Farm> lstFarms = await _unitOfWork.FarmRepository.GetAllAsync(includeProperties: "Location,PolygonApp");
                var lstFarmsDto = _mapper.Map<List<FarmDto>>(lstFarms);

                lstFarmsDto.Select(f => f.PolygonApp.Positions = _unitOfWork.PositionRepository
                            .GetAllAsync(u => u.PolygonAppId == f.PolygonApp.Id && !u.IsDeleted).GetAwaiter().GetResult());

                foreach (var f in lstFarmsDto)
                {
                    if (f.PolygonApp != null)
                    {
                        f.PolygonApp.Positions = await _unitOfWork.PositionRepository
                            .GetAllAsync(u => u.PolygonAppId == f.PolygonApp.Id && !u.IsDeleted);
                    }
                }

                if (!string.IsNullOrEmpty(searchString))
                {
                    lstFarmsDto = lstFarmsDto.Where(u => u.Name.ToLower().Contains(searchString.ToLower()) 
                                                        || u.Location.Address.ToLower().Contains(searchString.ToLower())).ToList();
                }

                if (pageNumber.HasValue && pageSize.HasValue)
                {
                    Pagination pagination = new()
                    {
                        CurrentPage = pageNumber,
                        PageSize = pageSize,
                        TotalRecords = lstFarms.Count(),
                    };
                    Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));

                    _response.Result = lstFarmsDto.Skip((int)((pageNumber - 1) * pageSize)).Take((int)pageSize);
                    _response.StatusCode = HttpStatusCode.OK;
                    return Ok(_response);
                }
                _response.Result = lstFarmsDto;
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

        [HttpGet("getFarmById/{id:int}")]
        public async Task<ActionResult<APIResponse>> GetFarmById(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Oops ! Something wrong when get Farm by id");
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                Farm farm = await _unitOfWork.FarmRepository.GetAsync(u => u.Id.Equals(Guid.Parse(id)));
                if (farm == null)
                {
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Oops ! Something wrong when get Farm by id");
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                FarmDto farmDto = _mapper.Map<FarmDto>(farm);
                _response.Result = farmDto;
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
        public async Task<ActionResult<APIResponse>> CreateFarm([FromForm] CreateFarmDto createFarmDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newFarm = _mapper.Map<Farm>(createFarmDto);
                    newFarm.CreatedAt = DateTime.Now;
                    newFarm.UpdatedAt = DateTime.Now;

                    await _unitOfWork.FarmRepository.CreateAsync(newFarm);
                    _unitOfWork.SaveAsync();
                    _response.Result = newFarm;
                    _response.StatusCode = HttpStatusCode.Created;
                    _response.SuccessMessage = "Farm created successfully";
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("Something wrong when creating new Farm");
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

        [HttpPut("{id:int}")]
        [Authorize(Roles = nameof(Role.ADMIN))]
        public async Task<ActionResult<APIResponse>> UpdateFarm(string id, [FromForm] FarmDto updateFarmDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (updateFarmDto == null || updateFarmDto.Id.Equals(Guid.Parse(id)))
                    {
                        _response.IsSuccess = false;
                        _response.ErrorMessages.Add("This Farm does not exist!");
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        return BadRequest();
                    }

                    Farm farmFromDb = await _unitOfWork.FarmRepository.GetAsync(u => u.Id.Equals(Guid.Parse(id)), false);

                    if (farmFromDb == null)
                    {
                        _response.IsSuccess = false;
                        _response.StatusCode = HttpStatusCode.NotFound;
                        _response.ErrorMessages.Add("Not found this Farm");
                        return NotFound(_response);
                    }
                    farmFromDb = _mapper.Map<Farm>(updateFarmDto);
                    farmFromDb.UpdatedAt = DateTime.Now;

                    await _unitOfWork.FarmRepository.Update(farmFromDb);
                    _unitOfWork.SaveAsync();
                    _response.Result = farmFromDb;
                    _response.SuccessMessage = "Farm updated successfully 🌿";
                    _response.StatusCode = HttpStatusCode.OK;
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("Something wrong when updating farm");
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

        [HttpDelete("{id:int}")]
        [Authorize(Roles = nameof(Role.ADMIN))]
        public async Task<ActionResult<APIResponse>> DeleteFarm(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("This Farm does not exist!");
                    return BadRequest(_response);
                }

                Farm farmFromDb = await _unitOfWork.FarmRepository.GetAsync(u => u.Id.Equals(Guid.Parse(id)));
                if (farmFromDb == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("Not found this Farm");
                    return NotFound(_response);
                }

                await _unitOfWork.FarmRepository.RemoveAsync(farmFromDb);
                _unitOfWork.SaveAsync();
                _response.SuccessMessage = "Farm deleted successfully !";
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);

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
