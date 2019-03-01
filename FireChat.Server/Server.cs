using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FireChat.Library;

namespace FireChat.Server
{
    public struct Holder
    {
        public Socket wSocket;
        public byte[] buffer;
    }

    public class Server
    {
        private Socket listener;

        private Thread receiver;

        private static ManualResetEvent receiveDone = new ManualResetEvent(false);

        public EventHandler<string> OnCommand;

        public Server(EndPoint ep)
        {
            Clients = new List<Socket>();
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(ep);
            receiver = new Thread(ReceiveLoop);
            receiver.Start();
        }

        ~Server()
        {
            foreach (Socket client in Clients)
            {
                client.Close();
                client.Dispose();
            }

            Clients = null;

            listener.Close();
            listener.Dispose();

            listener = null;
        }

        public virtual void Listen()
        {

            listener.Listen(10);

            while (true)
            {
                Clients.Add(listener.Accept());
            }
        }

        private void ReceiveLoop()
        {
            while (true)
            {
                for(int i = 0; i < Clients.Count; i++)
                {
                    byte[] buffer = new byte[256];

                    int bytesRead = Clients[i].Receive(buffer, 0, 256, SocketFlags.None);

                    if (bytesRead > 0)
                    {
                        if (!String.IsNullOrWhiteSpace(Encoding.ASCII.GetString(buffer)))
                        {
                            string data = Encoding.ASCII.GetString(buffer);

                            Console.WriteLine("Data Received: " + data);



                            if (data.StartsWith("/"))
                            {
                                OnCommand?.Invoke(Clients[i], data);
                            }

                        }
                    }

                }
            }
        }

        public List<Socket> Clients { get; private set; }
    }
}
