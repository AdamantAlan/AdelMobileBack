using System.Threading.Tasks;
using AdelMobileBackEnd.Controllers;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using AdelMobileBackEnd.models.absFactoryOfBook.products;
using AdelMobileBackEnd.models;

namespace TestsAdelMobileBack
{
    [TestFixture]
    class TestsFicbookController
    {
        [Test]
        public async Task GetRubinFromFicbook()
        {
            //A
            var controller = new FicbookController();
            var ok = 200;
            //A

            var result = await controller.GetRubinFromFicbook() as OkResult;
            //
            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, ok);
        }
        [Test]
        public async Task Bag_GetRubinForAdel()
        {
            //A
            var controller = new FicbookController();
            IBook ok = new Rubin("Рубин",11,15);
            //A
            var result = await controller.GetRubinForAdel();
            //A
            Assert.AreEqual(ok.Title,result.Title);
            Assert.AreEqual(ok.Comments, result.Comments);
            Assert.AreEqual(ok.Likes,result.Likes);
        }

        [Test]
        public async Task GetWoolFromFicbook()
        {
            //A
            var controller = new FicbookController();
            var ok = 200;
            //A

            var result = await controller.GetWoolFromFicbook() as OkResult;
            //
            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, ok);
        }
        [Test]
        public async Task Bag_GetWoolForAdel()
        {
            //A
            var controller = new FicbookController();
            IBook ok = new Wool("Шерсть", 0, 2);
            //A
            var result = await controller.GetWoolForAdel();
            //A
            Assert.AreEqual(ok.Title, result.Title);
            Assert.AreEqual(ok.Comments, result.Comments);
            Assert.AreEqual(ok.Likes, result.Likes);
        }
    }
}
//public async Task GetTestJson()
//{
//    //A
//    var controller = new TestController();
//    //A
//    var result = await controller.GetAllStubParseAsync();
//    var file = await StubJson.DeserializeOfFileAsync();
//    //A
//    Assert.That(Equals(result.a, file.a));
//    Assert.That(Equals(result.b, file.b));
//}