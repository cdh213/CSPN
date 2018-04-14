using CSPN.helper;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CSPN.assistcontrol
{
    public partial class WaitForm : Form
    {
        public WaitForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        private delegate void SetTextDelegate(string msg);
        public void SetText(string msg)
        {
            if (this.label1.InvokeRequired)
            {
                this.Invoke(new SetTextDelegate(SetText), msg);
            }
            else
            {
                this.label1.Text = msg;
            }
        }
    }
    public class WaitWin
    {
        private static WaitWin instance = null;
        private static readonly Object syncLock = new Object();
        private Thread waitThread = null;
        private static WaitForm waitForm = null;
        private static string _msg = null;
        private static ContainerControl _control = null;

        /// <summary>    
        /// 单例模式    
        /// </summary>    
        private static WaitWin Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncLock)
                    {
                        if (instance == null)
                        {
                            instance = new WaitWin();
                        }
                    }
                }
                return instance;
            }
        }
        /// <summary>    
        /// 为了单例模式防止new 实例化..    
        /// </summary>    
        private WaitWin()
        {
        }
        /// <summary>    
        /// 显示等待窗体    
        /// </summary>    
        public static void Show(ContainerControl control, string msg)
        {
            _control = control;
            _msg = msg;
            WaitWin.Instance.CreateForm();
        }
        /// <summary>    
        /// 关闭等待窗体    
        /// </summary>    
        public static void Close()
        {
            Thread.Sleep(100);
            WaitWin.Instance.CloseForm();
        }
        /// <summary>    
        /// 创建等待窗体    
        /// </summary>    
        private void CreateForm()
        {
            waitForm = null;
            waitThread = new Thread(new ThreadStart(this.ShowWaitForm));
            waitThread.Start();
            Thread.Sleep(100);
        }
        private void ShowWaitForm()
        {
            try
            {
                waitForm = new WaitForm();
                waitForm.SetText(_msg);
                if (_control is Form)
                {
                    Point loc = _control.Location;
                    waitForm.Left = loc.X + (_control.Bounds.Width - waitForm.Width) / 2;
                    waitForm.Top = loc.Y + (_control.Bounds.Height - waitForm.Height) / 2;
                }
                else
                {
                    Point loc = _control.ParentForm.Location;
                    waitForm.Left = loc.X + (_control.ParentForm.Bounds.Width - waitForm.Width) / 2;
                    waitForm.Top = loc.Y + (_control.ParentForm.Bounds.Height - waitForm.Height) / 2;
                }
                waitForm.ShowDialog();
            }
            catch (ThreadAbortException ex)
            {
                waitForm.Close();
                Thread.ResetAbort();
                LogHelper.WriteLog(ex.Message, ex);
            }
        }
        /// <summary>    
        /// 关闭窗体    
        /// </summary>    
        private void CloseForm()
        {
            if (waitThread != null)
            {
                waitForm.Close();
            }
        }
    }
}
