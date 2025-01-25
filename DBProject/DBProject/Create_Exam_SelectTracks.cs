using Microsoft.Data.SqlClient;
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
    public partial class Create_Exam_SelectTracks : Form
    {
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=ExaminationSystem;Integrated Security=True;TrustServerCertificate=True;";

        public Create_Exam_SelectTracks()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            InitializeComponent();
        }

        private void Create_Exam_SelectTracks_Load(object sender, EventArgs e)
        {
            checkedListBox1.Items.Add("Option 1");
            checkedListBox1.Items.Add("Option 2");
            checkedListBox1.Items.Add("Option 3");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in checkedListBox1.CheckedItems)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
