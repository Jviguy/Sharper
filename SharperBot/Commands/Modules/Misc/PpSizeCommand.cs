using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace SharperBot.Commands.Modules.Misc
{
    public class PpSizeCommand : ModuleBase<SocketCommandContext>
    {
        private readonly Random rnd = new Random();
        [Command("pp",false,RunMode = RunMode.Async)]
        public async Task PpSizeAsync()
        {
            var size = rnd.Next(1000);
            var pp = new StringBuilder(string.Empty);
            pp.Append("8");
            foreach (var i in Enumerable.Range(0, size))
            {
                pp.Append("=");
            }
            pp.Append(">");
            await ReplyAsync(embed: new EmbedBuilder()
            {
                Title = "Nice Cock Bro!",
                Description = pp.ToString()
            }.Build());
        }
    }
}