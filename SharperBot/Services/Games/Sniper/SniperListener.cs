using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using SharperBot.Services.Games.Structures;

namespace SharperBot.Services.Games.Sniper
{
    public class SniperListener
    {
        private SniperLoader Manager;

        public SniperListener(SniperLoader manager)
        {
            Manager = manager;
        }
        public async Task Handle(Cacheable<IMessage,ulong> cacheable, ISocketMessageChannel channel)
        {
            var msg = cacheable.Value;
            if (Manager.ShouldAddChannel(msg.Channel.Id))
            {
                Manager.AddChannel(msg.Channel.Id);
            }
        }
    }
}