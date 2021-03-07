using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AdelMobileBackEnd.models;
using AdelMobileBackEnd.Stubs;
namespace AdelMobileBackEnd.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // GET   api/v1/Test
        [HttpGet]
        public async Task<JsonTestStub> GetAllStubParseAsync()
        {
          
            return await  StubJson.DeserializeOfFileAsync();
        }
        // POST   api/v1/Test
        [HttpPost]
        public async Task<ActionResult> PostStubParseAsync([FromBody] JsonTestStub Json)
        {
            await StubJson.SerializeForFileAsync(Json);
            return Ok();
        }
        
        [HttpGet("parse")]
        public async Task<ActionResult> GetParseAsync()
        {
            Parser p = new Parser();
            await p.GetRubinAsync();
            return Ok();
        }
    }
}
