namespace InstructorPart
{
    partial class GradesForm
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
            TitleLabel = new Label();
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ControlText;
            button1.Font = new Font("Courier New", 12F, FontStyle.Bold);
            button1.ForeColor = Color.WhiteSmoke;
            button1.Location = new Point(771, 30);
            button1.Name = "button1";
            button1.Size = new Size(96, 39);
            button1.TabIndex = 0;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Font = new Font("Comic Sans MS", 15F, FontStyle.Bold);
            TitleLabel.Location = new Point(38, 40);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(87, 35);
            TitleLabel.TabIndex = 1;
            TitleLabel.Text = "label1";
            TitleLabel.Click += label1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 99);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 26;
            dataGridView1.Size = new Size(884, 426);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(35, 112);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.RowTemplate.Height = 26;
            dataGridView2.Size = new Size(841, 396);
            dataGridView2.TabIndex = 3;
            // 
            // GradesForm
            // 
            ClientSize = new Size(908, 537);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Controls.Add(TitleLabel);
            Controls.Add(button1);
            Name = "GradesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Load += GradesForm_Load_1;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewGrades;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label ExamTitleLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}