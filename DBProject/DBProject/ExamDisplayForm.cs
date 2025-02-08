using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

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
                ExamTitleLabel.ForeColor = Color.Teal;
            }

            QuestionsFlowLayoutPanel.SetFlowBreak(ExamTitleLabel, true);

            // Initialize question number
            int questionNumber = 1;

            // Fetch questions for the exam
            DataTable questions = dbHelper.GetQuestions(examId);
            foreach (DataRow questionRow in questions.Rows)
            {
                GroupBox questionGroupBox = new GroupBox
                {
                    Text = $"Q{questionNumber}: {questionRow["text"]}",
                    Font = new Font("Courier New", 10, FontStyle.Bold),
                    AutoSize = true,
                    Width = QuestionsFlowLayoutPanel.Width - 50,
                    AutoSizeMode = AutoSizeMode.GrowOnly,
                    Padding = new Padding(10),
                    Margin = new Padding(5)
                };

                FlowLayoutPanel questionPanel = new FlowLayoutPanel
                {
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowOnly,
                    FlowDirection = FlowDirection.TopDown,
                    Dock = DockStyle.Fill,
                    MinimumSize = new Size(QuestionsFlowLayoutPanel.Width - 50, 0)
                };

                FlowLayoutPanel optionsFlowLayoutPanel = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.LeftToRight,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowOnly,
                    WrapContents = true,
                    Dock = DockStyle.Top,
                    Padding = new Padding(5)
                };

                int questionId = Convert.ToInt32(questionRow["q_id"]);
                DataTable options = dbHelper.GetOptions(questionId);
                bool isCorrectAnswerSelected = false;

                int opNum = 0;

                int FinalHight = 0;
                foreach (DataRow optionRow in options.Rows)
                {
                    string optionText = optionRow["op_text"].ToString();

                    Size textSize = TextRenderer.MeasureText(optionText, new Font("Courier New", 12, FontStyle.Regular));
                    int factor = textSize.Width / (questionGroupBox.Width / 2);
                    int optionHeight = (factor >= 1) ? 40 * (factor + 1) : 40;

                    FinalHight = Math.Max(FinalHight, optionHeight);
                }

                foreach (DataRow optionRow in options.Rows)
                {
                    bool isCorrect = Convert.ToBoolean(optionRow["is_correct"]);
                    string optionText = optionRow["op_text"].ToString();
                    opNum++;


                    Button optionButton = new Button
                    {
                        Text = optionText,
                        AutoSize = false,
                        Size = new Size(questionGroupBox.Width / 2 - 10, FinalHight+10),
                        Margin = new Padding(5),
                        BackColor = isCorrect ? Color.Green : Color.White,
                        ForeColor = isCorrect ? Color.White : Color.Black,
                        Font = new Font("Courier New", 10, FontStyle.Regular),
                       // Enabled = false // Disable buttons to indicate that this is a display screen
                    };
                    if (opNum >= 2)
                    {
                        QuestionsFlowLayoutPanel.SetFlowBreak(optionButton, true);
                        opNum = 0;
                    }

                    optionsFlowLayoutPanel.Controls.Add(optionButton);
                   
                }

                questionPanel.Controls.Add(optionsFlowLayoutPanel);

                // Add grade and status
                Label gradeLabel = new Label
                {
                    Text = $"Grade: {questionRow["grade"]}",
                    AutoSize = true,
                    Font = new Font("Courier New", 10, FontStyle.Bold),
                    Margin = new Padding(5)
                };

                

                FlowLayoutPanel gradeStatusPanel = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.LeftToRight,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    Dock = DockStyle.Bottom,
                    Margin = new Padding(10)
                };

                gradeStatusPanel.Controls.Add(gradeLabel);

                questionPanel.Controls.Add(gradeStatusPanel);
                questionGroupBox.Controls.Add(questionPanel);
                QuestionsFlowLayoutPanel.Controls.Add(questionGroupBox);
                QuestionsFlowLayoutPanel.SetFlowBreak(questionGroupBox, true);

                questionNumber++;
            }
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
