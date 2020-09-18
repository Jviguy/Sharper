using System;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace SharperBot.Commands.Modules.Moderation
{
    public class KickCommand : ModuleBase<SocketCommandContext>
    {
        [Command("kick", RunMode = RunMode.Async)]
        [RequireUserPermission(permission: GuildPermission.KickMembers,
            ErrorMessage = "Error You Do not have Permission To Use This!")]
        public async Task KickAsync(string user,[Remainder]string reason)
        {
            var id = MentionUtils.ParseUser(user);
            var ban = Context.Guild.GetUser(id);
            await Context.Message.AddReactionAsync(new Emoji("✅"));
            await Task.Run(async () => //Task.Run automatically unwraps nested Task types!
            {
                await Task.Delay(2000);
                var w = await ReplyAsync(embed: new EmbedBuilder()
                {
                    Title = "Processing!",
                    ImageUrl = "https://media4.giphy.com/media/2WjpfxAI5MvC9Nl8U7/giphy.gif"
                }.Build());
                await Task.Delay(3000);
                await w.DeleteAsync();
                try
                {
                    await ban.KickAsync(reason);
                    await ReplyAsync(embed: new EmbedBuilder()
                    {
                        Title = "Success!",
                        Description = "Kicked User: " + ban.Username + " because " + reason + "!",
                        ImageUrl = "https://thumbs.gfycat.com/QuaintLikelyFlyingfish-size_restricted.gif"
                    }.Build());
                }
                catch (Exception e)
                {
                    await ReplyAsync(embed: new EmbedBuilder()
                    {
                        Title = "ERROR!",
                        Description = e.Message,
                        ImageUrl = "https://media.tenor.com/images/21aa6ef4312e1abcd50ffca5e1d4dd75/tenor.gif"
                    }.Build());
                }
            });
        }
    }
}