
namespace JSON_HOMEWORK
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
            this.tabControlller = new System.Windows.Forms.TabControl();
            this.workersPage = new System.Windows.Forms.TabPage();
            this.workersDataGridView = new System.Windows.Forms.DataGridView();
            this.workerIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workerNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workerAgeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workerSexColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workerProfessionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.visitorsPage = new System.Windows.Forms.TabPage();
            this.visitorGridView = new System.Windows.Forms.DataGridView();
            this.visitorIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.visitorNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.visitorAgeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.visitorSexColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.visitorCashColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.visitorAimColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.visitorDaysColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.visitorBaggageWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baggagePage = new System.Windows.Forms.TabPage();
            this.cellsGridView = new System.Windows.Forms.DataGridView();
            this.cellIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.infoPage = new System.Windows.Forms.TabPage();
            this.profitLabel = new System.Windows.Forms.Label();
            this.maxQueueLabel = new System.Windows.Forms.Label();
            this.locationLabel = new System.Windows.Forms.Label();
            this.tabControlller.SuspendLayout();
            this.workersPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.workersDataGridView)).BeginInit();
            this.visitorsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.visitorGridView)).BeginInit();
            this.baggagePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cellsGridView)).BeginInit();
            this.infoPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlller
            // 
            this.tabControlller.Controls.Add(this.workersPage);
            this.tabControlller.Controls.Add(this.visitorsPage);
            this.tabControlller.Controls.Add(this.baggagePage);
            this.tabControlller.Controls.Add(this.infoPage);
            this.tabControlller.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlller.Location = new System.Drawing.Point(0, 0);
            this.tabControlller.Name = "tabControlller";
            this.tabControlller.SelectedIndex = 0;
            this.tabControlller.Size = new System.Drawing.Size(800, 450);
            this.tabControlller.TabIndex = 0;
            // 
            // workersPage
            // 
            this.workersPage.Controls.Add(this.workersDataGridView);
            this.workersPage.Location = new System.Drawing.Point(4, 22);
            this.workersPage.Name = "workersPage";
            this.workersPage.Padding = new System.Windows.Forms.Padding(3);
            this.workersPage.Size = new System.Drawing.Size(792, 424);
            this.workersPage.TabIndex = 0;
            this.workersPage.Text = "Работники";
            this.workersPage.UseVisualStyleBackColor = true;
            // 
            // workersDataGridView
            // 
            this.workersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.workersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.workersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.workerIdColumn,
            this.workerNameColumn,
            this.workerAgeColumn,
            this.workerSexColumn,
            this.workerProfessionColumn});
            this.workersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workersDataGridView.Location = new System.Drawing.Point(3, 3);
            this.workersDataGridView.Name = "workersDataGridView";
            this.workersDataGridView.Size = new System.Drawing.Size(786, 418);
            this.workersDataGridView.TabIndex = 0;
            // 
            // workerIdColumn
            // 
            this.workerIdColumn.HeaderText = "ID";
            this.workerIdColumn.Name = "workerIdColumn";
            this.workerIdColumn.ReadOnly = true;
            // 
            // workerNameColumn
            // 
            this.workerNameColumn.HeaderText = "Имя";
            this.workerNameColumn.Name = "workerNameColumn";
            this.workerNameColumn.ReadOnly = true;
            // 
            // workerAgeColumn
            // 
            this.workerAgeColumn.HeaderText = "Возраст";
            this.workerAgeColumn.Name = "workerAgeColumn";
            this.workerAgeColumn.ReadOnly = true;
            // 
            // workerSexColumn
            // 
            this.workerSexColumn.HeaderText = "Пол";
            this.workerSexColumn.Name = "workerSexColumn";
            this.workerSexColumn.ReadOnly = true;
            // 
            // workerProfessionColumn
            // 
            this.workerProfessionColumn.HeaderText = "Професия";
            this.workerProfessionColumn.Name = "workerProfessionColumn";
            this.workerProfessionColumn.ReadOnly = true;
            // 
            // visitorsPage
            // 
            this.visitorsPage.Controls.Add(this.visitorGridView);
            this.visitorsPage.Location = new System.Drawing.Point(4, 22);
            this.visitorsPage.Name = "visitorsPage";
            this.visitorsPage.Padding = new System.Windows.Forms.Padding(3);
            this.visitorsPage.Size = new System.Drawing.Size(792, 424);
            this.visitorsPage.TabIndex = 1;
            this.visitorsPage.Text = "Клиенты";
            this.visitorsPage.UseVisualStyleBackColor = true;
            // 
            // visitorGridView
            // 
            this.visitorGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.visitorGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.visitorGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.visitorIdColumn,
            this.visitorNameColumn,
            this.visitorAgeColumn,
            this.visitorSexColumn,
            this.visitorCashColumn,
            this.visitorAimColumn,
            this.visitorDaysColumn,
            this.visitorBaggageWeight});
            this.visitorGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visitorGridView.Location = new System.Drawing.Point(3, 3);
            this.visitorGridView.Name = "visitorGridView";
            this.visitorGridView.Size = new System.Drawing.Size(786, 418);
            this.visitorGridView.TabIndex = 1;
            // 
            // visitorIdColumn
            // 
            this.visitorIdColumn.HeaderText = "ID";
            this.visitorIdColumn.Name = "visitorIdColumn";
            this.visitorIdColumn.ReadOnly = true;
            // 
            // visitorNameColumn
            // 
            this.visitorNameColumn.HeaderText = "Имя";
            this.visitorNameColumn.Name = "visitorNameColumn";
            this.visitorNameColumn.ReadOnly = true;
            // 
            // visitorAgeColumn
            // 
            this.visitorAgeColumn.HeaderText = "Возраст";
            this.visitorAgeColumn.Name = "visitorAgeColumn";
            this.visitorAgeColumn.ReadOnly = true;
            // 
            // visitorSexColumn
            // 
            this.visitorSexColumn.HeaderText = "Пол";
            this.visitorSexColumn.Name = "visitorSexColumn";
            this.visitorSexColumn.ReadOnly = true;
            // 
            // visitorCashColumn
            // 
            this.visitorCashColumn.HeaderText = "Денежки)";
            this.visitorCashColumn.Name = "visitorCashColumn";
            this.visitorCashColumn.ReadOnly = true;
            // 
            // visitorAimColumn
            // 
            this.visitorAimColumn.HeaderText = "Цель";
            this.visitorAimColumn.Name = "visitorAimColumn";
            this.visitorAimColumn.ReadOnly = true;
            // 
            // visitorDaysColumn
            // 
            this.visitorDaysColumn.HeaderText = "Количество дней на которое оставит багаж";
            this.visitorDaysColumn.Name = "visitorDaysColumn";
            this.visitorDaysColumn.ReadOnly = true;
            // 
            // visitorBaggageWeight
            // 
            this.visitorBaggageWeight.HeaderText = "Вес багажа";
            this.visitorBaggageWeight.Name = "visitorBaggageWeight";
            this.visitorBaggageWeight.ReadOnly = true;
            // 
            // baggagePage
            // 
            this.baggagePage.Controls.Add(this.cellsGridView);
            this.baggagePage.Location = new System.Drawing.Point(4, 22);
            this.baggagePage.Name = "baggagePage";
            this.baggagePage.Size = new System.Drawing.Size(792, 424);
            this.baggagePage.TabIndex = 2;
            this.baggagePage.Text = "Хранилище";
            this.baggagePage.UseVisualStyleBackColor = true;
            // 
            // cellsGridView
            // 
            this.cellsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.cellsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cellsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cellIdColumn,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.cellsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cellsGridView.Location = new System.Drawing.Point(0, 0);
            this.cellsGridView.Name = "cellsGridView";
            this.cellsGridView.Size = new System.Drawing.Size(792, 424);
            this.cellsGridView.TabIndex = 1;
            // 
            // cellIdColumn
            // 
            this.cellIdColumn.HeaderText = "Id Ячейки";
            this.cellIdColumn.Name = "cellIdColumn";
            this.cellIdColumn.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Допустимая масса";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Id багажа";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Id Владельца";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Масса багажа";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Цвет багажа";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // infoPage
            // 
            this.infoPage.Controls.Add(this.profitLabel);
            this.infoPage.Controls.Add(this.maxQueueLabel);
            this.infoPage.Controls.Add(this.locationLabel);
            this.infoPage.Location = new System.Drawing.Point(4, 22);
            this.infoPage.Name = "infoPage";
            this.infoPage.Size = new System.Drawing.Size(792, 424);
            this.infoPage.TabIndex = 3;
            this.infoPage.Text = "Информация";
            this.infoPage.UseVisualStyleBackColor = true;
            // 
            // profitLabel
            // 
            this.profitLabel.AutoSize = true;
            this.profitLabel.Location = new System.Drawing.Point(8, 35);
            this.profitLabel.Name = "profitLabel";
            this.profitLabel.Size = new System.Drawing.Size(45, 13);
            this.profitLabel.TabIndex = 2;
            this.profitLabel.Text = "Доход: ";
            // 
            // maxQueueLabel
            // 
            this.maxQueueLabel.AutoSize = true;
            this.maxQueueLabel.Location = new System.Drawing.Point(8, 22);
            this.maxQueueLabel.Name = "maxQueueLabel";
            this.maxQueueLabel.Size = new System.Drawing.Size(167, 13);
            this.maxQueueLabel.TabIndex = 1;
            this.maxQueueLabel.Text = "Максимальная длина очереди: ";
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Location = new System.Drawing.Point(8, 9);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(98, 13);
            this.locationLabel.TabIndex = 0;
            this.locationLabel.Text = "Местоположение:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControlller);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Чтение JSON";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControlller.ResumeLayout(false);
            this.workersPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.workersDataGridView)).EndInit();
            this.visitorsPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.visitorGridView)).EndInit();
            this.baggagePage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cellsGridView)).EndInit();
            this.infoPage.ResumeLayout(false);
            this.infoPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlller;
        private System.Windows.Forms.TabPage workersPage;
        private System.Windows.Forms.TabPage visitorsPage;
        private System.Windows.Forms.TabPage baggagePage;
        private System.Windows.Forms.TabPage infoPage;
        private System.Windows.Forms.DataGridView workersDataGridView;
        private System.Windows.Forms.DataGridView visitorGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn visitorIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn visitorNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn visitorAgeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn visitorSexColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn visitorCashColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn visitorAimColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn visitorDaysColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn visitorBaggageWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn workerIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn workerNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn workerAgeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn workerSexColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn workerProfessionColumn;
        private System.Windows.Forms.DataGridView cellsGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn cellIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Label profitLabel;
        private System.Windows.Forms.Label maxQueueLabel;
        private System.Windows.Forms.Label locationLabel;
    }
}

