using AutoMapper;
using Datactx.Models;
using Microsoft.AspNetCore.Mvc;
using TransactionLibrary.DTO;
using TransactionLibrary.IService;
using TransactionLibrary.Response;

namespace CMS_Lucky.Controllers
{
    [Route("api/[controller]")]
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
        //GetALl
        [HttpGet]
        public async Task<ActionResult> PositionGetAll()
        {
            try
            {
                var positgetall = await _positionService.PositionGetAll();
                return Ok(new
                {
                    status = "200",
                    message = "Success",
                    data = (positgetall == null ?
                    new List<PositionRP>() :
                    this._mapper.Map<List<PositionRP>>(positgetall))
                });
            }
            catch (Exception e) 
            {
                return Problem(e.Message); 
            }
        }
        //insert
        [HttpPost]
        public async Task<ActionResult> PositionInsert(PositionDTO positdto)
        {
            try
            {
                return (await _positionService.PositionInsert(positdto) == true ?
                        Ok(new { 
                                status = "200", 
                                message = "Success" 
                                }) :
                        Conflict(new {
                                status = "409", 
                                message = "Id already exsist"
                        }));
            }
            catch (Exception e) 
            { 
                return Problem(e.Message); 
            }
        }
        // GetID
        [HttpGet("{id}")]
        public async Task<ActionResult> PositionGetSingle(int id)
        {
            try
            {
                var positfind = await _positionService.PositionGetSingle(id);
                return (positfind == null ?
                    NotFound(new { 
                                status = "404", 
                                message = "Id Not Found"
                    }) :
                    Ok(new { 
                            statusCode = "200", 
                            message = "Success", 
                            data = this._mapper.Map<PositionRP>(positfind) 
                    }));
            }
            catch (Exception e)
            { 
                return Problem(e.Message); 
            }
        }
        //Update ID
        [HttpPut("{id}")]
        public async Task<ActionResult> PositionUpdate(int id, PositionDTO positdto)
        {
            try
            {
                if (id != positdto.posId)
                {
                    return BadRequest(new { 
                                        status = "400", 
                                        message = "Id Error" 
                    });
                }
                return (await _positionService.PositionUpdate(positdto) == true ?
                   Ok(new { 
                           status = "200", 
                           message = "Success" 
                   }) :
                   NotFound(new { 
                                status = "404", 
                                message = "Id Not Found" 
                   }));
            }
            catch (Exception e) 
            { 
                return Problem(e.Message); 
            }

        }
        //Delete ID
        [HttpDelete("{id}")]
        public async Task<ActionResult> PositionDelete(int id)
        {
            try
            {
                return (await _positionService.PositionDelete(id) == true ?
                    Ok(new { 
                            status = "200", 
                            message = "Success" 
                    }) :
                    NotFound(new { 
                                status = "404", 
                                message = "Id Not Found"
                    }));

            }
            catch (Exception e) 
            { 
                return Problem(e.Message); 
            }
        }
    }
}
