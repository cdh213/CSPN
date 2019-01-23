using CefSharp;
using CefSharp.WinForms;
using CSPN.BLL;
using CSPN.common;
using CSPN.IBLL;
using CSPN.job;
using CSPN.Model;
using CSPN.Properties;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSPN.webbrower
{
    public class WebBrower
    {
        private static IWellInfoService wellInfoService = null;
        private static List<WellInfo> list = null;
        private static string json = null;

        public static ChromiumWebBrowser webBrower { get; set; }

        public WebBrower()
        {
            RefreshWellInfoJob.refreshEvent += new RefreshDelegate(Reload);
        }

        public void Init()
        {
            //指定全局设置和命令行参数
            CefSettings settings = new CefSettings();
            //语言
            settings.Locale = "zh-CN";
            settings.AcceptLanguageList = "zh-CN";
            settings.LocalesDirPath = @"webbrowerlib\locales\";
            //日志输出
            settings.LogFile = @"log\LogData.txt";
            settings.LogSeverity = LogSeverity.Error;
            settings.CachePath = "cache";
            settings.BrowserSubprocessPath = @"webbrowerlib\CefSharp.BrowserSubprocess.exe";
            if (!Cef.IsInitialized)
            {
                Cef.Initialize(settings, true, false);
            }
            webBrower = new ChromiumWebBrowser("http://rendering/");
            webBrower.LoadHtml(Resources.Loading, "http://rendering/");
            webBrower.RegisterJsObject("jsObj", new JsEvent(), false);
            BrowserSettings browserSettings = new BrowserSettings();
            browserSettings.DefaultEncoding = "UTF-8";
            browserSettings.WebGl = CefState.Enabled;
            webBrower.BrowserSettings = browserSettings;
            //禁用右击菜单
            webBrower.MenuHandler = new MenuHandler();
            webBrower.JsDialogHandler = new JsDialogHandler();

            Task.Run(() =>
            {
                wellInfoService = new WellInfoService();
                StringBuilder html = new StringBuilder();
                string location = ReadWriteXml.ReadXml("DefaultLocation");
                list = wellInfoService.GetWellInfo_List(null);
                json = JsonConvert.SerializeObject(list);
                html.AppendFormat(Resources.mapHeader, json, location);
                html.Append(Resources.mapContent);
                webBrower.LoadHtml(html.ToString(), "http://rendering/");
            });
        }

        public static void Reload()
        {
            if (webBrower.IsBrowserInitialized)
            {
                Task.Run(() =>
                {
                    wellInfoService = new WellInfoService();
                    list = wellInfoService.GetWellInfo_List(null);
                    json = JsonConvert.SerializeObject(list);
                    webBrower.ExecuteScriptAsync("Refresh", json);
                });
            }
        }
    }
}