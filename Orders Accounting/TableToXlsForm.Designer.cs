namespace Orders_Accounting
{
    partial class TableToXlsForm
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
            this.listBox = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClientsSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.BackColor = System.Drawing.Color.White;
            this.listBox.CheckOnClick = true;
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(12, 25);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(177, 212);
            this.listBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберите поля для вывода:";
            // 
            // buttonClientsSave
            // 
            this.buttonClientsSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(78)))), ((int)(((byte)(123)))));
            this.buttonClientsSave.FlatAppearance.BorderSize = 0;
            this.buttonClientsSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(52)))), ((int)(((byte)(83)))));
            this.buttonClientsSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(105)))), ((int)(((byte)(168)))));
            this.buttonClientsSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClientsSave.ForeColor = System.Drawing.Color.White;
            this.buttonClientsSave.Location = new System.Drawing.Point(12, 248);
            this.buttonClientsSave.Name = "buttonClientsSave";
            this.buttonClientsSave.Size = new System.Drawing.Size(177, 23);
            this.buttonClientsSave.TabIndex = 26;
            this.buttonClientsSave.Text = "Вывести в Excel";
            this.buttonClientsSave.UseVisualStyleBackColor = false;
            this.buttonClientsSave.Click += new System.EventHandler(this.buttonClientsSave_Click);
            // 
            // TableToXlsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(201, 281);
            this.Controls.Add(this.buttonClientsSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox);
            this.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TableToXlsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Вывод в Excel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox listBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClientsSave;
    }
}