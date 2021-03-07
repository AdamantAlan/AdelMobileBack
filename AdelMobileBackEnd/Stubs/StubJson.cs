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
        public static async Task<JsonModel> DeserializeOfFileAsync()
        {
            if (File.Exists("state/test.json"))
                using (FileStream fs = new FileStream("state/test.json", FileMode.OpenOrCreate))
                {
                    JsonModel json = await JsonSerializer.DeserializeAsync<JsonModel>(fs);
                    return json;
                }
            return null;

        }
        public static  async Task<string> SerializeForFileAsync(JsonModel Json)
        {

            if (Json == null)
                return "Bad serialize, string is null or empty - SerializeForFile(string noJson)";
            using (FileStream fs = new FileStream("state/test.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync<JsonModel>(fs, Json);
                return "Serializeble successful";  //Good result
            }
        }
    }
}
