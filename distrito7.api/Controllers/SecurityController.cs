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
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _security;
        public SecurityController(ISecurityService security)
        {
            _security = security;
        }

        [HttpPost("encrypt")]
        public async Task<ActionResult<string>> Encrypt([FromBody] InputSecurity input)
        {
            try
            {
                var result = await _security.Encrypt(input.KeyWord);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost("decrypt")]
        public async Task<ActionResult<string>> Decrypt([FromBody] InputSecurity input)
        {
            try
            {
                var result = await _security.Decrypt(input.KeyWord);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}