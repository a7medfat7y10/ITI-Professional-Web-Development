namespace task2_desktop
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grdInstructors = new System.Windows.Forms.DataGridView();
            this.cBoxDeptID = new System.Windows.Forms.ComboBox();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtSSN = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdInstructors)).BeginInit();
            this.SuspendLayout();
            // 
            // grdInstructors
            // 
            this.grdInstructors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdInstructors.Location = new System.Drawing.Point(44, 303);
            this.grdInstructors.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdInstructors.Name = "grdInstructors";
            this.grdInstructors.RowHeadersWidth = 51;
            this.grdInstructors.RowTemplate.Height = 24;
            this.grdInstructors.Size = new System.Drawing.Size(936, 290);
            this.grdInstructors.TabIndex = 20;
            // 
            // cBoxDeptID
            // 
            this.cBoxDeptID.FormattingEnabled = true;
            this.cBoxDeptID.Location = new System.Drawing.Point(44, 200);
            this.cBoxDeptID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cBoxDeptID.Name = "cBoxDeptID";
            this.cBoxDeptID.Size = new System.Drawing.Size(223, 28);
            this.cBoxDeptID.TabIndex = 32;
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(97, 250);
            this.BtnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(90, 29);
            this.BtnAdd.TabIndex = 31;
            this.BtnAdd.Text = "Add Instructor";
            this.BtnAdd.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(44, 160);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 20);
            this.label8.TabIndex = 30;
            this.label8.Text = "Salary";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 20);
            this.label4.TabIndex = 29;
            this.label4.Text = "Age";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 28;
            this.label3.Text = "Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 27;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 20);
            this.label1.TabIndex = 26;
            this.label1.Text = "SSN";
            // 
            // txtSalary
            // 
            this.txtSalary.Location = new System.Drawing.Point(137, 160);
            this.txtSalary.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.Size = new System.Drawing.Size(132, 27);
            this.txtSalary.TabIndex = 25;
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(137, 123);
            this.txtAge.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(132, 27);
            this.txtAge.TabIndex = 24;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(137, 88);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(132, 27);
            this.txtAddress.TabIndex = 23;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(137, 53);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(132, 27);
            this.txtName.TabIndex = 22;
            // 
            // txtSSN
            // 
            this.txtSSN.Location = new System.Drawing.Point(137, 18);
            this.txtSSN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSSN.Name = "txtSSN";
            this.txtSSN.Size = new System.Drawing.Size(132, 27);
            this.txtSSN.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 607);
            this.Controls.Add(this.cBoxDeptID);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSalary);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtSSN);
            this.Controls.Add(this.grdInstructors);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.grdInstructors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DataGridView grdInstructors;
        private ComboBox cBoxDeptID;
        private Button BtnAdd;
        private Label label8;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtSalary;
        private TextBox txtAge;
        private TextBox txtAddress;
        private TextBox txtName;
        private TextBox txtSSN;
    }
}