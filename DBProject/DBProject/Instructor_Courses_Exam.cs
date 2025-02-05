using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using InstructorPart;
using Microsoft.Data.SqlClient;

namespace DBProject
{
    public partial class Instructor_Courses_Exam : Form
    {
        string connectionString = "Server=DESKTOP-JGIQ4Q8\\MSSQLSERVER1;Database=ExaminationSystem;Integrated Security=True;TrustServerCertificate=True;";
        int course_id;
        int instructor_id;

        public Instructor_Courses_Exam(int _course_id, int _instructor_id)
        {
            course_id = _course_id;
            instructor_id = _instructor_id;
            InitializeComponent();

            // Enable scrolling for the form
            this.AutoScroll = true;

            LoadCourses();
        }

        private void LoadCourses()
        {
            DataTable examsData = GetCourseExams(course_id, instructor_id); // Get exams with tracks

            FlowLayoutPanel panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false, // Ensures items are stacked vertically
                AutoScroll = true // Enable scrolling for the panel if needed
            };

            foreach (DataRow row in examsData.Rows)
            {
                string courseName = GetCourseName(course_id);  // Fetch course name
                string trackName = row["TrackName"].ToString(); // Track name for course
                int examId = Convert.ToInt32(row["ExamID"]); // Get the exam ID

                Panel coursePanel = new Panel
                {
                    Width = 700, // Full width minus padding
                    Height = 60, // Increased height for better spacing
                    BackColor = Color.Teal,
                    Margin = new Padding(5) // Adds spacing between panels
                };

                Label courseLabel = new Label
                {
                    Text = $"{courseName}\n{trackName}",
                    ForeColor = Color.White,
                    Font = new Font("Arial", 8, FontStyle.Bold),
                    Location = new Point(10, 15),
                    AutoSize = true
                };

                Button viewGradesButton = new Button
                {
                    Text = "Grades",
                    BackColor = Color.Black,
                    ForeColor = Color.White,
                    Location = new Point(400, 10),
                    Width = 90,
                    Height = 40,
                };
                viewGradesButton.Click += (sender, e) => {
                    GradesForm gradesForm = new GradesForm(1);
                    gradesForm.ShowDialog();
                };

                Button viewExamButton = new Button
                {
                    Text = "View Exam",
                    BackColor = Color.Black,
                    ForeColor = Color.White,
                    Location = new Point(500, 10),
                    Width = 90,
                    Height = 40,
                };
                viewExamButton.Click += (sender, e) => {
                    ExamDisplayForm examDisplayForm = new ExamDisplayForm(1);
                    examDisplayForm.ShowDialog();
                };

                Button deleteButton = new Button
                {
                    Text = "Delete",
                    BackColor = Color.Red,
                    ForeColor = Color.White,
                    Location = new Point(600, 10),
                    Width = 80,
                    Height = 40,
                    Tag = examId // Store the exam ID in the button's Tag property
                };
                deleteButton.Click += (sender, e) => DeleteButton_Click(sender, e, examId); // Pass the exam ID to the event handler

                // Add controls to panel
                coursePanel.Controls.Add(courseLabel);
                coursePanel.Controls.Add(viewGradesButton);
                coursePanel.Controls.Add(viewExamButton);
                coursePanel.Controls.Add(deleteButton);

                panel.Controls.Add(coursePanel);
            }

            this.Controls.Add(panel);

            Button addExamButton = new Button
            {
                Text = "Add Exam",
                BackColor = Color.Black,
                ForeColor = Color.White,
                Width = 120,
                Height = 40,
                Location = new Point(400, panel.Bottom + 20) // Below the last panel
            };

            addExamButton.Click += (sender, e) => {
                Create_Exam_SelectTracks examDisplayForm = new Create_Exam_SelectTracks(instructor_id);
                examDisplayForm.ShowDialog();
            };
            this.Controls.Add(addExamButton);
        }

        // Function to get course name by ID
        private string GetCourseName(int course_id)
        {
            string courseName = "Unknown Course";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT c.co_name FROM Course c WHERE c.co_id = @course_id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@course_id", course_id);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        courseName = result.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching course name: " + ex.Message);
                }
            }
            return courseName;
        }

        // Function to get exams and tracks for a course and instructor
        private DataTable GetCourseExams(int course_id, int instructor_id)
        {
            DataTable examsTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT DISTINCT
                        e.ex_id AS ExamID, 
                        t.track_name AS TrackName
                    FROM Course_Exam ce
                    JOIN Course c ON ce.co_id = c.co_id
                    JOIN Exam e ON ce.ex_id = e.ex_id
                    JOIN Track t ON ce.track_id = t.track_id
                    JOIN Instructor_Course ic ON ic.co_id = c.co_id
                    WHERE ce.co_id = @course_id AND ic.ins_id = @instructor_id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@course_id", course_id);
                cmd.Parameters.AddWithValue("@instructor_id", instructor_id);

                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(examsTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching exams: " + ex.Message);
                }
            }
            return examsTable;
        }

        // Event handler for the delete button
        private void DeleteButton_Click(object sender, EventArgs e, int examId)
        {
            // Confirm deletion with the user
            DialogResult result = MessageBox.Show("Are you sure you want to delete this exam?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // Delete from Course_Exam
                        string deleteCourseExamQuery = @"
                            DELETE ce
                            FROM Course_Exam ce
                            JOIN Course c ON ce.co_id = c.co_id
                            JOIN Instructor_Course ic ON c.co_id = ic.co_id
                            WHERE ce.ex_id = @examId AND ce.co_id = @course_id AND ic.ins_id = @instructor_id";

                        SqlCommand cmd1 = new SqlCommand(deleteCourseExamQuery, conn, transaction);
                        cmd1.Parameters.AddWithValue("@examId", examId); // Add examId parameter
                        cmd1.Parameters.AddWithValue("@course_id", course_id); // Add course_id parameter
                        cmd1.Parameters.AddWithValue("@instructor_id", instructor_id); // Add instructor_id parameter
                        int courseExamRowsAffected = cmd1.ExecuteNonQuery();

                        // Delete from Exam
                        string deleteExamQuery = @"
                            DELETE e
                            FROM Exam e
                            JOIN Course_Exam ce ON e.ex_id = ce.ex_id
                            JOIN Course c ON ce.co_id = c.co_id
                            JOIN Instructor_Course ic ON c.co_id = ic.co_id
                            WHERE e.ex_id = @examId AND ce.co_id = @course_id AND ic.ins_id = @instructor_id";

                        SqlCommand cmd2 = new SqlCommand(deleteExamQuery, conn, transaction);
                        cmd2.Parameters.AddWithValue("@examId", examId); // Add examId parameter
                        cmd2.Parameters.AddWithValue("@course_id", course_id); // Add course_id parameter
                        cmd2.Parameters.AddWithValue("@instructor_id", instructor_id); // Add instructor_id parameter
                        int examRowsAffected = cmd2.ExecuteNonQuery();

                        // Commit the transaction if both deletes were successful
                        transaction.Commit();

                        MessageBox.Show("Exam and associated course exams deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Clear existing controls and reload the exams
                        this.Controls.Clear();
                        LoadCourses(); // Refresh the course list
                    }
                    catch (Exception ex)
                    {
                        // Rollback the transaction in case of error
                        transaction.Rollback();
                        MessageBox.Show("Error deleting exam: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Instructor_Courses_Exam_Load(object sender, EventArgs e)
        {
            // Fetch exams when the form loads
            DataTable exams = GetCourseExams(course_id, instructor_id);
            foreach (DataRow row in exams.Rows)
            {
                Console.WriteLine($"Exam ID: {row["ExamID"]}, Track: {row["TrackName"]}");
            }
        }
    }
}