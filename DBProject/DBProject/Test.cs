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
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            ExamDisplayForm examDisplayForm = new ExamDisplayForm(1);
            examDisplayForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GradesForm gradesForm = new GradesForm(1);
            gradesForm.ShowDialog();
        }
    }
}
