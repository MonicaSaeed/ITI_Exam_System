using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace InstructorPart
{
    public partial class GradesForm : Form
    {
        private int examId;

        public GradesForm(int examId)
        {
            InitializeComponent();
            this.examId = examId;
            LoadGrades();
        }

        private void LoadGrades()
        {
            DatabaseHelper dbHelper = new DatabaseHelper();

            TitleLabel.Text = $"Grades of {dbHelper.GetCourseName(examId)} Exam";

            DataTable dt = dbHelper.GetStudentCorrectAnswers(examId);

            if (dt.Rows.Count > 0)
            {
                   dataGridView2.DataSource = dt;
            }
            else
            {
                CustomMessageBox customMessageBox = new CustomMessageBox(
$"No data found.", // Message
"Error", // Title
MessageBoxIcon.Warning // Icon
);
                customMessageBox.ShowDialog();
                //MessageBox.Show("No data found.");
            }

            dataGridView2.ScrollBars = ScrollBars.Both;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.BorderStyle = BorderStyle.None;
        }


        private void GradesForm_Load(object sender, EventArgs e)
        {

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GradesForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
