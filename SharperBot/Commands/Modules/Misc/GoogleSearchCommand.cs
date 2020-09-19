using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Google.Apis.Customsearch.v1;
using Google.Apis.Services;

namespace SharperBot.Commands.Modules.Misc
{
    public class GoogleSearchCommand : ModuleBase<SocketCommandContext>
    {
        [Command("google", RunMode = RunMode.Async)]
        public async Task GoogleSearchAsync(int results,[Remainder] string query)
        {
            try
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                var service = new CustomsearchService(new BaseClientService.Initializer()
                {
                    ApiKey = Program.GoogleToken,
                    ApplicationName = "Sharper Bot"
                });
                var result = service.Cse.List();
                result.Q = query;
                result.Cx = "8f9713cc92e654622";
                var data = await result.ExecuteAsync();
                var sb = new StringBuilder();
                var attepts = 0;
                foreach (var re in data.Items)
                {
                    attepts++;
                    if (attepts >= results + 1)
                    {
                        break;
                    }

                    sb.Append(re.Title + $"- [Click To View Result!]({re.Link})\n");
                }

                if (sb.ToString().Length >= 2048)
                {
                    await ReplyAsync(embed: new EmbedBuilder()
                    {
                        Title = "ERROR",
                        Description = "Too Many Results Too Display Try Lowering The Number!",
                        ImageUrl = "https://media.tenor.com/images/21aa6ef4312e1abcd50ffca5e1d4dd75/tenor.gif"
                    }.Build());
                    return;
                }
                await ReplyAsync(embed: new EmbedBuilder()
                {
                    Title = "Search Results From Google!",
                    Description = sb.ToString(),
                    Footer = new EmbedFooterBuilder()
                    {
                        Text = " - A Google Search by " + Context.User.Username + " Done in 0." +
                               stopwatch.ElapsedMilliseconds + "s!",
                        IconUrl = Context.User.GetAvatarUrl()
                    }
                }.Build());
                stopwatch.Stop();
            }
            catch (Exception e)
            {
                await ReplyAsync(embed: new EmbedBuilder()
                {
                    Title = "Google Error!",
                    Description = e.Message,
                    ImageUrl = "https://media.tenor.com/images/21aa6ef4312e1abcd50ffca5e1d4dd75/tenor.gif"
                }.Build());
            }
        }
    }
}