using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwilloSampleApi.Domain.Twilio;

namespace TwilloSampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoiceController : ControllerBase
    {
        private readonly ICredentials _credentials;

        //public VoiceController() : this(new Credentials()) { }

        public VoiceController(ICredentials credentials)
        {
            _credentials = credentials;
        }
        [HttpGet()]
        public IActionResult Token()
        {
            var token = new Capability(_credentials).Generate();
            return  Ok(new { Token=token});
        }
        [HttpPost()]
        public IActionResult Call()
        {
            var token = new Capability(_credentials).Generate();
            return Ok(new { Token = token });
        }
    }
}
