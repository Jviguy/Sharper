using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Discord.Commands;

namespace SharperBot.Commands.Modules.Misc
{
    public class cURLCommand : ModuleBase<SocketCommandContext>
    {
        [Command("curl", RunMode = RunMode.Async)]
        public async Task CurlAsync(string url,[Remainder] string request)
        {
            using (var webClient = new WebClient())
            {
                var re = request.Split(" ");
                var s = request.Split(" ");
                var l = s.ToList();
                l.RemoveAt(0);
                l.RemoveAt(1);
                l.RemoveAt(2);
                var msg = string.Join(" ", l);
                webClient.UploadValues(new Uri(url),new NameValueCollection()
                {
                    {re[0], re[1]},
                    {re[2],msg}
                });
            }
        }
    }
}