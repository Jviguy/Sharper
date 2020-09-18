using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using SharperBot.Services.Games;
using SharperBot.Services.Games.Sniper;

namespace SharperBot.Commands.Modules.Moderation
{
    public class SnipeCommand : ModuleBase<SocketCommandContext>
    {
        [Command("snipe", RunMode = RunMode.Async)]
        [Summary("Snipes a deleted message")]
        public async Task SnipeAsync([Summary("the number index to fetch")] int index=0)
        {
            try
            {
                var game = (SniperLoader) GameManager.GetInstance().GetGame(GameManager.Sniper);
                if (game.ShouldAddChannel(Context.Channel.Id))
                {
                    await ReplyAsync(embed: new EmbedBuilder()
                    {
                        Title = "No Messages To Snipe!",
                        Description = "Sniper By Jviguy Games! [Click Here!](https://github.com/Jviguy/Sharper/tree/master)",
                        Footer = new EmbedFooterBuilder()
                        {
                            Text = "0/0 Messages found in this channel!"
                        }
                    }.Build());
                }
            }
            catch (Exception e)
            {
                await ReplyAsync(embed: new EmbedBuilder()
                {
                    Title = "Error",
                    Description = e.Message
                }.Build());
            }
        }
    }
}