using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using distrito7.core.DAO;
using distrito7.core.Interfaces;
using distrito7.core.Models;
using Microsoft.AspNetCore.Mvc;

namespace distrito7.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentPlanController : ControllerBase
    {
        private readonly IPaymentPlanService _planService;

        public PaymentPlanController(IPaymentPlanService planService)
        {
            _planService = planService;
        }

        [HttpPost]
        public async Task<ActionResult<PaymentPlanInfo>> CreatePaymentPlan([FromBody] AddPaymentPlan plan)
        {
            try
            {
                Response<PaymentPlanInfo> result = await _planService.CreatePlan(plan);
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

        [HttpPut]
        public async Task<ActionResult<PaymentPlanInfo>> ModifyPaymentPlan([FromBody] UpdatePaymentPlan newPlan)
        {
            try
            {
                Response<PaymentPlanInfo> result = await _planService.ModifyPlan(newPlan);
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

        [HttpDelete("{planId}")]
        public async Task<ActionResult<string>> DeletePaymentPlan(int planId)
        {
            try
            {
                Response<string> result = await _planService.DeletePlan(planId);
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

        [HttpGet]
        public async Task<ActionResult<List<PaymentPlanInfo>>> GetAllPlans()
        {
            try
            {
                Response<List<PaymentPlanInfo>> result = await _planService.GetAllPlans();
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

        [HttpGet("GetById/{planId}")]
        public async Task<ActionResult<PaymentPlanInfo>> GetPlanById(int planId)
        {
            try
            {
                Response<PaymentPlanInfo> result = await _planService.GetPlan(planId);
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

        [HttpGet("GetByName/{planName}")]
        public async Task<ActionResult<PaymentPlanInfo>> GetPlanByName(string planName)
        {
            try
            {
                Response<PaymentPlanInfo> result = await _planService.GetPlanByName(planName);
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

        [HttpGet("GetByFreq/{planFrequency}")]
        public async Task<ActionResult<List<PaymentPlanInfo>>> GetPlansByFrequency(string planFrequency)
        {
            try
            {
                Response<List<PaymentPlanInfo>> result = await _planService.GetPlanByFrequency(planFrequency);
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