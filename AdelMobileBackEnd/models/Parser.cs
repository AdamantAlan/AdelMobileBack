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
        private static string htmlDoc;
        public static string HtmlDoc { get { return htmlDoc; } }
        public async Task<string> GetContent()
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
                            htmlDoc = await response.Content.ReadAsStringAsync();
                            return "OK";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                using (FileStream fs = new FileStream("state/log.txt", FileMode.OpenOrCreate))
                {
                    byte[] error = System.Text.Encoding.Default.GetBytes("GetContent ERROR:" + e.Message);
                    await fs.WriteAsync(error,0,error.Length);
                    return "Bad request!";
                }
            }
        }
    }
}



/*
 * получение лайков рубина
 * 
 *  
 * if (!string.IsNullOrEmpty(html))
                            {
                                HtmlDocument doc = new HtmlDocument();
                                doc.LoadHtml(html);
                                var like = doc.DocumentNode.SelectSingleNode(".//span[@class='badge-text js-marks-plus']");
                                var i = like.InnerText;

                            }
 * 
 * 
 * 
 */