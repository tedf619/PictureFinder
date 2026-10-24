using System.Drawing.Imaging;

namespace PictureFinder;

public partial class PictureCard : UserControl
{
  readonly HttpClient httpClient = new();

  public PictureCard()
  {
    InitializeComponent();

    saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
  }

  public async void ShowPicture(UnsplashPhoto photo)
  {
    pictureBox.Image = await DownloadImageAsync(photo.Urls.Small);
    pictureBox.Tag = photo;

    labelBy.Text = $"By: {photo.User.Name}";
    labelSize.Text = $"{photo.Width} x {photo.Height}";
  }

  async void ButtonDownload_Click(object sender, EventArgs e)
  {
    try
    {
      if (pictureBox.Tag is not UnsplashPhoto photo) return;

      using Image? image = await DownloadImageAsync(photo.Urls.Regular);
      if (image == null) return;
      if (!SaveImage(image)) return;

      MessageBox.Show("Image successfully downloaded.", "PictureFinder", MessageBoxButtons.OK);
    }
    catch (Exception ex)
    {
      MessageBox.Show($"Failed to download image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
  }

  async Task<Image?> DownloadImageAsync(string imageUri)
  {
    try
    {
      byte[] bytes = await httpClient.GetByteArrayAsync(imageUri);

      using MemoryStream ms = new(bytes);
      return Image.FromStream(ms);
    }
    catch
    {
      return null;
    }
  }

  bool SaveImage(Image image)
  {
    if (saveFileDialog.ShowDialog() != DialogResult.OK) return false;

    string fileName = saveFileDialog.FileName.ToLower();
    ImageFormat format = ImageFormat.Jpeg;

    if (fileName.EndsWith(".png"))
      format = ImageFormat.Png;

    else if (fileName.EndsWith(".bmp"))
      format = ImageFormat.Bmp;

    using Bitmap bitmap = new Bitmap(image);
    bitmap.Save(saveFileDialog.FileName, format);
    return true;
  }

  async void PictureBox_DoubleClick(object sender, EventArgs e)
  {
    if (sender is not PictureBox pictureBox) return;
    if (pictureBox.Tag is not UnsplashPhoto photo) return;

    FormImageInspector form = new();
    form.Image = await DownloadImageAsync(photo.Urls.Regular);
    form.Photo = photo;

    form.ShowDialog();
  }
}
