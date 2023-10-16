namespace EmployeeManagement
{
    partial class Login
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
            label1 = new Label();
            groupBox1 = new GroupBox();
            warningLabel = new Label();
            button1 = new Button();
            PasswordTextBox = new TextBox();
            EmailTextBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(26, 106);
            label1.Name = "label1";
            label1.Size = new Size(42, 17);
            label1.TabIndex = 0;
            label1.Text = "Email:";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(warningLabel);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(PasswordTextBox);
            groupBox1.Controls.Add(EmailTextBox);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(286, 63);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(246, 271);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // warningLabel
            // 
            warningLabel.AutoSize = true;
            warningLabel.Location = new Point(123, 129);
            warningLabel.Name = "warningLabel";
            warningLabel.Size = new Size(43, 15);
            warningLabel.TabIndex = 5;
            warningLabel.Text = "            ";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(84, 196);
            button1.Name = "button1";
            button1.Size = new Size(75, 34);
            button1.TabIndex = 4;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(122, 147);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.PasswordChar = '•';
            PasswordTextBox.Size = new Size(100, 23);
            PasswordTextBox.TabIndex = 3;
            // 
            // EmailTextBox
            // 
            EmailTextBox.Location = new Point(122, 100);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.Size = new Size(100, 23);
            EmailTextBox.TabIndex = 1;
            EmailTextBox.TextChanged += EmailTextBox_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(26, 150);
            label2.Name = "label2";
            label2.Size = new Size(67, 17);
            label2.TabIndex = 2;
            label2.Text = "Password:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(128, 64, 64);
            label3.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(26, 14);
            label3.Name = "label3";
            label3.Size = new Size(202, 47);
            label3.TabIndex = 5;
            label3.Text = "Login form";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(128, 64, 64);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(286, 63);
            panel1.Name = "panel1";
            panel1.Size = new Size(246, 61);
            panel1.TabIndex = 2;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            Name = "Login";
            Text = "Login";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private Button button1;
        private TextBox PasswordTextBox;
        private Label label2;
        private TextBox EmailTextBox;
        private Label label3;
        private Panel panel1;
        private Label warningLabel;
    }
}