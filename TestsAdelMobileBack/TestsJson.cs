using NUnit.Framework;
using AdelMobileBackEnd.Stubs;
using System.Threading.Tasks;
namespace TestsAdelMobileBack
{
    [TestFixture]
    public class TestsJson:AssertionHelper
    {
        [Test]
        public async Task JsonSerializeForFile()
        {
            // A 
            JsonTestStub model = new JsonTestStub { a = 2, b = "123" };
            string result = "Serializeble successful";
            //A
            string JAOK = await  StubJson.SerializeForFileAsync(model);
            //A
            Expect(Equals(JAOK,result));
        }
        [Test]
        public async Task JsonDeserializeForFile()
        {
            //A
            JsonTestStub model = new JsonTestStub { a = 0, b = "string" };
            //A
            JsonTestStub JAOK = await StubJson.DeserializeOfFileAsync();
            //A
            Expect(Equals(JAOK.a,model.a));
            Expect(Equals(JAOK.b, model.b));
        }
    }
}