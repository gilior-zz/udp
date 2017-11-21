using ConsoleApplication1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApi.Template3.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            //create a new client
            var client = UdpUser.ConnectTo("127.0.0.1", 55002);

            //wait for reply messages from server and send them to console 
            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    try
                    {
                        var received = await client.Receive();
                        Console.WriteLine(received.Message);
                        if (received.Message.Contains("quit"))
                            break;
                    }
                    catch (Exception ex)
                    {
                        Debug.Write(ex);
                    }
                }
            });

            //type ahead :-)
            string read;
            do
            {
                read = Console.ReadLine();
                client.Send(read);
            } while (read != "quit");

            return Ok(new List<int>() { 1, 2, 3 });
        }
    }
}
