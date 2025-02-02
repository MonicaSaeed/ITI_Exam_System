namespace DBProject
{
    partial class Take_Exam
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
        private void InitializeComponent()
        {
            this.SuspendLayout();

            this.ClientSize = new Size(1200, 650);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Exam";
            this.BackColor = Color.White;

            lblTimer = new Label
            {
                Text = "Time Remaining: 00:00:00",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.Red,
                BackColor = Color.White,
                AutoSize = true,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point((this.ClientSize.Width - 300) / 2, 10)
            };
            this.Controls.Add(lblTimer);

            examTimer = new System.Windows.Forms.Timer
            {
                Interval = 1000
            };

            examTimer.Tick += ExamTimer_Tick;
            examTimer.Start();

            int timerLabelHeight = lblTimer.Height + 20;

            scrollPanel = new Panel
            {
                BackColor = Color.White,
                Location = new Point(0, timerLabelHeight),
                Size = new Size(this.ClientSize.Width - 25, this.ClientSize.Height - timerLabelHeight),
            };

            vScrollBar = new VScrollBar
            {
                Location = new Point(this.ClientSize.Width - 25, timerLabelHeight),
                Height = this.ClientSize.Height - timerLabelHeight,
                Width = 25,
                Minimum = 0,
                SmallChange = 20,
            };
            vScrollBar.Scroll += VScrollBar_Scroll;

            this.Controls.Add(scrollPanel);
            this.Controls.Add(vScrollBar);

            GenerateQuestions();

            this.ResumeLayout(false);
        }

        private void GenerateQuestions()
        {
            int y = 20, q_num = 1; // Starting Y position for the first question

            foreach (var ed in examData)
            {

                Size questionTextSize = TextRenderer.MeasureText(ed.Value.QuestionText, new Font("Segoe UI", 12, FontStyle.Regular));
                int factorQ = questionTextSize.Width / 1060;
                int questionTextHeight = (factorQ >= 1) ? 40*(factorQ+1) : 40; // Adjust height if the question is long



                GroupBox questionGroup = new GroupBox
                {
                    Text = $"Q{q_num}: {ed.Value.QuestionText}",
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = Color.Black,
                    BackColor = Color.White,
                    AutoSize = false,
                    Size = new Size(1100, questionTextHeight + 180), // Adjust the height to accommodate the question text
                    Location = new Point(20, y),
                    Padding = new Padding(10)
                };
                scrollPanel.Controls.Add(questionGroup);

                int optionY = questionTextHeight + 20; ; // Starting Y position for options inside the GroupBox
                int totalOptionHeight = 0; // Track the total height of options

                bool isMultiAnswer = IsMultiAnswers(ed.Key);

                for (int i = 0; i < ed.Value.Options.Count; i++)
                {
                    var option = ed.Value.Options[i];

                    // Calculate the text height 
                    Size textSize = TextRenderer.MeasureText(option.Item1, new Font("Segoe UI", 12, FontStyle.Regular));
                    int factor = textSize.Width / 1060;
                    int optionHeight = (factor >= 1) ? 40*(factor + 1) : 40; // Adjust height if text is long

                    if (isMultiAnswer)
                    {
                        CheckBox optionCheckBox = new CheckBox
                        {
                            Text = option.Item1,
                            Font = new Font("Segoe UI", 12, FontStyle.Regular),
                            ForeColor = Color.White,
                            BackColor = Color.Teal,
                            FlatStyle = FlatStyle.Flat,
                            AutoSize = false,
                            Location = new Point(20, optionY),
                            Size = new Size(1060, optionHeight), 
                            Padding = new Padding(5),
                            Cursor = Cursors.Hand,
                            Tag = (ed.Key, option.Item2) // Store questionID and optionID in the Tag
                        };
                        optionCheckBox.CheckedChanged += OptionCheckBox_CheckedChanged;
                        questionGroup.Controls.Add(optionCheckBox);
                    }
                    else
                    {
                        RadioButton optionButton = new RadioButton
                        {
                            Text = option.Item1,
                            Font = new Font("Segoe UI", 12, FontStyle.Regular),
                            ForeColor = Color.White,
                            BackColor = Color.Teal,
                            FlatStyle = FlatStyle.Flat,
                            AutoSize = false,
                            Location = new Point(20, optionY),
                            Size = new Size(1060, optionHeight), // Use calculated height for option
                            Padding = new Padding(5),
                            Cursor = Cursors.Hand,
                            Tag = (ed.Key, option.Item2)
                        };
                        optionButton.CheckedChanged += optionButton_CheckedChanged;
                        questionGroup.Controls.Add(optionButton);
                    }

                    optionY += optionHeight + 10; // Increase Y position based on the option height
                    totalOptionHeight += optionHeight + 10; // Add the height of this option to the total height
                }

                // Adjust the height of the GroupBox 
                questionGroup.Height = totalOptionHeight + questionTextHeight + 50; // Add some padding to the GroupBox height

                y += questionGroup.Height + 20; // Update total height for next question
                q_num++;
            }

            Button btnSubmit = new Button
            {
                Text = "Submit",
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                BackColor = Color.Black,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point((scrollPanel.ClientSize.Width - 260) / 2, y + 20),
                Size = new Size(260, 40),
            };
            btnSubmit.Click += SubmitButton_Click;
            scrollPanel.Controls.Add(btnSubmit);

            int totalContentHeight = y + btnSubmit.Height + 40;

            vScrollBar.Maximum = totalContentHeight;
            vScrollBar.LargeChange = scrollPanel.Height;
        }

        #endregion
    }
}