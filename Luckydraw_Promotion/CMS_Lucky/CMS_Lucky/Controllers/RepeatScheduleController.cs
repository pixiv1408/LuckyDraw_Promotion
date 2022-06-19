using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransactionLibrary.DTO;
using TransactionLibrary.IService;
using TransactionLibrary.Response;

namespace CMS_Lucky.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepeatScheduleController : ControllerBase
    {
        private readonly IRepeatScheduleService _resService;
        private readonly IMapper _mapper;
        public RepeatScheduleController(IRepeatScheduleService ressv, IMapper mapper)
        {
            _resService = ressv;
            _mapper = mapper;
        }
        //GetALl
        [HttpGet]
        public async Task<ActionResult> ResGetAll()
        {
            try
            {
                var getallRes = await _resService.ResGetAll();
                if (getallRes == null)
                {
                    return NotFound(new
                    {
                        status = "200",
                        message = "Success",
                        data = new List<RepeatScheduleRP>()
                    });
                }
                return Ok(new
                {
                    status = "200",
                    message = "Success",
                    data = this._mapper.Map<List<RepeatScheduleRP>>(getallRes)
                });
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }
        //insert
        [HttpPost]
        public async Task<ActionResult> ResInsert(RepeatScheduleDTO resdto)
        {
            try
            {
                return (await _resService.ResInsert(resdto) == true ?
                        Ok(new
                        {
                            status = "200",
                            message = "Success"
                        }) :
                        Conflict(new
                        {
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
        public async Task<ActionResult> ResGetSingle(int id)
        {
            try
            {
                var resfind = await _resService.ResGetSingle(id);
                return (resfind == null ?
                    NotFound(new
                    {
                        status = "404",
                        message = "Id Not Found"
                    }) :
                    Ok(new
                    {
                        statusCode = "200",
                        message = "Success",
                        data = this._mapper.Map<RepeatScheduleRP>(resfind)
                    }));
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
        //Update ID
        [HttpPut("{id}")]
        public async Task<ActionResult> ResUpdate(int id, RepeatScheduleDTO resdto)
        {
            try
            {
                if (id != resdto.repeatId)
                {
                    return BadRequest(new
                    {
                        status = "400",
                        message = "Id Error"
                    });
                }
                return (await _resService.ResUpdate(resdto) == true ?
                   Ok(new
                   {
                       status = "200",
                       message = "Success"
                   }) :
                   NotFound(new
                   {
                       status = "404",
                       message = "Id Not Found"
                   }));
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }
        //delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> ResDelete(int id)
        {
            try
            {
                return (await _resService.ResDelete(id) == true ?
                    Ok(new
                    {
                        status = "200",
                        message = "Success"
                    }) :
                    NotFound(new
                    {
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
