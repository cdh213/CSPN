using CefSharp;
using CSPN.assistcontrol;
using CSPN.common;
using CSPN.control;
using CSPN.sms;
using CSPN.webbrower;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSPN
{
    public partial class MainForm : Form
    {
        static MsgShowControl msc = null;
        PendingMsgControl pmc = new PendingMsgControl();
        SystemSettingsControl ssc = new SystemSettingsControl();
        MaintainControl amc = new MaintainControl();
        LogInfoControl lil = new LogInfoControl();
        bool? _isOpen = true;

        public MainForm(bool? isOpen)
        {
            InitializeComponent();
            _isOpen = isOpen;
            lbUserName.Text += CommonClass.UserName;
            new QuartzInit().Quartz();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            switch (_isOpen)
            {
                case true:
                    msc = new MsgShowControl();
                    ssc.isOpen = true;
                    panelMain.Controls.Clear();
                    msc.Dock = DockStyle.Fill;
                    panelMain.Controls.Add(msc);
                    break;
                case false:
                    ssc.isOpen = false;
                    WaitWin.Show(this, "正在打开，请稍后。。。。。。");

                    btnMsgShow.Enabled = false;
                    btnPendingMsg.Enabled = false;
                    btnMessagelog.Enabled = false;
                    btnMaintain.Enabled = false;

                    panelMain.Controls.Clear();
                    ssc.Dock = DockStyle.Fill;
                    panelMain.Controls.Add(ssc);
                    WaitWin.Close();
                    break;
                case null:
                    WaitWin.Show(this, "正在打开，请稍后。。。。。。");

                    btnMsgShow.Enabled = false;
                    btnSystemSettings.Enabled = false;
                    btnMessagelog.Enabled = false;
                    btnPendingMsg.Enabled = false;
                    btnMaintain.Enabled = false;

                    pmc.Enabled = false;
                    WaitWin.Close();
                    new ErrorForm("系统错误，请等待恢复！", false).Show(this);
                    break;
            }
        }
        private void btnMsgShow_Click(object sender, EventArgs e)
        {
            WaitWin.Show(this, "正在打开，请稍后。。。。。。");
            panelMain.Controls.Clear();
            msc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(msc);
            WaitWin.Close();
        }

        private void btnPendingMsg_Click(object sender, EventArgs e)
        {
            WaitWin.Show(this, "正在打开，请稍后。。。。。。");
            panelMain.Controls.Clear();
            pmc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(pmc);
            pmc.RefreshInfo();
            WaitWin.Close();
        }

        private void btnMessagelog_Click(object sender, EventArgs e)
        {
            WaitWin.Show(this, "正在打开，请稍后。。。。。。");
            
            panelMain.Controls.Clear();
            lil.Dock = DockStyle.Fill;
            panelMain.Controls.Add(lil);
            WaitWin.Close();
        }
        private void btnMaintain_Click(object sender, EventArgs e)
        {
            WaitWin.Show(this, "正在打开，请稍后。。。。。。");
            panelMain.Controls.Clear();
            amc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(amc);
            WaitWin.Close();
        }
        private void btnSystemSettings_Click(object sender, EventArgs e)
        {
            WaitWin.Show(this, "正在打开，请稍后。。。。。。");
            panelMain.Controls.Clear();
            ssc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(ssc);
            WaitWin.Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Focus();
            WaitWin.Show(this, "正在关闭，请稍后。。。。。。");
            if (_isOpen == true)
            {
                WebBrower.webBrower.Dispose();
                Cef.Shutdown();
            }
            if (_isOpen != false)
            {
                CDMASMS.Close();
            }
            WaitWin.Close();
        }
    }
}
