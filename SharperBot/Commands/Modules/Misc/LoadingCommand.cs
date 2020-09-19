using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using SharperBot.Services.Discord.Embed;

namespace SharperBot.Commands.Modules.Misc
{
    public class LoadingCommand : ModuleBase<SocketCommandContext>
    {
        private LoadingUtils loading = new LoadingUtils();
        [Command("loading", RunMode = RunMode.Async)]
        public async Task LoadingAsync()
        {
            await ReplyAsync(embed: new EmbedBuilder()
            {
                Title = Context.User.Username + " Is Loading Please Hold!",
                ImageUrl = loading.FetchRandomGIF()
            }.Build());
        }
    }
}