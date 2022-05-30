
namespace AudioTest
{
    partial class Form1
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
            this.tabSwitcher = new System.Windows.Forms.TabControl();
            this.addPage = new System.Windows.Forms.TabPage();
            this.fillGroup = new System.Windows.Forms.GroupBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.descLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.surnameLabel = new System.Windows.Forms.Label();
            this.settingsBtn = new System.Windows.Forms.Button();
            this.gitLinkLabel = new System.Windows.Forms.LinkLabel();
            this.gitLabel = new System.Windows.Forms.Label();
            this.dataPage = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.surnameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabSwitcher.SuspendLayout();
            this.addPage.SuspendLayout();
            this.fillGroup.SuspendLayout();
            this.dataPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabSwitcher
            // 
            this.tabSwitcher.Controls.Add(this.addPage);
            this.tabSwitcher.Controls.Add(this.dataPage);
            this.tabSwitcher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSwitcher.Location = new System.Drawing.Point(0, 0);
            this.tabSwitcher.Name = "tabSwitcher";
            this.tabSwitcher.SelectedIndex = 0;
            this.tabSwitcher.Size = new System.Drawing.Size(817, 461);
            this.tabSwitcher.TabIndex = 0;
            this.tabSwitcher.SelectedIndexChanged += new System.EventHandler(this.tabChanged);
            // 
            // addPage
            // 
            this.addPage.Controls.Add(this.fillGroup);
            this.addPage.Controls.Add(this.settingsBtn);
            this.addPage.Controls.Add(this.gitLinkLabel);
            this.addPage.Controls.Add(this.gitLabel);
            this.addPage.Location = new System.Drawing.Point(4, 22);
            this.addPage.Name = "addPage";
            this.addPage.Padding = new System.Windows.Forms.Padding(3);
            this.addPage.Size = new System.Drawing.Size(809, 435);
            this.addPage.TabIndex = 0;
            this.addPage.Text = "Добавить";
            this.addPage.UseVisualStyleBackColor = true;
            // 
            // fillGroup
            // 
            this.fillGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fillGroup.Controls.Add(this.saveBtn);
            this.fillGroup.Controls.Add(this.textBox3);
            this.fillGroup.Controls.Add(this.textBox2);
            this.fillGroup.Controls.Add(this.textBox1);
            this.fillGroup.Controls.Add(this.descLabel);
            this.fillGroup.Controls.Add(this.nameLabel);
            this.fillGroup.Controls.Add(this.surnameLabel);
            this.fillGroup.Location = new System.Drawing.Point(6, 6);
            this.fillGroup.Name = "fillGroup";
            this.fillGroup.Size = new System.Drawing.Size(793, 144);
            this.fillGroup.TabIndex = 8;
            this.fillGroup.TabStop = false;
            this.fillGroup.Text = "Заполнение данных";
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.BackColor = System.Drawing.Color.LightGreen;
            this.saveBtn.FlatAppearance.BorderSize = 0;
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBtn.Location = new System.Drawing.Point(619, 95);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(168, 43);
            this.saveBtn.TabIndex = 6;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(71, 71);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(716, 20);
            this.textBox3.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(71, 45);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(716, 20);
            this.textBox2.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(71, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(716, 20);
            this.textBox1.TabIndex = 3;
            // 
            // descLabel
            // 
            this.descLabel.AutoSize = true;
            this.descLabel.Location = new System.Drawing.Point(6, 74);
            this.descLabel.Name = "descLabel";
            this.descLabel.Size = new System.Drawing.Size(60, 13);
            this.descLabel.TabIndex = 2;
            this.descLabel.Text = "Описание:";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(6, 48);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(32, 13);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Имя:";
            // 
            // surnameLabel
            // 
            this.surnameLabel.AutoSize = true;
            this.surnameLabel.Location = new System.Drawing.Point(6, 22);
            this.surnameLabel.Name = "surnameLabel";
            this.surnameLabel.Size = new System.Drawing.Size(59, 13);
            this.surnameLabel.TabIndex = 0;
            this.surnameLabel.Text = "Фамилия:";
            // 
            // settingsBtn
            // 
            this.settingsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsBtn.BackColor = System.Drawing.Color.DarkGray;
            this.settingsBtn.FlatAppearance.BorderSize = 0;
            this.settingsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsBtn.Location = new System.Drawing.Point(635, 386);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(168, 43);
            this.settingsBtn.TabIndex = 11;
            this.settingsBtn.Text = "⚙Настройки⚙";
            this.settingsBtn.UseVisualStyleBackColor = false;
            this.settingsBtn.Click += new System.EventHandler(this.ShowSettings);
            // 
            // gitLinkLabel
            // 
            this.gitLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gitLinkLabel.AutoSize = true;
            this.gitLinkLabel.Location = new System.Drawing.Point(115, 416);
            this.gitLinkLabel.Name = "gitLinkLabel";
            this.gitLinkLabel.Size = new System.Drawing.Size(157, 13);
            this.gitLinkLabel.TabIndex = 10;
            this.gitLinkLabel.TabStop = true;
            this.gitLinkLabel.Text = "https://github.com/Leonid-Vizel";
            // 
            // gitLabel
            // 
            this.gitLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gitLabel.AutoSize = true;
            this.gitLabel.Location = new System.Drawing.Point(6, 416);
            this.gitLabel.Name = "gitLabel";
            this.gitLabel.Size = new System.Drawing.Size(103, 13);
            this.gitLabel.TabIndex = 9;
            this.gitLabel.Text = "Ссылка на GitHub: ";
            // 
            // dataPage
            // 
            this.dataPage.Controls.Add(this.dataGridView1);
            this.dataPage.Location = new System.Drawing.Point(4, 22);
            this.dataPage.Name = "dataPage";
            this.dataPage.Padding = new System.Windows.Forms.Padding(3);
            this.dataPage.Size = new System.Drawing.Size(809, 435);
            this.dataPage.TabIndex = 1;
            this.dataPage.Text = "Просмотр";
            this.dataPage.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.surnameColumn,
            this.nameColumn,
            this.descColumn});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(803, 429);
            this.dataGridView1.TabIndex = 0;
            // 
            // surnameColumn
            // 
            this.surnameColumn.HeaderText = "Фамилия";
            this.surnameColumn.Name = "surnameColumn";
            this.surnameColumn.ReadOnly = true;
            // 
            // nameColumn
            // 
            this.nameColumn.HeaderText = "Имя";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            // 
            // descColumn
            // 
            this.descColumn.HeaderText = "Описание";
            this.descColumn.Name = "descColumn";
            this.descColumn.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(817, 461);
            this.Controls.Add(this.tabSwitcher);
            this.MinimumSize = new System.Drawing.Size(491, 268);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Форма #1";
            this.tabSwitcher.ResumeLayout(false);
            this.addPage.ResumeLayout(false);
            this.addPage.PerformLayout();
            this.fillGroup.ResumeLayout(false);
            this.fillGroup.PerformLayout();
            this.dataPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSwitcher;
        private System.Windows.Forms.TabPage addPage;
        private System.Windows.Forms.GroupBox fillGroup;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label descLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label surnameLabel;
        private System.Windows.Forms.Button settingsBtn;
        private System.Windows.Forms.LinkLabel gitLinkLabel;
        private System.Windows.Forms.Label gitLabel;
        private System.Windows.Forms.TabPage dataPage;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn surnameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descColumn;
    }
}

