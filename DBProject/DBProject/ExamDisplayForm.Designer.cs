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
            this.QuestionsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.BackButton = new System.Windows.Forms.Button();
            this.ExamTitleLabel = new System.Windows.Forms.Label();
            this.QuestionsFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // QuestionsFlowLayoutPanel
            // 
            this.QuestionsFlowLayoutPanel.AutoScroll = true;
            this.QuestionsFlowLayoutPanel.Controls.Add(this.ExamTitleLabel);
            this.QuestionsFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QuestionsFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.QuestionsFlowLayoutPanel.Name = "QuestionsFlowLayoutPanel";
            this.QuestionsFlowLayoutPanel.Size = new System.Drawing.Size(800, 450);
            this.QuestionsFlowLayoutPanel.TabIndex = 1;
            this.QuestionsFlowLayoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // BackButton
            // 
            this.BackButton.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Bold);
            this.BackButton.Location = new System.Drawing.Point(651, 18);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(108, 45);
            this.BackButton.TabIndex = 2;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // ExamTitleLabel
            // 
            this.ExamTitleLabel.AutoSize = true;
            this.QuestionsFlowLayoutPanel.SetFlowBreak(this.ExamTitleLabel, true);
            this.ExamTitleLabel.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExamTitleLabel.Location = new System.Drawing.Point(20, 20);
            this.ExamTitleLabel.Margin = new System.Windows.Forms.Padding(20, 20, 0, 0);
            this.ExamTitleLabel.Name = "ExamTitleLabel";
            this.ExamTitleLabel.Size = new System.Drawing.Size(99, 39);
            this.ExamTitleLabel.TabIndex = 0;
            this.ExamTitleLabel.Text = "label1";
            this.ExamTitleLabel.Click += new System.EventHandler(this.ExamTitleLabel_Click);
            // 
            // ExamDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.QuestionsFlowLayoutPanel);
            this.Name = "ExamDisplayForm";
            this.Text = "ExamDisplayForm";
            this.QuestionsFlowLayoutPanel.ResumeLayout(false);
            this.QuestionsFlowLayoutPanel.PerformLayout();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel QuestionsFlowLayoutPanel;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label ExamTitleLabel;
    }
}