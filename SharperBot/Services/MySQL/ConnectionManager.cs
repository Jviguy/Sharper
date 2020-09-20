using System;
using System.Data;
using System.Threading.Tasks;
using HtmlAgilityPack;
using MySql.Data.MySqlClient;

namespace SharperBot.Services.MySQL
{
    public class ConnectionManager
    {
        private readonly string LoginDetails;
        private readonly MySqlConnection Connection;

        public ConnectionManager(string loginDetails)
        {
            LoginDetails = loginDetails;
            Connection = new MySqlConnection(LoginDetails);
        }

        public Task StartAsync()
        {
            if (Connection.State == 0)
            {
                Connection.Close();
            }
            return Connection.OpenAsync();
        }

        public void Start()
        {
            if (Connection.State == 0)
            {
                return;
            }
            Connection.Open();
            Console.WriteLine("Started Mysql Connection!");
        }
        
    }
}