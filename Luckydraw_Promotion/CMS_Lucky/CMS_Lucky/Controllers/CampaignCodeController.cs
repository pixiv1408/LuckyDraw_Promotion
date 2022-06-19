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
    public class CampaignCodeController : ControllerBase
    {
        private readonly ICampaignCodeService _ccService;
        private readonly IMapper _mapper;
        public CampaignCodeController(ICampaignCodeService ccsv, IMapper mapper)
        {
            _ccService = ccsv;
            _mapper = mapper;
        }
        //GetALl
        [HttpGet]
        public async Task<ActionResult> CampaignCodeGetAll()
        {
            try
            {
                var getallCc = await _ccService.CampaignCodeGetAll();
                if (getallCc == null)
                {
                    return NotFound(new
                    {
                        status = "200",
                        message = "Success",
                        data = new List<CampaignCodeRP>()
                    });
                }
                return Ok(new
                {
                    status = "200",
                    message = "Success",
                    data = this._mapper.Map<List<CampaignCodeRP>>(getallCc)
                });
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }
        //insert
        [HttpPost]
        public async Task<ActionResult> CampaignCodeInsert(CampaignCodeDTO ccdto)
        {
            try
            {
                return (await _ccService.CampaignCodeInsert(ccdto) == true ?
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
        public async Task<ActionResult> CampaignCodeGetSingle(int id)
        {
            try
            {
                var ccfind = await _ccService.CampaignCodeGetSingle(id);
                return (ccfind == null ?
                    NotFound(new
                    {
                        status = "404",
                        message = "Id Not Found"
                    }) :
                    Ok(new
                    {
                        statusCode = "200",
                        message = "Success",
                        data = this._mapper.Map<CampaignCodeRP>(ccfind)
                    }));
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
        //Update ID
        [HttpPut("{id}")]
        public async Task<ActionResult> CampaignCodeUpdate(int id, CampaignCodeDTO ccdto)
        {
            try
            {
                if (id != ccdto.ccId)
                {
                    return BadRequest(new
                    {
                        status = "400",
                        message = "Id Error"
                    });
                }
                return (await _ccService.CampaignCodeUpdate(ccdto) == true ?
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
        public async Task<ActionResult> CampaignCodeDelete(int id)
        {
            try
            {
                return (await _ccService.CampaignCodeDelete(id) == true ?
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
