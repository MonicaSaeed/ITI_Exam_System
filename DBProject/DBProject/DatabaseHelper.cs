using System.Data.SqlClient;
using System.Data;

namespace InstructorPart
{
    internal class DatabaseHelper
    {
        private string connectionString = "Data Source=DESKTOP-I125DVC\\SQLEXPRESS;Initial Catalog=ITI_system;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        public DataTable GetExamName(int examId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT C.co_name AS examName FROM Course C JOIN Course_Exam CE ON C.co_id = CE.co_id WHERE CE.ex_id = @ExamId;", conn);
                cmd.Parameters.AddWithValue("@ExamId", examId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GetQuestions(int examId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Question WHERE ex_id = @ExamId", conn);
                cmd.Parameters.AddWithValue("@ExamId", examId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GetOptions(int questionId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Option] WHERE q_id = @QuestionId", conn);
                cmd.Parameters.AddWithValue("@QuestionId", questionId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}