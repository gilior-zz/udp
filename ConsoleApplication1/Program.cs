using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //create a new server
            var server = new UdpListener();

            //start listening for messages and copy the messages back to the client
            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    var received = await server.Receive();
                    server.Reply("copy " + received.Message, received.Sender);
                    if (received.Message == "quit")
                        break;
                }
            });
        }
    }
}
