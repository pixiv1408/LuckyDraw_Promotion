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
    public class RulesforgiftController : ControllerBase
    {
        private readonly IRulesforgiftService _ruleService;
        private readonly IMapper _mapper;
        public RulesforgiftController(IRulesforgiftService rulesv, IMapper mapper)
        {
            _ruleService = rulesv;
            _mapper = mapper;
        }
        //GetALl
        [HttpGet]
        public async Task<ActionResult> RulesforgiftGetAll()
        {
            try
            {
                var getallRule = await _ruleService.RulesforgiftGetAll();
                if (getallRule == null)
                {
                    return NotFound(new
                    {
                        status = "200",
                        message = "Success",
                        data = new List<RulesforgiftRP>()
                    });
                }
                return Ok(new
                {
                    status = "200",
                    message = "Success",
                    data = this._mapper.Map<List<RulesforgiftRP>>(getallRule)
                });
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }
        //insert
        [HttpPost]
        public async Task<ActionResult> RulesforgiftInsert(RulesforgiftDTO ruledto)
        {
            try
            {
                return (await _ruleService.RulesforgiftInsert(ruledto) == true ?
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
        public async Task<ActionResult> RulesforgiftGetSingle(int id)
        {
            try
            {
                var rulefind = await _ruleService.RulesforgiftGetSingle(id);
                return (rulefind == null ?
                    NotFound(new
                    {
                        status = "404",
                        message = "Id Not Found"
                    }) :
                    Ok(new
                    {
                        statusCode = "200",
                        message = "Success",
                        data = this._mapper.Map<RulesforgiftRP>(rulefind)
                    }));
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
        //Update ID
        [HttpPut("{id}")]
        public async Task<ActionResult> RulesforgiftUpdate(int id, RulesforgiftDTO ruledto)
        {
            try
            {
                if (id != ruledto.ruleId)
                {
                    return BadRequest(new
                    {
                        status = "400",
                        message = "Id Error"
                    });
                }
                return (await _ruleService.RulesforgiftUpdate(ruledto) == true ?
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
        public async Task<ActionResult> RulesforgiftDelete(int id)
        {
            try
            {
                return (await _ruleService.RulesforgiftDelete(id) == true ?
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
