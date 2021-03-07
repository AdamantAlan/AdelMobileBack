using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AdelMobileBackEnd.models;
namespace TestsAdelMobileBack
{
    [TestFixture]
    class TestsParser
    {
        [Test]
        public async Task GetRubin()
        {
            //A
            string result = "OK";
            //A
            string Ok = await new Parser().GetRubinAsync();
            //A
            Assert.That(Equals(Ok,result));
        }
    }
}
