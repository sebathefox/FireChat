using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FireChat.Library
{
    public interface ICommand
    {
        void Run(Socket sock);

        string CommandName { get; }
    }
}
