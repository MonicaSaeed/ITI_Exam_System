using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.Devices;
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
        int instructorId , courseId1; // Replace with actual instructor ID

        private string _courseNameSelected;
       // private int _courseIdSelected;
        private List<int> _tracksIdsSelected;

        int newExamId;

        string connectionString = "Server=localhost\\SQLEXPRESS;Database=ExaminationSystem;Integrated Security=True;TrustServerCertificate=True;";

        public Create_Exam_SelectTracks(int insId,int crs_id)
        {
            instructorId = insId;
            courseId1 = crs_id;
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
            #region course_button
            //var courses = coursessName();
            //foreach (var course in courses)
            //{
            //    var courseButton = new Button()
            //    {
            //        Text = course,
            //        AutoSize = true,
            //        BackColor = Color.LightGray,
            //        Tag = course // Store course name in Tag
            //    };

            //    courseButton.Click += (s, args) =>
            //    {
            //        _courseNameSelected = courseButton.Text;
            //        courseId(_courseNameSelected);
            //        //MessageBox.Show($"Selected Course: {_courseNameSelected}, ID: {_courseIdSelected}");
            //    };

            //    flowLayoutPanel1.Controls.Add(courseButton);
            // }
            #endregion

        }
        private void button3_Click(object sender, EventArgs e)
        {
            Instructor_Courses_Exam instructorCoursesExamForm = new Instructor_Courses_Exam(courseId1,instructorId); // Pass the instructor_id

            this.Hide();
            instructorCoursesExamForm.ShowDialog();
            this.Close();
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

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        foreach (int trackId in _tracksIdsSelected)
                        {


                            // Check if the exam already exists for the same course and track
                            string checkDuplicateQuery = @"SELECT COUNT(*) FROM Course_Exam 
                                                   WHERE co_id = @courseId AND track_id = @trackId";
                            using (SqlCommand checkCommand = new SqlCommand(checkDuplicateQuery, connection))
                            {
                                checkCommand.Parameters.AddWithValue("@courseId", courseId1);
                                checkCommand.Parameters.AddWithValue("@trackId", trackId);
                                int count = Convert.ToInt32(checkCommand.ExecuteScalar());
                                if (count > 0)
                                {
                                    // Show message and stop the process
                                    CustomMessageBox customMessageBox = new CustomMessageBox(
                                        $"An exam already exists for this Course.",
                                        "Duplicate Exam",
                                        MessageBoxIcon.Warning);
                                    customMessageBox.ShowDialog();
                                    return;
                                }
                            }

                            // Insert into Course_Exam only if no duplicate is found
                            string insertCourseExamQuery = @"INSERT INTO Course_Exam (ex_id, co_id, track_id)
                                                     VALUES (@examId, @courseId, @trackId)";

                            using (SqlCommand command = new SqlCommand(insertCourseExamQuery, connection))
                            {
                                command.Parameters.AddWithValue("@examId", newExamId);
                                command.Parameters.AddWithValue("@courseId", courseId1);
                                command.Parameters.AddWithValue("@trackId", trackId);
                                command.ExecuteNonQuery();
                            }
                        }
                    }

                    scope.Complete();
                    CustomMessageBox successMessageBox = new CustomMessageBox(
                        "Exam created and tracks assigned successfully.", "Exam Creation", MessageBoxIcon.Question);
                    successMessageBox.ShowDialog();
                }
                catch (SqlException sqlEx)
                {
                    CustomMessageBox errorMessageBox = new CustomMessageBox(
                        $"Database Error: {sqlEx.Message}", "Error", MessageBoxIcon.Error);
                    errorMessageBox.ShowDialog();
                }
                catch (Exception ex)
                {
                    CustomMessageBox errorMessageBox = new CustomMessageBox(
                        $"Unexpected Error: {ex.Message}", "Error", MessageBoxIcon.Error);
                    errorMessageBox.ShowDialog();
                }
            }

            // Open the next form
            Create_Questions q = new Create_Questions(instructorId);
            q.ExamIdInQuestion = newExamId;
            q.Show();
            this.Hide();
        }


        // to show all courses in flowLayoutPanel1_Paint
//        private List<string> coursessName()
//        {
//            var courses = new List<string>();

//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                try
//                {
//                    connection.Open();
//                    string query = @"SELECT c.co_name
//                                    FROM Course c
//                                    INNER JOIN Instructor_Course IC ON c.co_id = @crs_id
//                                    WHERE IC.ins_id = @ins_id";
//                    using (SqlCommand command = new SqlCommand(query, connection))
//                    {
//                        command.Parameters.AddWithValue("@ins_id", instructorId);
//                        command.Parameters.AddWithValue("@crs_id", courseId1);

//                        using (SqlDataReader reader = command.ExecuteReader())
//                        {
//                            while (reader.Read())
//                            {
//                                courses.Add(reader["co_name"].ToString());
//                            }
//                        }
//                    }
//                }
//                catch (Exception ex)
//                {
//                    //MessageBox.Show($"Error: {ex.Message}");
//                    CustomMessageBox customMessageBox = new CustomMessageBox(
//            $"Error: {ex.Message}.", // Message
//            "Error", // Title
//            MessageBoxIcon.Warning // Icon
//);
//                    customMessageBox.ShowDialog();
//                }
//            }

//            return courses;
//        }
//        private void courseId(string courseName)
//        {
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                try
//                {
//                    connection.Open();
//                    string query = @"SELECT co_id
//                                    FROM Course
//                                    WHERE co_name = @courseName";

//                    using (SqlCommand command = new SqlCommand(query, connection))
//                    {
//                        command.Parameters.AddWithValue("@courseName", courseName);

//                        using (SqlDataReader reader = command.ExecuteReader())
//                        {

//                            if (reader.Read())
//                            {
//                                _courseIdSelected = (int)reader["co_id"];
//                            }
//                        }
//                    }
//                }
//                catch (Exception ex)
//                {
//                    //  MessageBox.Show($"Error: {ex.Message}");
//                    CustomMessageBox customMessageBox = new CustomMessageBox(
//              $"Error: {ex.Message}.", // Message
//              "Error", // Title
//              MessageBoxIcon.Warning // Icon
//);
//                    customMessageBox.ShowDialog();
//                }
//            }

//        }
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
                        command.Parameters.AddWithValue("@co_id", courseId1);

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
                    //MessageBox.Show($"Error: {ex.Message}");
                    CustomMessageBox customMessageBox = new CustomMessageBox(
            $"Error: {ex.Message}", // Message
            "Error", // Title
            MessageBoxIcon.Warning // Icon
);
                    customMessageBox.ShowDialog();
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
                    //MessageBox.Show($"Error: {ex.Message}");
                    CustomMessageBox customMessageBox = new CustomMessageBox(
          $"Error: {ex.Message}", // Message
          "Error", // Title
          MessageBoxIcon.Warning // Icon
);
                    customMessageBox.ShowDialog();
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
                //MessageBox.Show("No tracks found for the given instructor and course.");
                CustomMessageBox customMessageBox = new CustomMessageBox(
          "No tracks found for the given instructor and course.", // Message
          "Error", // Title
          MessageBoxIcon.Warning // Icon
);
                customMessageBox.ShowDialog();
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