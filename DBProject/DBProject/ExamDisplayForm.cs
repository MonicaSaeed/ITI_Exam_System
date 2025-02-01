using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstructorPart
{
    public partial class ExamDisplayForm : Form
    {
        private int examId;
        public ExamDisplayForm(int examId)
        {
            InitializeComponent();
            this.examId = examId;
            LoadExam();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void LoadExam()
        {
            // Fetch exam details (e.g., exam name)
            DatabaseHelper dbHelper = new DatabaseHelper();
            DataTable examName = dbHelper.GetExamName(examId);
            if (examName.Rows.Count > 0)
            {
                ExamTitleLabel.Text = $"{examName.Rows[0]["examName"].ToString()} Exam";
            }

            QuestionsFlowLayoutPanel.SetFlowBreak(ExamTitleLabel, true);

            // Initialize question number
            int questionNumber = 1;

            // Fetch questions for the exam
            DataTable questions = dbHelper.GetQuestions(examId);
            foreach (DataRow questionRow in questions.Rows)
            {
                // Create a GroupBox for the question
                GroupBox questionGroupBox = new GroupBox();
                questionGroupBox.Text = $"Question {questionNumber}"; // Set the question number as the GroupBox text
                questionGroupBox.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
                questionGroupBox.AutoSize = true; // Allow the Panel to resize
                questionGroupBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                questionGroupBox.Width = QuestionsFlowLayoutPanel.Width - 100;

                // Create a Panel inside the GroupBox to hold the question text and options
                FlowLayoutPanel questionPanel = new FlowLayoutPanel();
                questionPanel.AutoSize = true; // Allow the Panel to resize
                questionPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                questionPanel.Dock = DockStyle.Fill; // Fill the GroupBox
                questionPanel.Padding = new Padding(10); // Add padding inside the Panel

                // Create a Label for the question text
                Label questionLabel = new Label();
                questionLabel.Text = questionRow["text"].ToString(); // Set the question text
                questionLabel.AutoSize = true; // Allow the Label to resize
                questionLabel.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Regular);
                questionLabel.Dock = DockStyle.Top; // Place the Label at the top of the Panel

                // Add the Label to the Panel
                questionPanel.Controls.Add(questionLabel);

                // Create a FlowLayoutPanel inside the Panel to hold the options
                FlowLayoutPanel optionsFlowLayoutPanel = new FlowLayoutPanel();
                optionsFlowLayoutPanel.FlowDirection = FlowDirection.TopDown; // Arrange options vertically
                optionsFlowLayoutPanel.AutoSize = true; // Allow the FlowLayoutPanel to resize
                optionsFlowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                optionsFlowLayoutPanel.WrapContents = true; // Wrap options to a new line if they overflow
                optionsFlowLayoutPanel.Dock = DockStyle.Fill; // Fill the remaining space in the Panel

                // Fetch options for the question
                int questionId = Convert.ToInt32(questionRow["q_id"]);
                DataTable options = dbHelper.GetOptions(questionId);
                foreach (DataRow optionRow in options.Rows)
                {
                    // Check if the option is correct
                    bool isCorrect = Convert.ToBoolean(optionRow["is_correct"]);

                    if (isCorrect)
                    {
                        // Use a Label for the correct option
                        Label correctOptionLabel = new Label();
                        correctOptionLabel.Text = $"✔ {optionRow["op_text"].ToString()}"; // Add a checkmark
                        correctOptionLabel.AutoSize = true;
                        correctOptionLabel.ForeColor = Color.Green; // Highlight the correct option in green
                        correctOptionLabel.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
                        correctOptionLabel.Margin = new Padding(5); // Add margin around the Label
                        optionsFlowLayoutPanel.Controls.Add(correctOptionLabel);
                    }
                    else
                    {
                        // Use a CheckBox for incorrect options
                        CheckBox optionCheckBox = new CheckBox();
                        optionCheckBox.Text = optionRow["op_text"].ToString();
                        optionCheckBox.AutoSize = true;
                        optionCheckBox.Margin = new Padding(5); // Add margin around each CheckBox
                        optionsFlowLayoutPanel.Controls.Add(optionCheckBox);
                    }
                }

                // Add the FlowLayoutPanel to the Panel
                questionPanel.Controls.Add(optionsFlowLayoutPanel);

                // Add the Panel to the GroupBox
                questionGroupBox.Controls.Add(questionPanel);

                // Add the GroupBox to the main FlowLayoutPanel
                QuestionsFlowLayoutPanel.Controls.Add(questionGroupBox);

                // Set a flow break to ensure the next GroupBox starts on a new line
                QuestionsFlowLayoutPanel.SetFlowBreak(questionGroupBox, true);

                // Increment the question number for the next question
                questionNumber++;
            }

            // Enable scrolling if content exceeds the panel size
            QuestionsFlowLayoutPanel.AutoScroll = true;
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the current form and return to the previous page
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ExamTitleLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
