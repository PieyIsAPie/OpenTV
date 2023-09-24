using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using HTTPServer;

namespace uihandler
{
    public partial class Main : Form
    {
        private string[] prefixes = new string[] { "http://localhost:8080/", "http://127.0.0.1:8080/" };
        public ChromiumWebBrowser chromeBrowser;

        public void InitializeChromium()
        {
            //start server
            UIServer server = new UIServer(prefixes);
            Thread thread1 = new Thread(server.Start);
            thread1.Start();
            //load cef settings
            CefSettings settings = new CefSettings();
            // Initialize cef with the provided settings
            Cef.Initialize(settings);
            // Create a browser component
            chromeBrowser = new ChromiumWebBrowser("http://localhost:8080/ui.html");
            // Add it to the form and fill it to the form window.
            this.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
            CefSharpSettings.WcfEnabled = true;
            chromeBrowser.JavascriptObjectRepository.Settings.LegacyBindingEnabled = true;
            chromeBrowser.JavascriptObjectRepository.Register("OpenTVBoundObjects", new JSObject(chromeBrowser, this), isAsync: false, options: BindingOptions.DefaultBinder);
            this.FormClosing += Main_FormClosing;
        }
        public Main()
        {
            InitializeComponent();
            // Start the browser after initialize global component
            InitializeChromium();
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.Bounds = Screen.PrimaryScreen.Bounds;
        }
    }
}
