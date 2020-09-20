using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace SharperBot.Commands.Modules.Misc
{
    public class InviteCommand : ModuleBase<SocketCommandContext>
    {
        [Command("invite", RunMode = RunMode.Async)]
        public async Task InviteAsync()
        {
            await ReplyAsync(embed: new EmbedBuilder()
            {
                Title = "Thanks For The Support!",
                ThumbnailUrl = "https://avatars0.githubusercontent.com/u/62412449?s=60&v=4"
            }
                .AddField("Invite Link: ","[Invite Link!](https://discord.com/oauth2/authorize?client_id=754357472315310130&scope=bot&permissions=8)")
                .AddField("Github Link: ", "[Github Link](https://github.com/Jviguy/Sharper)")
                .Build());
        }
    }
}