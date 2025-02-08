namespace DBProject
{
    public partial class ExamResultsForm : Form
    {
        private List<(string Question, List<string> Options, List<string> StudentAnswers, List<string> CorrectAnswers, int QuestionGrade)> results;
        private int totalGrade, actualTotal;
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=ExaminationSystem;Integrated Security=True;TrustServerCertificate=True;";

        public ExamResultsForm(int totalGrade, List<(string Question, List<string> Options, List<string> StudentAnswers, List<string> CorrectAnswers, int QuestionGrade)> results1, int actual)
        {
            this.results = results1;
            this.totalGrade = totalGrade;
            this.actualTotal = actual;
            InitializeComponent();

            //LoadResults();
        }
    }
}
