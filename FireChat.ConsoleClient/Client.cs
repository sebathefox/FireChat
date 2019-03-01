using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FireChat.ConsoleClient.Command;
using FireChat.Library;

namespace FireChat.ConsoleClient
{
    internal class Client
    {
        private Socket client;

        private List<ICommand> commands;

        public Client(int port)
        {
            commands = new List<ICommand>();

            try
            {
                

                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        ~Client()
        {
            client.Close();
            client.Dispose();
            client = null;
        }

        public void Init()
        {
            while (true)
            {
                Console.Write("INPUT: ");
                string dat = Console.ReadLine();

                foreach (ICommand command in commands)
                {
                    if (command.CommandName.Equals(dat))
                    {
                        command.Run(client);
                        break;
                    }
                }

                if (dat.Equals("/exit"))
                {
                    


                }

                byte[] data = Encoding.ASCII.GetBytes(dat);

                client.Send(data);

            }
        }

        public void StartReceiver()
        {

        }

        public bool Send(byte[] data)
        {
            return client.Send(data) > 0;
        }
    }
}
