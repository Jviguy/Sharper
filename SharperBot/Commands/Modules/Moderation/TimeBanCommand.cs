using System.Threading.Tasks;
using Discord.Commands;

namespace SharperBot.Commands.Modules.Moderation
{
    public class TimeBanCommand : ModuleBase<SocketCommandContext>
    {
        [Command("timeban", RunMode = RunMode.Async)]
        public async Task TimeBanAsync()
        {
            
        }
    }
}