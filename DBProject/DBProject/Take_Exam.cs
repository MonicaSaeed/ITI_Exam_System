using Microsoft.Data.SqlClient;

namespace DBProject
{
    public partial class Take_Exam : Form
    {
        private Dictionary<int, (string QuestionText, List<(string, int)> Options)> examData = new();
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=ExaminationSystem;Integrated Security=True;TrustServerCertificate=True;";
        private Dictionary<int, List<int>> studentAnswers = new Dictionary<int, List<int>>();
        private System.Windows.Forms.Timer examTimer;
        private int remainingTime;
        private Label lblTimer;
        private Panel scrollPanel;
        private VScrollBar vScrollBar;

        private int stId;



        public Take_Exam(int st_id, int exam_id)
        {
            remainingTime = getDuration(exam_id);
            stId = st_id;
            GetExam(exam_id);
            InitializeComponent();

        }
        private int getDuration(int examID)
        {
            int duration = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"                          
                        SELECT 
                            duration
                        FROM 
                            exam
                        WHERE 
                            ex_id = @examId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@examId", examID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            duration = reader.GetInt32(0);
                        }
                    }
                }

            }
            return duration * 60; //in seconds

        }
        private void ExamTimer_Tick(object sender, EventArgs e)
        {
            remainingTime--;

            lblTimer.Text = $"Time Remaining: {TimeSpan.FromSeconds(remainingTime):hh\\:mm\\:ss}";

            if (remainingTime <= 0)
            {
                examTimer.Stop();
                SubmitExam();
            }
        }
        private void GetExam(int exam_id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                List<(int QuestionId, string QuestionText)> questions = new List<(int, string)>();

                string questionQuery = @"
                                        SELECT 
                                            q.q_id, 
                                            q.text 
                                        FROM 
                                            Question q
                                        WHERE 
                                            q.ex_id = @exid;";

                using (SqlCommand questionCommand = new SqlCommand(questionQuery, connection))
                {
                    questionCommand.Parameters.AddWithValue("@exid", exam_id);

                    using (SqlDataReader questionReader = questionCommand.ExecuteReader())
                    {
                        while (questionReader.Read())
                        {
                            int questionId = questionReader.GetInt32(0);
                            string questionText = questionReader.GetString(1);

                            questions.Add((questionId, questionText));
                        }
                    }
                }
                foreach (var question in questions)
                {
                    List<(string, int)> options = GetOptionsForQuestion(connection, question.QuestionId);
                    examData[question.QuestionId] = (question.QuestionText, options);
                }
            }
        }




        private List<(string, int)> GetOptionsForQuestion(SqlConnection connection, int questionID)
        {
            var options = new List<(string, int)>();

            string query = @"
                            SELECT 
                                op_id, 
                                op_text 
                            FROM 
                                [Option]
                            WHERE 
                                q_id = @QID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@QID", questionID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int optionID = reader.GetInt32(0);
                        string optionText = reader.GetString(1);
                        options.Add((optionText, optionID));
                    }
                }
            }

            return options;
        }



        private bool IsMultiAnswers(int questionID)
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"                          
                        SELECT 
                            COUNT(is_correct)
                        FROM 
                            [Option]
                        WHERE 
                            q_id = @QID AND is_correct = 1";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@QID", questionID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            count = reader.GetInt32(0);
                        }
                    }
                }

            }
            return count > 1;
        }

        private void OptionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox optionCheckBox = sender as CheckBox;
            if (optionCheckBox != null)
            {
                var (questionID, optionID) = ((int, int))optionCheckBox.Tag;

                if (optionCheckBox.Checked)
                {
                    if (!studentAnswers.ContainsKey(questionID))
                    {
                        studentAnswers[questionID] = new List<int>();
                    }
                    studentAnswers[questionID].Add(optionID);

                    optionCheckBox.BackColor = Color.Gray;
                    optionCheckBox.ForeColor = Color.White;
                }
                else
                {
                    // Remove the unselected option from the list for this question
                    if (studentAnswers.ContainsKey(questionID))
                    {
                        studentAnswers[questionID].Remove(optionID);

                        // If no options are selected for this question, remove the question from the dictionary
                        if (studentAnswers[questionID].Count == 0)
                        {
                            studentAnswers.Remove(questionID);
                        }
                    }

                    // Update the UI
                    optionCheckBox.BackColor = Color.Teal;
                    optionCheckBox.ForeColor = Color.White;
                }
            }
        }
        private void optionButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton optionButton = sender as RadioButton;
            if (optionButton != null && optionButton.Checked)
            {
                var (questionID, optionID) = ((int, int))optionButton.Tag;

                studentAnswers[questionID] = [optionID];

                optionButton.BackColor = Color.Gray;
                optionButton.ForeColor = Color.White;
            }
            else
            {
                optionButton.BackColor = Color.Teal;
                optionButton.ForeColor = Color.White;
            }
        }

        private void SubmitExam()
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (var answer in studentAnswers)
                {
                    int questionID = answer.Key;
                    List<int> optionIDs = answer.Value;

                    foreach (int optionID in optionIDs)
                    {
                        string query = @"
                                        INSERT INTO student_answer (st_id, q_id, op_id)
                                        VALUES (@StudentID, @QuestionID, @OptionID)";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@StudentID", stId);
                            command.Parameters.AddWithValue("@QuestionID", questionID);
                            command.Parameters.AddWithValue("@OptionID", optionID);

                            command.ExecuteNonQuery();
                        }
                    }
                }
            }

            MessageBox.Show("Exam Ended! Returning to Home.", "Exam Ended", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            examTimer.Stop();
            SubmitExam();

        }

        private void VScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            foreach (Control control in scrollPanel.Controls)
            {
                control.Top = control.Top - (e.NewValue - e.OldValue);
            }
        }

        private void Take_Exam_Load(object sender, EventArgs e)
        {

        }

        private void scrollPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}