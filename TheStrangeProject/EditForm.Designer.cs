
namespace TheStrangeProject
{
    partial class EditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nameLabel = new System.Windows.Forms.Label();
            this.ageLabel = new System.Windows.Forms.Label();
            this.descLabel = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.descBox = new System.Windows.Forms.TextBox();
            this.ageBox = new System.Windows.Forms.NumericUpDown();
            this.removeBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(33, 9);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(32, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Имя:";
            // 
            // ageLabel
            // 
            this.ageLabel.AutoSize = true;
            this.ageLabel.Location = new System.Drawing.Point(7, 35);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(58, 13);
            this.ageLabel.TabIndex = 2;
            this.ageLabel.Text = "Восзраст:";
            // 
            // descLabel
            // 
            this.descLabel.AutoSize = true;
            this.descLabel.Location = new System.Drawing.Point(5, 62);
            this.descLabel.Name = "descLabel";
            this.descLabel.Size = new System.Drawing.Size(60, 13);
            this.descLabel.TabIndex = 3;
            this.descLabel.Text = "Описание:";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(76, 6);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(230, 20);
            this.nameBox.TabIndex = 4;
            // 
            // descBox
            // 
            this.descBox.Location = new System.Drawing.Point(76, 59);
            this.descBox.Multiline = true;
            this.descBox.Name = "descBox";
            this.descBox.Size = new System.Drawing.Size(230, 61);
            this.descBox.TabIndex = 5;
            // 
            // ageBox
            // 
            this.ageBox.Location = new System.Drawing.Point(76, 33);
            this.ageBox.Name = "ageBox";
            this.ageBox.Size = new System.Drawing.Size(54, 20);
            this.ageBox.TabIndex = 6;
            // 
            // removeBtn
            // 
            this.removeBtn.BackColor = System.Drawing.Color.Red;
            this.removeBtn.Location = new System.Drawing.Point(12, 126);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(294, 43);
            this.removeBtn.TabIndex = 7;
            this.removeBtn.Text = "Отчслить";
            this.removeBtn.UseVisualStyleBackColor = false;
            this.removeBtn.Click += new System.EventHandler(this.DeleteStudent);
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(12, 175);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(294, 43);
            this.editBtn.TabIndex = 8;
            this.editBtn.Text = "Сохранить";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.EditStudent);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TheStrangeProject.Properties.Resources.fuckYou;
            this.pictureBox1.Location = new System.Drawing.Point(312, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(396, 212);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 230);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.removeBtn);
            this.Controls.Add(this.ageBox);
            this.Controls.Add(this.descBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.descLabel);
            this.Controls.Add(this.ageLabel);
            this.Controls.Add(this.nameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование";
            this.Load += new System.EventHandler(this.OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.ageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label ageLabel;
        private System.Windows.Forms.Label descLabel;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox descBox;
        private System.Windows.Forms.NumericUpDown ageBox;
        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}