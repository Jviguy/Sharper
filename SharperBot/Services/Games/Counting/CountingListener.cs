using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Microsoft.VisualBasic;

namespace SharperBot.Services.Games.Counting
{
    public class CountingListener
    {
        private readonly CountingGameManager Manager;

        public CountingListener(CountingGameManager manager)
        {
            Manager = manager;
        }
        public async Task HandleMessage(SocketMessage messageParam)
        {
            var message = messageParam as SocketUserMessage;
            if (message == null) return;
            if (message.Content.Split(" ").Length != 1)
            {
                return;
            }
            var num = 0;
            try
            {
                num = int.Parse(message.Content.Split(" ")[0]);
            }
            catch
            {
                return;
            }
            
            if (Manager.getGame(message.Channel.Name) == null && num == 1)
            {
                    Manager.AddGame(message.Channel.Name, new CountingGame(message.Channel.Name, message.Author.Username));
                    await message.AddReactionAsync(new Emoji("✅"));
                    return;
            }

            if (Manager.getGame(message.Channel.Name) == null)
            {
                return;
            }
            try
            {
                Manager.getGame(message.Channel.Name).Play(message.Author.Username,num);
                await message.AddReactionAsync(new Emoji("✅"));
            }
            catch (Exception e)
            {
                Manager.StopGame(message.Channel.Name);
                await message.AddReactionAsync(new Emoji("❌"));
                await message.Channel.SendMessageAsync(embed: new EmbedBuilder()
                {
                    Title = "Failure!",
                    Color = Color.Red,
                    ThumbnailUrl = "https://i.redd.it/iysl5f5vrxe31.jpg",
                    Description = message.Author.Username + " Failed Because " + e.Message
                }.Build());
            }
        }
    }
}