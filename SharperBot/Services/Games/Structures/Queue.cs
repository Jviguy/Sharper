using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SharperBot.Services.Games.Structures
{
    public class Queue
    {
        public Queue()
        {
            _list = new List<QueueEntry>();
        }
        private List<QueueEntry> _list;
        /*
         * The position is the players position in the queue so like 1 would be the second player in the queue
         */
        public QueueEntry TakePlayer(int Position)
        {
            _list.RemoveAt(Position);
            return _list[Position];
        }
        public List<QueueEntry> TakePlayers(params int[] Positions)
        {
            var ret = new List<QueueEntry>();
            foreach (var Position in Positions)
            {
                ret.Add(_list[Position]);
                _list.RemoveAt(Position);
            }
            return ret;
        }

        public void AddPlayer(Player player)
        {
            _list.Add(new QueueEntry(player));
        }
        public void Reset()
        {
            _list = new List<QueueEntry>();
        }

        public void RemovePlayer(int position)
        {
            _list.RemoveAt(position);
        }
    }
}