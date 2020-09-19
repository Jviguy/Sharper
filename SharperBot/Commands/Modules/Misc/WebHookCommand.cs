using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace SharperBot.Commands.Modules.Misc
{
    [Group("curl")]
    public class WebHookCommand : ModuleBase<SocketCommandContext>
    {
        [Command("webhook", RunMode = RunMode.Async)]
        public async Task CurlAsync(string url,[Remainder] string request)
        {
            try
            {
                using (var webClient = new WebClient())
                {
                    var re = request.Split(" ");
                    var l = re.ToList();
                    for (var a = 0; a < 3; a++)
                    {
                        l.RemoveAt(0);
                    }

                    var msg = string.Join(" ", l);
                    webClient.UploadValues(new Uri(url), new NameValueCollection()
                    {
                        {re[0], re[1]},
                        {re[2], msg}
                    });
                }
            }
            catch (Exception e)
            {
                await ReplyAsync(embed: new EmbedBuilder()
                {
                    Title = "Error",
                    Description = e.Message,
                    ImageUrl = "https://media.tenor.com/images/21aa6ef4312e1abcd50ffca5e1d4dd75/tenor.gif"
                }.Build());
            }
        }
    }
}