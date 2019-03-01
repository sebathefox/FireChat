using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using FireChat.Library;

namespace FireChat.ConsoleClient.Command
{
    class ExitCommand : ICommand
    {
        public virtual void Run(Socket sock)
        {
            sock.Close();
            sock.Dispose();
        }

        public string CommandName { get; }
    }
}
