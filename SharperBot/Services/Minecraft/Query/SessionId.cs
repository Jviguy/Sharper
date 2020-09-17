namespace SharperBot.Services.Minecraft.Query
{
    public static class SessionId
    {
        private static int last;
        public static int GenerateSessionId()
        {
            return last++;
        }
    }
}