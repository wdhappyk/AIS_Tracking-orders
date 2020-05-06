namespace Orders_Accounting
{
    partial class EditEmployeeForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fullNameInput = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelPosition = new System.Windows.Forms.Label();
            this.daysInput = new System.Windows.Forms.NumericUpDown();
            this.rateInput = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.workStageStaffTableAdapter = new Orders_Accounting.dbDataSetTableAdapters.WorkStageStaffTableAdapter();
            this.staffTableAdapter = new Orders_Accounting.dbDataSetTableAdapters.StaffTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.daysInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rateInput)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Специалист*:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Должность:";
            // 
            // fullNameInput
            // 
            this.fullNameInput.BackColor = System.Drawing.Color.White;
            this.fullNameInput.Location = new System.Drawing.Point(140, 12);
            this.fullNameInput.MaxLength = 15;
            this.fullNameInput.Name = "fullNameInput";
            this.fullNameInput.ReadOnly = true;
            this.fullNameInput.Size = new System.Drawing.Size(182, 21);
            this.fullNameInput.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(329, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 21);
            this.button1.TabIndex = 2;
            this.button1.Text = "Выбрать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Трудозатраты (дней)*:";
            // 
            // labelPosition
            // 
            this.labelPosition.AutoSize = true;
            this.labelPosition.Location = new System.Drawing.Point(137, 41);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(10, 13);
            this.labelPosition.TabIndex = 8;
            this.labelPosition.Text = "-";
            // 
            // daysInput
            // 
            this.daysInput.Location = new System.Drawing.Point(140, 65);
            this.daysInput.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.daysInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.daysInput.Name = "daysInput";
            this.daysInput.Size = new System.Drawing.Size(250, 21);
            this.daysInput.TabIndex = 3;
            this.daysInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rateInput
            // 
            this.rateInput.DecimalPlaces = 2;
            this.rateInput.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.rateInput.Location = new System.Drawing.Point(140, 92);
            this.rateInput.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.rateInput.Name = "rateInput";
            this.rateInput.Size = new System.Drawing.Size(250, 21);
            this.rateInput.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Ставка (руб/час)*:";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(78)))), ((int)(((byte)(123)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(52)))), ((int)(((byte)(83)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(105)))), ((int)(((byte)(168)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(140, 119);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(250, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Сохранить";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // workStageStaffTableAdapter
            // 
            this.workStageStaffTableAdapter.ClearBeforeFill = true;
            // 
            // staffTableAdapter
            // 
            this.staffTableAdapter.ClearBeforeFill = true;
            // 
            // EditEmployeeForm
            // 
            this.AcceptButton = this.button2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(403, 152);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.rateInput);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.daysInput);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelPosition);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fullNameInput);
            this.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EditEmployeeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Специалист";
            this.Load += new System.EventHandler(this.EditEmployeeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.daysInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rateInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox fullNameInput;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.NumericUpDown daysInput;
        private System.Windows.Forms.NumericUpDown rateInput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private dbDataSetTableAdapters.WorkStageStaffTableAdapter workStageStaffTableAdapter;
        private dbDataSetTableAdapters.StaffTableAdapter staffTableAdapter;
    }
}