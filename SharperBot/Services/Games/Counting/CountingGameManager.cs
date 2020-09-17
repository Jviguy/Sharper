using System;
using System.Collections.Generic;
using Discord.WebSocket;

namespace SharperBot.Services.Games.Counting
{
    public class CountingGameManager : Manager
    {
        private DiscordSocketClient Client;
        private CountingListener Listener;
        private readonly Dictionary<string, CountingGame> Gamemaping;
        public CountingGameManager(DiscordSocketClient client)
        {
            Client = client;
            Gamemaping = new Dictionary<string, CountingGame>();
        }

        public override void Load()
        {
            Listener = new CountingListener(this);
            Client.MessageReceived += Listener.HandleMessage;
            Console.WriteLine("Loaded Counting Game!");
        }

        public void AddGame(string channelid,CountingGame game)
        {
            Gamemaping.Add(channelid,game);
        }
        public CountingGame getGame(string channelid)
        {
            try
            {
                var blah = Gamemaping[channelid];
                return blah;
            }
            catch
            {
                return null;
            }
        }
        public void StopGame(string channelid)
        {
            Gamemaping.Remove(channelid);
        }
    }
}