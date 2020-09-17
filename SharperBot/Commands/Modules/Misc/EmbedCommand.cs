using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using SharperBot.Services.Discord.Embed;

namespace SharperBot.Commands.Modules.Misc
{
    public class EmbedCommand : ModuleBase<SocketCommandContext>
    {
        [Command("embed", RunMode = RunMode.Async)]
        [Summary("Puts text into a embed!")]
        [Alias("em")]
        public Task EmbedAsync(
            [Summary("The Title of the embed!")] string title,[Remainder] [Summary("The Text To be put in the embed!")] string text) 
            =>
            ReplyAsync(embed: new EmbedBuilder()
            {
                Title = title,
                Description = text,
                Color = new ColorUtils().ColorRand(),
                Footer = new EmbedFooterBuilder() {Text = " Written By " + Context.User.Username, IconUrl = Context.User.GetAvatarUrl()}
            }.Build());
    }
}