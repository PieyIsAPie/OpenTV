using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HTTPServer
{
    public class UIServer : BaseServer
    {
        public UIServer(string[] prefixes) : base(prefixes)
        {
        }

        private string getFileContents(string path)
        {
            string crPath = AppDomain.CurrentDomain.BaseDirectory + "/" + path;
            return File.ReadAllText(crPath);
        }

        protected override void ProcessRequest(HttpListenerContext context)
        {
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            byte[] buffer = Encoding.UTF8.GetBytes(getFileContents("ui" + request.Url.AbsolutePath));

            response.StatusCode = (int)HttpStatusCode.NotFound;
            response.ContentLength64 = buffer.Length;
            response.OutputStream.Write(buffer, 0, buffer.Length);
            response.OutputStream.Close();
        }
    }
}
