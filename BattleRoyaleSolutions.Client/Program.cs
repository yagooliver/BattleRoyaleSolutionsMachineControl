using System;
using Microsoft.AspNetCore.SignalR.Client;

namespace BattleRoyaleSolutions.Client
{
    class Program
    {
        static HubConnection connection;

        static void Main(string[] args)
        {
            connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:54647/hub")
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
            connection.On<string>("ReceiveMessage",  (message) =>
            {
                var newMessage = $"{message}";
                Console.WriteLine(newMessage);
            });
            ExecuteCommand();
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

        private static void ExecuteCommand()
        {
            //TODO: Create process to execute commands from web
            connection.On<string>("SendCommand", (command) =>
            {
                var result = PowerShellExecutor.PowerShellExecutor.ExecuteCommand(command);
                Console.WriteLine(command);
            });
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
