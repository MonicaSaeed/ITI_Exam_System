using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.Collections.Generic;

namespace DBProject
{
    partial class Student_Courses
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        //private float baseFontSize = 12f;
        //private Size baseFormSize = new Size(1246, 450); // Initialize baseFormSize with the initial form size

        private List<Button> courseButtons = new List<Button>();
        private Label label1;
        private Label label2;
        private Size baseFormSize = new Size(1246, 450); // Initialize baseFormSize with the initial form size
        private int ExamId;
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

        List<(string CourseName, DateTime? ExamDate, int? Grade, int CourseID, int ExamId)> courses = new List<(string, DateTime?, int?, int, int)>();
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Teal;
            label1.Location = new Point(25, 18);
            label1.Name = "label1";
            label1.Size = new Size(177, 43);
            label1.TabIndex = 0;
            label1.Text = "Student";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Courier New", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(753, 50);
            label2.TabIndex = 1;
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Student_Courses
            // 
            AllowDrop = true;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(282, 253);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Student_Courses";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Student Test";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //baseFormSize = this.ClientSize; // Update baseFormSize with the current form size
            courses = GetStudentCourses(studentID); // Fetch courses for the logged-in student

            InitializeCourses(); // Initialize courses after the form is loaded

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT st_name FROM Student WHERE st_id = @stID";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@stID", studentID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            label1.Text = "Welcome, " + reader[0].ToString() ?? " ";
                        }
                    }
                }
            }
        }
        ////////////// old 
        //private List<string> GetStudentCourses(int studentID)
        //{
        //    List<string> courses = new List<string>();

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            connection.Open();
        //            string query = @"
        //SELECT 
        //    c.co_id AS CourseID,
        //    c.co_name AS CourseName
        //FROM 
        //    Student s
        //INNER JOIN 
        //    Track t ON s.track_id = t.track_id
        //INNER JOIN 
        //    Track_Course tc ON t.track_id = tc.track_id
        //INNER JOIN 
        //    Course c ON tc.co_id = c.co_id
        //WHERE 
        //    s.st_id = @StudentID;";
        //            using (SqlCommand command = new SqlCommand(query, connection))
        //            {
        //                command.Parameters.AddWithValue("@StudentID", studentID);
        //                using (SqlDataReader reader = command.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        courses.Add(reader["CourseName"].ToString());
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Error fetching courses: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }

        //    return courses;
        //}
        private List<(string CourseName, DateTime? ExamDate, int? Grade, int CourseID, int ExamId)> GetStudentCourses(int studentID)
        {
            List<(string CourseName, DateTime? ExamDate, int? Grade, int CourseID, int ExamId)> courses = new List<(string, DateTime?, int?, int, int)>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
SELECT 
    c.co_name AS CourseName,
    e.start_date AS ExamDate,
    ISNULL(SUM(CASE WHEN o.is_correct = 1 THEN q.grade ELSE 0 END), 0) AS Grade,
    c.co_id AS CourseID,
    e.ex_id AS ExamID
FROM 
    Student s
INNER JOIN 
    Track t ON s.track_id = t.track_id
INNER JOIN 
    Track_Course tc ON t.track_id = tc.track_id
INNER JOIN 
    Course c ON tc.co_id = c.co_id
LEFT JOIN 
    Course_Exam ce ON c.co_id = ce.co_id AND t.track_id = ce.track_id
LEFT JOIN 
    Exam e ON ce.ex_id = e.ex_id
LEFT JOIN 
    Question q ON e.ex_id = q.ex_id
LEFT JOIN 
    Student_Answer sa ON q.q_id = sa.q_id AND s.st_id = sa.st_id
LEFT JOIN 
    [Option] o ON sa.op_id = o.op_id
WHERE 
    s.st_id = @StudentID
GROUP BY 
    c.co_name, e.start_date, c.co_id,e.ex_id;
";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StudentID", studentID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string courseName = reader["CourseName"].ToString();
                                DateTime? examDate = reader["ExamDate"] as DateTime?;
                                int grade = reader["Grade"] as int? ?? 0; // Default to 0 if null
                                int courseID = Convert.ToInt32(reader["CourseID"]);
                                ExamId = reader["ExamID"] != DBNull.Value ? Convert.ToInt32(reader["ExamID"]) : 0;
                                courses.Add((courseName, examDate, grade, courseID, ExamId));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching courses: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return courses;
        }

        private void InitializeCourses()
        {
            // Number of buttons per row
            int buttonsPerRow = 2;

            // Button size
            int buttonWidth = 250;
            int buttonHeight = 50;

            // Spacing between buttons
            int spacingX = 20;
            int spacingY = 20;

            // Calculate the total width of the buttons and spacing
            int totalWidth = buttonsPerRow * buttonWidth + (buttonsPerRow - 1) * spacingX;

            // Calculate the starting X position to center the buttons horizontally
            int startX = (this.ClientSize.Width - totalWidth) / 2;

            // Starting Y position for the first button
            int startY = (this.ClientSize.Height / 3) + 10;

            // Loop through the courses and create buttons
            for (int i = 0; i < courses.Count; i++)
            {
                // Calculate the position of the button
                int row = i / buttonsPerRow;
                int col = i % buttonsPerRow;

                int x = startX + col * (buttonWidth + spacingX);
                int y = startY + row * (buttonHeight + spacingY);

                // Get course details
                var course = courses[i];

                // Create new button
                Button courseButton = new Button
                {
                    Text = course.CourseName,
                    Location = new Point(x, y),
                    Size = new Size(buttonWidth, buttonHeight),
                    Font = new Font("Courier New", 12, FontStyle.Regular, GraphicsUnit.Point, 0),
                    BackColor = Color.Teal,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };
                bool hasAttempted = HasStudentAttemptedExam(studentID, course.ExamId);
                // Determine the course status based on the exam date
                if (!course.ExamDate.HasValue)
                {
                    // Case 1: No exam date specified
                    courseButton.Text += "\nNo date specified";
                    //courseButton.Enabled = false;
                    courseButton.BackColor = Color.Gray;
                    courseButton.Click += (sender, e) =>
                    {
                        CustomMessageBox customMessageBox = new CustomMessageBox(
                               $"No date has been specified \n\nfor the {course.CourseName} exam.", // Message
                               "Exam Not Scheduled", // Title
                               MessageBoxIcon.Error // Icon
);
                        customMessageBox.ShowDialog(); // Show the custom message box
                                                       //         MessageBox.Show($"No date has been specified for the {course.CourseName} exam.", "Exam Not Scheduled");
                    };
                }
                else
                {
                    DateTime examDateTime = course.ExamDate.Value;
                    DateTime now = DateTime.Now;
                    if (hasAttempted)
                    {
                        // Case 2: Student has already attempted the exam
                        courseButton.Text += "\nExam already taken";
                        //  courseButton.BackColor = Color.Gray;
                        //   courseButton.Enabled = false; // Disable the button
                        courseButton.Click += (sender, e) =>
                        {
                            var (results, totalGrade) = GetExamResults(studentID, course.CourseID); // Replace courseID with the actual course ID

                            // Show the exam results form
                            ExamResultsForm examResultsForm = new ExamResultsForm(totalGrade, results);
                            examResultsForm.ShowDialog();
                            //   MessageBox.Show($"You have already taken the {course.CourseName} exam.", "Exam Taken");
                        };
                    }
                    else if (examDateTime.Date == DateTime.Today) // Exam is today
                    {
                        TimeSpan timeRemaining = examDateTime - now;

                        //if (timeRemaining.TotalMinutes > 0)
                        //{
                        courseButton.Click += (sender, e) =>
                        {
                            DateTime now = DateTime.Now;

                            TimeSpan timeRemaining = examDateTime - now;
                            if (timeRemaining.TotalSeconds > 0)
                            {
                                // MessageBox.Show($"Your {course.CourseName} exam is scheduled for {course.ExamDate.Value.ToShortDateString()}. Please prepare for it.", "Upcoming Exam");
                                CustomMessageBox customMessageBox = new CustomMessageBox(
            $"\nStarts in {timeRemaining.Hours}h {timeRemaining.Minutes}m , {timeRemaining.Seconds}s", // Message
            "Upcoming Exam", // Title
            MessageBoxIcon.Information // Icon
        );
                                customMessageBox.ShowDialog(); // Show the custom message box
                            }
                            else
                            {
                                Take_Exam examForm = new Take_Exam(studentID, course.ExamId);
                                examForm.Show();
                                this.Hide();
                            }
                        };

                        //else
                        //{
                        //    courseButton.Text += "\nExam is available now!";
                        //    courseButton.Click += (sender, e) =>
                        //    {
                        //        Take_Exam examForm = new Take_Exam(studentID, course.ExamId);
                        //        examForm.Show();
                        //        this.Hide();
                        //    };
                        //}
                    }
                    else if (examDateTime < DateTime.Now)
                    {
                        // Case 2: Past exam date (student has answered it, waiting for grade)
                        courseButton.Text += $"\nExam taken on {course.ExamDate.Value.ToShortDateString()}";
                        courseButton.Click += (sender, e) =>
                        {
                            // Fetch exam results
                            var (results, totalGrade) = GetExamResults(studentID, course.CourseID); // Replace courseID with the actual course ID

                            // Show the exam results form
                            ExamResultsForm examResultsForm = new ExamResultsForm(totalGrade, results);
                            examResultsForm.ShowDialog();
                        };
                        /*
                         Take_Exam form2 = new Take_Exam(studentID, course.ExamId);
                            form2.Show();
                            this.Hide();
                         */
                        //courseButton.Text += $"\nExam taken on {course.ExamDate.Value.ToShortDateString()}";
                        //courseButton.Click += (sender, e) =>
                        //{

                        //    MessageBox.Show($"You have already taken the {course.CourseName} exam on {course.ExamDate.Value.ToShortDateString()}. Please wait for the results.", "Exam Taken");
                        //};
                    }
                    else
                    {
                        // Case 3: Upcoming exam date
                        courseButton.Text += $"\nExam on {course.ExamDate.Value.ToShortDateString()}";
                        courseButton.Click += (sender, e) =>
                        {
                            // MessageBox.Show($"Your {course.CourseName} exam is scheduled for {course.ExamDate.Value.ToShortDateString()}. Please prepare for it.", "Upcoming Exam");
                            CustomMessageBox customMessageBox = new CustomMessageBox(
        $"Your OOP exam is scheduled \n\nfor {course.ExamDate?.ToString("dd/MM/yyyy")}. \n\nPlease prepare for it.", // Message
        "Upcoming Exam", // Title
        MessageBoxIcon.Information // Icon
    );
                            customMessageBox.ShowDialog(); // Show the custom message box
                        };


                    }
                    // Add the button to the form

                }
                this.Controls.Add(courseButton);
                courseButtons.Add(courseButton);
            }
        }
        #region OLD_ONE
        private (List<(string Question, List<string> Options, string StudentAnswer, string CorrectAnswer, bool IsCorrect, int QuestionGrade)>, int TotalGrade)
 GetExamResults(int studentID, int courseID)
        {
            var results = new List<(string Question, List<string> Options, string StudentAnswer, string CorrectAnswer, bool IsCorrect, int QuestionGrade)>();
            int totalGrade = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Step 1: Fetch questions, student answers, and correct answers
                /*string query = @"
        SELECT 
            q.text AS Question,
            sa.op_id AS StudentAnswerID,
            correct_op.op_id AS CorrectAnswerID,
            q.grade AS QuestionGrade
        FROM 
            Student_Answer sa
        INNER JOIN 
        Question q ON sa.q_id = q.q_id
    INNER JOIN
        [Option] correct_op ON q.q_id = correct_op.q_id AND correct_op.is_correct = 1

    WHERE
        sa.st_id = @StudentID AND q.ex_id IN (SELECT ex_id FROM Course_Exam WHERE co_id = @CourseID);";
                */
                string query = @"
            SELECT 
                q.text AS Question,
                q.grade AS QuestionGrade,
                correct_op.op_id AS CorrectAnswerID,
                sa.op_id AS StudentAnswerID
            FROM 
                Question q  
            INNER JOIN 
                [Option] correct_op ON q.q_id = correct_op.q_id AND correct_op.is_correct = 1
            LEFT JOIN 
                Student_Answer sa ON q.q_id = sa.q_id AND sa.st_id = @StudentID
            LEFT JOIN 
                [Option] o ON sa.op_id = o.op_id
            WHERE 
                q.ex_id IN (SELECT ex_id FROM Course_Exam WHERE co_id = @CourseID);";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentID", studentID);
                    command.Parameters.AddWithValue("@CourseID", courseID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Store the results in memory
                        var questions = new List<(string Question, int? StudentAnswerID, int CorrectAnswerID, int QuestionGrade)>();
                        while (reader.Read())
                        {
                            string question = reader["Question"]?.ToString() ?? "No Question";
                            int? studentAnswerID = reader["StudentAnswerID"] as int?; // Handle DBNull
                                                                                      //  string studentAnswerID = (reader["StudentAnswerID"]==null) ? "No Answer":reader["StudentAnswerID"].ToString();

                            int correctAnswerID = Convert.ToInt32(reader["CorrectAnswerID"]);
                            int questionGrade = Convert.ToInt32(reader["QuestionGrade"]);
                            //int temp = (studentAnswerID!="No Answer" ? Convert.ToInt32(studentAnswerID) : 0);
                            questions.Add((question, studentAnswerID, correctAnswerID, questionGrade));
                        }

                        // Close the reader before executing additional queries
                        reader.Close();

                        // Process each question
                        foreach (var question in questions)
                        {
                            // Step 2: Fetch options for the current question
                            List<string> options = GetOptionsForQuestion(connection, question.Question);

                            // Step 3: Fetch the student's answer and correct answer text
                            string studentAnswer = (question.StudentAnswerID != 0) ? GetOptionText(connection, question.StudentAnswerID) : "No Answer";
                            string correctAnswer = GetOptionText(connection, question.CorrectAnswerID);

                            // Step 4: Determine if the student's answer is correct
                            bool isCorrect = question.StudentAnswerID == question.CorrectAnswerID;

                            // Add the result to the list
                            results.Add((question.Question, options, studentAnswer, correctAnswer, isCorrect, question.QuestionGrade));

                            // Update the total grade
                            if (isCorrect)
                            {
                                totalGrade += question.QuestionGrade;
                            }
                        }
                    }
                }
            }

            return (results, totalGrade);
        }
        #endregion

        #region NEW_ONE
        //private (List<(string Question, List<string> Options, string StudentAnswer, string CorrectAnswer, bool IsCorrect, int QuestionGrade)>, int TotalGrade)
        //GetExamResults(int studentId, int courseID)
        //    {
        //        var results = new List<(string Question, List<string> Options, string StudentAnswer, string CorrectAnswer, bool IsCorrect, int QuestionGrade)>();
        //        int totalGrade = 0;

        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            connection.Open();

        //            // Step 1: Fetch all questions and their correct answers
        //            string query = @"
        //        SELECT 
        //            q.text AS Question,
        //            q.grade AS QuestionGrade,
        //            correct_op.op_text AS CorrectAnswer,
        //            sa.op_id AS StudentAnswerID,
        //            o.op_text AS StudentAnswer
        //        FROM 
        //            Question q
        //        INNER JOIN 
        //            [Option] correct_op ON q.q_id = correct_op.q_id AND correct_op.is_correct = 1
        //        LEFT JOIN 
        //            Student_Answer sa ON q.q_id = sa.q_id AND sa.st_id = @StudentID
        //        LEFT JOIN 
        //            [Option] o ON sa.op_id = o.op_id
        //        WHERE 
        //            q.ex_id IN (SELECT ex_id FROM Course_Exam WHERE co_id = @CourseID);";

        //            using (SqlCommand command = new SqlCommand(query, connection))
        //            {
        //                command.Parameters.AddWithValue("@StudentID", studentId);
        //                command.Parameters.AddWithValue("@CourseID", courseID);

        //                using (SqlDataReader reader = command.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        string question = reader["Question"]?.ToString() ?? "No Question";
        //                        int questionGrade = Convert.ToInt32(reader["QuestionGrade"]);
        //                        string correctAnswer = reader["CorrectAnswer"]?.ToString() ?? "No Correct Answer";
        //                        string studentAnswer = reader["StudentAnswer"]?.ToString() ?? "No Answer";

        //                        // Fetch all options for the question
        //                        List<string> options = GetOptionsForQuestion(connection, question);

        //                        // Determine if the student's answer is correct
        //                        bool isCorrect = studentAnswer == correctAnswer;

        //                        // Add the result to the list
        //                        results.Add((question, options, studentAnswer, correctAnswer, isCorrect, questionGrade));

        //                        // Update the total grade if the answer is correct
        //                        if (isCorrect)
        //                        {
        //                            totalGrade += questionGrade;
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //        return (results, totalGrade);
        //    }
        #endregion
        private List<string> GetOptionsForQuestion(SqlConnection connection, string question)
        {
            var options = new List<string>();

            string query = @"
SELECT 
    op_text AS OptionText
FROM 
    [Option]
WHERE 
    q_id = (SELECT q_id FROM Question WHERE text = @Question);";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Question", question);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string optionText = reader["OptionText"]?.ToString() ?? "No Option";
                        options.Add(optionText);
                    }
                }
            }

            return options;
        }

        private string GetOptionText(SqlConnection connection, int? optionID)
        {
            string optionText = "No Option";

            string query = @"
SELECT 
    op_text AS OptionText
FROM 
    [Option]
WHERE 
    op_id = @OptionID;";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@OptionID", optionID);
                if (optionID == null) return "null";
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        optionText = reader["OptionText"]?.ToString() ?? "No Option";
                    }
                }
            }

            return optionText;
        }
        //private void Form1_Resize(object sender, EventArgs e)
        //{
        //    UpdateFontAndControlSizes(); // Update font and control sizes
        //    InitializeCourses(); // Reposition buttons
        //    CenterLabel2(); // Re-center label2
        //}

        //private void UpdateFontAndControlSizes()
        //{
        //    // Calculate scaling factors for font and control sizes
        //    float widthScale = (float)this.ClientSize.Width / baseFormSize.Width;
        //    float heightScale = (float)this.ClientSize.Height / baseFormSize.Height;
        //    float scale = Math.Min(widthScale, heightScale);

        //    // Update font size
        //    float newFontSize = baseFontSize * scale;

        //    // Ensure newFontSize is within valid bounds
        //    if (newFontSize <= 0 || newFontSize > float.MaxValue)
        //    {
        //        newFontSize = baseFontSize; // Fallback to base font size if invalid
        //    }

        //    // Update label1 font and size
        //    label1.Font = new Font("Segoe UI", newFontSize + 10, FontStyle.Regular, GraphicsUnit.Point, 0);

        //    // Update label2 font and size
        //    label2.Font = new Font("Segoe UI", newFontSize + 5, FontStyle.Regular, GraphicsUnit.Point, 0);
        //    label2.Size = new Size((int)(753 * widthScale), (int)(50 * heightScale));

        //    // Update button fonts and sizes
        //    foreach (Button button in courseButtons)
        //    {
        //        button.Font = new Font("Segoe UI", newFontSize, FontStyle.Regular, GraphicsUnit.Point, 0);
        //        button.Size = new Size((int)(250 * widthScale), (int)(50 * heightScale));
        //    }
        //}

        private void CenterLabel2()
        {
            // Calculate the center position for the label
            int centerX = (this.ClientSize.Width - label2.Width) / 2;
            int centerY = 76;

            // Set the label's location
            label2.Location = new Point(centerX, centerY);
        }

        private void CourseButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            MessageBox.Show($"You clicked: {clickedButton.Text}", "Course Selected");
        }
        #region new_for_exam_attemptCheck 
        //private bool HasStudentAttemptedExam(int studentId, int examId)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        string query = @"
        //    SELECT attempted
        //    FROM Student_Exam_Attempt
        //    WHERE st_id = @StudentID AND ex_id = @ExamID;";

        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@StudentID", studentId);
        //            command.Parameters.AddWithValue("@ExamID", examId);

        //            object result = command.ExecuteScalar();
        //            if (result != null && result != DBNull.Value)
        //            {
        //                return Convert.ToBoolean(result); // Return the value of the 'attempted' column
        //            }
        //            return false; // If no record exists, the student has not attempted the exam
        //        }
        //    }
        //}
        private bool HasStudentAttemptedExam(int studentId, int examId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
            SELECT 1
            FROM Student_Exam_Attempt
            WHERE st_id = @StudentID AND ex_id = @ExamID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentID", studentId);
                    command.Parameters.AddWithValue("@ExamID", examId);

                    object result = command.ExecuteScalar();
                    // If a record exists, the student has attempted the exam
                    return result != null && result != DBNull.Value;
                }
            }
        }
        #endregion

        // Helper method to apply letter spacing to a control
        private void ApplyLetterSpacing(Control control, float spacing, string text)
        {
            control.Paint += (sender, e) =>
            {
                Font font = control.Font;
                Brush brush = new SolidBrush(control.ForeColor);

                // Calculate the total width of the text with spacing
                float totalWidth = 0;
                for (int i = 0; i < text.Length; i++)
                {
                    totalWidth += e.Graphics.MeasureString(text[i].ToString(), font).Width + spacing;
                }
                totalWidth -= spacing; // Remove the last spacing

                // Calculate the starting X position for center alignment
                float x = (control.Width - totalWidth) / 2;

                // Calculate the starting Y position for middle alignment
                float y = (control.Height - font.Height) / 2;

                // Draw each character with spacing
                for (int i = 0; i < text.Length; i++)
                {
                    e.Graphics.DrawString(text[i].ToString(), font, brush, x, y);
                    x += spacing + e.Graphics.MeasureString(text[i].ToString(), font).Width; // Add spacing
                }

                brush.Dispose();
            };
        }

    }
}