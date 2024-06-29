using System.ComponentModel;
using Newtonsoft.Json;

namespace hw_cSH_14;

public static class Query
{
   public static async void GetLocationByIp(string ip, string path)
   {
      string url = $"http://ipwho.is/{ip}";
      HttpClient client = new HttpClient();
      var response = await client.GetAsync(url);
      if (response.IsSuccessStatusCode)
      {
         string content = await response.Content.ReadAsStringAsync();
         if (content.Length > 0)
         {
            // десириализируем прошлые записи в json
            List<IpData> list = new List<IpData>();
            if (File.Exists(path))
            {
               string json = File.ReadAllText(path);
               if (json.Length > 0)
                  list = JsonConvert.DeserializeObject<List<IpData>>(json);
            }
            
            // десириализируем контент что нам пришел
            var data = JsonConvert.DeserializeObject<IpData>(content);
            list.Add(new IpData(data.Country, data.Region, data.City));

            // сериализируем данные
            string updatedJson = JsonConvert.SerializeObject(list);
            if (updatedJson.Length > 0)
            {
               File.WriteAllText(path, updatedJson);
            }
         }
      }
   }
}