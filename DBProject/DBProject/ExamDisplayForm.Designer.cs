namespace InstructorPart
{
    partial class ExamDisplayForm
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
            QuestionsFlowLayoutPanel = new FlowLayoutPanel();
            ExamTitleLabel = new Label();
            BackButton = new Button();
            QuestionsFlowLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // QuestionsFlowLayoutPanel
            // 
            QuestionsFlowLayoutPanel.AutoScroll = true;
            QuestionsFlowLayoutPanel.Controls.Add(ExamTitleLabel);
            QuestionsFlowLayoutPanel.Dock = DockStyle.Fill;
            QuestionsFlowLayoutPanel.Location = new Point(0, 0);
            QuestionsFlowLayoutPanel.Margin = new Padding(3, 4, 3, 4);
            QuestionsFlowLayoutPanel.Name = "QuestionsFlowLayoutPanel";
            QuestionsFlowLayoutPanel.Size = new Size(914, 562);
            QuestionsFlowLayoutPanel.TabIndex = 1;
            QuestionsFlowLayoutPanel.Paint += flowLayoutPanel1_Paint;
            // 
            // ExamTitleLabel
            // 
            ExamTitleLabel.AutoSize = true;
            QuestionsFlowLayoutPanel.SetFlowBreak(ExamTitleLabel, true);
            ExamTitleLabel.Font = new Font("Comic Sans MS", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ExamTitleLabel.Location = new Point(23, 25);
            ExamTitleLabel.Margin = new Padding(23, 25, 0, 0);
            ExamTitleLabel.Name = "ExamTitleLabel";
            ExamTitleLabel.Size = new Size(99, 39);
            ExamTitleLabel.TabIndex = 0;
            ExamTitleLabel.Text = "label1";
            ExamTitleLabel.Click += ExamTitleLabel_Click;
            // 
            // BackButton
            // 
            BackButton.BackColor = Color.Black;
            BackButton.Font = new Font("Bookman Old Style", 12F, FontStyle.Bold);
            BackButton.ForeColor = Color.Cornsilk;
            BackButton.Location = new Point(744, 22);
            BackButton.Margin = new Padding(3, 4, 3, 4);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(97, 42);
            BackButton.TabIndex = 2;
            BackButton.Text = "Back";
            BackButton.UseVisualStyleBackColor = false;
            BackButton.Click += button1_Click;
            // 
            // ExamDisplayForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 562);
            Controls.Add(BackButton);
            Controls.Add(QuestionsFlowLayoutPanel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ExamDisplayForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ExamDisplayForm";
            QuestionsFlowLayoutPanel.ResumeLayout(false);
            QuestionsFlowLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel QuestionsFlowLayoutPanel;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label ExamTitleLabel;
    }
}