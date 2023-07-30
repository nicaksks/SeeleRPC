using Newtonsoft.Json;
using SeeleRichPresence.Models;

namespace SeeleRichPresence.Api
{
    internal class StarRail
    {
        private readonly string url = "https://api.mihomo.me/sr_info";
        private readonly string uuid;
 
        public StarRail(string uuid)
        {
            this.uuid = uuid;
        }

        public async Task<DetailInfo> Api()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{url}/{uuid}?lang=en");
            var content = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<Root>(content);

            if((int)response.StatusCode != 200)
            {
                throw new Exception("Invalid Uuid");
            }

            return data?.DetailInfo;  
        }
    }
}
