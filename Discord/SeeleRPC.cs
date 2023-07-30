using DiscordRPC;
using SeeleRichPresence.Api;
using System.Diagnostics;
using System.Reflection;

namespace SeeleRichPresence.Discord
{
    class SeeleRPC
    {
        private static readonly string game = "starrail";
        private static readonly string token = "1098657418218586174";
        private static bool Initialized = false;

        private static readonly DiscordRpcClient client = new(token);
        private static readonly RichPresence presence = new()
        {
            Assets = new Assets()
            {
                LargeImageText = "Honkai: Star Rail",
                LargeImageKey = "starrail",
                SmallImageText = "Honkai: Star Rail",
                SmallImageKey = "starrail",
            }
        };

        private async static void RPCStart()
        {
            Config config = (Config)Config.RPC();

            if(config.Uuid == null || config.Uuid.Length == 0)
            {
                throw new ArgumentNullException("Uuid", "Missing Uuid");
            }

            var account = await new StarRail(config.Uuid).Api();

            presence.Timestamps = Timestamps.Now;
            presence.Details = $"{account?.Nickname} | LvL: {account?.Level} | Achv: {account?.RecordInfo?.AchievementCount}";
            presence.State = $"{account?.Signature}";
            presence.Buttons = new Button[] {
                new Button() { Label = "View Profile", Url = config.Profile },
                new Button() { Label = "HoYoLab Profile", Url = config.Hoyolab },
            };

            if (!Initialized)
            {
                client.Initialize();
                Initialized = true;
            }

            client.SetPresence(presence);
        }

        private static void Cancel()
        {
            if (client != null && client.IsInitialized)
            {
                presence.Timestamps = null;
                client.ClearPresence();
            }
        }

        public static void Start()
        {
            var isRunning = false;

            while (true)
            {
                Process[] starRail = Process.GetProcessesByName(game);

                if (starRail.Length > 0 && !isRunning)
                {
                    RPCStart();
                    isRunning = true;
                }
                else if (starRail.Length == 0 && isRunning)
                {
                    Cancel();
                    isRunning = false;
                }

                Thread.Sleep(1000);
            }
        }
    }
}
