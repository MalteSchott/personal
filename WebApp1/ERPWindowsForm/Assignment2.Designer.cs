namespace ERPWindowsForm
{
    partial class Assignment2
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
            this.BackButton = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.Table1Button = new System.Windows.Forms.Button();
            this.Table2Button = new System.Windows.Forms.Button();
            this.IndexButton = new System.Windows.Forms.Button();
            this.RelativesButton = new System.Windows.Forms.Button();
            this.empIDTxt = new System.Windows.Forms.TextBox();
            this.empIDLbl = new System.Windows.Forms.Label();
            this.EmployeeInfoButton = new System.Windows.Forms.Button();
            this.EmployeeColumns1Button = new System.Windows.Forms.Button();
            this.EmployeeColumns2Button = new System.Windows.Forms.Button();
            this.ConstraintsButton = new System.Windows.Forms.Button();
            this.EmployeeLbl = new System.Windows.Forms.Label();
            this.KeysButton = new System.Windows.Forms.Button();
            this.Sick2004Button = new System.Windows.Forms.Button();
            this.AbsenseButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.MetaButton = new System.Windows.Forms.Button();
            this.AllEmployeeButton = new System.Windows.Forms.Button();
            this.ResponseLbl2 = new System.Windows.Forms.Label();
            this.ResponseLbl1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(12, 12);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(52, 23);
            this.BackButton.TabIndex = 0;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // listView
            // 
            this.listView.Location = new System.Drawing.Point(16, 107);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(958, 463);
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            // 
            // Table1Button
            // 
            this.Table1Button.Location = new System.Drawing.Point(96, 23);
            this.Table1Button.Name = "Table1Button";
            this.Table1Button.Size = new System.Drawing.Size(90, 30);
            this.Table1Button.TabIndex = 2;
            this.Table1Button.Text = "All Tables 1";
            this.Table1Button.UseVisualStyleBackColor = true;
            this.Table1Button.Click += new System.EventHandler(this.Table1Button_Click);
            // 
            // Table2Button
            // 
            this.Table2Button.Location = new System.Drawing.Point(96, 59);
            this.Table2Button.Name = "Table2Button";
            this.Table2Button.Size = new System.Drawing.Size(90, 30);
            this.Table2Button.TabIndex = 3;
            this.Table2Button.Text = "All Tables 2";
            this.Table2Button.UseVisualStyleBackColor = true;
            this.Table2Button.Click += new System.EventHandler(this.Table2Button_Click);
            // 
            // IndexButton
            // 
            this.IndexButton.Location = new System.Drawing.Point(192, 59);
            this.IndexButton.Name = "IndexButton";
            this.IndexButton.Size = new System.Drawing.Size(86, 30);
            this.IndexButton.TabIndex = 4;
            this.IndexButton.Text = "All Indexes";
            this.IndexButton.UseVisualStyleBackColor = true;
            this.IndexButton.Click += new System.EventHandler(this.IndexButton_Click);
            // 
            // RelativesButton
            // 
            this.RelativesButton.Location = new System.Drawing.Point(889, 36);
            this.RelativesButton.Name = "RelativesButton";
            this.RelativesButton.Size = new System.Drawing.Size(85, 30);
            this.RelativesButton.TabIndex = 5;
            this.RelativesButton.Text = "Relatives";
            this.RelativesButton.UseVisualStyleBackColor = true;
            this.RelativesButton.Click += new System.EventHandler(this.RelativesButton_Click);
            // 
            // empIDTxt
            // 
            this.empIDTxt.Location = new System.Drawing.Point(840, 5);
            this.empIDTxt.Name = "empIDTxt";
            this.empIDTxt.Size = new System.Drawing.Size(134, 20);
            this.empIDTxt.TabIndex = 6;
            // 
            // empIDLbl
            // 
            this.empIDLbl.AutoSize = true;
            this.empIDLbl.Location = new System.Drawing.Point(764, 9);
            this.empIDLbl.Name = "empIDLbl";
            this.empIDLbl.Size = new System.Drawing.Size(70, 13);
            this.empIDLbl.TabIndex = 7;
            this.empIDLbl.Text = "Employee ID:";
            // 
            // EmployeeInfoButton
            // 
            this.EmployeeInfoButton.Location = new System.Drawing.Point(799, 36);
            this.EmployeeInfoButton.Name = "EmployeeInfoButton";
            this.EmployeeInfoButton.Size = new System.Drawing.Size(84, 30);
            this.EmployeeInfoButton.TabIndex = 8;
            this.EmployeeInfoButton.Text = "Information";
            this.EmployeeInfoButton.UseVisualStyleBackColor = true;
            this.EmployeeInfoButton.Click += new System.EventHandler(this.EmployeeInfoButton_Click);
            // 
            // EmployeeColumns1Button
            // 
            this.EmployeeColumns1Button.Location = new System.Drawing.Point(502, 36);
            this.EmployeeColumns1Button.Name = "EmployeeColumns1Button";
            this.EmployeeColumns1Button.Size = new System.Drawing.Size(83, 29);
            this.EmployeeColumns1Button.TabIndex = 9;
            this.EmployeeColumns1Button.Text = "Columns1";
            this.EmployeeColumns1Button.UseVisualStyleBackColor = true;
            this.EmployeeColumns1Button.Click += new System.EventHandler(this.EmployeeColumns1Button_Click);
            // 
            // EmployeeColumns2Button
            // 
            this.EmployeeColumns2Button.Location = new System.Drawing.Point(591, 36);
            this.EmployeeColumns2Button.Name = "EmployeeColumns2Button";
            this.EmployeeColumns2Button.Size = new System.Drawing.Size(83, 29);
            this.EmployeeColumns2Button.TabIndex = 10;
            this.EmployeeColumns2Button.Text = "Columns2";
            this.EmployeeColumns2Button.UseVisualStyleBackColor = true;
            this.EmployeeColumns2Button.Click += new System.EventHandler(this.EmployeeColumns2Button_Click);
            // 
            // ConstraintsButton
            // 
            this.ConstraintsButton.Location = new System.Drawing.Point(284, 23);
            this.ConstraintsButton.Name = "ConstraintsButton";
            this.ConstraintsButton.Size = new System.Drawing.Size(87, 30);
            this.ConstraintsButton.TabIndex = 11;
            this.ConstraintsButton.Text = "All Constraints";
            this.ConstraintsButton.UseVisualStyleBackColor = true;
            this.ConstraintsButton.Click += new System.EventHandler(this.ConstraintsButton_Click);
            // 
            // EmployeeLbl
            // 
            this.EmployeeLbl.AutoSize = true;
            this.EmployeeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.EmployeeLbl.Location = new System.Drawing.Point(415, 3);
            this.EmployeeLbl.Name = "EmployeeLbl";
            this.EmployeeLbl.Size = new System.Drawing.Size(82, 20);
            this.EmployeeLbl.TabIndex = 12;
            this.EmployeeLbl.Text = "Employee";
            // 
            // KeysButton
            // 
            this.KeysButton.Location = new System.Drawing.Point(192, 23);
            this.KeysButton.Name = "KeysButton";
            this.KeysButton.Size = new System.Drawing.Size(86, 30);
            this.KeysButton.TabIndex = 13;
            this.KeysButton.Text = "All Keys";
            this.KeysButton.UseVisualStyleBackColor = true;
            this.KeysButton.Click += new System.EventHandler(this.KeysButton_Click);
            // 
            // Sick2004Button
            // 
            this.Sick2004Button.Location = new System.Drawing.Point(502, 72);
            this.Sick2004Button.Name = "Sick2004Button";
            this.Sick2004Button.Size = new System.Drawing.Size(115, 29);
            this.Sick2004Button.TabIndex = 14;
            this.Sick2004Button.Text = "Absent during 2004";
            this.Sick2004Button.UseVisualStyleBackColor = true;
            this.Sick2004Button.Click += new System.EventHandler(this.Sick2004Button_Click);
            // 
            // AbsenseButton
            // 
            this.AbsenseButton.Location = new System.Drawing.Point(623, 72);
            this.AbsenseButton.Name = "AbsenseButton";
            this.AbsenseButton.Size = new System.Drawing.Size(100, 29);
            this.AbsenseButton.TabIndex = 15;
            this.AbsenseButton.Text = "Longest absense";
            this.AbsenseButton.UseVisualStyleBackColor = true;
            this.AbsenseButton.Click += new System.EventHandler(this.AbsenseButton_Click);
            // 
            // MetaButton
            // 
            this.MetaButton.Location = new System.Drawing.Point(502, 4);
            this.MetaButton.Name = "MetaButton";
            this.MetaButton.Size = new System.Drawing.Size(83, 26);
            this.MetaButton.TabIndex = 16;
            this.MetaButton.Text = "Metadata";
            this.MetaButton.UseVisualStyleBackColor = true;
            this.MetaButton.Click += new System.EventHandler(this.MetaButton_Click);
            // 
            // AllEmployeeButton
            // 
            this.AllEmployeeButton.Location = new System.Drawing.Point(591, 4);
            this.AllEmployeeButton.Name = "AllEmployeeButton";
            this.AllEmployeeButton.Size = new System.Drawing.Size(83, 26);
            this.AllEmployeeButton.TabIndex = 17;
            this.AllEmployeeButton.Text = "All Employees";
            this.AllEmployeeButton.UseVisualStyleBackColor = true;
            this.AllEmployeeButton.Click += new System.EventHandler(this.AllEmployeeButton_Click);
            // 
            // ResponseLbl2
            // 
            this.ResponseLbl2.AutoSize = true;
            this.ResponseLbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResponseLbl2.ForeColor = System.Drawing.Color.Red;
            this.ResponseLbl2.Location = new System.Drawing.Point(729, 78);
            this.ResponseLbl2.Name = "ResponseLbl2";
            this.ResponseLbl2.Size = new System.Drawing.Size(0, 16);
            this.ResponseLbl2.TabIndex = 18;
            // 
            // ResponseLbl1
            // 
            this.ResponseLbl1.AutoSize = true;
            this.ResponseLbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResponseLbl1.ForeColor = System.Drawing.Color.Red;
            this.ResponseLbl1.Location = new System.Drawing.Point(284, 66);
            this.ResponseLbl1.Name = "ResponseLbl1";
            this.ResponseLbl1.Size = new System.Drawing.Size(0, 16);
            this.ResponseLbl1.TabIndex = 19;
            // 
            // Assignment2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 582);
            this.Controls.Add(this.ResponseLbl1);
            this.Controls.Add(this.ResponseLbl2);
            this.Controls.Add(this.AllEmployeeButton);
            this.Controls.Add(this.MetaButton);
            this.Controls.Add(this.AbsenseButton);
            this.Controls.Add(this.Sick2004Button);
            this.Controls.Add(this.KeysButton);
            this.Controls.Add(this.EmployeeLbl);
            this.Controls.Add(this.ConstraintsButton);
            this.Controls.Add(this.EmployeeColumns2Button);
            this.Controls.Add(this.EmployeeColumns1Button);
            this.Controls.Add(this.EmployeeInfoButton);
            this.Controls.Add(this.empIDLbl);
            this.Controls.Add(this.empIDTxt);
            this.Controls.Add(this.RelativesButton);
            this.Controls.Add(this.IndexButton);
            this.Controls.Add(this.Table2Button);
            this.Controls.Add(this.Table1Button);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.BackButton);
            this.Name = "Assignment2";
            this.Text = "Assignment2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Button Table1Button;
        private System.Windows.Forms.Button Table2Button;
        private System.Windows.Forms.Button IndexButton;
        private System.Windows.Forms.Button RelativesButton;
        private System.Windows.Forms.TextBox empIDTxt;
        private System.Windows.Forms.Label empIDLbl;
        private System.Windows.Forms.Button EmployeeInfoButton;
        private System.Windows.Forms.Button EmployeeColumns1Button;
        private System.Windows.Forms.Button EmployeeColumns2Button;
        private System.Windows.Forms.Button ConstraintsButton;
        private System.Windows.Forms.Label EmployeeLbl;
        private System.Windows.Forms.Button KeysButton;
        private System.Windows.Forms.Button Sick2004Button;
        private System.Windows.Forms.Button AbsenseButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button MetaButton;
        private System.Windows.Forms.Button AllEmployeeButton;
        private System.Windows.Forms.Label ResponseLbl2;
        private System.Windows.Forms.Label ResponseLbl1;
    }
}