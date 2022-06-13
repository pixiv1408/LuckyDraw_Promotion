using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TransactionLibrary.IService;
using TransactionLibrary.Response;

namespace CMS_Lucky.Controllers
{
    [Route("api/positions")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _positionService;
        private readonly IMapper _mapper;
        public PositionController(IPositionService positionsv, IMapper mapper)
        {
            _positionService = positionsv;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<PositionRP>>> GetAll()
        {
            var getallposition = await _positionService.PositionGetAll();
            var response = this._mapper.Map<List<PositionRP>>(getallposition);
            return response;
        }
    }
}
