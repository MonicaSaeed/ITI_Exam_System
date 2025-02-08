using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.Devices;
using static System.Windows.Forms.Design.AxImporter;

namespace DBProject
{
    partial class ExamResultsForm
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


        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Set fixed form size
            this.ClientSize = new Size(1200, 650); // Fixed size
            this.Text = "Exam Results";
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            // Create a panel for scrollable content
            Panel scrollPanel = new Panel
            {
                AutoScroll = true, // Enable scrolling
                Dock = DockStyle.Fill, // Fill the entire form
                BorderStyle = BorderStyle.None
            };
            this.Controls.Add(scrollPanel);

            // Add a label for the total grade
            Label lblTotalGrade = new Label
            {
                Text = $"Your Total Grade is   {totalGrade} degrees {(totalGrade>(actualTotal/2) ?  " :)" :" :(" )}",
                Font = new Font("Comic Sans MS", 16, FontStyle.Bold),
                ForeColor = Color.Teal,
                AutoSize = true,
                //TextAlign=ContentAlignment.TopCenter,
                Location = new Point(this.ClientSize.Width/2-400, 20)
            };
            scrollPanel.Controls.Add(lblTotalGrade);
            Label horizontalLine1 = new Label
            {
                // Text = "bla",
                // ForeColor = Color.Black,
                BackColor = Color.Black, // Line color
                Height = 2, // Line thickness
                AutoSize = false,
                Width = this.ClientSize.Width - 40, // Line width (form width minus padding)
                Location = new Point(20, 80) // Position below the total grade
            };
            scrollPanel.Controls.Add(horizontalLine1);
            int y = 120 , q_num=1; // Starting Y position for the first question
          
            foreach (var result in this.results)
            {
                // Add the question
                Size questionTextSize = TextRenderer.MeasureText(result.Question, new Font("Courier New", 12, FontStyle.Bold));
                int factorQ = questionTextSize.Width / 1100;
                int questionTextHeight = (factorQ >= 1) ? 40 * (factorQ + 1) : 40; // Adjust height if the question is long

                GroupBox questionGroup = new GroupBox
                {
                    Text = "Q" + q_num + ": " + result.Question,
                    Font = new Font("Courier New", 12, FontStyle.Bold),
                    ForeColor = Color.Black,
                    //BackColor = Color.White,
                    AutoSize = false,
                    Size = new Size(1100, questionTextHeight + 180), // Adjust the height to accommodate the question text
                    Location = new Point(20, y),
                   // Padding = new Padding(5),
                 //  BorderColor = System.Drawing.Color.Gray

                    /////////////////////////////


                    //Size= new Size(Width,60),
                    //BorderStyle = BorderStyle.FixedSingle,
                };
                scrollPanel.Controls.Add(questionGroup);
              
                //Label lblQuestion = new Label
                //{
                //    Text = "Q" + q_num + ": " + result.Question,
                //    Font = new Font("Courier New", 12, FontStyle.Bold),
                //    ForeColor = Color.Black,
                //    AutoSize = false,
                //    Size = new Size(questionTextSize.Width+20, questionTextHeight), // Adjust the height to accommodate the question text
                //    TextAlign = ContentAlignment.TopLeft,
                //    //Size= new Size(Width,60),
                //    //BorderStyle = BorderStyle.FixedSingle,
                //    Location = new Point(20, 0)
                //};

                //questionGroup.Controls.Add(lblQuestion);
                y += 30;

                // Add all options in two columns
                int x = 40; // Starting X position for the first option
                int finalHeight = 0;
                int totalOptionHeight = 0; // Track the total height of options
                int optionY = questionTextHeight + 20 , track_correct=0 ; // Starting Y position for options inside the GroupBox
                bool iscorrect = false;
                for (int i = 0; i < result.Options.Count; i++) {
                    var option = result.Options[i];

                    Size textSize = TextRenderer.MeasureText(option, new Font("Courier New", 12, FontStyle.Regular));

                    int factor = textSize.Width / 1060;
                    int optionHeight = (factor >= 1) ? 40 * (factor + 1) : 40; // Adjust height if text is long
                    finalHeight = Math.Max(finalHeight, optionHeight);

                    //// is correct 
                      if (result.StudentAnswers.Contains(option))
                    {
                        //btnOption.ForeColor = Color.White;
                        if (result.CorrectAnswers.Contains(option)) track_correct++; 
                    }
                };
                if (track_correct == result.CorrectAnswers.Count()) iscorrect = true;
               
                for (int i = 0; i < result.Options.Count; i++)
                {
                    var option = result.Options[i];

                    //Button btnOption = new Button
                    //{
                    //    Text = option,
                    //    Font = new Font("Courier New", 12, FontStyle.Regular),
                    //    ForeColor = Color.Black,
                    //    BackColor = Color.White, // Default background color
                    //    FlatStyle = FlatStyle.Flat,

                    //    TextAlign = ContentAlignment.TopLeft, // Align text to the top-left to accommodate wrapping
                    //    AutoSize = false, // Disable AutoSize to keep the fixed size
                    //    UseMnemonic = false, // Disable mnemonics
                    //    AutoEllipsis = false, // Disable text truncation
                    //    Location = new Point(x, y+10),
                    //    Size = new Size(500, 60) // Fixed size for uniformity
                    //};
                    Label btnOption = new Label
                    {
                        Text = option,
                        Font = new Font("Courier New", 12, FontStyle.Regular),
                        ForeColor = Color.Black,
                        //BackColor = Color.White, // Default background color
                        Size = new Size(500, finalHeight), // Fixed size for uniformity and wrapping
                        Location = new Point(x, optionY),
                        TextAlign = (option == "T" || option == "F")?ContentAlignment.MiddleCenter: ContentAlignment.MiddleLeft, // Align text to the top-left to accommodate wrapping
                        AutoSize = false, // Disable AutoSize to keep the fixed size
                        //MaximumSize = new Size(500, 0), // Ensure text is wrapped when it exceeds the width
                        BorderStyle = BorderStyle.FixedSingle // Optional: Add a border for a button-like look
                    };

                    #region old
                    // Highlight the student's chosen answer
                    //if (option == result.StudentAnswer)
                    //{
                    //    // If the student's answer is incorrect, set the background to red
                    //    if (!result.IsCorrect)
                    //    {
                    //        btnOption.ForeColor = Color.White;
                    //        btnOption.BackColor = Color.Red;
                    //      //  btnOption.FlatAppearance.BorderColor = Color.Red; // Set border color to red
                    //        //btnOption.FlatAppearance.BorderSize = 2; // Set border thickness
                    //     // btnOption.BackColor = Color.LightCoral; // Red background for incorrect answer
                    //    }
                    //}

                    //// Highlight the correct answer
                    //if (option == result.CorrectAnswer)
                    //{
                    //    btnOption.ForeColor = Color.White;
                    //    btnOption.BackColor = Color.Green;
                    //    //    btnOption.FlatAppearance.BorderColor = Color.Green; // Set border color to red
                    //    //    btnOption.FlatAppearance.BorderSize = 2; // Set border thickness
                    //    //    btnOption.BackColor = Color.LightGreen; // Green background for correct answer
                    //}
                    #endregion

                    #region new
                    // Highlight the student's chosen answers
                    if (result.StudentAnswers.Contains(option))
                    {
                        btnOption.ForeColor = Color.White;
                        btnOption.Font = new Font("Courier New", 12, FontStyle.Bold);
                        btnOption.BackColor = result.CorrectAnswers.Contains(option) ? Color.Green : Color.DarkRed;
                    }

                    // Highlight the correct answers
                    if (result.CorrectAnswers.Contains(option))
                    {
                        btnOption.ForeColor = Color.White;
                        btnOption.Font = new Font("Courier New", 12, FontStyle.Bold);

                        btnOption.BackColor = Color.Green;
                    }
                    #endregion
                    questionGroup.Controls.Add(btnOption);

                    // Adjust X position for the next option
                    if (i % 2 == 0)
                    {
                        x += 520; // Move to the second column
                        if (i == result.Options.Count - 1)
                        {
                            optionY += finalHeight + 20; // Move to the next row
                            totalOptionHeight += finalHeight + 10; // Add the height of this option to the total height

                        }
                    } 
                    else
                    {
                        x = 40; // Reset X position for the next row
                        optionY += finalHeight + 20; // Move to the next row
                        totalOptionHeight += finalHeight + 10; // Add the height of this option to the total height

                    }
                }

                // Add the grade for the question
                Label lblGrade = new Label
                {
                    Text = $"Grade: {result.QuestionGrade}",
                    Font = new Font("Courier New", 12, FontStyle.Bold),
                    ForeColor = Color.Black,
                    AutoSize = true,
                    Location = new Point(this.ClientSize.Width/2-200, optionY )
                };
                questionGroup.Controls.Add(lblGrade);
                Label iconLabel = new Label
                {
                    Text = iscorrect ? "✔" : "❌",
                    ForeColor = iscorrect ? Color.Green : Color.Red,
                    Location = new Point(this.ClientSize.Width / 2, optionY-10),
                    AutoSize = true,
                    Font = new Font("Courier New", 16, FontStyle.Bold)
                };
                questionGroup.Controls.Add(iconLabel);
                //Label newlabel = new Label { };
                //if (result.StudentAnswers.Count() ==0)
                //{
                //    newlabel.Text = "Not Answered !!!";
                //    newlabel.Font = new Font("Showcard Gothic", 12, FontStyle.Bold);
                //    newlabel.ForeColor = Color.Red;
                //    newlabel.AutoSize = true;
                //    //Size= new Size(Width,60),
                //    //BorderStyle = BorderStyle.FixedSingle,
                //    newlabel.Location = new Point(this.ClientSize.Width / 2 , optionY );
                //    // Highlight unanswered questions with a yellow background
                //    // lblQuestion.ForeColor = Color.DarkGoldenrod;
                //}
                //questionGroup.Controls.Add(newlabel);

                questionGroup.Height = totalOptionHeight + questionTextHeight + 80; // Add some padding to the GroupBox height

                q_num++;
                // horizontalLine1 = new Label
                //{
                //    // Text = "bla",
                //    // ForeColor = Color.Black,
                //    BackColor = Color.Black, // Line color
                //    Height = 2, // Line thickness
                //    AutoSize = false,
                //    Width = this.ClientSize.Width - 40, // Line width (form width minus padding)
                //    Location = new Point(20, y+80) // Position below the total grade
                //};
                //  y += 100; // Add extra spacing between questions
                y += questionGroup.Height + 20; // Update total height for next question

                //if(q_num!= this.results.Count+1)
                //scrollPanel.Controls.Add(horizontalLine1);
            }


            // Add a back button
            Button btnBack = new Button
            {
                Text = "Back to Courses",
                Font = new Font("Courier New", 12, FontStyle.Regular),
                BackColor = Color.Teal,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(this.ClientSize.Width/2-150, y + 20),
                Size = new Size(260, 40)
            };
            btnBack.Click += (sender, e) => this.Close();
            scrollPanel.Controls.Add(btnBack);
            Label horizontalLine2= new Label
            {
                // Text = "bla",
                // ForeColor = Color.Black,
                BackColor = Color.Transparent, // Line color
                Height = 2, // Line thickness
                AutoSize = false,
                Width = this.ClientSize.Width - 40, // Line width (form width minus padding)
                Location = new Point(20, y + 80) // Position below the total grade
            };
            y += 100; // Add extra spacing between questions

            scrollPanel.Controls.Add(horizontalLine2);
            this.ResumeLayout(false);
        }

    }
}