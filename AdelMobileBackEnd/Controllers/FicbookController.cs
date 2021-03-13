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
            await GetRubinFromFicbook();
            return await JsonAsync.DeserializeOfFileAsync<Rubin>(); 
        }

        // GET:api/v1/ficbook/wool
        [HttpGet("wool")]
        public async Task<ActionResult> GetWoolFromFicbook()
        {
            IParser<Wool> parser = new Parser<Wool>();
            _ = await JsonAsync.SerializeForFileAsync<Wool>(await parser.GetBookAsync());
            return Ok();
        }
        // GET:api/v1/ficbook/wool/get
        [HttpGet("wool/get")]
        public async Task<IBook> GetWoolForAdel()
        {
            await GetWoolFromFicbook();
            return await JsonAsync.DeserializeOfFileAsync<Wool>();
        }

        // GET:api/v1/ficbook/prayer
        [HttpGet("prayer")]
        public async Task<ActionResult> GetPrayerFromFicbook()
        {
            IParser<Prayer> parser = new Parser<Prayer>();
            _ = await JsonAsync.SerializeForFileAsync<Prayer>(await parser.GetBookAsync());
            return Ok();
        }
        // GET:api/v1/ficbook/prayer/get
        [HttpGet("prayer/get")]
        public async Task<IBook> GetPrayerForAdel()
        {
            await GetPrayerFromFicbook();
            return await JsonAsync.DeserializeOfFileAsync<Prayer> ();
        }

        // GET:api/v1/ficbook/portrait
        [HttpGet("portrait")]
        public async Task<ActionResult> GetPortraitFromFicbook()
        {
            IParser<Portrait> parser = new Parser<Portrait>();
            _ = await JsonAsync.SerializeForFileAsync<Portrait>(await parser.GetBookAsync());
            return Ok();
        }
        // GET:api/v1/ficbook/portrait/get
        [HttpGet("portrait/get")]
        public async Task<IBook> GetPortraitForAdel()
        {
            await GetPortraitFromFicbook();
            return await JsonAsync.DeserializeOfFileAsync<Portrait>();
        }

        // GET:api/v1/ficbook/all
        [HttpGet("all")]
        public async Task<ActionResult> GetAllFicbook()
        {
            IParser<Portrait> parser = new Parser<Portrait>();
            Dictionary<string, IBook> books = await parser.GetAllBooksAsync();
            foreach (var book in books) {
                if(book.Key == "Rubin" )
                _ = await JsonAsync.SerializeForFileAsync<Rubin>(book.Value);
                    if (book.Key == "Wool")
                        _ = await JsonAsync.SerializeForFileAsync<Wool>(book.Value);
                    if (book.Key == "Prayer")
                        _ = await JsonAsync.SerializeForFileAsync<Prayer>(book.Value);
                    if (book.Key == "Portrait")
                        _ = await JsonAsync.SerializeForFileAsync<Portrait>(book.Value);
                }
         
            return Ok();
        }
        // GET:api/v1/ficbook/all/get
        [HttpGet("all/get")]
        public async Task<Dictionary<string, IBook>> GetAllForAdel()
        {
            return new Dictionary<string, IBook>
            {
                ["Rubin"] = await JsonAsync.DeserializeOfFileAsync<Rubin>(),
                ["Wool"] = await JsonAsync.DeserializeOfFileAsync<Wool>(),
                ["Prayer"] = await JsonAsync.DeserializeOfFileAsync<Prayer>(),
                ["Portrait"] = await JsonAsync.DeserializeOfFileAsync<Portrait>()
            };
        }

    }
}
