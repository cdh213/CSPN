using CefSharp;
using System.Windows.Forms;

namespace CSPN.webbrower
{
    public class JsDialogHandler : IJsDialogHandler
    {
        public void OnDialogClosed(IWebBrowser browserControl, IBrowser browser)
        {

        }

        public bool OnJSBeforeUnload(IWebBrowser browserControl, IBrowser browser, string message, bool isReload, IJsDialogCallback callback)
        {
            return true;
        }

        public bool OnJSDialog(IWebBrowser browserControl, IBrowser browser, string originUrl, string acceptLang, CefJsDialogType dialogType, string messageText, string defaultPromptText, IJsDialogCallback callback, ref bool suppressMessage)
        {
            if (dialogType == CefJsDialogType.Alert)
            {
                MessageBox.Show(messageText, "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                suppressMessage = true;
                return false;
            }
            else
            {
                return true;
            }
        }

        public void OnResetDialogState(IWebBrowser browserControl, IBrowser browser)
        {
            
        }
    }
}
