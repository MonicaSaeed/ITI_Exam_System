namespace DBProject
{
    partial class Create_Questions
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
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.ForeColor = Color.FromArgb(7, 62, 64);
            label1.Location = new Point(33, 36);
            label1.Name = "label1";
            label1.Size = new Size(285, 37);
            label1.TabIndex = 3;
            label1.Text = "Create Exam: Step Two";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.BackColor = Color.FromArgb(2, 2, 2);
            button1.ForeColor = Color.White;
            button1.Location = new Point(745, 502);
            button1.Name = "button1";
            button1.Size = new Size(213, 47);
            button1.TabIndex = 4;
            button1.Text = "Add Question";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Create_Questions
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 577);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Create_Questions";
            Text = "Create_Questions";
            Load += Create_Questions_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
    }
}