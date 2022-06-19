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
    public class WinnerController : ControllerBase
    {
        private readonly IWinnerService _winService;
        private readonly IMapper _mapper;
        public WinnerController(IWinnerService winsv, IMapper mapper)
        {
            _winService = winsv;
            _mapper = mapper;
        }
        //GetALl
        [HttpGet]
        public async Task<ActionResult> WinnerGetAll()
        {
            try
            {
                var getallWin = await _winService.WinnerGetAll();
                if (getallWin == null)
                {
                    return NotFound(new
                    {
                        status = "200",
                        message = "Success",
                        data = new List<WinnerRP>()
                    });
                }
                return Ok(new
                {
                    status = "200",
                    message = "Success",
                    data = this._mapper.Map<List<WinnerRP>>(getallWin)
                });
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }
        //insert
        [HttpPost]
        public async Task<ActionResult> WinnerInsert(WinnerDTO windto)
        {
            try
            {
                return (await _winService.WinnerInsert(windto) == true ?
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
        public async Task<ActionResult> WinnerGetSingle(int id)
        {
            try
            {
                var winfind = await _winService.WinnerGetSingle(id);
                return (winfind == null ?
                    NotFound(new
                    {
                        status = "404",
                        message = "Id Not Found"
                    }) :
                    Ok(new
                    {
                        statusCode = "200",
                        message = "Success",
                        data = this._mapper.Map<WinnerRP>(winfind)
                    }));
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
        //Update ID
        [HttpPut("{id}")]
        public async Task<ActionResult> WinnerUpdate(int id, WinnerDTO windto)
        {
            try
            {
                if (id != windto.winId)
                {
                    return BadRequest(new
                    {
                        status = "400",
                        message = "Id Error"
                    });
                }
                return (await _winService.WinnerUpdate(windto) == true ?
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
        public async Task<ActionResult> WinnerDelete(int id)
        {
            try
            {
                return (await _winService.WinnerDelete(id) == true ?
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
