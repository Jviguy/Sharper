using System.Collections.Generic;
using Discord;
using Discord.WebSocket;

namespace SharperBot.Services.Games.Sniper
{
    public class SniperLogs
    {
        public List<IMessage> Messages;

        public void Log(IMessage message)
        {
            Messages.Add(message);
        }

        public IMessage GetMessage(int index = 0)
        {
            return Messages[index];
        }
    }
}