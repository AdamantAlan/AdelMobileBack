using NUnit.Framework;
using AdelMobileBackEnd.models;
using AdelMobileBackEnd.Stubs;
using System.Threading.Tasks;
namespace TestsAdelMobileBack
{
    [TestFixture]
    public class TestsJson:AssertionHelper
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task JsonSerializeForFile()
        {
            // A 
            JsonModel model = new JsonModel { a = 2, b = "123" };
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
            JsonModel model = new JsonModel { a = 123, b = "123123" };
            //A
            JsonModel JAOK = await   StubJson.DeserializeOfFileAsync();
            //A
            Expect(Equals(JAOK.a,model.a));
            Expect(Equals(JAOK.b, model.b));
        }
    }
}