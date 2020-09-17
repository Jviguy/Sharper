using System;
using System.Reflection.Metadata.Ecma335;
using Discord;

namespace SharperBot.Services.Discord.Embed
{
    public class ColorUtils
    {
        private Random rnd = new Random();

        public Color ColorRand()
        {
            var number = rnd.Next(10);
            switch (number)
            {
                case 0:
                    return Color.Blue;
                case 1:
                    return Color.DarkBlue;
                case 2:
                    return Color.Red;
                case 3:
                    return Color.DarkRed;
                case 4:
                    return Color.LightOrange;
                case 5:
                    return Color.Purple;
                case 6:
                    return Color.DarkMagenta;
                case 7:
                    return Color.Gold;
                case 8:
                    return Color.LightOrange;
                case 9:
                    return Color.Teal;
                case 10:
                    return Color.Orange;
            }
            return Color.Default;
        }
    }
}