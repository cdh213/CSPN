using CefSharp;
using CefSharp.WinForms;
using CSPN.BLL;
using CSPN.helper;
using CSPN.IBLL;
using CSPN.Model;
using CSPN.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPN.webbrower
{
    public class WebBrower
    {
        public static ChromiumWebBrowser webBrower { get; set; }
        static readonly bool DebuggingSubProcess = Debugger.IsAttached;

        public static void Init()
        {
            IWellInfoService wellInfoService = new WellInfoService();
            StringBuilder html = new StringBuilder();

            IList<WellInfo> list = wellInfoService.GetWellInfo_List(null);
            string json = JsonConvert.SerializeObject(list);

            //指定全局设置和命令行参数
            CefSettings settings = new CefSettings();
            settings.Locale = "zh-CN";
            //日志输出
            settings.LogFile = "log/LogData.txt";
            settings.LogSeverity = LogSeverity.Error;
            settings.CachePath = "cache";
            settings.BrowserSubprocessPath = "webbrowerlib\\CefSharp.BrowserSubprocess.exe";

            if (!Cef.IsInitialized)
            {
                Cef.Initialize(settings, shutdownOnProcessExit: true, performDependencyCheck: !DebuggingSubProcess);
            }
            webBrower = new ChromiumWebBrowser("http://rendering/");
            html.AppendFormat(Resources.mapHeader, json);
            html.Append(Resources.mapContent);
            webBrower.LoadHtml(html.ToString(), "http://rendering/");

            webBrower.RegisterJsObject("jsObj", new JsEvent(), false);

            BrowserSettings browserSettings = new BrowserSettings();
            browserSettings.DefaultEncoding = "UTF-8";
            browserSettings.WebGl = CefState.Enabled;
            webBrower.BrowserSettings = browserSettings;

            //禁用右击菜单
            webBrower.MenuHandler = new MenuHandler();
        }
    }
}
