using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace SharperBot.Commands.Modules.Moderation
{
    public class TimeBanCommand : ModuleBase<SocketCommandContext>
    {
        [Command("timeban", RunMode = RunMode.Async)]
        public async Task TimeBanAsync(string user,int day,int hour,int minutes,int seconds)
        {
            var id = MentionUtils.ParseUser(user);
            var ban = Context.Guild.GetUser(id);
            await Context.Message.AddReactionAsync(new Emoji("✅"));
            var ts = new TimeSpan(day,hour,minutes,seconds);
            await Task.Run(async () =>
            {
                try
                {
                    await Task.Delay((int) ts.TotalMilliseconds);
                }
                catch (Exception e)
                {
                    await ReplyAsync(e.Message);
                }
                await ReplyAsync("DONE");
            });
        }
    }
}