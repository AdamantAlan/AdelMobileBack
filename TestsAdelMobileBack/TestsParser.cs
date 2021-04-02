using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AdelMobileBackEnd.models;
using AdelMobileBackEnd.models.absFactoryOfBook.products;
using Moq;

namespace TestsAdelMobileBack
{
    [TestFixture]
    class TestsParser
    {
        [Test]
        public async Task GetRubin()
        {
            //A
            Rubin result = new Rubin("Рубин", 11,16);

            //A
            Rubin Ok = await new Parser().GetBookAsync<Rubin>();
            //A
            Assert.That(Equals(Ok.Title,result.Title));
            Assert.That(Equals(Ok.Likes, result.Likes));
            Assert.That(Equals(Ok.Comments, result.Comments));
        }
        [Test]
        public async Task GetWool()
        {
            //A
            Wool result = new Wool("Шерсть", 0, 2);
          
            //A
            Wool Ok = await new Parser().GetBookAsync<Wool>();
            //A
            Assert.That(Equals(Ok.Title, result.Title));
            Assert.That(Equals(Ok.Likes, result.Likes));
            Assert.That(Equals(Ok.Comments, result.Comments));
        }

        [Test]
        public async Task GetPrayer()
        {
            //A
            Prayer result = new Prayer("Просьба", 4, 10);
        
            //A
            Prayer Ok = await new Parser().GetBookAsync<Prayer>();
            //A
            Assert.That(Equals(Ok.Title, result.Title));
            Assert.That(Equals(Ok.Likes, result.Likes));
            Assert.That(Equals(Ok.Comments, result.Comments));
        }

        [Test]
        public async Task GetPortrait()
        {
            //A
            Portrait result = new Portrait("История одного портрета", 1, 5);
            //A
            Portrait Ok = await new Parser().GetBookAsync<Portrait>();
            //A
            Assert.That(Equals(Ok.Title, result.Title));
            Assert.That(Equals(Ok.Likes, result.Likes));
            Assert.That(Equals(Ok.Comments, result.Comments));
        }
        [Test]
        public async Task GetAll()
        {
            //A
            var rubin = await new Parser().GetBookAsync<Rubin>();
            var wool = await new Parser().GetBookAsync<Wool>();
            var prayer = await new Parser().GetBookAsync<Prayer>();
            var portrait = await new Parser().GetBookAsync<Portrait>();
            Dictionary<string, IBook> bookStubs = new Dictionary<string, IBook>();
           bookStubs.Add("Rubin",rubin);
            bookStubs.Add("Wool",wool);
            bookStubs.Add("Prayer",prayer);
            bookStubs.Add("Portrait",portrait);
            //A
            Dictionary<string,IBook> Ok = await  new Parser().GetAllBooksAsync();
            //A
            foreach(var i in Ok)
                foreach(var j in bookStubs)
                    if(i.Key == j.Key)
                    {
                        Assert.AreEqual(i.Value.Likes,j.Value.Likes);
                        Assert.AreEqual(i.Value.Title, j.Value.Title);
                        Assert.AreEqual(i.Value.Comments, j.Value.Comments);
                    }
         
        }
    }
}
