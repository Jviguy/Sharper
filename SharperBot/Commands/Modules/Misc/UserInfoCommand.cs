using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using SharperBot.Services.Discord.Embed;

namespace SharperBot.Commands.Modules.Misc
{
    public class UserInfoCommand : ModuleBase<SocketCommandContext>
    {
        private ColorUtils _colorUtils = new ColorUtils();
        [Command("usrinfo", RunMode = RunMode.Async)]
        public async Task UserInfoAsync(string id = null)
        {
            try
            {
                SocketGuildUser user;
                var stpwatch = new Stopwatch();
                stpwatch.Start();
                if (id == null)
                {
                    user = Context.Guild.GetUser(Context.User.Id);
                }
                else
                {
                    try
                    {
                        var b = MentionUtils.ParseUser(id);
                        user = Context.Guild.GetUser(b);
                    }
                    catch (Exception)
                    {
                        user = Context.Guild.GetUser(Convert.ToUInt64(id));
                    }
                }
                var joinspan = DateTime.Now.Subtract(user.JoinedAt.HasValue ? user.JoinedAt.Value.Date: DateTime.Now);
                var premiumspan = DateTime.Now.Subtract(user.PremiumSince.HasValue ? user.PremiumSince.Value.Date: DateTime.Now);
                var discordjoinspan = DateTime.Now.Subtract(user.CreatedAt.DateTime.Date);
                await ReplyAsync(embed: new EmbedBuilder()
                {
                    Title = "User Info On " + user.Username,
                    Color = _colorUtils.ColorRand(),
                    ThumbnailUrl = user.GetAvatarUrl(),
                    Footer = new EmbedFooterBuilder()
                    {
                        Text = $" - Requested By {Context.User.Username} - Done in 0.{stpwatch.ElapsedMilliseconds}s",
                        IconUrl = Context.User.GetAvatarUrl()
                    },
                    Timestamp = DateTimeOffset.Now
                }
                    .AddField("Username: ",user.Username)
                    .AddField("Nickname: ",user.Nickname ?? "None")
                    .AddField("Bot? ", user.IsBot ?":green_circle:":":red_circle:")
                    .AddField("WebHook? ",user.IsWebhook?":green_circle:":":red_circle:")
                    .AddField("Deafened? ",user.IsDeafened?":green_circle:":":red_circle:")
                    .AddField("Muted? ", user.IsMuted?":green_circle:":":red_circle:")
                    .AddField("Premium? ",user.PremiumSince.HasValue? user.Username + " Has been Premium since " + user.PremiumSince.Value + $" - ({premiumspan.Days} days ago!)":user.Username + " Is Not Premium!")
                    .AddField("Permissions Count: ",user.Username+ " Has "+user.GuildPermissions.ToList().Count+ " Permissions!")
                    .AddField("Roles Count: ", user.Username+ " Has "+user.Roles.Count+" Roles!")
                    .AddField("Hierarchy Level: ",user.Hierarchy == 2147483647 ? user.Hierarchy + " Owner/Highest Role!": user.Hierarchy.ToString())
                    .AddField("Status: ",user.Status.ToString() == "Online" ?":green_circle:":":red_circle:")
                    .AddField("Joined This Server at: ",user.JoinedAt.HasValue ? user.JoinedAt.Value.Date + $" - ({joinspan.Days} days ago!)" : "Date Not Found")
                    .AddField("Joined Discord on: ",user.CreatedAt.DateTime.Date + $" - ({discordjoinspan.Days} days ago!)")
                    .AddField("Roles: ",string.Join(", ",user.Roles))
                    .AddField("Permissions: ", string.Join(", ", user.GuildPermissions.ToList()))
                    .Build());
                stpwatch.Stop();
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