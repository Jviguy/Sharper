using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace SharperBot.Commands.Modules.Misc
{
    public class SexCommand : ModuleBase<SocketCommandContext>
    {
        private Random rnd = new Random();

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
                        Title = f.Mention + " Absolutley Wanged the bang and " + v.Mention +
                                " Ran as he tried to get her back!",
                        Footer = new EmbedFooterBuilder()
                        {
                            Text = "Sex Score of " +sexscore + "out of 100 || " + sexscore + "/100!",
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
                        Title = f.Mention + " Fucking laid a whole train of pipe on " + v.Mention + " For " + sexscore +
                                " Hours!",
                        Footer = new EmbedFooterBuilder()
                        {
                            Text = "Sex Score of " +sexscore + "out of 100 || " + sexscore + "/100!",
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
                        Title = f.Mention + " Laid a small salamander on " + v.Mention + "!",
                        Footer = new EmbedFooterBuilder()
                        {
                            Text = "Sex Score of " +sexscore + "out of 100 || " + sexscore + "/100!",
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
                        Title = f.Mention + " Hit the perfect Middle with his little wiener on " + v.Mention + " For " +
                                sexscore + " Minutes!",
                        Footer = new EmbedFooterBuilder()
                        {
                            Text = "Sex Score of " +sexscore + "out of 100 || " + sexscore + "/100!",
                            IconUrl = f.GetAvatarUrl()
                        }
                    }.Build()
                );
                return;
            }
            await ReplyAsync(
                embed: new EmbedBuilder()
                {
                    Title = f.Mention + " almost hit a home run on " + v.Mention + "!",
                    Footer = new EmbedFooterBuilder()
                    {
                        Text = "Sex Score of " +sexscore + "out of 100 || " + sexscore + "/100!",
                        IconUrl = f.GetAvatarUrl()
                    }
                }.Build()
            );
        }
    }
}