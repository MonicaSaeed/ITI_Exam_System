using InstructorPart;

namespace DBProject
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //Application.Run(new GradesForm(1)); //// this
            //Application.Run(new ExamDisplayForm(1));
            Application.Run(new LogIn()); //// this
            //Application.Run(new Create_Exam_SelectTracks(1)); //// this

            //Application.Run(new Student_Courses(5));
            //     Application.Run(new CustomMessageBox("it's no date for it now \n\n, please prepare for it" , "UpComing Exam" , MessageBoxIcon.Information));

        }
    }
}