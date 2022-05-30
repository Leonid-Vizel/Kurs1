
namespace TheStrangeProject
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("09-121");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("09-122");
            this.verticalSplitContainer = new System.Windows.Forms.SplitContainer();
            this.horisontalSplitContainer = new System.Windows.Forms.SplitContainer();
            this.treePart = new System.Windows.Forms.TreeView();
            this.dataPart = new System.Windows.Forms.DataGridView();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SurnameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AgeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colorTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.verticalSplitContainer)).BeginInit();
            this.verticalSplitContainer.Panel1.SuspendLayout();
            this.verticalSplitContainer.Panel2.SuspendLayout();
            this.verticalSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.horisontalSplitContainer)).BeginInit();
            this.horisontalSplitContainer.Panel1.SuspendLayout();
            this.horisontalSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataPart)).BeginInit();
            this.SuspendLayout();
            // 
            // verticalSplitContainer
            // 
            this.verticalSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.verticalSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.verticalSplitContainer.Name = "verticalSplitContainer";
            // 
            // verticalSplitContainer.Panel1
            // 
            this.verticalSplitContainer.Panel1.Controls.Add(this.horisontalSplitContainer);
            // 
            // verticalSplitContainer.Panel2
            // 
            this.verticalSplitContainer.Panel2.Controls.Add(this.dataPart);
            this.verticalSplitContainer.Size = new System.Drawing.Size(800, 450);
            this.verticalSplitContainer.SplitterDistance = 266;
            this.verticalSplitContainer.TabIndex = 0;
            // 
            // horisontalSplitContainer
            // 
            this.horisontalSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horisontalSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.horisontalSplitContainer.Name = "horisontalSplitContainer";
            this.horisontalSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // horisontalSplitContainer.Panel1
            // 
            this.horisontalSplitContainer.Panel1.Controls.Add(this.treePart);
            this.horisontalSplitContainer.Size = new System.Drawing.Size(266, 450);
            this.horisontalSplitContainer.SplitterDistance = 88;
            this.horisontalSplitContainer.TabIndex = 0;
            // 
            // treePart
            // 
            this.treePart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treePart.Location = new System.Drawing.Point(0, 0);
            this.treePart.Name = "treePart";
            treeNode1.Name = "Node09121";
            treeNode1.Text = "09-121";
            treeNode2.Name = "Node09122";
            treeNode2.Text = "09-122";
            this.treePart.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.treePart.Size = new System.Drawing.Size(266, 88);
            this.treePart.TabIndex = 1;
            this.treePart.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnSelect);
            this.treePart.DoubleClick += new System.EventHandler(this.OnClick);
            // 
            // dataPart
            // 
            this.dataPart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataPart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameColumn,
            this.SurnameColumn,
            this.AgeColumn,
            this.groupColumn,
            this.DescriptionColumn});
            this.dataPart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataPart.Location = new System.Drawing.Point(0, 0);
            this.dataPart.Name = "dataPart";
            this.dataPart.Size = new System.Drawing.Size(530, 450);
            this.dataPart.TabIndex = 1;
            // 
            // NameColumn
            // 
            this.NameColumn.HeaderText = "Имя";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            // 
            // SurnameColumn
            // 
            this.SurnameColumn.HeaderText = "Фамилия";
            this.SurnameColumn.Name = "SurnameColumn";
            // 
            // AgeColumn
            // 
            this.AgeColumn.HeaderText = "Возраст";
            this.AgeColumn.Name = "AgeColumn";
            this.AgeColumn.ReadOnly = true;
            // 
            // groupColumn
            // 
            this.groupColumn.HeaderText = "Группа";
            this.groupColumn.Name = "groupColumn";
            this.groupColumn.ReadOnly = true;
            // 
            // DescriptionColumn
            // 
            this.DescriptionColumn.HeaderText = "Описание";
            this.DescriptionColumn.Name = "DescriptionColumn";
            this.DescriptionColumn.ReadOnly = true;
            // 
            // colorTimer
            // 
            this.colorTimer.Enabled = true;
            this.colorTimer.Interval = 5000;
            this.colorTimer.Tick += new System.EventHandler(this.colorTimerElapsed);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.verticalSplitContainer);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главное окно";
            this.Load += new System.EventHandler(this.OnLoad);
            this.verticalSplitContainer.Panel1.ResumeLayout(false);
            this.verticalSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.verticalSplitContainer)).EndInit();
            this.verticalSplitContainer.ResumeLayout(false);
            this.horisontalSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.horisontalSplitContainer)).EndInit();
            this.horisontalSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataPart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer verticalSplitContainer;
        private System.Windows.Forms.SplitContainer horisontalSplitContainer;
        private System.Windows.Forms.TreeView treePart;
        private System.Windows.Forms.DataGridView dataPart;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SurnameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AgeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptionColumn;
        private System.Windows.Forms.Timer colorTimer;
    }
}

