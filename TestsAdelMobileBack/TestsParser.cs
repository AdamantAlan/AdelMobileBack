using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AdelMobileBackEnd.models;
using AdelMobileBackEnd.models.absFactoryOfBook.products;


namespace TestsAdelMobileBack
{
    [TestFixture]
    class TestsParser
    {
        [Test]
        public async Task GetRubin()
        {
            //A
            Rubin result = new Rubin("Рубин", 11,15);
            IParser<Rubin> parser = new Parser<Rubin>();
            //A
            Rubin Ok = await parser.GetBookAsync();
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
            IParser<Wool> parser = new Parser<Wool>();
            //A
            Wool Ok = await parser.GetBookAsync();
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
            IParser<Prayer> parser = new Parser<Prayer>();
            //A
            Prayer Ok = await parser.GetBookAsync();
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
            IParser<Portrait> parser = new Parser<Portrait>();
            //A
            Portrait Ok = await parser.GetBookAsync();
            //A
            Assert.That(Equals(Ok.Title, result.Title));
            Assert.That(Equals(Ok.Likes, result.Likes));
            Assert.That(Equals(Ok.Comments, result.Comments));
        }
        [Test]
        public async Task GetAll()
        {
            //A
            var rubin = await new Parser<Rubin>().GetBookAsync();
            var wool = await new Parser<Wool>().GetBookAsync();
            var prayer = await new Parser<Prayer>().GetBookAsync();
            var portrait = await new Parser<Portrait>().GetBookAsync();
            Dictionary<string, IBook> bookStubs = new Dictionary<string, IBook>();
           bookStubs.Add("Rubin",rubin);
            bookStubs.Add("Wool",wool);
            bookStubs.Add("Prayer",prayer);
            bookStubs.Add("Portrait",portrait);
            //A
            Dictionary<string,IBook> Ok = await  new Parser<Rubin>().GetAllBooksAsync();
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
