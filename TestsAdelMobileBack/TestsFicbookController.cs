using System.Threading.Tasks;
using AdelMobileBackEnd.Controllers;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using AdelMobileBackEnd.models.absFactoryOfBook.products;
using AdelMobileBackEnd.models;
using System.Collections.Generic;
using Moq;

namespace TestsAdelMobileBack
{
    [TestFixture]
    class TestsFicbookController
    {
        [Test]
        public async Task GetRubinFromFicbook()
        {
            //A
            var mock = new Mock<IParser>();
            mock.Setup(repo => repo.GetBookAsync<Rubin>()).Returns(new Parser().GetBookAsync<Rubin>());
            var controller = new FicbookController(mock.Object);
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
            var mock = new Mock<IParser>();
            mock.Setup(repo => repo.GetBookAsync<Rubin>()).Returns(new Parser().GetBookAsync<Rubin>());
            var controller = new FicbookController(mock.Object);
            IBook ok = new Rubin("Рубин",11,16);
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
            var mock = new Mock<IParser>();
            mock.Setup(repo => repo.GetBookAsync<Wool>()).Returns(new Parser().GetBookAsync<Wool>());
            var controller = new FicbookController(mock.Object);
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
            var mock = new Mock<IParser>();
            mock.Setup(repo => repo.GetBookAsync<Wool>()).Returns(new Parser().GetBookAsync<Wool>());
            var controller = new FicbookController(mock.Object);
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
            var mock = new Mock<IParser>();
            mock.Setup(repo => repo.GetBookAsync<Prayer>()).Returns(new Parser().GetBookAsync<Prayer>());
            var controller = new FicbookController(mock.Object);
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
            var mock = new Mock<IParser>();
            mock.Setup(repo => repo.GetBookAsync<Prayer>()).Returns(new Parser().GetBookAsync<Prayer>());
            var controller = new FicbookController(mock.Object);
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
            var mock = new Mock<IParser>();
            mock.Setup(repo => repo.GetBookAsync<Portrait>()).Returns(new Parser().GetBookAsync<Portrait>());
            var controller = new FicbookController(mock.Object);
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
            var mock = new Mock<IParser>();
            mock.Setup(repo => repo.GetBookAsync<Portrait>()).Returns(new Parser().GetBookAsync<Portrait>());
            var controller = new FicbookController(mock.Object);
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
            var mock = new Mock<IParser>();
            mock.Setup(repo => repo.GetAllBooksAsync()).Returns(new Parser().GetAllBooksAsync());
            var controller = new FicbookController(mock.Object);
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
            var mock = new Mock<IParser>();
            mock.Setup(repo => repo.GetAllBooksAsync()).Returns(new Parser().GetAllBooksAsync());
            var controller = new FicbookController(mock.Object);
            var rubin = await new Parser().GetBookAsync<Rubin>();
            var wool = await new Parser().GetBookAsync<Wool>();
            var prayer = await new Parser().GetBookAsync<Prayer>();
            var portrait = await new Parser().GetBookAsync<Portrait>();
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