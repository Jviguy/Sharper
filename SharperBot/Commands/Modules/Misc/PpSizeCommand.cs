using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using SharperBot.Services.Discord.Embed;

namespace SharperBot.Commands.Modules.Misc
{
    public class PpSizeCommand : ModuleBase<SocketCommandContext>
    {
        private readonly Random rnd = new Random();
        private readonly DickUtils DickUtils = new DickUtils();
        [Command("pp",true,RunMode = RunMode.Async)]
        public async Task PpSizeAsync()
        {
            var size = rnd.Next(1000);
            var pp = new StringBuilder(string.Empty);
            if (size > 600)
            {
                var d = await ReplyAsync(embed: new EmbedBuilder()
                {
                    Title = "Your Dick Is So Long We need To Process IT!",
                    ImageUrl = new LoadingUtils().FetchRandomGIF()
                }.Build());
                await Task.Delay(5000);
                await d.DeleteAsync();
            }
            pp.Append("8");
            foreach (var i in Enumerable.Range(0, size))
            {
                pp.Append("=");
            }
            pp.Append("D");
            await ReplyAsync(embed: new EmbedBuilder()
            {
                Title = "Nice Cock Bro!",
                Description = pp.ToString(),
                ThumbnailUrl = DickUtils.FetchRandom()
            }.Build());
        }
    }
}