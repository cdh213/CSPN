using System.Drawing;
using System.Windows.Forms;

namespace CSPN.assistcontrol
{
    /// <summary>
    /// 显示自定义消息窗口（也称为对话框）向用户展示消息，此消息框最顶层显示。
    /// </summary>
    public static class UMessageBox
    {
        /// <summary>
        /// 显示一个具有指定文本、标题、按钮、图标、默认按钮、选项和“帮助”按钮的消息框。
        /// </summary>
        /// <param name="text">要在消息框中显示的文本。</param>
        /// <param name="caption">要在消息框的标题栏中显示的文本。</param>
        /// <param name="buttons">System.Windows.Forms.MessageBoxButtons 值之一，可指定在消息框中显示哪些按钮。</param>
        /// <param name="icon">System.Windows.Forms.MessageBoxIcon 值之一，它指定在消息框中显示哪个图标。</param>
        /// <returns></returns>
        public static DialogResult Show(string text, string caption,
            MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            Form topmostForm = new Form();
            topmostForm.Text = "人井监控管理系统";
            topmostForm.ShowIcon = false;
            topmostForm.ShowInTaskbar = false;
            topmostForm.Size = new Size(1, 1);
            topmostForm.StartPosition = FormStartPosition.Manual;
            Rectangle rect = SystemInformation.VirtualScreen;
            topmostForm.Location = new Point(rect.Bottom + 10, rect.Right + 10);
            topmostForm.Show();
            topmostForm.Focus();
            topmostForm.BringToFront();
            topmostForm.TopMost = true;
            DialogResult result = MessageBox.Show(topmostForm, text, caption, buttons, icon);
            topmostForm.Dispose();
            return result;
        }
    }
}
