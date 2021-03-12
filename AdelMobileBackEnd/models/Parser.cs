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
    }




    public class Parser<T>:IParser<T> where T:class
    {

        private FactoryOfBook _absFactory;
        public async Task<T> GetBookAsync()
        {

            _absFactory = getFactory();
            try
            {
                 
               
              return await _absFactory.GetBook() as T;
            }
            catch (Exception e)
            {
                    await Log.LoggingAsync(e, "GetRubinAsync");
                    return null;
            }
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
            return null;
        }
    
    }

   



}



/*
 * получение лайков рубина
 * 
 *  
 
 * 
 * 
 * 
 */