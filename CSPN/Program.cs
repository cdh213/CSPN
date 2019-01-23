using CefSharp;
using CSPN.assistcontrol;
using CSPN.common;
using CSPN.helper;
using CSPN.webbrower;
using log4net.Config;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace CSPN
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Mutex instance = new Mutex(true, "CSPN", out bool createdNew); //同步基元变量
            if (createdNew)
            {
                try
                {
                    XmlConfigurator.ConfigureAndWatch(new FileInfo("CSPN.exe.config"));
                    //设置应用程序处理异常方式：ThreadException处理
                    Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                    //处理UI线程异常
                    Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
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
                                new WebBrower().Init();
                                Application.Run(new MainForm(true));
                                break;

                            case DialogResult.No:
                                Application.Run(new MainForm(false));
                                break;

                            case DialogResult.Abort:
                                Application.Run(new MainForm(null));
                                break;

                            default:
                                Environment.Exit(0);
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex.Message, ex);
                    UMessageBox.Show("系统错误。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Process.GetCurrentProcess().CloseMainWindow();
                }
                finally
                {
                    instance.ReleaseMutex();
                    instance.Dispose();
                    Environment.Exit(0);
                }
            }
            else
            {
                UMessageBox.Show("已经启动了一个程序，请先退出!", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            LogHelper.WriteLog(e.ToString(), e.Exception);
            UMessageBox.Show("系统错误。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            WaitWin.Close();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            LogHelper.WriteLog(e.ToString(), e.ExceptionObject as Exception);
            UMessageBox.Show("系统错误。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            WaitWin.Close();
        }
    }
}