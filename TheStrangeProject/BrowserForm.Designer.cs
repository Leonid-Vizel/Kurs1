
namespace TheStrangeProject
{
    partial class BrowserForm
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
            this.formBtn = new System.Windows.Forms.Button();
            this.homeBtn = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.forwardBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // formBtn
            // 
            this.formBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.formBtn.Location = new System.Drawing.Point(0, 0);
            this.formBtn.Name = "formBtn";
            this.formBtn.Size = new System.Drawing.Size(800, 23);
            this.formBtn.TabIndex = 1;
            this.formBtn.Text = "Форма 2";
            this.formBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.formBtn.UseVisualStyleBackColor = true;
            this.formBtn.Click += new System.EventHandler(this.formBtn_Click);
            // 
            // homeBtn
            // 
            this.homeBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.homeBtn.Location = new System.Drawing.Point(86, 0);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Size = new System.Drawing.Size(90, 29);
            this.homeBtn.TabIndex = 2;
            this.homeBtn.Text = "HOME";
            this.homeBtn.UseVisualStyleBackColor = true;
            this.homeBtn.Click += new System.EventHandler(this.HomeBtnClick);
            // 
            // backBtn
            // 
            this.backBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.backBtn.Location = new System.Drawing.Point(0, 0);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(43, 29);
            this.backBtn.TabIndex = 3;
            this.backBtn.Text = "<-";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.BackBtnClick);
            // 
            // forwardBtn
            // 
            this.forwardBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.forwardBtn.Location = new System.Drawing.Point(43, 0);
            this.forwardBtn.Name = "forwardBtn";
            this.forwardBtn.Size = new System.Drawing.Size(43, 29);
            this.forwardBtn.TabIndex = 4;
            this.forwardBtn.Text = "->";
            this.forwardBtn.UseVisualStyleBackColor = true;
            this.forwardBtn.Click += new System.EventHandler(this.ForwardBtnClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.homeBtn);
            this.panel1.Controls.Add(this.forwardBtn);
            this.panel1.Controls.Add(this.backBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 29);
            this.panel1.TabIndex = 5;
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 52);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(800, 398);
            this.webBrowser.TabIndex = 6;
            this.webBrowser.Url = new System.Uri("https://www.google.com/", System.UriKind.Absolute);
            // 
            // BrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.formBtn);
            this.Name = "BrowserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BrowserForm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button formBtn;
        private System.Windows.Forms.Button homeBtn;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Button forwardBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.WebBrowser webBrowser;
    }
}