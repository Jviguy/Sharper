using System;

namespace SharperBot.Services.Games.Counting
{
    public class CountingGame
    {
        private string Channelid;
        private int Count;
        private string Lastid;

        public CountingGame(string channelid,string lastid, int count = 1)
        {
            Channelid = channelid;
            Count = count;
            Lastid = lastid;
        }

        public string getChannel()
        {
            return Channelid;
        }
        public void Play(string newid,int newcount)
        {
            if (newid == Lastid)
            {
                throw new Exception("The Same Player Cant Count Twice In A Row!");
            }
            if (Count + 1 != newcount)
            {
                throw new Exception("Wrong Next Number!");
            }
            Count = newcount;
            Lastid = newid;
        }
    }
}