using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BattleRoyaleSolutions.Client
{
    class Program
    {
        static HubConnection connection;

        static void Main(string[] args)
        {
            connection = new HubConnectionBuilder()
            .WithUrl("https://localhost:44302/hub")
            .Build();

            ConnectToServer();
            string message = "Hello world!";
            SendMessage(message);

            while (true)
            {
                Console.WriteLine(Console.ReadLine());
            }
        }

        private static async void ConnectToServer()
        {
            //TODO: Create process to execute commands from web
            connection.On<string>("ReceiveMessage",  (message) =>
            {
                var newMessage = $"{message}";
                Console.WriteLine(newMessage);
            });

            try
            {
                await connection.StartAsync();
                Console.WriteLine("Connection started");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static async void SendMessage(string message)
        {
            try
            {
                //TODO: Create machine instance to send for WebApplication
                await connection.InvokeAsync("SendMessage", message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
