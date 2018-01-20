using CefSharp;
using CefSharp.WinForms;
using CSPN.BLL;
using CSPN.common;
using CSPN.helper;
using CSPN.IBLL;
using CSPN.job;
using CSPN.Model;
using CSPN.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CSPN.webbrower
{
    public class WebBrower
    {
        private static IWellInfoService wellInfoService = null;
        private BackgroundWorker bw = null;
        private static IList<WellInfo> list = null;
        private static string json = null;

        public static ChromiumWebBrowser webBrower { get; set; }

        public WebBrower()
        {
            RefreshWellInfoJob.refreshEventHandler += new job.RefreshEventHandler(Reload);
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
        }
        
        public static void Reload()
        {
            if (webBrower.IsBrowserInitialized)
            {
                wellInfoService = new WellInfoService();
                list = wellInfoService.GetWellInfo_List(null);
                json = JsonConvert.SerializeObject(list);
                webBrower.ExecuteScriptAsync("Refresh", json);
            }
        }
    }
}
