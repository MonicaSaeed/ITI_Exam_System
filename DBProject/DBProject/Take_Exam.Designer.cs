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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();

            this.ClientSize = new Size(1200, 650);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
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

                AutoScroll = true,
                BackColor = Color.White,
                Location = new Point(0, timerLabelHeight),
                Size = new Size(this.ClientSize.Width, this.ClientSize.Height - timerLabelHeight) 
            };
            this.Controls.Add(scrollPanel);

            GenerateQuestions();

            this.ResumeLayout(false);
        }

        private void GenerateQuestions()
        {
            int y = 20, q_num = 1; // Starting Y position for the first question 

            foreach (var ed in examData)
            {
                GroupBox questionGroup = new GroupBox
                {
                    Text = $"Q{q_num}: {ed.Value.QuestionText}",
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = Color.Black,
                    BackColor = Color.White,
                    AutoSize = false,
                    Size = new Size(1100, 150),
                    Location = new Point(20, y),
                    Padding = new Padding(10)
                };
                scrollPanel.Controls.Add(questionGroup);

                int optionY = 40; // Starting Y position for options inside the GroupBox
                int optionX = 20; // Starting X position for the first option in the row

                bool isMultiAnswer = IsMultiAnswers(ed.Key);

                // Add all options for the current question
                for (int i = 0; i < ed.Value.Options.Count; i++)
                {
                    var option = ed.Value.Options[i];

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
                            Location = new Point(optionX, optionY),
                            Size = new Size(500, 50),
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
                            Location = new Point(optionX, optionY),
                            Size = new Size(500, 50),
                            Padding = new Padding(5),
                            Cursor = Cursors.Hand,
                            Tag = (ed.Key, option.Item2) // Store questionID and optionID in the Tag
                        };
                        optionButton.CheckedChanged += optionButton_CheckedChanged;
                        questionGroup.Controls.Add(optionButton);
                    }
                    if (i % 2 == 0)
                    {
                        optionX += 520; // Move to the second column
                    }
                    else
                    {
                        optionX = 20; // Reset X position for the next row
                        optionY += 70; // Move to the next row
                    }
                }

                questionGroup.Height = optionY + 60; // Add extra space at the bottom

                y += questionGroup.Height + 20; // Add spacing between questions
                q_num++;
            }

            Button btnSubmit = new Button
            {
                Text = "Submit",
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                BackColor = Color.Teal,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point((scrollPanel.ClientSize.Width - 260) / 2, y + 20),
                Size = new Size(260, 40),
            };
            btnSubmit.Click += SubmitButton_Click;
            scrollPanel.Controls.Add(btnSubmit);
        }

        #endregion
    }
}