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
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.BackColor = Color.FromArgb(2, 2, 2);
            button1.ForeColor = Color.White;
            button1.Location = new Point(705, 434);
            button1.Name = "button1";
            button1.Size = new Size(213, 47);
            button1.TabIndex = 0;
            button1.Text = "Add Questions";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // checkedListBox1
            // 
            checkedListBox1.BackColor = Color.White;
            checkedListBox1.BorderStyle = BorderStyle.FixedSingle;
            checkedListBox1.ForeColor = Color.FromArgb(2, 2, 2);
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.HorizontalScrollbar = true;
            checkedListBox1.Location = new Point(39, 31);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.ScrollAlwaysVisible = true;
            checkedListBox1.Size = new Size(374, 68);
            checkedListBox1.TabIndex = 1;
            checkedListBox1.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // Create_Exam_SelectTracks
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(944, 505);
            Controls.Add(checkedListBox1);
            Controls.Add(button1);
            ForeColor = Color.FromArgb(2, 2, 2);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Create_Exam_SelectTracks";
            Text = "Create_Exam_SelectTracks";
            Load += Create_Exam_SelectTracks_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private CheckedListBox checkedListBox1;
    }
}