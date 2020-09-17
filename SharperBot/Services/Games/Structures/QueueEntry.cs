using System;

namespace SharperBot.Services.Games.Structures
{
    public class QueueEntry
    {
        public QueueEntry(Player player)
        {
            Player = player;
            JoinTime = DateTime.Now;
        }
        public Player Player;
        public DateTime JoinTime;
    }
}