using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Project_DataBase
{
    public partial class Form1 : Form
    {
        private DataGridView dataGridViewGrades;
        private TextBox textBoxExamName;
        private DateTimePicker dateTimePickerExamDate;

        public Form1()
        {
            InitializeComponent();
            InitializeDataGridView();
            InitializeControls();
            InitializeButtons();
        }

        private void InitializeDataGridView()
        {
            dataGridViewGrades = new DataGridView
            {
                Location = new System.Drawing.Point(12, 200),
                Size = new System.Drawing.Size(500, 400)
            };
            Controls.Add(dataGridViewGrades);
        }

        private void InitializeControls()
        {
            textBoxExamName = new TextBox
            {
                Location = new System.Drawing.Point(12, 50),
                Size = new System.Drawing.Size(200, 22)
            };
            Controls.Add(textBoxExamName);

            dateTimePickerExamDate = new DateTimePicker
            {
                Location = new System.Drawing.Point(12, 100),
                Size = new System.Drawing.Size(200, 22)
            };
            Controls.Add(dateTimePickerExamDate);
        }

        private void InitializeButtons()
        {
            Button button1 = new Button
            {
                Text = "Add Exam",
                Location = new System.Drawing.Point(12, 150),
                Size = new System.Drawing.Size(75, 23)
            };
            button1.Click += button1_Click;
            Controls.Add(button1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //LoadGrades();
        }

        private void LoadGrades()
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = "Server=DESKTOP-JGIQ4Q8\\MSSQLSERVER1;Database=ITI;Trusted_Connection=True;TrustServerCertificate=True;";
                try
                {
                    con.Open();
                    string query = "SELECT St_Id,Grade FROM Stud_Course";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridViewGrades.DataSource = dt; // Bind data to DataGridView
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"SQL Error: {ex.Message}");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Collect exam details from input fields
            string examName = textBoxExamName.Text; // TextBox for exam name
            DateTime examDate = dateTimePickerExamDate.Value; // DateTimePicker for exam date

            // Debugging: Show the collected values
            MessageBox.Show($"Exam Name: '{examName}'\nExam Date: {examDate.ToShortDateString()}");

            // Validate input
            if (string.IsNullOrWhiteSpace(examName))
            {
                MessageBox.Show("Please enter a valid exam name.");
                return;
            }

            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = "Server=DESKTOP-JGIQ4Q8\\MSSQLSERVER1;Database=ITI;Trusted_Connection=True;TrustServerCertificate=True;";
                try
                {
                    con.Open();
                    string query = "INSERT INTO Exams (ExamName, ExamDate) VALUES (@ExamName, @ExamDate);"; // Adjust column names as needed
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@ExamName", examName);
                    cmd.Parameters.AddWithValue("@ExamDate", examDate);

                    // Execute the command
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Provide feedback
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Exam added successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to add exam.");
                    }

                    // Optionally, reload the exams into the DataGridView
                    LoadExams(); // Method to refresh the data in the DataGridView
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"SQL Error: {ex.Message}");
                }
            }
        }

        // Method to load exams into the DataGridView (if needed)
        private void LoadExams()
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = "Server=DESKTOP-JGIQ4Q8\\MSSQLSERVER1;Database=ITI;Trusted_Connection=True;TrustServerCertificate=True;";
                try
                {
                    con.Open();
                    string query = "SELECT * FROM Exams"; // Adjust as needed
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridViewGrades.DataSource = dt; // Load data into the DataGridView
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"SQL Error: {ex.Message}");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Add functionality for button2
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Add functionality for button4
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoadGrades(); // Load grades when button6 is clicked, if needed
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = "Server=DESKTOP-JGIQ4Q8\\MSSQLSERVER1;Database=ITI;Trusted_Connection=True;TrustServerCertificate=True;";
                try
                {
                    con.Open();
                    string query = "DELETE FROM Instructor WHERE Ins_Id = 1;"; // Adjust as needed
                    SqlCommand cmd = new SqlCommand(query, con);

                    // Execute the DELETE command and get the number of affected rows
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Check if any rows were affected and display a message
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Instructor deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("No instructor found with the specified ID.");
                    }

                    // Optionally, you can refresh the DataGridView after deletion
                    LoadInstructors(); // Create a method to reload data if necessary
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"SQL Error balala");
                    //MessageBox.Show($"SQL Error: {ex.Message}");
                }
                finally
                {
                    con.Close();
                }
            }
        }

        // Method to reload instructors into the DataGridView (if needed)
        private void LoadInstructors()
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = "Server=DESKTOP-JGIQ4Q8\\MSSQLSERVER1;Database=ITI;Trusted_Connection=True;TrustServerCertificate=True;";
                try
                {
                    con.Open();
                    string query = "SELECT * FROM Instructor"; // Adjust as needed
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridViewGrades.DataSource = dt; // Reload data into the DataGridView
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"SQL Error: {ex.Message}");
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Add functionality for button8
        }

        private void View_Exam_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = "Server=DESKTOP-JGIQ4Q8\\MSSQLSERVER1;Database=ITI;Trusted_Connection=True;TrustServerCertificate=True;";
                try
                {
                    con.Open();
                    string query = "Select * from Course "; // Adjust table name if needed
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridViewGrades.DataSource = dt; // Assuming you want to display exams in the same DataGridView
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"SQL Error: {ex.Message}");
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}