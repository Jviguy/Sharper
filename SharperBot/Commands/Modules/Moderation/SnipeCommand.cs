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
        public async Task SnipeAsync([Summary("the number index to fetch")] int index)
        {
            var game = (SniperLoader) GameManager.GetInstance().GetGame(GameManager.Sniper);
            if (game.ShouldAddChannel(Context.Channel.Id))
            {
                await ReplyAsync(embed: new EmbedBuilder()
                {
                    Title = "Error",
                    Timestamp = new DateTimeOffset(),
                    Footer = new EmbedFooterBuilder()
                    {
                        Text = "Sniper By Jviguy Games! [Click Here!][]"
                    },
                }.Build());
            }
        }
    }
}