using System.Collections.Generic;

namespace SharperBot.Services.Games.Structures
{
    public class PlayerList
    {
        private readonly Dictionary<ulong, Player> Players;

        public PlayerList()
        {
            Players = new Dictionary<ulong, Player>();
        }
        public Player GetPlayer(ulong id)
        {
            return Players[id];
        }
        public void AddPlayer(ulong id,Player player)
        {
            Players.Add(id,player);
        }

        public void RemovePlayer(ulong id)
        {
            Players.Remove(id);
        }
    }
}