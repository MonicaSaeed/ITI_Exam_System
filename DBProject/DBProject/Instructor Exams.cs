using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Project_DataBase
{
    public partial class Form1 : Form
    {
        private DataGridView dataGridViewGrades;
        

        public Form1()
        {
            InitializeComponent();
            InitializeDataGridView();
            InitializeControls();
            
        }

        private void InitializeDataGridView()
        {
            dataGridViewGrades = new DataGridView
            {
                Location = new System.Drawing.Point(12, 350), // Adjusted for layout
                Size = new System.Drawing.Size(500, 400)
            };
            Controls.Add(dataGridViewGrades);
        }

        private void InitializeControls()
        {
            
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            // Navigate to AddExamForm
            AddExamForm_.Form1 addExamForm = new AddExamForm_.Form1();
            addExamForm.Show(); // Show the AddExamForm
            this.Hide(); // Optionally hide the current form
        }
        private void LoadGrades()
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = "Server=DESKTOP-JGIQ4Q8\\MSSQLSERVER1;Database=ExaminationSystem;Trusted_Connection=True;TrustServerCertificate=True;";
                try
                {
                    con.Open();
                    string query = "SELECT q.grade FROM Course c " +
                                   "INNER JOIN Course_Exam cex ON c.co_id = cex.co_id AND c.co_name = 'Database' " +
                                   "INNER JOIN Track t ON t.track_id = cex.track_id AND t.track_name = 'Mobile Applications Development (Cross Platform)' " +
                                   "INNER JOIN Question q ON cex.ex_id = q.ex_id";
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
        private void Form1_Load(object sender, EventArgs e)
        {
           // LoadGrades(); // Load grades on form load
        }
        private void LoadExams()
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = "Server=DESKTOP-JGIQ4Q8\\MSSQLSERVER1;Database=ExaminationSystem;Trusted_Connection=True;TrustServerCertificate=True;";
                try
                {
                    con.Open();
                    string query = "SELECT * FROM Exam"; // Adjust as needed
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
                con.ConnectionString = "Server=DESKTOP-JGIQ4Q8\\MSSQLSERVER1;Database=ExaminationSystem;Trusted_Connection=True;TrustServerCertificate=True;";
                try
                {
                    con.Open();
                    string query = "delete q\r\n\tfrom Course c inner join Course_Exam cex \r\n\ton c.co_id=cex.co_id and c.co_name='Database'\r\n\tinner join Track t  \r\n\ton t.track_id= cex.track_id and t.track_name='Mobile Applications Development (Cross Platform)'\r\n\tinner join Question q\r\n\ton  cex.ex_id=q.ex_id"; // Adjust as needed
                    SqlCommand cmd = new SqlCommand(query, con);

                    // Execute the DELETE command and get the number of affected rows
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Check if any rows were affected and display a message
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show(" deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("No Data Deleted");
                    }

                  
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"SQL Error :Data Conflicted");
                   // MessageBox.Show($"SQL Error: {ex.Message}");
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
            LoadGrades();// Add functionality for button8
        }

        private void View_Exam_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = "Server=DESKTOP-JGIQ4Q8\\MSSQLSERVER1;Database=ExaminationSystem;Trusted_Connection=True;TrustServerCertificate=True;";
                try
                {
                    con.Open();
                    string query = "select q.*\r\n\tfrom Course c inner join Course_Exam cex \r\n\ton c.co_id=cex.co_id and c.co_name='Database'\r\n\tinner join Track t  \r\n\ton t.track_id= cex.track_id and t.track_name='Mobile Applications Development (Cross Platform)'\r\n\tinner join Question q\r\n\ton  cex.ex_id=q.ex_id "; // Adjust table name if needed
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

        private void View_Exam2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = "Server=DESKTOP-JGIQ4Q8\\MSSQLSERVER1;Database=ExaminationSystem;Trusted_Connection=True;TrustServerCertificate=True;";
                try
                {
                    con.Open();
                    string query = "select q.*\r\n\tfrom Course c inner join Course_Exam cex \r\n\ton c.co_id=cex.co_id and c.co_name='Database'\r\n\tinner join Track t  \r\n\ton t.track_id= cex.track_id and t.track_name='Web & User Interface Development'\r\n\tinner join Question q\r\n\ton  cex.ex_id=q.ex_id "; // Adjust table name if needed
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

        private void Delete2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = "Server=DESKTOP-JGIQ4Q8\\MSSQLSERVER1;Database=ExaminationSystem;Trusted_Connection=True;TrustServerCertificate=True;";
                try
                {
                    con.Open();
                    string query = "delete q\r\n\tfrom Course c inner join Course_Exam cex \r\n\ton c.co_id=cex.co_id and c.co_name='Database'\r\n\tinner join Track t  \r\n\ton t.track_id= cex.track_id and t.track_name='Web & User Interface Development'\r\n\tinner join Question q\r\n\ton  cex.ex_id=q.ex_id"; // Adjust as needed
                    SqlCommand cmd = new SqlCommand(query, con);

                    // Execute the DELETE command and get the number of affected rows
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Check if any rows were affected and display a message
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show(" deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("No Data  Deleted.");
                    }

                 
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"SQL Error Data:Conflicted");
                    //MessageBox.Show($"SQL Error: {ex.Message}");
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}