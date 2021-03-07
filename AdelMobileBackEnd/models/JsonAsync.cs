
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace AdelMobileBackEnd.models
{
    public static class JsonAsync
    {

       public static async Task<JsonModel> DeserializeOfFileAsync()
        {
            try
            {
                using (FileStream fs = new FileStream("state/result.json", FileMode.OpenOrCreate))
                {
                    JsonModel json = await JsonSerializer.DeserializeAsync<JsonModel>(fs);
                    return json;
                }
            }
            catch (Exception e)
            {
                using (FileStream fs = new FileStream("state/log.txt", FileMode.OpenOrCreate))
                {
                    byte[] error = System.Text.Encoding.Default.GetBytes(" DeserializeOfFileAsync:" + e.Message);
                   await fs.WriteAsync(error, 0, error.Length);
                    return null;
                }
            }
        }

        public static async Task<string> SerializeForFileAsync(JsonModel Json)
        {
            try
            {
                if (Json == null)
                    return "Bad serialize, string is null or empty - SerializeForFile(string noJson)";
                using (FileStream fs = new FileStream("state/result.json", FileMode.OpenOrCreate))
                    await JsonSerializer.SerializeAsync<JsonModel>(fs, Json);
                return "Serializeble successful";  //Good result
            }
            catch (Exception e)
            {
                using (FileStream fs = new FileStream("state/log.txt", FileMode.OpenOrCreate))
                {
                    byte[] error = System.Text.Encoding.Default.GetBytes("SerializeForFileAsync ERROR:" + e.Message);
                   await fs.WriteAsync(error, 0, error.Length);
                    return null;
                }
            }
        }
    }
}
