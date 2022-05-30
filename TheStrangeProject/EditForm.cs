using System;
using System.Windows.Forms;

namespace TheStrangeProject
{
    public partial class EditForm : Form
    {
        private bool deleted;
        private StudentInfo info;
        private EditForm(StudentInfo info)
        {
            deleted = false;
            this.info = info;
            InitializeComponent();
        }

        public static bool ShowDialog(StudentInfo info)
        {
            EditForm edit = new EditForm(info);
            edit.ShowDialog();
            return edit.deleted;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            nameBox.Text = $"{info.Name} {info.Surname}";
            ageBox.Value = info.Age;
            descBox.Text = info.Description;
        }

        private void DeleteStudent(object sender, EventArgs e)
        {
            deleted = true;
            Close();
        }

        private void EditStudent(object sender, EventArgs e)
        {
            string[] names = nameBox.Text.Split(' ');
            if (names.Length == 2)
            {
                info.Name = names[0];
                info.Surname = names[1];
                info.Age = (int)ageBox.Value;
                info.Description = descBox.Text;
                Close();
            }
            else
            {
                MessageBox.Show(this,"Неверный формат фамилии и имени","Ошибка");
            }
        }
    }
}
