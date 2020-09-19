using System;
using System.Collections.Generic;

namespace SharperBot.Services.Discord.Embed
{
    public class SexUtils
    {
        private List<string> Links = new List<string>();
        private Random rnd = new Random();

        public SexUtils()
        {
            Links.Add("https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/4c5d65fe-b704-4839-9e2d-6fa70414cb98/dsstdp-9fb70e6f-063c-45e0-88ce-e19212581267.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOiIsImlzcyI6InVybjphcHA6Iiwib2JqIjpbW3sicGF0aCI6IlwvZlwvNGM1ZDY1ZmUtYjcwNC00ODM5LTllMmQtNmZhNzA0MTRjYjk4XC9kc3N0ZHAtOWZiNzBlNmYtMDYzYy00NWUwLTg4Y2UtZTE5MjEyNTgxMjY3LmpwZyJ9XV0sImF1ZCI6WyJ1cm46c2VydmljZTpmaWxlLmRvd25sb2FkIl19.yVhso8NlUp1Uj3NLv4pGIh20sAF5nJmiwQU3w9N6528");
            Links.Add("https://cdn.neow.in/forum/uploads/post-48-1094283748.gif");
            Links.Add("https://en.pimg.jp/057/586/815/1/57586815.jpg");
            Links.Add("https://image.spreadshirtmedia.com/image-server/v1/compositions/T812A2PA3140PT17X73Y68D12420812FS22170Cx9DC8D9%3AxFFA1B7/views/1,width=650,height=650,appearanceId=2/acrobatic-sex-position-illustrated-by-two-stickmen-figures-kamasutra.jpg");
            Links.Add("https://media1.tenor.com/images/5211495e4bb4a9c3bbac04c1469aadde/tenor.gif?itemid=15595356");
            Links.Add("https://i.ytimg.com/vi/xD-d9akZQ0w/hqdefault.jpg");
            Links.Add("https://i3.cpcache.com/merchandise/137_300x300_Front_Color-NA.jpg?Size=NA&AttributeValue=NA&c=True&OrientationNo=1&region={%22name%22:%22FrontCenter%22,%22width%22:2.5,%22height%22:2.5,%22alignment%22:%22MiddleCenter%22,%22orientation%22:1,%22dpi%22:200,%22crop_x%22:0,%22crop_y%22:0,%22crop_h%22:400,%22crop_w%22:400,%22scale%22:0,%22template%22:{%22id%22:13580622,%22params%22:{}}}%20&Filters=[{%22name%22:%22background%22,%22value%22:%22ddddde%22,%22sequence%22:2}]");
            Links.Add("https://pics.me.me/thumb_ahh-artoonix-unregistered-stickman-sex-youtube-51089103.png");
            Links.Add("https://cdn.discordapp.com/attachments/674077546089807897/756734488658182204/bentover01_stickfigure.png");
        }
        public string FetchRandom()
        {
            var i = rnd.Next(minValue: 0,maxValue: Links.Count);
            return Fetch(i);
        }
        public string Fetch(int gif)
        {
            return Links[gif];
        }
    }
}