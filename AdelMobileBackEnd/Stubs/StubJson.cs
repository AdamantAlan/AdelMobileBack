using AdelMobileBackEnd.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace AdelMobileBackEnd.Stubs
{
    public static class StubJson
    {
        public static async Task<JsonTestStub> DeserializeOfFileAsync()
        {
            try
            {
                using (FileStream fs = new FileStream("state/test.json", FileMode.OpenOrCreate))
                {
                    JsonTestStub json = await JsonSerializer.DeserializeAsync<JsonTestStub>(fs);
                    return json;
                }
            }
            catch (Exception e)
            {
                await Log.LoggingAsync(e, "STUBDeserializeOfFileAsync");
                return null;
            }
        }

        public static async Task<string> SerializeForFileAsync(JsonTestStub Json)
        {
            try
            {
                if (Json == null)
                    return "Bad serialize, string is null or empty - SerializeForFile(string noJson)";
                using (FileStream fs = new FileStream("state/test.json", FileMode.OpenOrCreate))
                    await JsonSerializer.SerializeAsync<JsonTestStub>(fs, Json);
                return "Serializeble successful";  //Good result
            }
            catch (Exception e)
            {
                await Log.LoggingAsync(e, "STUBSerializeForFileAsync");
                return null;
            }
        }
    }
}
