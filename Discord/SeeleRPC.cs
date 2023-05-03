using DiscordRPC;
using System.Diagnostics;

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
            Timestamps = Timestamps.Now,
            Assets = new Assets()
            {
                LargeImageText = "Honkai: Star Rail",
                LargeImageKey = "starrail",
                SmallImageText = "Honkai: Star Rail",
                SmallImageKey = "starrail",
            }
        };

        private static void RPCStart()
        {
            if (!Initialized)
            {
                client.Initialize();
                Initialized = true;
            }

            Config config = (Config)Config.RPC();

            presence.Details = config.Details;
            presence.State = config.Message;
            presence.Buttons = new Button[] {
                new Button() { Label = "View Profile", Url = config.Profile },
                new Button() { Label = "HoYoLab Profile", Url = config.Hoyolab },
            };

            client.SetPresence(presence);
        }

        private static void Cancel()
        {
            if (client != null && client.IsInitialized)
            {
                client.ClearPresence();
            }
        }

        public static void Start()
        {
            while (true)
            {
                Process[] starRail = Process.GetProcessesByName(game);

                if (starRail.Length > 0)
                {
                    SeeleRPC.RPCStart();
                }
                else
                {
                    SeeleRPC.Cancel();
                }
                Thread.Sleep(1000);
            }
        }
    }
}
