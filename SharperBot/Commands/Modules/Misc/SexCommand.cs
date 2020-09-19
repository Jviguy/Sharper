using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using SharperBot.Services.Discord.Embed;

namespace SharperBot.Commands.Modules.Misc
{
    public class SexCommand : ModuleBase<SocketCommandContext>
    {
        private readonly Random rnd = new Random();
        private readonly SexUtils SexUtils = new SexUtils();
        [Command("sex", RunMode = RunMode.Async)]
        public async Task SexAsync(string fucker, string victom)
        {
            var fuckerid = MentionUtils.ParseUser(fucker);
            var victomid = MentionUtils.ParseUser(victom);
            var v = Context.Guild.GetUser(victomid);
            var f = Context.Guild.GetUser(fuckerid);
            var sexscore = rnd.Next(100);
            if (sexscore == 0)
            {
                await ReplyAsync(
                    embed: new EmbedBuilder()
                    {
                        Title = f.Username + " Absolutley Wanged the bang and " + v.Username +
                                " Ran as he tried to get her back!",
                        ImageUrl = SexUtils.FetchRandom(),
                        Footer = new EmbedFooterBuilder()
                        {
                            Text = "Sex Score of " +sexscore + " out of 100 || " + sexscore + "/100!",
                            IconUrl = f.GetAvatarUrl()
                        }
                    }.Build()
                );
                return;
            }
            if (sexscore == 100)
            {
                await ReplyAsync(
                    embed: new EmbedBuilder()
                    {
                        Title = f.Username+ " Fucking laid a whole train of pipe on " + v.Username + " For " + sexscore +
                                " Hours!",
                        ImageUrl = SexUtils.FetchRandom(),
                        Footer = new EmbedFooterBuilder()
                        {
                            Text = "Sex Score of " +sexscore + " out of 100 || " + sexscore + "/100!",
                            IconUrl = f.GetAvatarUrl()
                        }
                    }.Build()
                );
                return;
            }
            if (sexscore < 50)
            {
                await ReplyAsync(
                    embed: new EmbedBuilder()
                    {
                        Title = f.Username + " Laid a small salamander on " + v.Username + "!",
                        ImageUrl = SexUtils.FetchRandom(),
                        Footer = new EmbedFooterBuilder()
                        {
                            Text = "Sex Score of " +sexscore + " out of 100 || " + sexscore + "/100!",
                            IconUrl = f.GetAvatarUrl()
                        }
                    }.Build()
                );
                return;
            }
            if (sexscore == 50)
            {
                await ReplyAsync(
                    embed: new EmbedBuilder()
                    {
                        Title = f.Username + " Hit the perfect Middle with his little wiener on " + v.Username + " For " +
                                sexscore + " Minutes!",
                        ImageUrl = SexUtils.FetchRandom(),
                        Footer = new EmbedFooterBuilder()
                        {
                            Text = "Sex Score of " +sexscore + " out of 100 || " + sexscore + "/100!",
                            IconUrl = f.GetAvatarUrl()
                        }
                    }.Build()
                );
                return;
            }
            await ReplyAsync(
                embed: new EmbedBuilder()
                {
                    Title = f.Username + " almost hit a home run on " + v.Username + "!",
                    ImageUrl = SexUtils.FetchRandom(),
                    Footer = new EmbedFooterBuilder()
                    {
                        Text = "Sex Score of " +sexscore + " out of 100 || " + sexscore + "/100!",
                        IconUrl = f.GetAvatarUrl()
                    }
                }.Build()
            );
        }
    }
}