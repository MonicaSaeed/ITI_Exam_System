using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace AddExamForm_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (ValidateInputs(out DateTime startDate, out int duration))
            {
                // If validation is successful, insert data into the database
                InsertExamData(startDate, duration);
            }
        }

        private bool ValidateInputs(out DateTime startDate, out int duration)
        {
            // Reset output parameters
            startDate = DateTime.MinValue;
            duration = 0;

            // Validate Start Date
            if (!DateTime.TryParse(textBox2.Text, out startDate))
            {
                MessageBox.Show("Please enter a valid Start Date (e.g., YYYY-MM-DD).");
                return false;
            }

            // Validate Duration
            if (!int.TryParse(textBox3.Text, out duration) || duration <= 0)
            {
                MessageBox.Show("Please enter a valid Duration (positive integer).");
                return false;
            }

            return true; // All validations passed
        }

        private void InsertExamData(DateTime startDate, int duration)
        {
            using (SqlConnection con = new SqlConnection("Server=DESKTOP-JGIQ4Q8;Database=ExaminationSystem;Trusted_Connection=True;TrustServerCertificate=True;"))
            {
                try
                {
                    con.Open();
                    string query = "INSERT INTO Exam (start_date, duration) VALUES (@StartDate, @Duration);";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@Duration", duration);

                    // Execute the command
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Provide feedback to the user
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Exam added successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to add exam.");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"SQL Error: {ex.Message}");
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Optional: Add any logic you want to execute when the text changes
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // Optional: Add any logic you want to execute when the text changes
        }
    }
}