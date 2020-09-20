using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace SharperBot.Commands.Modules.Misc
{
    public class AvatarCommand : ModuleBase<SocketCommandContext>
    {
        [Command("av", RunMode = RunMode.Async)]
        public async Task AvatarAsyc(string id)
        {
            SocketGuildUser user;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
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
                Title = user.Username + "'s Avatar!",
                ImageUrl = user.GetAvatarUrl(),
                Footer = new EmbedFooterBuilder()
                {
                    Text = $" - Requested by {Context.User.Username} - Done in 0.{stopwatch.ElapsedMilliseconds}s!"
                }
            }.Build());
            stopwatch.Stop();
        }
    }
}