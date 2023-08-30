using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTTPServer;

namespace TestHTTPServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UIServer server = new UIServer(args);
            server.Start();
        }
    }
}
