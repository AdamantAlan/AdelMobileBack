using AdelMobileBackEnd.models;
using AdelMobileBackEnd.models.absFactoryOfBook.products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdelMobileBackEnd.Controllers
{
    [Route("api/v1/ficbook")]
    [ApiController]
    public class FicbookController : ControllerBase
    {

        // GET:api/v1/ficbook/rubin
        [HttpGet("rubin")]
        public async Task<ActionResult> GetRubinFromFicbook()
        {
            IParser<Rubin> parser = new Parser<Rubin>();
            _ = await JsonAsync.SerializeForFileAsync<Rubin>(await parser.GetBookAsync());
            return Ok();
        }
        // GET:api/v1/ficbook/rubin/get
        [HttpGet("rubin/get")]
        public async Task<IBook> GetRubinForAdel()
        {
            return await JsonAsync.DeserializeOfFileAsync<Rubin>(); 
        }

        // GET:api/v1/ficbook/rubin
        [HttpGet("wool")]
        public async Task<ActionResult> GetWoolFromFicbook()
        {
            IParser<Wool> parser = new Parser<Wool>();
            _ = await JsonAsync.SerializeForFileAsync<Wool>(await parser.GetBookAsync());
            return Ok();
        }
        // GET:api/v1/ficbook/rubin/get
        [HttpGet("wool/get")]
        public async Task<IBook> GetWoolForAdel()
        {
            return await JsonAsync.DeserializeOfFileAsync<Wool>();
        }


    }
}
