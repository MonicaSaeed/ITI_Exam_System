using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.Devices;

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
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "Exam Results";

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
                Text = $"Your Total Grade is   {totalGrade} degrees {(totalGrade>50 ?  " :)" :" :(" )}",
                Font = new Font("Showcard Gothic", 16, FontStyle.Bold),
                ForeColor = Color.Teal,
                AutoSize = true,
                Location = new Point(20, 20)
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
                Label lblQuestion = new Label
                {
                    Text = "Q"+q_num +": " +result.Question,
                    Font = new Font("Courier New", 12, FontStyle.Bold),
                    ForeColor = Color.Black,
                    AutoSize = true,
                    //Size= new Size(Width,60),
                    //BorderStyle = BorderStyle.FixedSingle,
                    Location = new Point(20, y)
                };
               
                scrollPanel.Controls.Add(lblQuestion);
                y += 30;

                // Add all options in two columns
                int x = 40; // Starting X position for the first option
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
                        BackColor = Color.White, // Default background color
                        Size = new Size(500, 60), // Fixed size for uniformity and wrapping
                        Location = new Point(x, y + 10),
                        TextAlign = (option == "T" || option == "F")?ContentAlignment.MiddleCenter: ContentAlignment.TopLeft, // Align text to the top-left to accommodate wrapping
                        AutoSize = false, // Disable AutoSize to keep the fixed size
                        //MaximumSize = new Size(500, 0), // Ensure text is wrapped when it exceeds the width
                        BorderStyle = BorderStyle.FixedSingle // Optional: Add a border for a button-like look
                    };


                    // Highlight the student's chosen answer
                    if (option == result.StudentAnswer)
                    {
                        // If the student's answer is incorrect, set the background to red
                        if (!result.IsCorrect)
                        {
                            btnOption.ForeColor = Color.White;
                            btnOption.BackColor = Color.DarkRed;
                          //  btnOption.FlatAppearance.BorderColor = Color.Red; // Set border color to red
                            //btnOption.FlatAppearance.BorderSize = 2; // Set border thickness
                         // btnOption.BackColor = Color.LightCoral; // Red background for incorrect answer
                        }
                    }

                    // Highlight the correct answer
                    if (option == result.CorrectAnswer)
                    {
                        btnOption.ForeColor = Color.White;
                        btnOption.BackColor = Color.DarkGreen;
                        //    btnOption.FlatAppearance.BorderColor = Color.Green; // Set border color to red
                        //    btnOption.FlatAppearance.BorderSize = 2; // Set border thickness
                        //    btnOption.BackColor = Color.LightGreen; // Green background for correct answer
                    }

                    scrollPanel.Controls.Add(btnOption);

                    // Adjust X position for the next option
                    if (i % 2 == 0)
                    {
                        x += 520; // Move to the second column
                    }
                    else
                    {
                        x = 40; // Reset X position for the next row
                        y += 100; // Move to the next row
                    }
                }

                // Add the grade for the question
                Label lblGrade = new Label
                {
                    Text = $"Grade: {result.QuestionGrade}",
                    Font = new Font("Courier New", 12, FontStyle.Bold),
                    ForeColor = Color.Black,
                    AutoSize = true,
                    Location = new Point(this.ClientSize.Width/2-100, y+30)
                };
                scrollPanel.Controls.Add(lblGrade);
                Label newlabel = new Label { };
                if (result.StudentAnswer == "null")
                {
                    newlabel.Text = "Not Answered !!!";
                    newlabel.Font = new Font("Showcard Gothic", 12, FontStyle.Bold);
                    newlabel.ForeColor = Color.Red;
                    newlabel.AutoSize = true;
                    //Size= new Size(Width,60),
                    //BorderStyle = BorderStyle.FixedSingle,
                    newlabel.Location = new Point(this.ClientSize.Width / 2 +50, y + 30);
                    // Highlight unanswered questions with a yellow background
                    // lblQuestion.ForeColor = Color.DarkGoldenrod;
                }
                scrollPanel.Controls.Add(newlabel);
                q_num++;
                 horizontalLine1 = new Label
                {
                    // Text = "bla",
                    // ForeColor = Color.Black,
                    BackColor = Color.Black, // Line color
                    Height = 2, // Line thickness
                    AutoSize = false,
                    Width = this.ClientSize.Width - 40, // Line width (form width minus padding)
                    Location = new Point(20, y+80) // Position below the total grade
                };
                y += 100; // Add extra spacing between questions
                if(q_num!= this.results.Count+1)
                scrollPanel.Controls.Add(horizontalLine1);
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