using Microsoft.Data.SqlClient;


namespace DBProject
{
    public partial class LogIn : Form
    {

        string connectionString = "Server=localhost\\SQLEXPRESS;Database=ExaminationSystem;Integrated Security=True;TrustServerCertificate=True;";
        string selectedType = "student";
        public LogIn()
        {
            InitializeComponent();
        }

        private void ButtonStudent_Click(object sender, EventArgs e)
        {
            buttonStudent.BackColor = Color.Teal;
            buttonStudent.ForeColor = Color.White;

            buttonInstructor.BackColor = Color.White;
            buttonInstructor.ForeColor = Color.Teal;

            selectedType = "student";
        }

        private void ButtonInstructor_Click(object sender, EventArgs e)
        {
            buttonInstructor.BackColor = Color.Teal;
            buttonInstructor.ForeColor = Color.White;

            buttonStudent.BackColor = Color.White;
            buttonStudent.ForeColor = Color.Teal;

            selectedType = "instructor";


        }
        private void button1_Click(object sender, EventArgs e)
        {
            string enteredEmail = textBox1.Text;
            string enteredPass = textBox2.Text;


            if (string.IsNullOrWhiteSpace(enteredEmail))
            {
                MessageBox.Show("Please enter an email.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(enteredPass))
            {
                MessageBox.Show("Please enter an password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (IsEmailExistsAndMatchPass(enteredEmail, enteredPass))
            {


                string returnedId = string.Empty;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query;

                    if (selectedType == "student")
                        query = "SELECT st_id FROM Student WHERE st_email = @Email AND st_password = @Pass";
                    else
                        query = "SELECT ins_id FROM Instructor WHERE ins_email = @Email AND ins_password = @Pass";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Email", enteredEmail);
                        cmd.Parameters.AddWithValue("@Pass", enteredPass);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows && reader.Read())
                            {
                                returnedId = reader[0].ToString() ?? " ";
                            }
                        }
                    }
                }
                if (selectedType == "student")
                {
                    Student_Courses form2 = new Student_Courses(int.Parse(returnedId));
                    form2.Show();
                    this.Hide();
                }
                else
                {

                    //var instructorForm = new InstructorForm(returnedId);
                    //studentForm.Show();
                    //this.Hide();

                    MessageBox.Show($"Instructor id {returnedId}.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }



            }
            else
            {
                MessageBox.Show("Email does not exist or wrong password.", "Try Adain", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        SqlCommand command;
        private bool IsEmailExistsAndMatchPass(string email, string password)
        {
            bool foundcorrectly = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query;
                if (selectedType == "student")
                    query = "SELECT st_id FROM Student WHERE st_email = @Email and st_password = @Pass";
                else
                    query = "SELECT ins_id FROM Instructor WHERE ins_email = @Email and ins_password = @Pass";

                using (command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Pass", password);


                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            foundcorrectly = true;
                        }
                    }
                }
            }

            return foundcorrectly;
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }
    }
}
