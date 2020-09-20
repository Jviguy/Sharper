using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace SharperBot.Commands.Modules.Misc
{
    public class FakeSniper : ModuleBase<SocketCommandContext>
    {
        [Command("snipe", RunMode = RunMode.Async)]
        public async Task FakeSniperAsyc(string id, [Remainder] string msg)
        {
            SocketGuildUser user;
            try
            {
                var b = MentionUtils.ParseUser(id);
                user = Context.Guild.GetUser(b);
            }
            catch (Exception)
            { 
                user = Context.Guild.GetUser(Convert.ToUInt64(id));
            }
            await ReplyAsync(embed: new EmbedBuilder()
            {
                Author = new EmbedAuthorBuilder()
                {
                    Name = user.Username,
                    IconUrl = user.GetAvatarUrl()
                },
                Description = msg,
                Footer = new EmbedFooterBuilder()
                {
                    Text = "1/10 • Today at " + DateTime.Now.Hour + ":"+DateTime.Now.Minute + "!"
                }
            }.Build());
        }
    }
}