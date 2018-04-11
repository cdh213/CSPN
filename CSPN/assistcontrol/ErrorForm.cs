using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace CSPN.assistcontrol
{
    public partial class ErrorForm : Form
    {
        public ErrorForm(string msg, bool isShowBtn)
        {
            InitializeComponent();
            label1.Text = msg;
            if (!isShowBtn)
            {
                panel1.Hide();
            }
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().CloseMainWindow();
        }
    }
}
