using CefSharp;
using CefSharp.WinForms;
using CSPN.BLL;
using CSPN.common;
using CSPN.helper;
using CSPN.IBLL;
using CSPN.Model;
using CSPN.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPN.webbrower
{
    public class WebBrower
    {
        private static WebBrower webBrowerInstance = null;
        private static readonly object locker = new object();
        private IWellInfoService wellInfoService = null;
        BackgroundWorker bw = null;
        private IList<WellInfo> list = null;
        private string json = null;

        public ChromiumWebBrowser webBrower { get; set; }

        private WebBrower()
        {
        }
        public static WebBrower GetInstance()
        {
            if (webBrowerInstance == null)
            {
                lock (locker)
                {
                    if (webBrowerInstance == null)
                    {
                        webBrowerInstance = new WebBrower();
                    }
                }
            }
            return webBrowerInstance;
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

            bw = new BackgroundWorker();
            bw.DoWork += bw_DoWork;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            bw.RunWorkerAsync();
        }
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            wellInfoService = new WellInfoService();
            list = wellInfoService.GetWellInfo_List(null);
            e.Result = JsonConvert.SerializeObject(list);
        }
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            StringBuilder html = new StringBuilder();
            string location = ReadWriteConfig.ReadConfig("DefaultLocation");
            html.AppendFormat(Resources.mapHeader, e.Result, location);
            html.Append(Resources.mapContent);
            webBrower.LoadHtml(html.ToString(), "http://rendering/");
            if (bw != null)
            {
                bw.Dispose();
            }
        }
        
        public void Reload()
        {
            wellInfoService = new WellInfoService();
            list = wellInfoService.GetWellInfo_List(null);
            json = JsonConvert.SerializeObject(list);
            webBrower.ExecuteScriptAsync("Refresh", json);
        }
    }
}
