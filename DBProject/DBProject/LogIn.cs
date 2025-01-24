using Microsoft.Data.SqlClient;


namespace DBProject
{
    public partial class LogIn : Form
    {

        string connectionString = "Server=localhost\\SQLEXPRESS;Database=ExaminationSystem;Integrated Security=True;TrustServerCertificate=True;";
        public LogIn()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }

        private void ButtonStudent_Click(object sender, EventArgs e)
        {
            buttonStudent.BackColor = Color.Teal;
            buttonStudent.ForeColor = Color.White;

            buttonInstructor.BackColor = Color.White;
            buttonInstructor.ForeColor = Color.Teal;

        }

        private void ButtonInstructor_Click(object sender, EventArgs e)
        {
            buttonInstructor.BackColor = Color.Teal;
            buttonInstructor.ForeColor = Color.White;

            buttonStudent.BackColor = Color.White;
            buttonStudent.ForeColor = Color.Teal;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Retrieve the email from textBox1
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
            // Check if the email exists in the database
            if (IsEmailExistsAndMatchPass(enteredEmail, enteredPass))
            {
                MessageBox.Show("Email Founded.", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                /*
                    if button student selected --> open and pass st_id to form student
                    else if instructor button selected --> open and pass ins_id to form instructor
                */
            }
            else
            {
                MessageBox.Show("Email does not exist or wrong password.", "Try Adain", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private bool IsEmailExistsAndMatchPass(string email, string password)
        {
            bool foundcorrectly = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                /****also check which button and edit query ****/
                string query = "SELECT st_email FROM Student WHERE st_email = @Email and st_password = @Pass";

                using (SqlCommand command = new SqlCommand(query, connection))
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
    }
}
