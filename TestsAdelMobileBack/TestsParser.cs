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
    }
}
