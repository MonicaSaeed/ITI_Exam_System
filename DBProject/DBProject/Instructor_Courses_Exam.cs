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
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=ExaminationSystem;Integrated Security=True;TrustServerCertificate=True;";
        int course_id ;
        int instructor_id ;

        public Instructor_Courses_Exam( int _course_id, int _instructor_id)
        {
            course_id = _course_id ;
            instructor_id = _instructor_id;
            InitializeComponent();
            LoadCourses();
        }

        private void LoadCourses()
        {
            DataTable examsData = GetCourseExams(course_id, instructor_id); // Get courses with tracks

            FlowLayoutPanel panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false // Ensures items are stacked vertically
            };

            foreach (DataRow row in examsData.Rows)
            {
                string courseName = GetCourseName(course_id);  // Fetch course name
                string trackName = row["TrackName"].ToString(); // Track name for course

                Panel coursePanel = new Panel
                {
                    Width = 700 , // Full width minus padding
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
                };

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
