using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.IO;
using HtmlAgilityPack;

namespace AdelMobileBackEnd.models
{
    public class Parser
    {
        private static string ficbook;
        public static string Ficbook { get { return ficbook; } }
        public async Task<string> GetRubinAsync()
        {
            try
            {
                //  string htmlSite = new WebClient().DownloadString(URI);
                //  string NameBook =  Regex.Match(htmlSite, @"<h1 class""mb-10"" itemprop=""name"">[А-Я-а-я]+").Groups[1].Value;
                using (HttpClientHandler handler = new HttpClientHandler { AllowAutoRedirect = false, AutomaticDecompression = DecompressionMethods.All })
                {

                    using (HttpClient client = new HttpClient(handler))
                    {
                        client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; AcmeInc/1.0)");
                        using (HttpResponseMessage response = await client.GetAsync("https://ficbook.net/readfic/9838377"))
                        {
                            ficbook = await response.Content.ReadAsStringAsync();
                            if (string.IsNullOrEmpty(ficbook))
                                return "Bad request!";
                            HtmlDocument doc = new HtmlDocument();
                            doc.LoadHtml(Ficbook);
                      
                            var like = doc.DocumentNode.SelectSingleNode(".//span[@class='badge-text js-marks-plus']").InnerText;
                            var title = doc.DocumentNode.SelectSingleNode(".//h1[@class='mb-10']").InnerText;
                            var comments = (doc.DocumentNode.SelectSingleNode(".//span[@class='main-info']").InnerText).Replace("\n", " ").Replace(" ","");
                            return "OK";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                
                    await Log.LoggingAsync(e, "GetRubinAsync");
                    return "Bad request!";
                
            }
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