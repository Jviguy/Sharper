using System.Linq;
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
            if (cacheable.HasValue)
            {
                var msg = cacheable.Value;
                if (Manager.ShouldAddChannel(msg.Channel.Id))
                {
                    Manager.AddChannel(msg.Channel.Id);
                }
            }
            else
            {
                //we are fucked because no cache was stored so yeah
            }
        }

        public async Task Message(SocketMessage messageParam)
        {
            var message = messageParam as SocketUserMessage;
            if (message == null) return;
            
        }
    }
}