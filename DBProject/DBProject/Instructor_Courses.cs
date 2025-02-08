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
    public partial class Instructor_Courses : Form
    {
        private int studentID;
        string connectionString = "Server=DESKTOP-JGIQ4Q8\\MSSQLSERVER1;Database=ExaminationSystem;Integrated Security=True;TrustServerCertificate=True;";

        public Instructor_Courses(int studentID)
        {
            this.studentID = studentID; // Store the student ID
            baseFormSize = new Size(1246, 450); // Store the initial form size

            InitializeComponent();
            InitializeCourses();   // Call your custom method to initialize courses
            CenterLabel2();
            //this.Resize += Form1_Resize; // Subscribe to the Resize event
            //CenterLabel2(); // Center the label initially


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_2(object sender, EventArgs e)
        {

        }
    }
}