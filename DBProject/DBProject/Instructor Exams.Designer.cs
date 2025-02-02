namespace Project_DataBase
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
            Add_Exam = new Button();
            DataBase_Mobile = new Button();
            label1 = new Label();
            View_Grades = new Button();
            Delete = new Button();
            View_Exam = new Button();
            View_Exam2 = new Button();
            DataBaseUI = new Button();
            View_Grades2 = new Button();
            Delete2 = new Button();
            SuspendLayout();
            // 
            // Add_Exam
            // 
            Add_Exam.BackColor = SystemColors.InactiveCaptionText;
            Add_Exam.FlatStyle = FlatStyle.Popup;
            Add_Exam.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Add_Exam.ForeColor = SystemColors.ButtonFace;
            Add_Exam.Location = new Point(812, 220);
            Add_Exam.Name = "Add_Exam";
            Add_Exam.Size = new Size(139, 32);
            Add_Exam.TabIndex = 0;
            Add_Exam.Text = "Add Exam";
            Add_Exam.UseVisualStyleBackColor = false;
            Add_Exam.Click += button1_Click;
            // 
            // DataBase_Mobile
            // 
            DataBase_Mobile.BackColor = Color.Teal;
            DataBase_Mobile.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DataBase_Mobile.ForeColor = Color.White;
            DataBase_Mobile.Location = new Point(12, 64);
            DataBase_Mobile.Name = "DataBase_Mobile";
            DataBase_Mobile.Padding = new Padding(40, 5, 0, 0);
            DataBase_Mobile.Size = new Size(896, 53);
            DataBase_Mobile.TabIndex = 1;
            DataBase_Mobile.Text = "Data base for Mobile";
            DataBase_Mobile.TextAlign = ContentAlignment.TopLeft;
            DataBase_Mobile.UseVisualStyleBackColor = false;
            DataBase_Mobile.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Teal;
            label1.Location = new Point(29, 7);
            label1.Name = "label1";
            label1.Size = new Size(138, 32);
            label1.TabIndex = 2;
            label1.Text = "Instrructor";
            // 
            // View_Grades
            // 
            View_Grades.BackColor = SystemColors.InactiveCaptionText;
            View_Grades.FlatStyle = FlatStyle.Popup;
            View_Grades.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            View_Grades.ForeColor = SystemColors.ButtonFace;
            View_Grades.Location = new Point(527, 73);
            View_Grades.Name = "View_Grades";
            View_Grades.Size = new Size(119, 35);
            View_Grades.TabIndex = 6;
            View_Grades.Text = "View Grades";
            View_Grades.UseVisualStyleBackColor = false;
            View_Grades.Click += button6_Click;
            // 
            // Delete
            // 
            Delete.BackColor = Color.Red;
            Delete.FlatStyle = FlatStyle.Popup;
            Delete.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Delete.ForeColor = SystemColors.ButtonFace;
            Delete.Location = new Point(776, 73);
            Delete.Name = "Delete";
            Delete.Size = new Size(98, 31);
            Delete.TabIndex = 7;
            Delete.Text = "Delete";
            Delete.UseVisualStyleBackColor = false;
            Delete.Click += button5_Click;
            // 
            // View_Exam
            // 
            View_Exam.BackColor = SystemColors.InactiveCaptionText;
            View_Exam.FlatStyle = FlatStyle.Popup;
            View_Exam.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            View_Exam.ForeColor = SystemColors.ButtonFace;
            View_Exam.Location = new Point(652, 73);
            View_Exam.Name = "View_Exam";
            View_Exam.Size = new Size(109, 35);
            View_Exam.TabIndex = 8;
            View_Exam.Text = "View Exam";
            View_Exam.UseVisualStyleBackColor = false;
            View_Exam.Click += View_Exam_Click;
            // 
            // View_Exam2
            // 
            View_Exam2.BackColor = SystemColors.InactiveCaptionText;
            View_Exam2.FlatStyle = FlatStyle.Popup;
            View_Exam2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            View_Exam2.ForeColor = SystemColors.ButtonFace;
            View_Exam2.Location = new Point(652, 155);
            View_Exam2.Name = "View_Exam2";
            View_Exam2.Size = new Size(109, 35);
            View_Exam2.TabIndex = 14;
            View_Exam2.Text = "View Exam";
            View_Exam2.UseVisualStyleBackColor = false;
            View_Exam2.Click += View_Exam2_Click;
            // 
            // DataBaseUI
            // 
            DataBaseUI.BackColor = Color.DarkCyan;
            DataBaseUI.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DataBaseUI.ForeColor = Color.White;
            DataBaseUI.Location = new Point(12, 146);
            DataBaseUI.Name = "DataBaseUI";
            DataBaseUI.Padding = new Padding(40, 5, 0, 0);
            DataBaseUI.Size = new Size(896, 53);
            DataBaseUI.TabIndex = 10;
            DataBaseUI.Text = "Data base for UI";
            DataBaseUI.TextAlign = ContentAlignment.TopLeft;
            DataBaseUI.UseVisualStyleBackColor = false;
            // 
            // View_Grades2
            // 
            View_Grades2.BackColor = SystemColors.InactiveCaptionText;
            View_Grades2.FlatStyle = FlatStyle.Popup;
            View_Grades2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            View_Grades2.ForeColor = SystemColors.ButtonFace;
            View_Grades2.Location = new Point(527, 155);
            View_Grades2.Name = "View_Grades2";
            View_Grades2.Size = new Size(119, 35);
            View_Grades2.TabIndex = 12;
            View_Grades2.Text = "View Grades";
            View_Grades2.UseVisualStyleBackColor = false;
            View_Grades2.Click += button8_Click;
            // 
            // Delete2
            // 
            Delete2.BackColor = Color.Red;
            Delete2.FlatStyle = FlatStyle.Popup;
            Delete2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Delete2.ForeColor = SystemColors.ButtonFace;
            Delete2.Location = new Point(776, 155);
            Delete2.Name = "Delete2";
            Delete2.Size = new Size(98, 35);
            Delete2.TabIndex = 13;
            Delete2.Text = "Delete";
            Delete2.UseVisualStyleBackColor = false;
            Delete2.Click += Delete2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(963, 401);
            Controls.Add(View_Exam2);
            Controls.Add(Delete2);
            Controls.Add(View_Grades2);
            Controls.Add(DataBaseUI);
            Controls.Add(View_Exam);
            Controls.Add(Delete);
            Controls.Add(View_Grades);
            Controls.Add(label1);
            Controls.Add(DataBase_Mobile);
            Controls.Add(Add_Exam);
            ForeColor = Color.Black;
            Name = "Form1";
            Text = "Instructor Exams";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Add_Exam;
        private Button DataBase_Mobile;
        private Label label1;
        private Button View_Grades;
        private Button Delete;
        private Button View_Exam;
        private Button View_Exam2;
        private Button DataBaseUI;
        private Button View_Grades2;
        private Button Delete2;
    }
}
