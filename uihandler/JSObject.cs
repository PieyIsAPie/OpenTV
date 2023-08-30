using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace uihandler
{
    class JSObject
    {
        // Declare a local instance of chromium and the main form in order to execute things from here in the main thread
        private static ChromiumWebBrowser _instanceBrowser = null;
        // The form class needs to be changed according to yours
        private static Main _instanceMainForm = null;


        public JSObject(ChromiumWebBrowser originalBrowser, Main mainForm)
        {
            _instanceBrowser = originalBrowser;
            _instanceMainForm = mainForm;
        }

        public void showDevTools()
        {
            _instanceBrowser.ShowDevTools();
        }

        public void quitApp()
        {
            if (_instanceMainForm.InvokeRequired)
            {
                // If we're not on the UI thread, invoke this method on the UI thread
                _instanceMainForm.Invoke(new Action(quitApp));
                return;
            }

            _instanceMainForm.Close();
        }
    }
}

