using NUnit.Framework;
using System.Threading.Tasks;
using AdelMobileBackEnd.models;
using AdelMobileBackEnd.models.absFactoryOfBook.products;

namespace TestsAdelMobileBack
{
    [TestFixture]
    public class TestsJsonAsync:AssertionHelper
    {
        [Test]
        public async Task JsonSerializeForFile()
        {
            // A 
            IBook model = new Rubin("test",12,4);
            string result = "Serializeble successful";
            //A
            string JAOK = await  JsonAsync.SerializeForFileAsync<Rubin>((Rubin)model);
            //A
            Expect(Equals(JAOK,result));
        }
        [Test]
        public async Task Bag_JsonDeserializeForFile()
        {
            //A
            IBook model = new Rubin("test", 12, 4);
            //A
            IBook JAOK = await JsonAsync.DeserializeOfFileAsync<Rubin>();
            //A
            Expect(Equals(JAOK.Title, model.Title));
            Expect(Equals(JAOK.Comments, model.Comments));
            Expect(Equals(JAOK.Likes, model.Likes));
        }
    }
}