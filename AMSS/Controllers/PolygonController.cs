using AMSS.Dto.Polygon;
using AMSS.Entities;
using AMSS.Enums;
using AMSS.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace AMSS.Controllers
{
    [Route("api/polygon")]
    [ApiController]
    public class PolygonController : BaseController<PolygonController>
    {

        private readonly IPolygonAppService _polygonAppService;

        public PolygonController(IPolygonAppService polygonAppService)
        {
            _polygonAppService = polygonAppService;
        }

        [HttpGet("getAll")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<IEnumerable<PolygonDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPolygons()
        {
            var response = await _polygonAppService.GetAllPolygonsAsync();
            return ProcessResponseMessage(response);
        }

        //[HttpGet("getPolygonByFarmId/{id:int}")]
        //public async Task<ActionResult<APIResponse>> GetPolygonByFarmId(int farmId)
        //{
        //    try
        //    {
        //        if (farmId == null || farmId == 0)
        //        {
        //            _response.IsSuccess = false;
        //            _response.StatusCode = HttpStatusCode.NotFound;
        //            _response.ErrorMessages.Add("Something wrong when get polygon");
        //            return NotFound(_response);
        //        }
        //        PolygonApp polygon = await _polygonRepository.GetAsync(u => u.FarmId == farmId);
        //        if (polygon == null)
        //        {
        //            _response.IsSuccess = false;
        //            _response.StatusCode = HttpStatusCode.NotFound;
        //            _response.ErrorMessages.Add("Something wrong when get polygon");
        //            return NotFound(_response);
        //        }
        //        var polygonDto = _mapper.Map<PolygonDto>(polygon);
        //        var lstPositions = await _positionRepository.GetAllAsync(u => u.PolygonAppId == polygon.Id);
        //        polygonDto.Positions = lstPositions;

        //        _response.Result = polygonDto;
        //        _response.SuccessMessage = "Get polygon successfully";
        //        _response.StatusCode = HttpStatusCode.OK;
        //        return Ok(_response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _response.IsSuccess = false;
        //        _response.StatusCode = HttpStatusCode.BadRequest;
        //        _response.ErrorMessages.Add(ex.Message);
        //        return StatusCode(StatusCodes.Status500InternalServerError, _response);
        //    }
        //}

        [HttpPost]
        [Authorize(Roles = nameof(Role.ADMIN))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<PolygonDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreatePolygon(CreatePolygonDto createPolygonDto)
        {
            var response = await _polygonAppService.CreatePolygonAsync(createPolygonDto);
            return ProcessResponseMessage(response);
        }


        [HttpPut]
        [Authorize(Roles = nameof(Role.ADMIN))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(APIResponse<PolygonDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdatePolygon(UpdatePolygonDto updatePolygonDto)
        {
            var response = await _polygonAppService.UpdatePolygonAsync(updatePolygonDto);
            return ProcessResponseMessage(response);
        }
    }
}
