using System.Threading.Tasks;
using AdelMobileBackEnd.Controllers;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using AdelMobileBackEnd.models.absFactoryOfBook.products;
using AdelMobileBackEnd.models;
using System.Collections.Generic;

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
        [Test]
        public async Task GetPrayerFromFicbook()
        {
            //A
            var controller = new FicbookController();
            var ok = 200;
            //A

            var result = await controller.GetPrayerFromFicbook() as OkResult;
            //
            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, ok);
        }
        [Test]
        public async Task Bag_GetPrayerForAdel()
        {
            //A
            var controller = new FicbookController();
            IBook ok = new Prayer("Просьба", 4, 10);
            //A
            var result = await controller.GetPrayerForAdel();
            //A
            Assert.AreEqual(ok.Title, result.Title);
            Assert.AreEqual(ok.Comments, result.Comments);
            Assert.AreEqual(ok.Likes, result.Likes);
        }
        [Test]
        public async Task GetPortraitFromFicbook()
        {
            //A
            var controller = new FicbookController();
            var ok = 200;
            //A

            var result = await controller.GetPortraitFromFicbook() as OkResult;
            //
            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, ok);
        }

        [Test]
        public async Task Bag_GetPortraitForAdel()
        {
            //A
            var controller = new FicbookController();
            IBook ok = new Portrait("История одного портрета", 1, 5);
            //A
            var result = await controller.GetPortraitForAdel();
            //A
            Assert.AreEqual(ok.Title, result.Title);
            Assert.AreEqual(ok.Comments, result.Comments);
            Assert.AreEqual(ok.Likes, result.Likes);
        }

        [Test]
        public async Task GetAllFicbook()
        {
            //A
            var controller = new FicbookController();
            var ok = 200;
            //A

            var result = await controller.GetAllFicbook() as OkResult;
            //
            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, ok);
        }
        [Test]
        public async Task Bag_GeAllForAdel()
        {
            //A
            var controller = new FicbookController();
            var rubin = await new Parser<Rubin>().GetBookAsync();
            var wool = await new Parser<Wool>().GetBookAsync();
            var prayer = await new Parser<Prayer>().GetBookAsync();
            var portrait = await new Parser<Portrait>().GetBookAsync();
            Dictionary<string, IBook> bookStubs = new Dictionary<string, IBook>();
            bookStubs.Add("Rubin", rubin);
            bookStubs.Add("Wool", wool);
            bookStubs.Add("Prayer", prayer);
            bookStubs.Add("Portrait", portrait);
            //A
            Dictionary<string, IBook> ok = await controller.GetAllForAdel();
            //A
            foreach (var i in ok)
                foreach (var j in bookStubs)
                    if (i.Key == j.Key)
                    {
                        Assert.AreEqual(i.Value.Likes, j.Value.Likes);
                        Assert.AreEqual(i.Value.Title, j.Value.Title);
                        Assert.AreEqual(i.Value.Comments, j.Value.Comments);
                    }
        }

    }
}