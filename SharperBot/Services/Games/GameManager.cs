using System;
using System.Collections.Generic;
using Discord.WebSocket;
using SharperBot.Services.Games.Counting;

namespace SharperBot.Services.Games
{
    public class GameManager
    {
        private static GameManager Instance;

        public static GameManager GetInstance()
        {
            return Instance;
        }
        private DiscordSocketClient Client;
        private readonly Dictionary<string,Manager> Loadedgames;
        public GameManager(DiscordSocketClient client)
        {
            Client = client;
            Loadedgames = new Dictionary<string,Manager>();
            Instance = this;
        }
        public void Load()
        {
            Console.WriteLine("Started Loading Games!");
            Loadedgames.Add(Counting,new CountingGameManager(Client));
            foreach (var loadedgame in Loadedgames)
            {
                loadedgame.Value.Load();
            }
        }

        public Manager GetGame(string name)
        {
            return Loadedgames[name];
        }
        //consts
        public const string Counting = "Counting";
    }
}