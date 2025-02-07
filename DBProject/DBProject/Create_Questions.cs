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
        Form popup = new Form();

        string connectionString = "Server=localhost\\SQLEXPRESS;Database=ExaminationSystem;Integrated Security=True;TrustServerCertificate=True;";

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ExamIdInQuestion { get; set; }
        public Create_Questions()
        {
            InitializeComponent();
            button1.Click += new EventHandler(button1_Click);

            ExamIdInQuestion = 10; // Setting ExamIdInQuestion to 10
        }

        private void Create_Questions_Load(object sender, EventArgs e)
        {
            showQuestions();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            popup = new Form
            {
                Width = 800,
                Height = 700,
                Text = "Question Details",
                StartPosition = FormStartPosition.CenterScreen,
                AutoScroll = true // Enable scrolling for the form
            };

            // Save Button
            Button save = new Button
            {
                Location = new System.Drawing.Point(650, 550),
                Text = "Save Question",
                BackColor = Color.Teal,
                ForeColor = Color.White,
                Height = 50,
                Width = 80,
                Name = "SaveButton"
            };


            // for question text
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
                Width = 500
            };
            popup.Controls.Add(textBox);

            // for question grade
            Label label2 = new Label
            {
                Text = "Enter question grade:",
                Location = new System.Drawing.Point(20, 100),
                AutoSize = true
            };
            popup.Controls.Add(label2);

            NumericUpDown numericUpDown1 = new NumericUpDown()
            {
                Location = new System.Drawing.Point(20, 130),
                Width = 200
            };
            popup.Controls.Add(numericUpDown1);

            // for question type
            Label label3 = new Label
            {
                Text = "Select question type:",
                Location = new System.Drawing.Point(20, 180),
                AutoSize = true
            };
            popup.Controls.Add(label3);

            ComboBox comboBox = new ComboBox
            {
                Location = new System.Drawing.Point(20, 210),
                Width = 200
            };
            comboBox.Items.AddRange(new string[] { "T/F", "MCQ" });
            popup.Controls.Add(comboBox);


            int optionNumMCQ = 0; // to save number of option need to add if question MCQ
            int torf = 0; // to save true or false is correct if question is t/f

            // Event handler for ComboBox selection(T/F, MCQ)
            comboBox.SelectedIndexChanged += (s, args) =>
            {
                // Clear previously added controls if select mcq after this select t/f
                var controlsToRemove = new System.Windows.Forms.Control[popup.Controls.Count];
                popup.Controls.CopyTo(controlsToRemove, 0);
                foreach (var control in controlsToRemove)
                {
                    if (control.Location.Y > 250 && control.Name != "SaveButton")
                    {
                        popup.Controls.Remove(control);
                    }
                }

                if (comboBox.SelectedIndex == 0)
                {
                    Label tfLabel = new Label
                    {
                        Text = "Is the statement True or False?",
                        Location = new System.Drawing.Point(20, 260),
                        AutoSize = true
                    };
                    popup.Controls.Add(tfLabel);

                    ComboBox tfComboBox = new ComboBox
                    {
                        Name = "tfComboBox", 
                        Location = new System.Drawing.Point(20, 290),
                        Width = 200
                    };
                    tfComboBox.Items.AddRange(new string[] { "True", "False" });
                    tfComboBox.SelectedIndex = 0; // Default selection
                    popup.Controls.Add(tfComboBox);
                }
                else if (comboBox.SelectedIndex == 1)
                {
                    Label label4 = new Label
                    {
                        Text = "Enter number of options for the MCQ question:",
                        Location = new System.Drawing.Point(20, 260),
                        AutoSize = true
                    };
                    popup.Controls.Add(label4);

                    NumericUpDown numericUpDown2 = new NumericUpDown()
                    {
                        Location = new System.Drawing.Point(20, 290),
                        Width = 200
                    };
                    popup.Controls.Add(numericUpDown2);

                    numericUpDown2.ValueChanged += (numSender, numArgs) =>
                    {
                        optionNumMCQ = (int)numericUpDown2.Value;
                        int startY = 330; // Starting Y position for options

                        //////Clear previous option controls
                        var controlsToRemove = popup.Controls.OfType<Control>()
                            .Where(c => c.Location.Y > 250 && c.Name != "SaveButton").ToList();
                        foreach (var control in controlsToRemove)
                        {
                            popup.Controls.Remove(control);
                        }

                        for (int i = 0; i < optionNumMCQ; i++)
                        {
                            Label optionLabel = new Label
                            {
                                Text = $"Option {i + 1}:",
                                Location = new System.Drawing.Point(20, startY + (i * 40)),
                                AutoSize = true
                            };
                            popup.Controls.Add(optionLabel);

                            TextBox optionTextBox = new TextBox
                            {
                                Name = $"optionTextBox{i}", 
                                Location = new System.Drawing.Point(100, startY + (i * 40)),
                                Width = 300
                            };
                            popup.Controls.Add(optionTextBox);

                            ComboBox validityComboBox = new ComboBox
                            {
                                Name = $"validityComboBox{i}", 
                                Location = new System.Drawing.Point(420, startY + (i * 40)),
                                Width = 100
                            };
                            validityComboBox.Items.AddRange(new string[] { "Valid", "Invalid" });
                            validityComboBox.SelectedIndex = 0;
                            popup.Controls.Add(validityComboBox);
                        }
                    };

                }
            };

            bool clicked = false;
            save.Click += (s, args) =>
            {
                string questionText = textBox.Text;
                int grade = (int)numericUpDown1.Value;
                string questionType = comboBox.SelectedItem?.ToString();

                // Insert the question
                int questionId = insertQuestion(questionType, questionText, grade, ExamIdInQuestion);

                if (questionId != -1)
                {
                    if (questionType == "MCQ")
                    {
                        for (int i = 0; i < optionNumMCQ; i++)
                        {
                            TextBox optionTextBox = (TextBox)popup.Controls.Find($"optionTextBox{i}", true).FirstOrDefault();
                            ComboBox validityComboBox = (ComboBox)popup.Controls.Find($"validityComboBox{i}", true).FirstOrDefault();

                            if (optionTextBox != null && validityComboBox != null)
                            {
                                string optionText = optionTextBox.Text;
                                int isCorrect = validityComboBox.SelectedIndex == 0 ? 1 : 0;
                                //MessageBox.Show($"optionText {optionText}, isCorrect {isCorrect}, questionId {questionId}");
                                insertOption(optionText, isCorrect, questionId);
                            }
                            else
                            {
                                //MessageBox.Show($"Error: Option controls for index {i} were not found.");
                                CustomMessageBox customMessageBox1 = new CustomMessageBox(
$"Option controls for index {i} were not found.", // Message
"Error", // Title
MessageBoxIcon.Warning // Icon
);
                                customMessageBox1.ShowDialog();
                            }
                        }
                    }
                    else
                    {
                        ComboBox torf = (ComboBox)popup.Controls.Find("tfComboBox", true).FirstOrDefault();
                        if (torf != null)
                        {
                            int isSelect = torf.SelectedIndex;
                            if(isSelect == 0)
                            {
                                insertOption("T", 1, questionId);
                                insertOption("F", 0, questionId);
                            }
                            else
                            {
                                insertOption("T", 0, questionId);
                                insertOption("F", 1, questionId);
                            }

                        }
                        else
                        {
                            #region need_edit

                            //MessageBox.Show(string.Join(", ", popup.Controls.Cast<Control>().Select(c => c.Name)));
                            CustomMessageBox customMessageBox2 = new CustomMessageBox(
string.Join(", ", popup.Controls.Cast<Control>().Select(c => c.Name)), // Message
"Error", // Title
MessageBoxIcon.Warning // Icon
);
                            customMessageBox2.ShowDialog();
                            #endregion
                        }
                    }
                    CustomMessageBox customMessageBox = new CustomMessageBox(
$"Question and options saved successfully!", // Message
"Question Added", // Title
MessageBoxIcon.Question // Icon
);
                    customMessageBox.ShowDialog();
                    //  MessageBox.Show("Question and options saved successfully!");
                    popup.Hide();
                    clicked = true;
                    showQuestions();
                }
            };
          //  popup.Hide();

            popup.Controls.Add(save);
            if(!clicked)
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
                        command.Parameters.AddWithValue("@ex_id", ExamIdInQuestion);

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
                                //MessageBox.Show ($"Question ID: {questionId}, Text: {questionText}, Grade: {grade}, optionText: {optionText}, isCorrect {isCorrect} ");


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
                    CustomMessageBox customMessageBox = new CustomMessageBox(
$"Error: {ex.Message}", // Message
"Error", // Title
MessageBoxIcon.Warning // Icon
);
                    customMessageBox.ShowDialog();
                    //MessageBox.Show($"Error: {ex.Message}");
                }
            }

            return questionsList;
        }
        Panel scrollablePanel = new Panel
        {
            AutoScroll = true,
            Dock = DockStyle.Fill, // Fill the entire form
            BorderStyle = BorderStyle.FixedSingle, // Optional: adds a border around the panel
        };
        private void showQuestions()
        {
            label1.Text = "Create Exam: Step Two";
            label1.ForeColor = Color.Teal;
            label1.Location = new Point(20, 20);
            label1.Font = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.BackColor = Color.Black;
            button1.Location = new Point(800, 20);
            button1.Text = "Add Question";
            button1.Width = 150;
            button1.Height = 50;
            //this.button1.Click += new System.EventHandler(this.button1_Click);
            backButton.ForeColor = Color.White;
            backButton.BackColor = Color.Black;
            backButton.Location = new Point(400, 20);
            backButton.Text = "Back";
            backButton.Width = 150;
            backButton.Height = 50;
           
            //backButton.Click += (sender, e) => {
            //    this.Hide();
            //   Instructor_Courses_Exam CouresShow = new Instructor_Courses_Exam();
            //    CouresShow.ShowDialog();
            //};
            this.Controls.Add(backButton);
            List<QuestionDetails> questions = getQuestions();

            if (this.Controls.Contains(scrollablePanel))
            {
                this.Controls.Remove(scrollablePanel);
            }
            scrollablePanel = new Panel
            {
                AutoScroll = true,
                Dock = DockStyle.Fill, // Fill the entire form
                BorderStyle = BorderStyle.FixedSingle, // Optional: adds a border around the panel
            };
            this.Controls.Add(scrollablePanel);


            // Set the initial position for dynamically created controls within the panel
            int yOffset = 80;
            int xOffset = 20;
            int i = 1;
            foreach (var question in questions)
            {
                // Create a GroupBox for better visual separation
                CustomGroupBox questionGroup = new CustomGroupBox
                {
                    Font = new System.Drawing.Font("Arial", 12, FontStyle.Bold),
                    ForeColor = Color.Black,
                    AutoSize = false,
                    Size = new Size(900, 100), // Default height, adjusted later
                    Location = new Point(xOffset, yOffset),
                    Padding = new Padding(10),
                    BorderColor = Color.Gray
                };
                scrollablePanel.Controls.Add(questionGroup);

                // Add question text
                Label questionLabel = new Label
                {
                    Text = $"Q{i}: {question.QuestionText} ({question.Grade} pts)",
                    Font = new System.Drawing.Font("Arial", 12, FontStyle.Bold),
                    ForeColor = Color.Black,
                    AutoSize = true,
                    Location = new Point(20, 10)
                };
                questionGroup.Controls.Add(questionLabel);

                // Add question type label
                Label questionTypeLabel = new Label
                {
                    Text = question.QuestionType,
                    Font = new System.Drawing.Font("Arial", 12, FontStyle.Italic),
                    AutoSize = true,
                    ForeColor = Color.Gray,
                    Location = new Point(questionGroup.Width - 150, 10)
                };
                questionGroup.Controls.Add(questionTypeLabel);

                int optionYOffset = questionLabel.Height + 20;
                int finalHeight = 0;

                foreach (var option in question.Options)
                {
                    // Measure option text size
                    Size textSize = TextRenderer.MeasureText(option.OptionText, new System.Drawing.Font("Courier New", 12, FontStyle.Regular));
                    int factor = textSize.Width / 1060;
                    int optionHeight = (factor >= 1) ? 40 * (factor + 1) : 40; // Adjust height if text is long
                    finalHeight = Math.Max(finalHeight, optionHeight);
                }

                foreach (var option in question.Options)
                {
                    Label optionLabel = new Label
                    {
                        Text = option.OptionText,
                        Font = new System.Drawing.Font("Arial", 12, FontStyle.Regular),
                        //ForeColor = Color.Black,
                        Size = new Size(500, finalHeight),
                        Location = new Point(40, optionYOffset),
                        TextAlign = ContentAlignment.MiddleLeft,
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = option.IsCorrect ? Color.DarkGreen : Color.Transparent,
                        ForeColor = option.IsCorrect ? Color.White : Color.Black
                    };
                    questionGroup.Controls.Add(optionLabel);
                    optionYOffset += finalHeight + 5;
                }

                // Adjust the height of the questionGroup dynamically
                questionGroup.Height = optionYOffset + 20;
                yOffset += questionGroup.Height + 20;
                i++;
            }

        }

        // data base
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
                    //MessageBox.Show($"Error: {ex.Message}");
                    CustomMessageBox customMessageBox = new CustomMessageBox(
$"Error: {ex.Message}", // Message
"Error", // Title
MessageBoxIcon.Warning // Icon
);
                    customMessageBox.ShowDialog();
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
                        command.Parameters.AddWithValue("@q_id", q_id);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    CustomMessageBox customMessageBox = new CustomMessageBox(
$"Error: {ex.Message}", // Message
"Error", // Title
MessageBoxIcon.Warning // Icon
);
                    customMessageBox.ShowDialog();
                    //MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {
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