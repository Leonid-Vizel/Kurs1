using System;
using System.Windows.Forms;

namespace TheStrangeProject
{
    public partial class BrowserForm : Form
    {
        public BrowserForm()
        {
            InitializeComponent();
            webBrowser.ScriptErrorsSuppressed = true;
        }

        private void BackBtnClick(object sender, System.EventArgs e) => webBrowser.GoBack();

        private void ForwardBtnClick(object sender, System.EventArgs e) => webBrowser.GoForward();

        private void HomeBtnClick(object sender, System.EventArgs e) => webBrowser.Url = new System.Uri("https://www.google.com/");

        private void formBtn_Click(object sender, System.EventArgs e)
        {
            MainForm form = new MainForm();
            form.FormClosed += ShowAgain;
            Hide();
            form.Show();
        }

        private void ShowAgain(object sender, FormClosedEventArgs e) => Show();
    }
}
