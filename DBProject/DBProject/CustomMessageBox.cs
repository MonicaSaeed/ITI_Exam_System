using System.Windows.Forms;

public partial class CustomMessageBox : Form
{
    public CustomMessageBox(string message, string title, MessageBoxIcon icon)
    {
        InitializeComponent();
        CenterControls();
        // Set the form title
        this.Text = title;
        
        // Set the message
        lblMessage.Text = message;
        Console.WriteLine(icon);
        // Load custom icons based on the MessageBoxIcon parameter
        switch (icon)
        {
            case MessageBoxIcon.Information:
                pictureBoxIcon.Image = LoadIconFromResources("1.png"); // Load custom info icon
                break;
            case MessageBoxIcon.Warning:
                pictureBoxIcon.Image = LoadIconFromResources("warning.png"); // Load custom warning icon
                break;
            case MessageBoxIcon.Error:
                pictureBoxIcon.Image = LoadIconFromResources("2.png"); // Load custom error icon
                break;
            default:
                pictureBoxIcon.Image = null; // No icon
                break;
        }
    }

   
    private Image LoadIconFromResources(string iconName)
    {
        // Load the icon from the embedded resources
        var assembly = System.Reflection.Assembly.GetExecutingAssembly();
        var resourceName = $"DBProject.{iconName}"; // Adjust the namespace and folder path

        Console.WriteLine($"Loading resource: {resourceName}");

        using (var stream = assembly.GetManifestResourceStream(resourceName))
        {
            if (stream != null)
            {
                var image = Image.FromStream(stream);
                Console.WriteLine($"Image loaded: {image != null}");
                return image;
            }
            else
            {
                throw new FileNotFoundException($"Icon '{iconName}' not found in resources.");
            }
        }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
        this.Close(); // Close the form when the OK button is clicked
    }
}