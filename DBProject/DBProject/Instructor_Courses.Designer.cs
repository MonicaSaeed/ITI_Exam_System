using Microsoft.Data.SqlClient;

namespace DBProject
{
    partial class Instructor_Courses
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

        List<(string CourseName, int CourseID)> courses = new List<(string, int)>();
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
            ApplyLetterSpacing(label2, 0.001f, "Your Courses");
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Instructor_Courses
            // 
            AllowDrop = true;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(875, 523);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Instructor_Courses";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Istructor Courses";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //baseFormSize = this.ClientSize; // Update baseFormSize with the current form size
            courses = GetInstructorCourses(studentID); // Fetch courses for the logged-in student

            InitializeCourses(); // Initialize courses after the form is loaded

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT ins_name FROM Instructor WHERE ins_id = @stID";
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
    
        private List<(string CourseName, int CourseID)> GetInstructorCourses(int instructorID)
        {
            List<(string CourseName, int CourseID)> courses = new List<(string, int)>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
                                SELECT 
                                    c.co_name AS CourseName,
                                    c.co_id AS CourseID
                                FROM 
                                    Instructor i
                                INNER JOIN 
                                    Instructor_Course ic ON i.ins_id = ic.ins_id
                                INNER JOIN 
                                    Course c ON ic.co_id = c.co_id
                                WHERE 
                                    i.ins_id = @InstructorID
                                ";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@InstructorID", instructorID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string courseName = reader["CourseName"].ToString();
                                int courseID = Convert.ToInt32(reader["CourseID"]);
                                courses.Add((courseName, courseID));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    CustomMessageBox customMessageBox = new CustomMessageBox(
$"Error fetching courses: {ex.Message}", // Message
"Error", // Title
MessageBoxIcon.Warning // Icon
);
                    customMessageBox.ShowDialog();
                    //MessageBox.Show("Error fetching courses: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // Determine the course status based on the exam date
                this.Controls.Add(courseButton);
                courseButtons.Add(courseButton);
                courseButton.Click += (sender, e) => {
                    Instructor_Courses_Exam instructor_Courses_Exam = new Instructor_Courses_Exam(course.CourseID, studentID);
                    this.Hide();
                    instructor_Courses_Exam.ShowDialog();
                    
                }; ///////////////////////////////////
            }
        }
        private void CenterLabel2()
        {
            // Calculate the center position for the label
            int centerX = (this.ClientSize.Width - label2.Width) / 2;
            int centerY = 76;

            // Set the label's location
            label2.Location = new Point(centerX, centerY);
        }

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