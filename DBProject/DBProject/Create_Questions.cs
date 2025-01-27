using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DBProject
{
    public partial class Create_Questions : Form
    {
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=ExaminationSystem;Integrated Security=True;TrustServerCertificate=True;";

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ExamIdInQuestion { get; set; }

        public Create_Questions()
        {
            InitializeComponent();
        }

        private void Create_Questions_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form popup = new Form
            {
                Width = 800,
                Height = 500,
                Text = "Question Details",
                StartPosition = FormStartPosition.CenterScreen
            };
            Label label = new Label
            {
                Text = "Enter question text:",
                Location = new System.Drawing.Point(20, 20),
                AutoSize = true
            };
            popup.Controls.Add(label);
            TextBox textBox = new TextBox
            {
                Location = new System.Drawing.Point(20, 50),
                Width = 200
            };
            popup.Controls.Add(textBox);
            popup.Show();
        }

        private List<QuestionDetails> getQuestions()
        {
            List<QuestionDetails> questionsList = new List<QuestionDetails>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"SELECT q.q_id, q.q_type, q.text, q.grade, o.op_text, o.is_correct
                             FROM Question q
                             INNER JOIN [Option] o ON q.q_id = o.q_id
                             WHERE q.ex_id = @ex_id
                             ORDER BY q.q_id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ex_id", 1);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Dictionary<int, QuestionDetails> questionsMap = new Dictionary<int, QuestionDetails>();

                            while (reader.Read())
                            {
                                int questionId = reader.GetInt32(0);
                                string questionType = reader.GetString(1);
                                string questionText = reader.GetString(2);
                                int grade = reader.GetInt32(3);
                                string optionText = reader.GetString(4);
                                bool isCorrect = reader.GetBoolean(5);

                                if (!questionsMap.ContainsKey(questionId))
                                {
                                    questionsMap[questionId] = new QuestionDetails
                                    {
                                        QuestionId = questionId,
                                        QuestionType = questionType,
                                        QuestionText = questionText,
                                        Grade = grade
                                    };
                                }

                                questionsMap[questionId].Options.Add(new OptionDetails
                                {
                                    OptionText = optionText,
                                    IsCorrect = isCorrect
                                });
                            }

                            questionsList = questionsMap.Values.ToList();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }

            return questionsList;
        }

        private void showQuestions()
        {
            List<QuestionDetails> questions = getQuestions();

            // Create a scrollable panel
            Panel scrollablePanel = new Panel
            {
                AutoScroll = true,
                Dock = DockStyle.Fill, // Fill the entire form
                BorderStyle = BorderStyle.FixedSingle, // Optional: adds a border around the panel
            };
            this.Controls.Add(scrollablePanel);

            // Set the initial position for dynamically created controls within the panel
            int yOffset = 100; // Vertical space between controls
            int xOffset = 20; // Horizontal space from the left

            foreach (var question in questions)
            {
                // Create and add a label for the question text
                Label questionLabel = new Label
                {
                    Text = $"Q{question.QuestionId}: {question.QuestionText} ({question.Grade} pts)",
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    Location = new Point(xOffset, yOffset)
                };
                scrollablePanel.Controls.Add(questionLabel);

                // Create and add a label to display the question type on the right
                Label questionTypeLabel = new Label
                {
                    Text = question.QuestionType,
                    AutoSize = true,
                    Font = new Font("Arial", 9, FontStyle.Italic),
                    Location = new Point(scrollablePanel.Width - 150, yOffset), // Right side
                    ForeColor = Color.Gray
                };
                scrollablePanel.Controls.Add(questionTypeLabel);

                yOffset += 30; // Move down for the options

                foreach (var option in question.Options)
                {
                    // Create and add a label for each option
                    Label optionLabel = new Label
                    {
                        Text = $"- {option.OptionText}",
                        AutoSize = true,
                        Font = new Font("Arial", 9),
                        Location = new Point(xOffset + 20, yOffset), // Indented from the question
                        ForeColor = option.IsCorrect ? Color.Green : Color.Black // Highlight correct options in green
                    };
                    scrollablePanel.Controls.Add(optionLabel);

                    yOffset += 25; // Space between options
                }
                yOffset += 15; // Extra space between questions
            }
        }
        
        private int insertQuestion(string q_type, string text, int grade, int ex_id)
        {
            int qId = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"INSERT INTO Question (q_type, text, grade, ex_id) 
                                    VALUES (@q_type, @text, @grade, @ex_id);
                                    SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@q_type", q_type);
                        command.Parameters.AddWithValue("@text", text);
                        command.Parameters.AddWithValue("@grade", grade);
                        command.Parameters.AddWithValue("@ex_id", ex_id);
                        qId = Convert.ToInt32(command.ExecuteScalar());

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            return qId;
        }
        private void insertOption(string op_text, int is_correct, int q_id){
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"INSERT INTO [Option] (op_text, is_correct, q_id) 
                                    VALUES (@op_text, @is_correct, @q_id);";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@op_text", op_text);
                        command.Parameters.AddWithValue("@is_correct", is_correct);
                        command.Parameters.AddWithValue("@grade", q_id);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
    
    }
}
public class QuestionDetails
{
    public int QuestionId { get; set; }
    public string QuestionType { get; set; }
    public string QuestionText { get; set; }
    public int Grade { get; set; }
    public List<OptionDetails> Options { get; set; } = new List<OptionDetails>();
}

public class OptionDetails
{
    public string OptionText { get; set; }
    public bool IsCorrect { get; set; }
}