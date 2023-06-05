using Newtonsoft.Json;

namespace SeeleRichPresence.Discord
{
    class Config
    {
        public string? Uuid { get; set; }
        public string? Hoyolab { get; set; }
        public string? Profile { get; set; }

        public static object RPC()
        {
            string json = File.ReadAllText("config.json");
            Config? config = JsonConvert.DeserializeObject<Config>(json);

            return config == null ? throw new Exception("Missing config.json") : (object)config;
        }
    }
}