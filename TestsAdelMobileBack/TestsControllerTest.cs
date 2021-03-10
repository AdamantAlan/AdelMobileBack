using System.Threading.Tasks;
using AdelMobileBackEnd.Controllers;
using NUnit.Framework;
using AdelMobileBackEnd.Stubs;
using Microsoft.AspNetCore.Mvc;

namespace TestsAdelMobileBack
{
    [TestFixture]
    class TestsControllerTest
    {

        [Test]
        public async Task GetTestJson()
        {
            //A
            var controller = new TestController();
            //A
            var result = await controller.GetAllStubParseAsync();
            var file = await StubJson.DeserializeOfFileAsync();
            //A
            Assert.That(Equals(result.a, file.a));
            Assert.That(Equals(result.b, file.b));
        }
        [Test]
        public async Task GetTestParse()
        {
            //A
            var controller = new TestController();
            //A
            var result = await controller.GetParseAsync();
            var r_ok = result as OkResult; 
            //A
            Assert.That(Equals(r_ok.StatusCode, 200));
        }
        [Test]
        public async Task PostTestJson()
        {
            //A
            var controller = new TestController();
            //A
            var result = await controller.PostStubParseAsync(new JsonTestStub { a=0,b="string"});
            var r_ok = result as OkResult;
            //A
            Assert.That(Equals(r_ok.StatusCode, 200));
        }
    }

}