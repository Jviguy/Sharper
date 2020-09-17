using System.Net;
using System.Net.Sockets;

namespace SharperBot.Services.Minecraft.Query
{
    public class UdpState
    {
        public UdpClient Client;
        public IPEndPoint IpEndPoint;

        public UdpState()
        {
            
        }
    }
}