using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.Rest;
using SharperBot.Services.Discord.Embed;
using SharperBot.Services.Minecraft.Query;

namespace SharperBot.Commands.Modules.Minecraft
{
    public class QueryCommand : ModuleBase<SocketCommandContext>
    {
        [Command("query", RunMode = RunMode.Async)]
        [Summary("Queries a gamespy server")]
        public async Task QueryAsync([Summary("IP of the server")] string ip, [Summary("Port of the server")] int port=19132)
        {
            try
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                var query = new MCQuery(ip,port);
                var data = query.Query();
                var em = new EmbedBuilder() {Title = $"A Long Query On {ip}!"};
                em.Footer = new EmbedFooterBuilder()
                {
                    Text = "- A Long Query By " + Context.User.Username +"#"+Context.User.Discriminator
                        + " - Done in " + "0." +stopwatch.ElapsedMilliseconds + "s",
                    IconUrl = Context.User.GetAvatarUrl()
                };
                em.Color = new ColorUtils().ColorRand();
                em.AddField("MOTD: ", data.MessageOfTheDay);
                em.AddField("Game: ", data.GameId);
                em.AddField("Version: ", data.Version);
                em.AddField("GameType: ", data.Gametype);
                em.AddField("Software: ", data.Plugins);
                em.AddField("Player Count: ", data.NumPlayers + "/" + data.MaxPlayers);
                if (data.Players.ToArray().Length == 0)
                {
                    em.AddField("Players: ", "None");
                }
                else
                {
                    em.AddField("Players: ",string.Join(" ",data.Players.ToArray()));
                }
                await ReplyAsync(embed: em.Build());
                stopwatch.Stop();
            }
            catch (Exception e)
            {
                await ReplyAsync(embed: new EmbedBuilder(){Title = "ERROR", Description = e.Message}.Build());
            }
        }
    }
}