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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerService customersv, IMapper mapper)
        {
            _customerService = customersv;
            _mapper = mapper;
        }
        //GetALl
        [HttpGet]
        public async Task<ActionResult> CustomerGetAll()
        {
            try
            {
                var getallCus = await _customerService.CustomerGetAll();
                if (getallCus == null)
                {
                    return NotFound(new { 
                                        status = "200", 
                                        message = "Success", 
                                        data = new List<CustomerRP>() 
                    });
                }
                return Ok(new { 
                                status = "200", 
                                message = "Success", 
                                data = this._mapper.Map<List<CustomerRP>>(getallCus)
            });
            }
            catch (Exception e) 
            { 
                return Problem(e.Message); 
            }

        }
        //insert
        [HttpPost]
        public async Task<ActionResult> CustomerInsert(CustomerDTO cusdto)
        {
            try
            {
                return (await _customerService.CustomerInsert(cusdto) == true ?
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
        public async Task<ActionResult> CustomerGetSingle(int id)
        {
            try
            {
                var cusfind = await _customerService.CustomerGetSingle(id);
                return (cusfind == null ?
                    NotFound(new
                    {
                        status = "404",
                        message = "Id Not Found"
                    }) :
                    Ok(new
                    {
                        statusCode = "200",
                        message = "Success",
                        data = this._mapper.Map<CustomerRP>(cusfind)
                    }));
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
        //Update ID
        [HttpPut("{id}")]
        public async Task<ActionResult> CustomerUpdate(int id, CustomerDTO cusdto)
        {
            try
            {
                if (id != cusdto.cusId)
                {
                    return BadRequest(new
                    {
                        status = "400",
                        message = "Id Error"
                    });
                }
                return (await _customerService.CustomerUpdate(cusdto) == true ?
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
        public async Task<ActionResult> CustomerDelete(int id)
        {
            try
            {
                return (await _customerService.CustomerDelete(id) == true ?
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
