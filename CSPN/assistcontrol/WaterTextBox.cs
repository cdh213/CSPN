using CSPN.common;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CSPN.assistcontrol
{
    public partial class WaterTextBox : TextBox
    {
        private string mWaterText;
        [Category("扩展属性"), Description("TextBox水印")]
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
                NativeMethods.SendMessage(this.Handle, 0x1501, (IntPtr)0, mWaterText);
            }
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            UpdateWaterText();
        }
    }
}
