using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using distrito7.core.DAO;
using distrito7.core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace distrito7.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<ActionResult<SimpleCustomer>> RegisterCustomer([FromBody] AddCustomer customer)
        {
            try
            {
                Response<SimpleCustomer> result = await _customerService.RegisterCustomer(customer);
                if (!result.IsSuccessful)
                {
                    return BadRequest(result.ErrorMessage);
                }
                return Ok(result.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("browse-customer")]
        public async Task<ActionResult<CompleteCustomer>> BrowseCustomer([FromBody] InputSecurity emailEncrypted)
        {
            try
            {
                Response<CompleteCustomer> result = await _customerService.GetCustomer(emailEncrypted.KeyWord);
                if (!result.IsSuccessful)
                {
                    return BadRequest(result.ErrorMessage);
                }
                return Ok(result.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("assign-plan")]
        public async Task<ActionResult<CompleteCustomer>> AssignPlanToCustomer([FromBody] AddCustomerPayment plan)
        {
            try
            {
                Response<CompleteCustomer> result = await _customerService.AssignPlanToCustomer(plan);
                if (!result.IsSuccessful)
                {
                    return BadRequest(result.ErrorMessage);
                }
                return Ok(result.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }
}