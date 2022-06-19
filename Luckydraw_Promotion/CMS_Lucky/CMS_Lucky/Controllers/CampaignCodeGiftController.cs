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
    public class CampaignCodeGiftController : ControllerBase
    {
        private readonly ICampaignCodeGiftService _ccgService;
        private readonly IMapper _mapper;
        public CampaignCodeGiftController(ICampaignCodeGiftService ccgsv, IMapper mapper)
        {
            _ccgService = ccgsv;
            _mapper = mapper;
        }
        //GetALl
        [HttpGet]
        public async Task<ActionResult> CampaignCodeGiftGetAll()
        {
            try
            {
                var getallCcg = await _ccgService.CampaignCodeGiftGetAll();
                if (getallCcg == null)
                {
                    return NotFound(new
                    {
                        status = "200",
                        message = "Success",
                        data = new List<CampaignCodeGiftRP>()
                    });
                }
                return Ok(new
                {
                    status = "200",
                    message = "Success",
                    data = this._mapper.Map<List<CampaignCodeGiftRP>>(getallCcg)
                });
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }
        //insert
        [HttpPost]
        public async Task<ActionResult> CampaignCodeGiftInsert(CampaignCodeGiftDTO ccgdto)
        {
            try
            {
                return (await _ccgService.CampaignCodeGiftInsert(ccgdto) == true ?
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
        public async Task<ActionResult> CampaignCodeGiftGetSingle(int id)
        {
            try
            {
                var ccgfind = await _ccgService.CampaignCodeGiftGetSingle(id);
                return (ccgfind == null ?
                    NotFound(new
                    {
                        status = "404",
                        message = "Id Not Found"
                    }) :
                    Ok(new
                    {
                        statusCode = "200",
                        message = "Success",
                        data = this._mapper.Map<CampaignCodeGiftRP>(ccgfind)
                    }));
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
        //Update ID
        [HttpPut("{id}")]
        public async Task<ActionResult> CampaignCodeGiftUpdate(int id, CampaignCodeGiftDTO ccgdto)
        {
            try
            {
                if (id != ccgdto.cgcId)
                {
                    return BadRequest(new
                    {
                        status = "400",
                        message = "Id Error"
                    });
                }
                return (await _ccgService.CampaignCodeGiftUpdate(ccgdto) == true ?
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
        public async Task<ActionResult> CampaignCodeGiftDelete(int id)
        {
            try
            {
                return (await _ccgService.CampaignCodeGiftDelete(id) == true ?
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
