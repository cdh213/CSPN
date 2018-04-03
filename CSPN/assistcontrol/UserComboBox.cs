using CSPN.common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSPN.assistcontrol
{
    public partial class UserComboBox : ComboBox
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, string lp);

        private string mWaterText;
        [Category("扩展属性"), Description("ComboBox水印")]
        public string WaterText
        {
            get { return mWaterText; }
            set
            {
                mWaterText = value;
                UpdateWaterText();
            }
        }
        private void UpdateWaterText()
        {
            if (this.IsHandleCreated && mWaterText != null)
            {
                SendMessage(this.Handle, 0x1703, (IntPtr)0, mWaterText);
            }
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            UpdateWaterText();
        }
    }
}
