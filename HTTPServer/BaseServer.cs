using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HTTPServer
{
    public abstract class BaseServer
    {
        private readonly HttpListener listener;

        protected BaseServer(string[] prefixes)
        {
            listener = new HttpListener();
            foreach (var prefix in prefixes)
            {
                listener.Prefixes.Add(prefix);
            }
        }

        public void Start()
        {
            listener.Start();
            Console.WriteLine("Server started. Listening for requests...");

            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                ProcessRequest(context);
            }
        }

        protected abstract void ProcessRequest(HttpListenerContext context);
    }
}
