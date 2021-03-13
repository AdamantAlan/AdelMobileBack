using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.IO;
using HtmlAgilityPack;
using AdelMobileBackEnd.models.absFactoryOfBook;
using AdelMobileBackEnd.models.absFactoryOfBook.factories;
using AdelMobileBackEnd.models.absFactoryOfBook.products;

namespace AdelMobileBackEnd.models
{
    public interface IParser<T>
    {
        public Task<T> GetBookAsync();
        public Task<Dictionary<string, IBook>> GetAllBooksAsync();
    }

    public class Parser<T>:IParser<T> where T:class
    {
        private FactoryOfBook _absFactory;
        public async Task<T> GetBookAsync()
        {
            try
            {
                _absFactory = getFactory();
                return await _absFactory.GetBook() as T;
            }
            catch (Exception e)
            {
                    await Log.LoggingAsync(e, "GetRubinAsync");
                    return null;
            }
        }
        public async  Task<Dictionary<string, IBook>> GetAllBooksAsync()
        {
          return  new Dictionary<string, IBook> {
                [nameof(Rubin)] = await new Parser<Rubin>().GetBookAsync(),
                [nameof(Wool)] = await new Parser<Wool>().GetBookAsync(),
                [nameof(Prayer)] = await new Parser<Prayer>().GetBookAsync(),
                [nameof(Portrait)] = await new Parser<Portrait>().GetBookAsync(),
            };


        }
        private FactoryOfBook getFactory()
        {
            if(typeof(T).Name == "Rubin")
                return new RubinFactory();
            if (typeof(T).Name is "Portrait")
                return new PortraitFactory();
            if (typeof(T).Name is "Prayer")
                return new PrayerFactory();
            if (typeof(T).Name is "Wool")
                return new WoolFactory();
            throw new Exception("factory not found!");
        }
    
    }
}
