namespace DBProject
{
    partial class Create_Exam_SelectTracks
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
            button1 = new Button();
            checkedListBox1 = new CheckedListBox();
            label1 = new Label();
            label2 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label3 = new Label();
            numericUpDown1 = new NumericUpDown();
            flowLayoutPanel1 = new FlowLayoutPanel();
            button2 = new Button();
            button3 = new Button();

            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.BackColor = Color.FromArgb(2, 2, 2);
            button1.ForeColor = Color.White;
            button1.Location = new Point(743, 482);
            button1.Name = "button1";
            button1.Size = new Size(213, 47);
            button1.TabIndex = 0;
            button1.Text = "Next";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            //button 3
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button3.BackColor = Color.FromArgb(2, 2, 2);
            button3.ForeColor = Color.White;
            button3.Location = new Point(200, 482);
            button3.Name = "button2";
            button3.Size = new Size(213, 47);
            button3.TabIndex = 0;
            button3.Text = "Back";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            ///
            // checkedListBox1
            // 
            checkedListBox1.BackColor = Color.White;
            checkedListBox1.BorderStyle = BorderStyle.FixedSingle;
            checkedListBox1.ForeColor = Color.FromArgb(2, 2, 2);
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.HorizontalScrollbar = true;
            checkedListBox1.Location = new Point(39, 227);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.ScrollAlwaysVisible = true;
            checkedListBox1.Size = new Size(374, 156);
            checkedListBox1.TabIndex = 1;
            checkedListBox1.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.ForeColor = Color.FromArgb(7, 62, 64);
            label1.Location = new Point(39, 48);
            label1.Name = "label1";
            label1.Size = new Size(281, 37);
            label1.TabIndex = 2;
            label1.Text = "Create Exam: Step one";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(524, 226);
            label2.Name = "label2";
            label2.Size = new Size(205, 28);
            label2.TabIndex = 3;
            label2.Text = "Enter exam start date: ";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(524, 295);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 4;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(524, 355);
            label3.Name = "label3";
            label3.Size = new Size(273, 28);
            label3.TabIndex = 5;
            label3.Text = "Enter exam duration(minutes):";
            label3.Click += label3_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(530, 395);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(150, 27);
            numericUpDown1.TabIndex = 6;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(39, 130);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(374, 37);
            flowLayoutPanel1.TabIndex = 7;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // button2
            // 
            button2.Location = new Point(511, 130);
            button2.Name = "button2";
            button2.Size = new Size(218, 37);
            button2.TabIndex = 8;
            button2.Text = "Select Tracks to continue";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(530, 261);
            label4.Name = "label4";
            label4.Size = new Size(166, 20);
            label4.TabIndex = 9;
            label4.Text = "YYYY-MM-DD HH:MI:SS";
            // 
            // Create_Exam_SelectTracks
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(982, 553);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(button3);

            Controls.Add(flowLayoutPanel1);
            Controls.Add(numericUpDown1);
            Controls.Add(label3);
            Controls.Add(dateTimePicker1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(checkedListBox1);
            Controls.Add(button1);
            ForeColor = Color.FromArgb(2, 2, 2);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Create_Exam_SelectTracks";
            Text = "Create_Exam_SelectTracks";
            Load += Create_Exam_SelectTracks_Load;
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button3;

        private CheckedListBox checkedListBox1;
        private Label label1;
        private Label label2;
        private DateTimePicker dateTimePicker1;
        private Label label3;
        private NumericUpDown numericUpDown1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button2;
        private Label label4;
    }
}