using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace SharperBot.Services.Games.Structures
{
    public interface Listener
    {
        public async Task Handle(SocketMessage messageParam)
        {
            var message = messageParam as SocketUserMessage;
            if (message == null) return;
            await message.Channel.SendMessageAsync(embed: 
                new EmbedBuilder()
                {
                    Title = "ERROR!",
                    Description = "A Game Listener Has Not been Setup ,but Is Loaded!"
                }.Build()
                );
        }
    }
}