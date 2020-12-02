namespace ERPWindowsForm
{
    partial class Assignment1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.userIDTxt = new System.Windows.Forms.TextBox();
            this.languageIDTxt = new System.Windows.Forms.TextBox();
            this.FindButton = new System.Windows.Forms.Button();
            this.CreateButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.BackButton = new System.Windows.Forms.Button();
            this.DisplayButton = new System.Windows.Forms.Button();
            this.ResponseLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F);
            this.label1.Location = new System.Drawing.Point(280, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage Users";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "User ID:*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label3.Location = new System.Drawing.Point(12, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Language ID:";
            // 
            // userIDTxt
            // 
            this.userIDTxt.Location = new System.Drawing.Point(120, 107);
            this.userIDTxt.Name = "userIDTxt";
            this.userIDTxt.Size = new System.Drawing.Size(149, 20);
            this.userIDTxt.TabIndex = 3;
            // 
            // languageIDTxt
            // 
            this.languageIDTxt.Location = new System.Drawing.Point(120, 153);
            this.languageIDTxt.Name = "languageIDTxt";
            this.languageIDTxt.Size = new System.Drawing.Size(149, 20);
            this.languageIDTxt.TabIndex = 4;
            // 
            // FindButton
            // 
            this.FindButton.Font = new System.Drawing.Font("Arial", 9.75F);
            this.FindButton.Location = new System.Drawing.Point(15, 321);
            this.FindButton.Name = "FindButton";
            this.FindButton.Size = new System.Drawing.Size(172, 46);
            this.FindButton.TabIndex = 5;
            this.FindButton.Text = "Find";
            this.FindButton.UseVisualStyleBackColor = true;
            this.FindButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // CreateButton
            // 
            this.CreateButton.Font = new System.Drawing.Font("Arial", 9.75F);
            this.CreateButton.Location = new System.Drawing.Point(193, 321);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(177, 46);
            this.CreateButton.TabIndex = 6;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Font = new System.Drawing.Font("Arial", 9.75F);
            this.EditButton.Location = new System.Drawing.Point(376, 321);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(181, 45);
            this.EditButton.TabIndex = 7;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Font = new System.Drawing.Font("Arial", 9.75F);
            this.DeleteButton.Location = new System.Drawing.Point(563, 322);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(175, 45);
            this.DeleteButton.TabIndex = 8;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // listView
            // 
            this.listView.Location = new System.Drawing.Point(396, 90);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(377, 189);
            this.listView.TabIndex = 9;
            this.listView.UseCompatibleStateImageBehavior = false;
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(12, 12);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(72, 24);
            this.BackButton.TabIndex = 10;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // DisplayButton
            // 
            this.DisplayButton.Location = new System.Drawing.Point(563, 26);
            this.DisplayButton.Name = "DisplayButton";
            this.DisplayButton.Size = new System.Drawing.Size(180, 41);
            this.DisplayButton.TabIndex = 11;
            this.DisplayButton.Text = "Display all users";
            this.DisplayButton.UseVisualStyleBackColor = true;
            this.DisplayButton.Click += new System.EventHandler(this.DisplayButton_Click);
            // 
            // ResponseLbl
            // 
            this.ResponseLbl.AutoSize = true;
            this.ResponseLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResponseLbl.ForeColor = System.Drawing.Color.Red;
            this.ResponseLbl.Location = new System.Drawing.Point(12, 236);
            this.ResponseLbl.Name = "ResponseLbl";
            this.ResponseLbl.Size = new System.Drawing.Size(0, 16);
            this.ResponseLbl.TabIndex = 12;
            // 
            // Assignment1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ResponseLbl);
            this.Controls.Add(this.DisplayButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.FindButton);
            this.Controls.Add(this.languageIDTxt);
            this.Controls.Add(this.userIDTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Assignment1";
            this.Text = "Assignment1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox userIDTxt;
        private System.Windows.Forms.TextBox languageIDTxt;
        private System.Windows.Forms.Button FindButton;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button DisplayButton;
        private System.Windows.Forms.Label ResponseLbl;
    }
}