using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using distrito7.core.Interfaces;
using distrito7.core.Models;
using Microsoft.AspNetCore.Mvc;

namespace distrito7.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentPlanController : ControllerBase
    {
        private readonly IRepository _repository;

        public PaymentPlanController(IRepository repository)
        {
            _repository = repository;

        }

        [HttpPost("CreatePlan")]
        public async Task<ActionResult<PaymentPlan>> CreatePaymentPlan([FromBody] PaymentPlan plan)
        {
            await _repository.AddPlan(plan);
            return Ok(plan);
        }

    }
}