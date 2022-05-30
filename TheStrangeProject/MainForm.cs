using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TheStrangeProject
{
    public partial class MainForm : Form
    {
        private Random rnd;
        private List<StudentInfo> information;

        public MainForm()
        {
            rnd = new Random(Guid.NewGuid().GetHashCode());
            InitializeComponent();
        }

        private void OnClick(object sender, EventArgs e)
        {
            if (treePart.SelectedNode == treePart.Nodes[0] || treePart.SelectedNode == treePart.Nodes[1])
            {
                return;
            }
            if (EditForm.ShowDialog(treePart.SelectedNode.Tag as StudentInfo))
            {
                information.Remove(treePart.SelectedNode.Tag as StudentInfo);
                treePart.Nodes.Remove(treePart.SelectedNode);
                MapCells();
                File.WriteAllText("baza.txt", string.Join("\n",information.Select(x=>x.ToString())));
            }
            else
            {
                treePart.SelectedNode.Text = (treePart.SelectedNode.Tag as StudentInfo)?.Name;
                MapCells();
                File.WriteAllText("baza.txt", string.Join("\n", information.Select(x => x.ToString())));
            }
        }

        private void colorTimerElapsed(object sender, EventArgs e)
        {
            horisontalSplitContainer.Panel2.BackColor = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
        }

        private void OnLoad(object sender, EventArgs e)
        {
            information = new List<StudentInfo>();
            string[] parseStrings = File.ReadAllLines("Baza.txt");
            foreach(string info in parseStrings)
            {
                string[] infoParts = info.Split(' ');
                StudentInfo student = new StudentInfo(int.Parse(infoParts[0]));
                student.Name = infoParts[1];
                student.Surname = infoParts[2];
                student.Age = int.Parse(infoParts[3]);
                student.Group = infoParts[4];
                for (int i = 5; i < infoParts.Length; i++)
                {
                    student.Description += $" {infoParts[i]}";
                }
                if (student.Group.Equals("09-121"))
                {
                    treePart.Nodes[0].Nodes.Add(new TreeNode()
                    {
                        Text = student.Name,
                        Tag = student
                    });
                }
                else if (student.Group.Equals("09-122"))
                {
                    treePart.Nodes[1].Nodes.Add(new TreeNode()
                    {
                        Text = student.Name,
                        Tag = student
                    });
                }
                information.Add(student);
            }
        }

        private void OnSelect(object sender, TreeViewEventArgs e)
        {
            if (treePart.Nodes.Contains(treePart.SelectedNode))
            {
                MapCells();
            }
        }

        private void MapCells()
        {
            dataPart.Rows.Clear();
            foreach (StudentInfo info in information.Where(x => x.Group.Equals(treePart.SelectedNode.Text)))
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataPart);
                row.SetValues(new object[] { info.Name, info.Surname, info.Age, info.Group, info.Description });
                ToolStripButton btn = new ToolStripButton() { Text = "Открыть" };
                btn.Tag = info;
                btn.Size = new Size(40,40);
                btn.Click += OnContextClick;
                ContextMenuStrip strip = new ContextMenuStrip();
                strip.Items.Add(btn);
                row.ContextMenuStrip = strip;
                dataPart.Rows.Add(row);
            }
        }

        private void OnContextClick(object sender, EventArgs e)
        {
            if (EditForm.ShowDialog(((ToolStripButton)sender).Tag as StudentInfo))
            {
                information.Remove(((ToolStripButton)sender).Tag as StudentInfo);
                MapCells();
                File.WriteAllText("baza.txt", string.Join("\n", information.Select(x => x.ToString())));
            }
            else
            {
                MapCells();
                File.WriteAllText("baza.txt", string.Join("\n", information.Select(x => x.ToString())));
            }
        }
    }
}
