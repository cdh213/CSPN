using System.ComponentModel;
using System.Windows.Forms;

namespace CSPN.assistcontrol
{
    public partial class ImportProgressBarForm : Form
    {
        private BackgroundWorker _backgroundWorker;

        public ImportProgressBarForm(BackgroundWorker backgroundWorker, int width)
        {
            InitializeComponent();
            this.Width = width / 2;
            this.TransparencyKey = this.BackColor;
            this._backgroundWorker = backgroundWorker;
            this._backgroundWorker.ProgressChanged += _backgroundWorker_ProgressChanged;
            this._backgroundWorker.RunWorkerCompleted += _backgroundWorker_RunWorkerCompleted;
        }
        void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();//执行完之后，直接关闭页面
        }

        void _backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar.Value = e.ProgressPercentage;
            this.progressBar.Maximum = (int)e.UserState;
        }
    }
}
