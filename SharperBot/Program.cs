using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using SharperBot.Commands;
using SharperBot.Services.Games;

namespace SharperBot
{
    class Program
    {
        private GameManager GameManager;
        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();
        private async Task MainAsync() 
        {
            var client = new DiscordSocketClient();
            GameManager = new GameManager(client);
            GameManager.Load();
            client.Log += Log;

            // Remember to keep token private or to read it from an 
            // external source! In this case, we are reading the token 
            // from an environment variable. If you do not know how to set-up
            // environment variables, you may find more information on the 
            // Internet or by using other methods such as reading from 
            // a configuration.
            await client.LoginAsync(TokenType.Bot, 
                "TOKENNNNNNN LEAVE IT");
            await client.StartAsync();
            //init the commands
            var commands = new CommandHandler(client, new CommandService(),InstallServices());
            await commands.InstallCommandsAsync();
            // Block this task until the program is closed.
            await Task.Delay(-1);
        }
        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
        private IServiceProvider InstallServices()
        {
            ServiceCollection services = new ServiceCollection();
            // Add all additional services here
            // Return the service provider.
            return services.BuildServiceProvider();
        }
    }
}
