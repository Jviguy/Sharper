using System;
using System.Threading.Tasks;
using System.Timers;
using Discord;
using Discord.Commands;

namespace SharperBot.Commands.Modules.Misc
{
    [RequireUserPermission(GuildPermission.Administrator)]
    public class MessageRepeater : ModuleBase<SocketCommandContext>
    {
        [Command("msgrepeat", RunMode = RunMode.Async)]
        public async Task MsgRepeatAsync(int day, int hour, int minutes, int seconds, [Remainder] string message)
        {
            var tm = new Timer();
            tm.Elapsed += async (source,e) =>
            {
                await ReplyAsync(message);
            };
            tm.Interval = new TimeSpan(day,hour,minutes,seconds).TotalMilliseconds;
            tm.Start();
        }
    }
}