using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace SharperBot.Commands.Modules.Misc
{
    public class UserInfoCommand : ModuleBase<SocketCommandContext>
    {
        [Command("usrinfo", RunMode = RunMode.Async)]
        public async Task UserInfoAsync(string id)
        {
            try
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
                    Title = "User Info On " + user.Username,
                }
                    .AddField("Username: ",user.Username)
                    .AddField("Nickname: ",user.Nickname ?? "None")
                    .AddField("Joined This Server at: ",user.JoinedAt.HasValue ? user.JoinedAt.Value.Date.ToString() : "Date Not Found")
                    .AddField("Joined Discord on: ",user.CreatedAt.DateTime.Date.ToString())
                    .Build());
            }
            catch (Exception e)
            {
                await ReplyAsync(embed: new EmbedBuilder()
                {
                    Title = "ERROR!",
                    Description = e.Message 
                }.Build());
            }
        }
    }
}