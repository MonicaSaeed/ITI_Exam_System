using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Security.Cryptography;
using System.Transactions;
using System.Windows.Forms;
using static Azure.Core.HttpHeader;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace DBProject
{
    public partial class Create_Exam_SelectTracks : Form
    {
        int instructorId = 1; // Replace with actual instructor ID

        private string _courseNameSelected;
        private int _courseIdSelected;
        private List<int> _tracksIdsSelected;

        int newExamId;

        string connectionString = "Server=localhost\\SQLEXPRESS;Database=ExaminationSystem;Integrated Security=True;TrustServerCertificate=True;";

        public Create_Exam_SelectTracks()
        {
            InitializeComponent();
        }

        private void Create_Exam_SelectTracks_Load(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Teal;
            button2.BackColor = Color.Teal;
            button2.ForeColor = Color.White;

            dateTimePicker1.Value = DateTime.Now; // Current date as default
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";

            var courses = coursessName();
            foreach (var course in courses)
            {
                var courseButton = new Button()
                {
                    Text = course,
                    AutoSize = true,
                    BackColor = Color.LightGray,
                    Tag = course // Store course name in Tag
                };

                courseButton.Click += (s, args) =>
                {
                    _courseNameSelected = courseButton.Text;
                    courseId(_courseNameSelected);
                    //MessageBox.Show($"Selected Course: {_courseNameSelected}, ID: {_courseIdSelected}");
                };

                flowLayoutPanel1.Controls.Add(courseButton);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _tracksIdsSelected = new List<int>();
            foreach (var item in checkedListBox1.CheckedItems)
            {
                _tracksIdsSelected.Add(GetTrackId(item.ToString()));
            }

            var startDate = dateTimePicker1.Value;
            var duration = (int)numericUpDown1.Value;

            //// Convert _tracksIdsSelected list to a comma-separated string
            //string tracksIdsString = string.Join(", ", _tracksIdsSelected);
            //// Show all values in a message box
            //MessageBox.Show($"Selected Tracks: {tracksIdsString}, Start Date: {startDate:yyyy-MM-dd HH:mm:ss}, Duration: {duration} minutes, Selected Course ID: {_courseIdSelected}");

            using (var scope = new TransactionScope())
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string insertExamQuery = @"INSERT INTO Exam (start_date, duration) 
                                           VALUES (@startDate, @duration);
                                           SELECT SCOPE_IDENTITY();";

                        using (SqlCommand command = new SqlCommand(insertExamQuery, connection))
                        {
                            command.Parameters.AddWithValue("@startDate", startDate);
                            command.Parameters.AddWithValue("@duration", duration);
                            newExamId = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }

                    // Insert Course_Exam records for each selected track_id
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        foreach (int trackId in _tracksIdsSelected)
                        {
                            string insertCourseExamQuery = @"INSERT INTO Course_Exam (ex_id, co_id, track_id)
                                                     VALUES (@examId, @courseId, @trackId)";

                            using (SqlCommand command = new SqlCommand(insertCourseExamQuery, connection))
                            {
                                command.Parameters.AddWithValue("@examId", newExamId);
                                command.Parameters.AddWithValue("@courseId", _courseIdSelected); 
                                command.Parameters.AddWithValue("@trackId", trackId);
                                command.ExecuteNonQuery();
                            }
                        }
                    }

                    // Commit the transaction
                    scope.Complete();
                    MessageBox.Show("Exam created and tracks assigned successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }


            /// to pass ExamIdInQuestion to Create_Questions
            Create_Questions q = new Create_Questions();
            q.ExamIdInQuestion = newExamId;
            q.Show();
            this.Hide();

        }
    
        // to show all courses in flowLayoutPanel1_Paint
        private List<string> coursessName()
        {
            var courses = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"SELECT c.co_name
                                    FROM Course c
                                    INNER JOIN Instructor_Course IC ON c.co_id = IC.co_id
                                    WHERE IC.ins_id = @ins_id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ins_id", instructorId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                courses.Add(reader["co_name"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }

            return courses;
        }
        private void courseId(string courseName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"SELECT co_id
                                    FROM Course
                                    WHERE co_name = @courseName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@courseName", courseName);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                _courseIdSelected = (int)reader["co_id"];
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }

        }
        private List<string> tracksName()
        {
            var tracks = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"SELECT t.track_name
                                    FROM Track t
                                    INNER JOIN Instructor_Track IT ON t.track_id = IT.track_id
                                    INNER JOIN Track_Course TC ON t.track_id = TC.track_id
                                    WHERE IT.ins_id = @ins_id AND TC.co_id = @co_id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ins_id", instructorId);
                        command.Parameters.AddWithValue("@co_id", _courseIdSelected);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tracks.Add(reader["track_name"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            return tracks;
        }
        private int GetTrackId(string trackName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT track_id FROM Track WHERE track_name = @trackName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@trackName", trackName);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return (int)reader["track_id"];
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }

            return -1; // Return -1 if no track found
        }
        private void button2_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            List<string> _tracksNames = tracksName();
            if (_tracksNames.Count > 0)
            {
                foreach (var track in _tracksNames)
                {
                    checkedListBox1.Items.Add(track);
                }
            }
            else
            {
                MessageBox.Show("No tracks found for the given instructor and course.");
            }
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }
        private void label2_Click(object sender, EventArgs e)
        {
        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void label3_Click(object sender, EventArgs e)
        {
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}