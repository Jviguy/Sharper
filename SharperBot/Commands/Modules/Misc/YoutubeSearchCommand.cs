using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;

namespace SharperBot.Commands.Modules.Misc
{
    public class YoutubeSearchCommand : ModuleBase<SocketCommandContext>
    {
        [Command("yt", RunMode = RunMode.Async)]
        public async Task YtSearchAsync([Remainder] string query)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = Program.GoogleToken,
                ApplicationName = "Sharper Bot"
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = query; // Replace with your search term.
            searchListRequest.MaxResults = 10;

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = await searchListRequest.ExecuteAsync();

            List<string> videos = new List<string>();
            List<string> channels = new List<string>();
            List<string> playlists = new List<string>();

            // Add each result to the appropriate list, and then display the lists of
            // matching videos, channels, and playlists.
            foreach (var searchResult in searchListResponse.Items)
            {
                switch (searchResult.Id.Kind)
                {
                    case "youtube#video":
                        videos.Add($"{searchResult.Snippet.Title} by {searchResult.Snippet.ChannelTitle} - [Click Here To Watch Now!](https://www.youtube.com/watch?v={searchResult.Id.VideoId})");
                        break;
                }
            }
            var des = new StringBuilder();
            foreach (var text in videos)
            {
                des.Append(text + "\n");
            }
            await ReplyAsync(embed: new EmbedBuilder()
            {
                Title = "Search Results from Youtube!",
                Description = des.ToString(),
                ImageUrl = searchListResponse.Items[0].Snippet.Thumbnails.High.Url,
                Footer = new EmbedFooterBuilder()
                {
                    Text = " - A Youtube Search by " + Context.User.Username + " Done in 0." + stopwatch.ElapsedMilliseconds + "s!",
                    IconUrl = Context.User.GetAvatarUrl()
                }
            }.Build());
            stopwatch.Stop();
        }
    }
}