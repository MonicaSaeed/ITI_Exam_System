using Microsoft.Data.SqlClient;


namespace DBProject
{
    public partial class Form1 : Form
    {

        string connectionString = "Server=localhost\\SQLEXPRESS;Database=ExaminationSystem;Integrated Security=True;TrustServerCertificate=True;";
        public Form1()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }
    }
}
