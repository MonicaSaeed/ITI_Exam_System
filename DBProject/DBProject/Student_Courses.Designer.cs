using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
namespace DBProject
{
    partial class Student_Courses
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private float baseFontSize = 12f;
        private Size baseFormSize = new Size(1246, 450); // Initialize baseFormSize with the initial form size

        private List<Button> courseButtons = new List<Button>();
        private Label label1;
        private Label label2;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        List<string> courses = new List<string>();

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();

            // Label1
            label1.Font = new Font("Showcard Gothic", baseFontSize + 10, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Teal;
            label1.Location = new Point(23, 18);
            label1.Name = "label1";
            label1.AutoSize = true;
            label1.TabIndex = 0;
            label1.Text = "Student";

            // Label2
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.AutoSize = false;
            label2.Font = new Font("Showcard Gothic", baseFontSize + 5, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Size = new Size(753, 50);
            label2.TabIndex = 1;
            ApplyLetterSpacing(label2, 3 / 2, "Your Courses");
            label2.TextAlign = ContentAlignment.MiddleCenter;
            //label2.Click += label2_Click;

            // Form1
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.None; // Disable auto-scaling
            ClientSize = baseFormSize; // Set initial form size
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Student Test";
            Load += Form1_Load;
            Resize += Form1_Resize; // Add Resize event handler
            ResumeLayout(false);
            PerformLayout();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            baseFormSize = this.ClientSize; // Update baseFormSize with the current form size
            courses = GetStudentCourses(studentID); // Fetch courses for the logged-in student

            InitializeCourses(); // Initialize courses after the form is loaded
        }

        private List<string> GetStudentCourses(int studentID)
        {
            List<string> courses = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
        SELECT 
            c.co_id AS CourseID,
            c.co_name AS CourseName
        FROM 
            Student s
        INNER JOIN 
            Track t ON s.track_id = t.track_id
        INNER JOIN 
            Track_Course tc ON t.track_id = tc.track_id
        INNER JOIN 
            Course c ON tc.co_id = c.co_id
        WHERE 
            s.st_id = @StudentID;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StudentID", studentID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                courses.Add(reader["CourseName"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching courses: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return courses;
        }


        private void InitializeCourses()
        {
            // List of courses for the student
            //List<string> courses = new List<string> { "Data base", "C#", "Java", "C++", "Python", "JavaScript" };

            // Number of buttons per row
            int buttonsPerRow = 2;

            // Button size
            int buttonWidth = 250;
            int buttonHeight = 50;

            // Spacing between buttons
            int spacingX = 20;
            int spacingY = 20;

            // Calculate the total width of the buttons and spacing
            int totalWidth = buttonsPerRow * buttonWidth + (buttonsPerRow - 1) * spacingX;

            // Calculate the starting X position to center the buttons horizontally
            int startX = (this.ClientSize.Width - totalWidth) / 2;

            // Starting Y position for the first button
            int startY = (this.ClientSize.Height / 3);

            // Calculate scaling factors
            float widthScale = (float)this.ClientSize.Width / baseFormSize.Width;
            float heightScale = (float)this.ClientSize.Height / baseFormSize.Height;
            float scale = Math.Min(widthScale, heightScale);

            // Update font size
            float newFontSize = baseFontSize * scale;

            // Loop through the courses and create/reposition buttons
            for (int i = 0; i < courses.Count; i++)
            {
                // Calculate the position of the button
                int row = i / buttonsPerRow;
                int col = i % buttonsPerRow;

                int x = startX + col * (buttonWidth + spacingX);
                int y = startY + row * (buttonHeight + spacingY);

                if (i < courseButtons.Count && courseButtons[i] != null)
                {
                    // Reposition existing button
                    courseButtons[i].Location = new Point(x, y);
                    courseButtons[i].Size = new Size(buttonWidth, buttonHeight);
                    courseButtons[i].Font = new Font("Showcard Gothic", newFontSize, FontStyle.Regular, GraphicsUnit.Point, 0);
                }
                else
                {
                    // Create new button
                    Button courseButton = new Button
                    {
                        Text = courses[i],
                        Location = new Point(x, y),
                        Size = new Size(buttonWidth, buttonHeight),
                        Font = new Font("Showcard Gothic", newFontSize, FontStyle.Regular, GraphicsUnit.Point, 0),
                        BackColor = Color.Teal,
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Flat
                    };

                    // Add a click event handler
                    courseButton.Click += CourseButton_Click;

                    // Add the button to the form
                    this.Controls.Add(courseButton);
                    courseButtons.Add(courseButton);
                }
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            UpdateFontAndControlSizes(); // Update font and control sizes
            InitializeCourses(); // Reposition buttons
            CenterLabel2(); // Re-center label2
        }

        private void UpdateFontAndControlSizes()
        {
            // Calculate scaling factors for font and control sizes
            float widthScale = (float)this.ClientSize.Width / baseFormSize.Width;
            float heightScale = (float)this.ClientSize.Height / baseFormSize.Height;
            float scale = Math.Min(widthScale, heightScale);

            // Update font size
            float newFontSize = baseFontSize * scale;

            // Ensure newFontSize is within valid bounds
            if (newFontSize <= 0 || newFontSize > float.MaxValue)
            {
                newFontSize = baseFontSize; // Fallback to base font size if invalid
            }

            // Update label1 font and size
            label1.Font = new Font("Showcard Gothic", newFontSize + 10, FontStyle.Regular, GraphicsUnit.Point, 0);

            // Update label2 font and size
            label2.Font = new Font("Showcard Gothic", newFontSize + 5, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Size = new Size((int)(753 * widthScale), (int)(50 * heightScale));

            // Update button fonts and sizes
            foreach (Button button in courseButtons)
            {
                button.Font = new Font("Showcard Gothic", newFontSize, FontStyle.Regular, GraphicsUnit.Point, 0);
                button.Size = new Size((int)(250 * widthScale), (int)(50 * heightScale));
            }
        }

        private void CenterLabel2()
        {
            // Calculate the center position for the label
            int centerX = (this.ClientSize.Width - label2.Width) / 2;
            int centerY = 76;

            // Set the label's location
            label2.Location = new Point(centerX, centerY);
        }

        private void CourseButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            MessageBox.Show($"You clicked: {clickedButton.Text}", "Course Selected");
        }

        // Helper method to apply letter spacing to a control
        private void ApplyLetterSpacing(Control control, float spacing, string text)
        {
            control.Paint += (sender, e) =>
            {
                Font font = control.Font;
                Brush brush = new SolidBrush(control.ForeColor);

                // Calculate the total width of the text with spacing
                float totalWidth = 0;
                for (int i = 0; i < text.Length; i++)
                {
                    totalWidth += e.Graphics.MeasureString(text[i].ToString(), font).Width + spacing;
                }
                totalWidth -= spacing; // Remove the last spacing

                // Calculate the starting X position for center alignment
                float x = (control.Width - totalWidth) / 2;

                // Calculate the starting Y position for middle alignment
                float y = (control.Height - font.Height) / 2;

                // Draw each character with spacing
                for (int i = 0; i < text.Length; i++)
                {
                    e.Graphics.DrawString(text[i].ToString(), font, brush, x, y);
                    x += spacing + e.Graphics.MeasureString(text[i].ToString(), font).Width; // Add spacing
                }

                brush.Dispose();
            };
        }

    }
}
