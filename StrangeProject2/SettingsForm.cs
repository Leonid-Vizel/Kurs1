using System;
using System.Windows.Forms;

namespace AudioTest
{
    public partial class SettingsForm : Form
    {
        private SettingsResult result;
        private SettingsForm(bool turnedOn)
        {
            result = SettingsResult.Cancelled;
            InitializeComponent();
            onRadioBtn.Checked = turnedOn;
            offRadioBtn.Checked = !turnedOn;
        }

        private void AcceptChanges(object sender, EventArgs e)
        {
            result = onRadioBtn.Checked ? SettingsResult.On : SettingsResult.Off;
            Close();
        }

        private void DiscardChanges(object sender, EventArgs e) => Close();

        public static SettingsResult ShowDialog(bool turnedOn)
        {
            SettingsForm form = new SettingsForm(turnedOn);
            form.ShowDialog();
            return form.result;
        }
    }

    public enum SettingsResult
    {
        On,
        Off,
        Cancelled
    }
}
