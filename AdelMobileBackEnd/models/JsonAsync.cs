using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AdelMobileBackEnd.Stubs;
namespace AdelMobileBackEnd.models
{

    public static class JsonAsync
    {

       internal static async Task<JsonTestStub> DeserializeOfFileAsync()
        {
            try
            {
                using (FileStream fs = new FileStream("state/result.json", FileMode.OpenOrCreate))
                {
                    JsonTestStub json = await JsonSerializer.DeserializeAsync<JsonTestStub>(fs);
                    return json;
                }
            }
            catch (Exception e)
            {
                await Log.LoggingAsync(e, "DeserializeOfFileAsync");
                return null;
            }
        }

        internal static async Task<string> SerializeForFileAsync(JsonTestStub Json)
        {
            try
            {
                if (Json == null)
                    return "Bad serialize, string is null or empty - SerializeForFile(string noJson)";
                using (FileStream fs = new FileStream("state/result.json", FileMode.OpenOrCreate))
                    await JsonSerializer.SerializeAsync<JsonTestStub>(fs, Json);
                return "Serializeble successful";  //Good result
            }
            catch (Exception e)
            {
                await Log.LoggingAsync(e, "SerializeForFileAsync");
                return null;
            }
        }
    }
}
