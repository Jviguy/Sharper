using System;
using System.Collections.Generic;

namespace SharperBot.Services.Discord.Embed
{
    public class LoadingUtils
    {
        private List<string> Links = new List<string>();
        private Random rnd = new Random();

        public LoadingUtils()
        {
            Links.Add("https://media4.giphy.com/media/2WjpfxAI5MvC9Nl8U7/giphy.gif");
            Links.Add("https://media4.giphy.com/media/l0GRk3KHYv2W6hmJG/giphy.gif");
            Links.Add("https://cdna.artstation.com/p/assets/images/images/016/928/246/original/cloe-ferrara-loader1-0.gif?1554021979");
            Links.Add("https://miro.medium.com/max/1600/1*CsJ05WEGfunYMLGfsT2sXA.gif");
            Links.Add("https://media1.giphy.com/media/xTk9ZvMnbIiIew7IpW/source.gif");
            Links.Add("https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/b6e0b072897469.5bf6e79950d23.gif");
            Links.Add("https://sezeromer.com/wp-content/uploads/2019/09/Infinity-1s-200px.gif");
            Links.Add("https://static.dribbble.com/users/1186261/screenshots/3718681/_______.gif");
            Links.Add("https://codemyui.com/wp-content/uploads/2017/09/rotate-pulsating-loading-animation.gif");
            Links.Add("https://media1.tenor.com/images/8488ee981be1f3f7821a32485d63c0c9/tenor.gif?itemid=16187521");
            Links.Add("https://wpamelia.com/wp-content/uploads/2018/11/ezgif-2-5468d589f84e.gif");
            Links.Add("https://motiongraphicsphoebe.files.wordpress.com/2018/10/943d662b-25c9-42d6-9fd2-cc36d2ffab76.gif");
            Links.Add("https://24.media.tumblr.com/f678ce38eb896bc1d4aaa911958af087/tumblr_n2eccv6Dev1rgpzseo1_1280.gif");
            Links.Add("https://i.imgur.com/NbiwZLB.gif");
        }

        public string FetchRandomGIF()
        {
            var i = rnd.Next(minValue: 0,maxValue: Links.Count);
            return FetchGif(i);
        }
        public string FetchGif(int gif)
        {
            return Links[gif];
        }
    }
}