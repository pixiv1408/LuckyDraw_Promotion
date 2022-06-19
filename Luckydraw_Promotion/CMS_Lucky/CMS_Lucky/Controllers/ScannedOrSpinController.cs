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
    public class ScannedOrSpinController : ControllerBase
    {
        private readonly IScannedOrSpinService _sosService;
        private readonly IMapper _mapper;
        public ScannedOrSpinController(IScannedOrSpinService sossv, IMapper mapper)
        {
            _sosService = sossv;
            _mapper = mapper;
        }
        //GetALl
        [HttpGet]
        public async Task<ActionResult> SosGetAll()
        {
            try
            {
                var getallSos = await _sosService.SosGetAll();
                if (getallSos == null)
                {
                    return NotFound(new
                    {
                        status = "200",
                        message = "Success",
                        data = new List<ScannedOrSpinRP>()
                    });
                }
                return Ok(new
                {
                    status = "200",
                    message = "Success",
                    data = this._mapper.Map<List<ScannedOrSpinRP>>(getallSos)
                });
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }
        //insert
        [HttpPost]
        public async Task<ActionResult> SosInsert(ScannedOrSpinDTO sosdto)
        {
            try
            {
                return (await _sosService.SosInsert(sosdto) == true ?
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
        public async Task<ActionResult> SosGetSingle(int id)
        {
            try
            {
                var sosfind = await _sosService.SosGetSingle(id);
                return (sosfind == null ?
                    NotFound(new
                    {
                        status = "404",
                        message = "Id Not Found"
                    }) :
                    Ok(new
                    {
                        statusCode = "200",
                        message = "Success",
                        data = this._mapper.Map<ScannedOrSpinRP>(sosfind)
                    }));
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
        //Update ID
        [HttpPut("{id}")]
        public async Task<ActionResult> SosUpdate(int id, ScannedOrSpinDTO sosdto)
        {
            try
            {
                if (id != sosdto.sosId)
                {
                    return BadRequest(new
                    {
                        status = "400",
                        message = "Id Error"
                    });
                }
                return (await _sosService.SosUpdate(sosdto) == true ?
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
        public async Task<ActionResult> SosDelete(int id)
        {
            try
            {
                return (await _sosService.SosDelete(id) == true ?
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
