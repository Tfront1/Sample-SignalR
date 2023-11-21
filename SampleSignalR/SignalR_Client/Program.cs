using Microsoft.AspNetCore.SignalR.Client;
using SignalR_Common;

namespace SignalR_Client
{
    internal class Program
    {
        static HubConnection hubConnection;
        static async Task Main(string[] args)
        {
            await InitSignalRConnection();

            bool isExit = false;
            while (!isExit)
            {
                Console.WriteLine("Enter message or exit or setname.");
                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input)) {
                    continue;
                }

                if (input == "exit")
                {
                    isExit = true;
                }
                else if (input == "setname") 
                {
                    Console.WriteLine("Enter user name:");
                    var userName = Console.ReadLine();
                    if(string.IsNullOrWhiteSpace(userName))
                    {
                        continue;
                    }

                    await hubConnection.SendAsync("SetName", userName);
                }
                else
                {
                    var message = new Message()
                    {
                        Title = "Simple message",
                        Body = input
                    };

                    await hubConnection.SendAsync("SenaMessage", message);
                }
            }
        }
        private static Task InitSignalRConnection() {
            hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7271/notification")
                .Build();

            hubConnection.On<Message>("Send", message =>
            {
                Console.WriteLine(message.Title+"\n"+message.Body);
            });

            return hubConnection.StartAsync();
        }
    }
}