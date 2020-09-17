using System.Collections.Generic;
using Discord.WebSocket;

namespace SharperBot.Services.Games.Sniper
{
    public class SniperLoader : Manager
    {
        private DiscordSocketClient Client;
        private SniperListener SniperListener;
        private Dictionary<ulong, SniperLogs> Logs;
        public SniperLoader(DiscordSocketClient client)
        {
            Client = client;
            Logs = new Dictionary<ulong, SniperLogs>();
            SniperListener = new SniperListener(this);
        }
        public override void Load()
        {
            Client.MessageDeleted += SniperListener.Handle;
        }

        public bool ShouldAddChannel(ulong id)
        {
            if (Logs[id] == null)
            {
                return true;
            }
            return false;
        }

        public void AddChannel(ulong id)
        {
            Logs.Add(id,new SniperLogs());
        }

        public SniperLogs GetChannel(ulong id)
        {
            return Logs[id];
        }
    }
}