using Discord.WebSocket;

namespace SharperBot.Services.Games.Structures
{
    public class Player
    {
        private SocketGuildUser User;

        public Player(SocketGuildUser user)
        {
            User = user;
        }
    }
}