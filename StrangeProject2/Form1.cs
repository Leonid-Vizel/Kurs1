using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace AudioTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Redirect(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start(gitLinkLabel.Text);

        private void tabChanged(object sender, EventArgs e)
        {
            if (tabSwitcher.SelectedIndex == 1)
            {
                dataGridView1.Rows.Clear();
                string[] lines = File.ReadAllLines($"{Environment.CurrentDirectory}\\Baza.txt");
                foreach(string line in lines)
                {
                    string[] parseStrings = line.Split(' ');
                    string description = parseStrings[2];
                    for (int i = 3; i < parseStrings.Length; i++)
                    {
                        description += $" {parseStrings[i]}";
                    }
                    dataGridView1.Rows.Add(new object[3] { parseStrings[0], parseStrings[1], description });
                }
            }
        }

        private void ShowSettings(object sender, EventArgs e)
        {
            SettingsResult result = SettingsForm.ShowDialog(!textBox1.ReadOnly);
            switch (result)
            {
                case SettingsResult.On:
                    textBox1.ReadOnly = textBox2.ReadOnly = textBox3.ReadOnly = false;
                    saveBtn.Enabled = true;
                    break;
                case SettingsResult.Off:
                    textBox1.ReadOnly = textBox2.ReadOnly = textBox3.ReadOnly = true;
                    saveBtn.Enabled = false;
                    break;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || textBox1.Text.Contains(" "))
            {
                MessageBox.Show("Неверный формат фамилии!", "Ошибка");
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text) || textBox2.Text.Contains(" "))
            {
                MessageBox.Show("Неверный формат имени!", "Ошибка");
                return;
            }
            File.AppendAllText($"{Environment.CurrentDirectory}\\Baza.txt", $"{textBox1.Text} {textBox2.Text} {textBox3.Text}\n");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            MessageBox.Show("Успешно добавлено!", "Операция выполнена");
        }
    }
}
