using System;
using System.ComponentModel; // Add this namespace for DesignerSerializationVisibility
using System.Drawing;
using System.Windows.Forms;

public class CustomGroupBox : GroupBox
{
    // Add the DesignerSerializationVisibility attribute
    [DefaultValue(typeof(Color), "Black")]
    //[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public Color BorderColor { get; set; } = Color.Black;
    protected override void OnPaint(PaintEventArgs e)
    {
        // Get the text size to position the border correctly
        Size textSize = TextRenderer.MeasureText(this.Text, this.Font);

        // Define the border rectangle
        Rectangle borderRect = new Rectangle(
            0, textSize.Height / 2, this.Width - 1, this.Height - (textSize.Height / 2) - 1);

        // Draw the border
        using (Pen borderPen = new Pen(BorderColor, 2)) // Adjust border thickness here
        {
            e.Graphics.DrawRectangle(borderPen, borderRect);
        }

        //// Draw the text
        //using (Brush textBrush = new SolidBrush(this.ForeColor))
        //{
        //    e.Graphics.DrawString(this.Text, this.Font, textBrush, 10, 0);
        //}
    }
}