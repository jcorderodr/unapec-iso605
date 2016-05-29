namespace Unapec.HumanResourcesM.Forms.Jobs
{
    partial class NewJobOffer
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
            this.label31 = new System.Windows.Forms.Label();
            this.departmentComboBox = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtBoxJobOfferDescription = new System.Windows.Forms.TextBox();
            this.jobPositionComboBox = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxMaxSalary = new System.Windows.Forms.MaskedTextBox();
            this.txtBoxMinSalary = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(40, 101);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(100, 13);
            this.label31.TabIndex = 20;
            this.label31.Text = "Detalles del puesto:";
            // 
            // departmentComboBox
            // 
            this.departmentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.departmentComboBox.FormattingEnabled = true;
            this.departmentComboBox.Location = new System.Drawing.Point(158, 23);
            this.departmentComboBox.Name = "departmentComboBox";
            this.departmentComboBox.Size = new System.Drawing.Size(255, 21);
            this.departmentComboBox.TabIndex = 19;
            this.departmentComboBox.SelectedValueChanged += new System.EventHandler(this.departmentComboBox_SelectedValueChanged);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(63, 26);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(77, 13);
            this.label30.TabIndex = 18;
            this.label30.Text = "Departamento:";
            // 
            // txtBoxJobOfferDescription
            // 
            this.txtBoxJobOfferDescription.Location = new System.Drawing.Point(158, 98);
            this.txtBoxJobOfferDescription.Multiline = true;
            this.txtBoxJobOfferDescription.Name = "txtBoxJobOfferDescription";
            this.txtBoxJobOfferDescription.Size = new System.Drawing.Size(255, 98);
            this.txtBoxJobOfferDescription.TabIndex = 17;
            // 
            // jobPositionComboBox
            // 
            this.jobPositionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jobPositionComboBox.FormattingEnabled = true;
            this.jobPositionComboBox.Location = new System.Drawing.Point(158, 61);
            this.jobPositionComboBox.Name = "jobPositionComboBox";
            this.jobPositionComboBox.Size = new System.Drawing.Size(255, 21);
            this.jobPositionComboBox.TabIndex = 16;
            this.jobPositionComboBox.SelectedValueChanged += new System.EventHandler(this.jobPositionComboBox_SelectedValueChanged);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(90, 64);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(50, 13);
            this.label29.TabIndex = 15;
            this.label29.Text = "Posición:";
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.Location = new System.Drawing.Point(260, 292);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 21;
            this.btnAccept.Text = "Guardar";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(341, 292);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "&Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Máximo salario del puesto:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 253);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Mínimo salario del puesto:";
            // 
            // txtBoxMaxSalary
            // 
            this.txtBoxMaxSalary.Location = new System.Drawing.Point(158, 213);
            this.txtBoxMaxSalary.Mask = "$000,000.00";
            this.txtBoxMaxSalary.Name = "txtBoxMaxSalary";
            this.txtBoxMaxSalary.Size = new System.Drawing.Size(255, 20);
            this.txtBoxMaxSalary.TabIndex = 26;
            this.txtBoxMaxSalary.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtBoxMinSalary
            // 
            this.txtBoxMinSalary.Location = new System.Drawing.Point(158, 250);
            this.txtBoxMinSalary.Mask = "$000,000.00";
            this.txtBoxMinSalary.Name = "txtBoxMinSalary";
            this.txtBoxMinSalary.Size = new System.Drawing.Size(255, 20);
            this.txtBoxMinSalary.TabIndex = 26;
            this.txtBoxMinSalary.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // NewJobOffer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 327);
            this.Controls.Add(this.txtBoxMinSalary);
            this.Controls.Add(this.txtBoxMaxSalary);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.departmentComboBox);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.txtBoxJobOfferDescription);
            this.Controls.Add(this.jobPositionComboBox);
            this.Controls.Add(this.label29);
            this.Name = "NewJobOffer";
            this.Text = "NewJobOffer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.ComboBox departmentComboBox;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtBoxJobOfferDescription;
        private System.Windows.Forms.ComboBox jobPositionComboBox;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtBoxMaxSalary;
        private System.Windows.Forms.MaskedTextBox txtBoxMinSalary;
    }
}