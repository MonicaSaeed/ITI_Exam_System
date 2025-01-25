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
    public partial class Student_Courses : Form
    {
        private int studentID;
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=ExaminationSystem;Integrated Security=True;TrustServerCertificate=True;";

        public Student_Courses(int studentID)
        {
            this.studentID = studentID; // Store the student ID

            InitializeComponent();
            InitializeCourses();   // Call your custom method to initialize courses
            baseFormSize = this.ClientSize; // Store the initial form size

            this.Resize += Form1_Resize; // Subscribe to the Resize event
            CenterLabel2(); // Center the label initially


        }
    }
}
