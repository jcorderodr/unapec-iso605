namespace Unapec.HumanResourcesM.Forms.Candidates
{
    partial class EmployeeSelectionFromCandidate
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
            this.components = new System.ComponentModel.Container();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.applicantModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.jobOfferComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.markAsDiscardedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectApplicantAndCloseJobOfferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ColumnMark = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.identificationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.applicationDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birthDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneHouseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneCellDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gradingLevelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicantModelBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(808, 278);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Aplicantes al puesto";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnMark,
            this.ColumnId,
            this.identificationDataGridViewTextBoxColumn,
            this.applicationDateDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.lastNameDataGridViewTextBoxColumn,
            this.birthDateDataGridViewTextBoxColumn,
            this.phoneHouseDataGridViewTextBoxColumn,
            this.phoneCellDataGridViewTextBoxColumn,
            this.gradingLevelDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.applicantModelBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(802, 259);
            this.dataGridView1.TabIndex = 0;
            // 
            // applicantModelBindingSource
            // 
            this.applicantModelBindingSource.DataSource = typeof(Unapec.HumanResourcesM.Models.ApplicantModel);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.jobOfferComboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(808, 67);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Búsqueda";
            // 
            // jobOfferComboBox
            // 
            this.jobOfferComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jobOfferComboBox.FormattingEnabled = true;
            this.jobOfferComboBox.Location = new System.Drawing.Point(181, 27);
            this.jobOfferComboBox.Name = "jobOfferComboBox";
            this.jobOfferComboBox.Size = new System.Drawing.Size(199, 21);
            this.jobOfferComboBox.TabIndex = 1;
            this.jobOfferComboBox.SelectedValueChanged += new System.EventHandler(this.jobOfferComboBox_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vacante:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(808, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.markAsDiscardedToolStripMenuItem,
            this.selectApplicantAndCloseJobOfferToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.optionsToolStripMenuItem.Text = "Opciones";
            // 
            // markAsDiscardedToolStripMenuItem
            // 
            this.markAsDiscardedToolStripMenuItem.Name = "markAsDiscardedToolStripMenuItem";
            this.markAsDiscardedToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
            this.markAsDiscardedToolStripMenuItem.Text = "Marcar como descartados";
            this.markAsDiscardedToolStripMenuItem.Click += new System.EventHandler(this.markAsDiscardedToolStripMenuItem_Click);
            // 
            // selectApplicantAndCloseJobOfferToolStripMenuItem
            // 
            this.selectApplicantAndCloseJobOfferToolStripMenuItem.Name = "selectApplicantAndCloseJobOfferToolStripMenuItem";
            this.selectApplicantAndCloseJobOfferToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
            this.selectApplicantAndCloseJobOfferToolStripMenuItem.Text = "Seleccionar Candidatos y Cerrar Vacante";
            this.selectApplicantAndCloseJobOfferToolStripMenuItem.Click += new System.EventHandler(this.selectApplicantAndCloseJobOfferToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(283, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
            this.exitToolStripMenuItem.Text = "Salir";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // ColumnMark
            // 
            this.ColumnMark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ColumnMark.HeaderText = "Seleccionar";
            this.ColumnMark.Name = "ColumnMark";
            this.ColumnMark.ReadOnly = true;
            this.ColumnMark.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnMark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnMark.Width = 88;
            // 
            // ColumnId
            // 
            this.ColumnId.DataPropertyName = "ApplicantId";
            this.ColumnId.HeaderText = "ColumnId";
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.ReadOnly = true;
            this.ColumnId.Visible = false;
            // 
            // identificationDataGridViewTextBoxColumn
            // 
            this.identificationDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.identificationDataGridViewTextBoxColumn.DataPropertyName = "Identification";
            this.identificationDataGridViewTextBoxColumn.HeaderText = "Cédula";
            this.identificationDataGridViewTextBoxColumn.Name = "identificationDataGridViewTextBoxColumn";
            this.identificationDataGridViewTextBoxColumn.ReadOnly = true;
            this.identificationDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.identificationDataGridViewTextBoxColumn.Width = 65;
            // 
            // applicationDateDataGridViewTextBoxColumn
            // 
            this.applicationDateDataGridViewTextBoxColumn.DataPropertyName = "ApplicationDate";
            this.applicationDateDataGridViewTextBoxColumn.HeaderText = "Fecha de Solicitud";
            this.applicationDateDataGridViewTextBoxColumn.Name = "applicationDateDataGridViewTextBoxColumn";
            this.applicationDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lastNameDataGridViewTextBoxColumn
            // 
            this.lastNameDataGridViewTextBoxColumn.DataPropertyName = "LastName";
            this.lastNameDataGridViewTextBoxColumn.HeaderText = "Apellido";
            this.lastNameDataGridViewTextBoxColumn.Name = "lastNameDataGridViewTextBoxColumn";
            this.lastNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // birthDateDataGridViewTextBoxColumn
            // 
            this.birthDateDataGridViewTextBoxColumn.DataPropertyName = "BirthDate";
            this.birthDateDataGridViewTextBoxColumn.HeaderText = "Fecha de Nacimiento";
            this.birthDateDataGridViewTextBoxColumn.Name = "birthDateDataGridViewTextBoxColumn";
            this.birthDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // phoneHouseDataGridViewTextBoxColumn
            // 
            this.phoneHouseDataGridViewTextBoxColumn.DataPropertyName = "PhoneHouse";
            this.phoneHouseDataGridViewTextBoxColumn.HeaderText = "Tel. Residencial";
            this.phoneHouseDataGridViewTextBoxColumn.Name = "phoneHouseDataGridViewTextBoxColumn";
            this.phoneHouseDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // phoneCellDataGridViewTextBoxColumn
            // 
            this.phoneCellDataGridViewTextBoxColumn.DataPropertyName = "PhoneCell";
            this.phoneCellDataGridViewTextBoxColumn.HeaderText = "Tel. Móvil";
            this.phoneCellDataGridViewTextBoxColumn.Name = "phoneCellDataGridViewTextBoxColumn";
            this.phoneCellDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gradingLevelDataGridViewTextBoxColumn
            // 
            this.gradingLevelDataGridViewTextBoxColumn.DataPropertyName = "GradingLevel";
            this.gradingLevelDataGridViewTextBoxColumn.HeaderText = "Grado Profesional";
            this.gradingLevelDataGridViewTextBoxColumn.Name = "gradingLevelDataGridViewTextBoxColumn";
            this.gradingLevelDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // EmployeeSelectionFromCandidate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 369);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "EmployeeSelectionFromCandidate";
            this.Text = "EmployeeSelectionFromCandidate";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicantModelBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectApplicantAndCloseJobOfferToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox jobOfferComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource applicantModelBindingSource;
        private System.Windows.Forms.ToolStripMenuItem markAsDiscardedToolStripMenuItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn identificationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn applicationDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn birthDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneHouseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneCellDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gradingLevelDataGridViewTextBoxColumn;
    }
}