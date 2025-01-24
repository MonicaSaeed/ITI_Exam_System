namespace DBProject
{
    partial class LogIn
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

        private void InitializeComponent()
        {
            label1 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            label4 = new Label();
            button1 = new Button();
            buttonStudent = new Button();
            buttonInstructor = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Stencil", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Teal;
            label1.Location = new Point(166, 27);
            label1.Name = "label1";
            label1.Size = new Size(158, 52);
            label1.TabIndex = 0;
            label1.Text = "Log In";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(50, 200);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Enter your email";
            textBox1.Size = new Size(400, 34);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(50, 280);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.PlaceholderText = "Enter your password";
            textBox2.Size = new Size(400, 34);
            textBox2.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(50, 170);
            label2.Name = "label2";
            label2.Size = new Size(64, 28);
            label2.TabIndex = 3;
            label2.Text = "Email ";
            label2.Click += label2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(50, 250);
            label4.Name = "label4";
            label4.Size = new Size(93, 28);
            label4.TabIndex = 5;
            label4.Text = "Password";
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(50, 350);
            button1.Name = "button1";
            button1.Size = new Size(400, 50);
            button1.TabIndex = 6;
            button1.Text = "Log In";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // buttonStudent
            // 
            buttonStudent.BackColor = Color.Teal;
            buttonStudent.FlatStyle = FlatStyle.Flat;
            buttonStudent.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonStudent.ForeColor = Color.White;
            buttonStudent.Location = new Point(50, 120);
            buttonStudent.Name = "buttonStudent";
            buttonStudent.Size = new Size(180, 40);
            buttonStudent.TabIndex = 7;
            buttonStudent.Text = "Student";
            buttonStudent.UseVisualStyleBackColor = false;
            buttonStudent.Click += ButtonStudent_Click;
            // 
            // buttonInstructor
            // 
            buttonInstructor.BackColor = Color.White;
            buttonInstructor.FlatStyle = FlatStyle.Flat;
            buttonInstructor.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonInstructor.ForeColor = Color.Teal;
            buttonInstructor.Location = new Point(270, 120);
            buttonInstructor.Name = "buttonInstructor";
            buttonInstructor.Size = new Size(180, 40);
            buttonInstructor.TabIndex = 8;
            buttonInstructor.Text = "Instructor";
            buttonInstructor.UseVisualStyleBackColor = false;
            buttonInstructor.Click += ButtonInstructor_Click;
            // 
            // LogIn
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(500, 500);
            Controls.Add(button1);
            Controls.Add(buttonInstructor);
            Controls.Add(buttonStudent);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "LogIn";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Log In";
            Load += LogIn_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        private Label label4;
        private Button button1;
        private Button buttonInstructor;
        private Button buttonStudent;
    }
}
