using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace SharperBot.Commands.Modules.Misc
{
    public class cURLCommand : ModuleBase<SocketCommandContext>
    {
        [Command("curl", RunMode = RunMode.Async)]
        public async Task CurlAsync(string url,[Remainder] string request)
        {
            var array = request.Split(" ");
            var requestContent = new FormUrlEncodedContent(new [] {
                new KeyValuePair<string, string>(array[0],string.Join(" ",array,1)),
            });
            var client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync(
                url,requestContent);
            HttpContent responseContent = response.Content;
            using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
            {
                await ReplyAsync(embed: new EmbedBuilder()
                {
                    Title = "Curl Response!",
                    Description = await reader.ReadToEndAsync()
                }.Build());
            }
        }
    }
}