using CefSharp;
using CSPN.assistcontrol;
using CSPN.common;
using CSPN.helper;
using CSPN.webbrower;
using log4net.Config;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSPN
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            bool createdNew;
            Mutex instance = new Mutex(true, "CSPN", out createdNew); //同步基元变量   
            if (createdNew)
            {
                try
                {
                    XmlConfigurator.ConfigureAndWatch(new FileInfo("CSPN.exe.config"));
                    //设置应用程序处理异常方式：ThreadException处理
                    Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                    //处理UI线程异常
                    Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                    //处理非UI线程异常
                    AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    LoginForm loginForm = new LoginForm();
                    loginForm.ShowDialog();
                    string userName = loginForm.userName;
                    if (loginForm.DialogResult == DialogResult.OK)
                    {
                        WelcomeForm welcomeForm = new WelcomeForm();
                        welcomeForm.ShowDialog();
                        CommonClass.UserName = userName;
                        switch (welcomeForm.DialogResult)
                        {
                            case DialogResult.OK:
                                Cef.EnableHighDPISupport();
                                WebBrower.Init();
                                Application.Run(new MainForm(true));
                                break;
                            case DialogResult.No:
                                Application.Run(new MainForm(false));
                                break;
                            case DialogResult.Cancel:
                                Application.Run(new MainForm(null));
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex.Message, ex);
                    MessageBox.Show("系统错误。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Process.GetCurrentProcess().CloseMainWindow();
                }
                instance.ReleaseMutex();
                Environment.Exit(0);
            }
            else
            {
                MessageBox.Show("已经启动了一个程序，请先退出!");
                Environment.Exit(0);
            }
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            LogHelper.WriteLog(e.ToString(), e.Exception);
            MessageBox.Show("系统错误。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            LogHelper.WriteLog(e.ToString(), e.ExceptionObject as Exception);
            MessageBox.Show("系统错误。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
