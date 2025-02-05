using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBProject
{
    public partial class ExamResultsForm : Form
    {
        private List<(string Question, List<string> Options, string StudentAnswer, string CorrectAnswer, bool IsCorrect, int QuestionGrade)> results;
        private int totalGrade;
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=ExaminationSystem;Integrated Security=True;TrustServerCertificate=True;";

        public ExamResultsForm(int totalGrade, List<(string Question, List<string> Answers, string StudentAnswer, string CorrectAnswer, bool IsCorrect, int QuestionGrade)>  results1)
        {
            this.results = results1;
            this.totalGrade = totalGrade;
            InitializeComponent();
            
            //LoadResults();
        }
    }
}
