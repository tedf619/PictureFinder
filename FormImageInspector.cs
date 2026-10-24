using System.ComponentModel;

namespace PictureFinder
{
  public partial class FormImageInspector : Form
  {
    [DefaultValue(null)]
    public Image? Image
    {
      get { return pictureBox.Image; }
      set { pictureBox.Image = value; }
    }

    [DefaultValue(null)]
    public UnsplashPhoto? Photo
    {
      set 
      {
        if (value == null) return;
        labelSize.Text = $"Size: {value.Width} x {value.Height}";
        labelCreated.Text = $"Created: {value.CreatedAt:yyyy-MM-dd}";
        labelDescription.Text = $"Description: {value.Description ?? "<None>"}";
      }
    }
    public FormImageInspector()
    {
      InitializeComponent();
    }
  }
}
