
namespace AudioTest
{
    partial class SettingsForm
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
            this.fillGroup = new System.Windows.Forms.GroupBox();
            this.offRadioBtn = new System.Windows.Forms.RadioButton();
            this.onRadioBtn = new System.Windows.Forms.RadioButton();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.fillGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // fillGroup
            // 
            this.fillGroup.Controls.Add(this.offRadioBtn);
            this.fillGroup.Controls.Add(this.onRadioBtn);
            this.fillGroup.Location = new System.Drawing.Point(12, 12);
            this.fillGroup.Name = "fillGroup";
            this.fillGroup.Size = new System.Drawing.Size(222, 68);
            this.fillGroup.TabIndex = 0;
            this.fillGroup.TabStop = false;
            this.fillGroup.Text = "Поля заполнения";
            // 
            // offRadioBtn
            // 
            this.offRadioBtn.AutoSize = true;
            this.offRadioBtn.Location = new System.Drawing.Point(6, 42);
            this.offRadioBtn.Name = "offRadioBtn";
            this.offRadioBtn.Size = new System.Drawing.Size(85, 17);
            this.offRadioBtn.TabIndex = 1;
            this.offRadioBtn.Text = "Выключены";
            this.offRadioBtn.UseVisualStyleBackColor = true;
            // 
            // onRadioBtn
            // 
            this.onRadioBtn.AutoSize = true;
            this.onRadioBtn.Checked = true;
            this.onRadioBtn.Location = new System.Drawing.Point(6, 19);
            this.onRadioBtn.Name = "onRadioBtn";
            this.onRadioBtn.Size = new System.Drawing.Size(77, 17);
            this.onRadioBtn.TabIndex = 0;
            this.onRadioBtn.TabStop = true;
            this.onRadioBtn.Text = "Включены";
            this.onRadioBtn.UseVisualStyleBackColor = true;
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.okBtn.BackColor = System.Drawing.Color.LightGreen;
            this.okBtn.FlatAppearance.BorderSize = 0;
            this.okBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okBtn.Location = new System.Drawing.Point(0, 86);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(126, 33);
            this.okBtn.TabIndex = 1;
            this.okBtn.Text = "Ок";
            this.okBtn.UseVisualStyleBackColor = false;
            this.okBtn.Click += new System.EventHandler(this.AcceptChanges);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.BackColor = System.Drawing.Color.IndianRed;
            this.cancelBtn.FlatAppearance.BorderSize = 0;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.Location = new System.Drawing.Point(126, 86);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(126, 33);
            this.cancelBtn.TabIndex = 2;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.DiscardChanges);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 116);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.fillGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.fillGroup.ResumeLayout(false);
            this.fillGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox fillGroup;
        private System.Windows.Forms.RadioButton offRadioBtn;
        private System.Windows.Forms.RadioButton onRadioBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}