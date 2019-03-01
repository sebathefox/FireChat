using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FireChat.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = null;

            int port = 1234;

            if (args.Length > 0)
            {
                if (args[0].ToUpper().Contains("PORT="))
                {
                    Console.WriteLine(Int32.TryParse(args[0].Substring(args[0].IndexOf("=") + 1), out port));

                    client = new Client(port);
                }
            }
            else
            {
                client = new Client(port);
            }

            Console.WriteLine("___________.__               _________ .__            __   \r\n\\_   _____/|__|______   ____ \\_   ___ \\|  |__ _____ _/  |_ \r\n |    __)  |  \\_  __ \\_/ __ \\/    \\  \\/|  |  \\\\__  \\\\   __\\\r\n |     \\   |  ||  | \\/\\  ___/\\     \\___|   Y  \\/ __ \\|  |  \r\n \\___  /   |__||__|    \\___  >\\______  /___|  (____  /__|  \r\n     \\/                    \\/        \\/     \\/     \\/      ");
            Console.WriteLine();
            Console.WriteLine("Made by SD Development");
            Console.WriteLine("-----------------------------------------------------------");

            client.StartReceiver();



            Console.WriteLine("\\__    ___/|  |__ _____    ____ |  | __  ______\r\n  |    |   |  |  \\\\__  \\  /    \\|  |/ / /  ___/\r\n  |    |   |   Y  \\/ __ \\|   |  \\    <  \\___ \\ \r\n  |____|   |___|  (____  /___|  /__|_ \\/____  >\r\n                \\/     \\/     \\/     \\/     \\/ ");
            Console.WriteLine("   _____             \r\n_/ ____\\___________ \r\n\\   __\\/  _ \\_  __ \\\r\n |  | (  <_> )  | \\/\r\n |__|  \\____/|__|   ");
            Console.WriteLine("              .__                \r\n __ __  _____|__| ____    ____  \r\n|  |  \\/  ___/  |/    \\  / ___\\ \r\n|  |  /\\___ \\|  |   |  \\/ /_/  >\r\n|____//____  >__|___|  /\\___  / \r\n           \\/        \\//_____/  ");
            Thread.Sleep(1000);
            Environment.Exit(0);

            Console.ReadLine();
        }
    }
}
