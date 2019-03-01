using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FireChat.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server(new IPEndPoint(IPAddress.Loopback, 1234));

            server.OnCommand += CommandReceived;

            server.Listen();
        }

        private static void CommandReceived(object sender, string command)
        {
            string[] cmd = command.Split(' ');



            Console.WriteLine("Command Received: " + cmd[0]);

            for (int i = 1; i < cmd.Length; i++)
            {
                Console.WriteLine("Command Argument no {0} = {1}", i, cmd[i]);
            }

            switch (cmd[0])
            {
                case "/echo":
                    for (int i = 1; i < cmd.Length; i++)
                    {
                        Console.Write(cmd[i] + " ");
                    }
                    break;
            }
        }
    }
}
