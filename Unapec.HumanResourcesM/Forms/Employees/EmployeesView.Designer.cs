namespace Unapec.HumanResourcesM.Forms.Employees
{
    partial class EmployeesView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.actionButtonCreateNewEmployee = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.employeeDataGridView = new System.Windows.Forms.DataGridView();
            this.lastNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registeredDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneCellDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.positionNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departmentNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.refreshSearchButton = new System.Windows.Forms.Button();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.employeeStatusComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.departmentComboBox = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.jobPositionComboBox = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.btnAcceptSelection = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeViewModelBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // actionButtonCreateNewEmployee
            // 
            this.actionButtonCreateNewEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.actionButtonCreateNewEmployee.Image = global::Unapec.HumanResourcesM.Properties.Resources.add;
            this.actionButtonCreateNewEmployee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.actionButtonCreateNewEmployee.Location = new System.Drawing.Point(12, 327);
            this.actionButtonCreateNewEmployee.Name = "actionButtonCreateNewEmployee";
            this.actionButtonCreateNewEmployee.Size = new System.Drawing.Size(142, 23);
            this.actionButtonCreateNewEmployee.TabIndex = 0;
            this.actionButtonCreateNewEmployee.Text = "Crear nuevo empleado";
            this.actionButtonCreateNewEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.actionButtonCreateNewEmployee.UseVisualStyleBackColor = true;
            this.actionButtonCreateNewEmployee.Click += new System.EventHandler(this.actionButtonCreateNewEmployee_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.employeeDataGridView);
            this.groupBox1.Location = new System.Drawing.Point(0, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(772, 224);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listado de Empleados";
            // 
            // employeeDataGridView
            // 
            this.employeeDataGridView.AllowUserToAddRows = false;
            this.employeeDataGridView.AllowUserToDeleteRows = false;
            this.employeeDataGridView.AutoGenerateColumns = false;
            this.employeeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.employeeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lastNameDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.registeredDateDataGridViewTextBoxColumn,
            this.phoneCellDataGridViewTextBoxColumn,
            this.positionNameDataGridViewTextBoxColumn,
            this.departmentNameDataGridViewTextBoxColumn});
            this.employeeDataGridView.DataSource = this.employeeViewModelBindingSource;
            this.employeeDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employeeDataGridView.Location = new System.Drawing.Point(3, 16);
            this.employeeDataGridView.Name = "employeeDataGridView";
            this.employeeDataGridView.ReadOnly = true;
            this.employeeDataGridView.Size = new System.Drawing.Size(766, 205);
            this.employeeDataGridView.TabIndex = 0;
            // 
            // lastNameDataGridViewTextBoxColumn
            // 
            this.lastNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.lastNameDataGridViewTextBoxColumn.DataPropertyName = "LastName";
            this.lastNameDataGridViewTextBoxColumn.HeaderText = "Apellidos";
            this.lastNameDataGridViewTextBoxColumn.Name = "lastNameDataGridViewTextBoxColumn";
            this.lastNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastNameDataGridViewTextBoxColumn.Width = 74;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Nombres";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 74;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Estado";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // registeredDateDataGridViewTextBoxColumn
            // 
            this.registeredDateDataGridViewTextBoxColumn.DataPropertyName = "RegisteredDate";
            dataGridViewCellStyle1.Format = "D";
            dataGridViewCellStyle1.NullValue = null;
            this.registeredDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.registeredDateDataGridViewTextBoxColumn.HeaderText = "Fecha de Ingreso";
            this.registeredDateDataGridViewTextBoxColumn.Name = "registeredDateDataGridViewTextBoxColumn";
            this.registeredDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // phoneCellDataGridViewTextBoxColumn
            // 
            this.phoneCellDataGridViewTextBoxColumn.DataPropertyName = "PhoneCell";
            this.phoneCellDataGridViewTextBoxColumn.HeaderText = "Celular";
            this.phoneCellDataGridViewTextBoxColumn.Name = "phoneCellDataGridViewTextBoxColumn";
            this.phoneCellDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // positionNameDataGridViewTextBoxColumn
            // 
            this.positionNameDataGridViewTextBoxColumn.DataPropertyName = "PositionName";
            this.positionNameDataGridViewTextBoxColumn.HeaderText = "Puesto";
            this.positionNameDataGridViewTextBoxColumn.Name = "positionNameDataGridViewTextBoxColumn";
            this.positionNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // departmentNameDataGridViewTextBoxColumn
            // 
            this.departmentNameDataGridViewTextBoxColumn.DataPropertyName = "DepartmentName";
            this.departmentNameDataGridViewTextBoxColumn.HeaderText = "Departamento";
            this.departmentNameDataGridViewTextBoxColumn.Name = "departmentNameDataGridViewTextBoxColumn";
            this.departmentNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // employeeViewModelBindingSource
            // 
            this.employeeViewModelBindingSource.DataSource = typeof(Unapec.HumanResourcesM.Models.EmployeeViewModel);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.refreshSearchButton);
            this.groupBox2.Controls.Add(this.txtBoxName);
            this.groupBox2.Controls.Add(this.employeeStatusComboBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.departmentComboBox);
            this.groupBox2.Controls.Add(this.label30);
            this.groupBox2.Controls.Add(this.jobPositionComboBox);
            this.groupBox2.Controls.Add(this.label29);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(772, 91);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Opciones de Filtrado";
            // 
            // refreshSearchButton
            // 
            this.refreshSearchButton.Image = global::Unapec.HumanResourcesM.Properties.Resources.search_32;
            this.refreshSearchButton.Location = new System.Drawing.Point(707, 32);
            this.refreshSearchButton.Name = "refreshSearchButton";
            this.refreshSearchButton.Size = new System.Drawing.Size(53, 48);
            this.refreshSearchButton.TabIndex = 4;
            this.refreshSearchButton.UseVisualStyleBackColor = true;
            this.refreshSearchButton.Click += new System.EventHandler(this.refreshSearchButton_Click);
            // 
            // txtBoxName
            // 
            this.txtBoxName.Location = new System.Drawing.Point(70, 19);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(193, 20);
            this.txtBoxName.TabIndex = 0;
            // 
            // employeeStatusComboBox
            // 
            this.employeeStatusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.employeeStatusComboBox.FormattingEnabled = true;
            this.employeeStatusComboBox.Location = new System.Drawing.Point(70, 57);
            this.employeeStatusComboBox.Name = "employeeStatusComboBox";
            this.employeeStatusComboBox.Size = new System.Drawing.Size(193, 21);
            this.employeeStatusComboBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Estado:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Nombre:";
            // 
            // departmentComboBox
            // 
            this.departmentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.departmentComboBox.FormattingEnabled = true;
            this.departmentComboBox.Location = new System.Drawing.Point(398, 19);
            this.departmentComboBox.Name = "departmentComboBox";
            this.departmentComboBox.Size = new System.Drawing.Size(255, 21);
            this.departmentComboBox.TabIndex = 1;
            this.departmentComboBox.SelectedValueChanged += new System.EventHandler(this.departmentComboBox_SelectedValueChanged);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(304, 22);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(77, 13);
            this.label30.TabIndex = 16;
            this.label30.Text = "Departamento:";
            // 
            // jobPositionComboBox
            // 
            this.jobPositionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jobPositionComboBox.FormattingEnabled = true;
            this.jobPositionComboBox.Location = new System.Drawing.Point(398, 57);
            this.jobPositionComboBox.Name = "jobPositionComboBox";
            this.jobPositionComboBox.Size = new System.Drawing.Size(255, 21);
            this.jobPositionComboBox.TabIndex = 3;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(331, 60);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(50, 13);
            this.label29.TabIndex = 14;
            this.label29.Text = "Posición:";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Image = global::Unapec.HumanResourcesM.Properties.Resources.close_16px;
            this.cancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelButton.Location = new System.Drawing.Point(685, 327);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "&Cancelar";
            this.cancelButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // btnAcceptSelection
            // 
            this.btnAcceptSelection.Image = global::Unapec.HumanResourcesM.Properties.Resources.interface_16px;
            this.btnAcceptSelection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAcceptSelection.Location = new System.Drawing.Point(549, 327);
            this.btnAcceptSelection.Name = "btnAcceptSelection";
            this.btnAcceptSelection.Size = new System.Drawing.Size(130, 23);
            this.btnAcceptSelection.TabIndex = 0;
            this.btnAcceptSelection.Text = "Elegir Seleccionados";
            this.btnAcceptSelection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAcceptSelection.UseVisualStyleBackColor = true;
            this.btnAcceptSelection.Click += new System.EventHandler(this.btnAcceptSelection_Click);
            // 
            // EmployeesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 362);
            this.Controls.Add(this.btnAcceptSelection);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.actionButtonCreateNewEmployee);
            this.Name = "EmployeesView";
            this.Text = "EmployeesView";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.employeeDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeViewModelBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button actionButtonCreateNewEmployee;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView employeeDataGridView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.ComboBox employeeStatusComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox departmentComboBox;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBox jobPositionComboBox;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Button refreshSearchButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn registeredDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneCellDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource employeeViewModelBindingSource;
        private System.Windows.Forms.Button btnAcceptSelection;
    }
}