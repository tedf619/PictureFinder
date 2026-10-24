using System.Text.Json;

namespace PictureFinder
{
  public partial class FormMain : Form
  {
    string? apiKey;
    readonly HttpClient http = new();

    public FormMain()
    {
      InitializeComponent();

      SetInitialCardWidth();

      apiKey = Environment.GetEnvironmentVariable("UNSPLASH_PHOTO_API_KEY");  // required to access unsplash.com
    }

    void SetInitialCardWidth()
    {
      int width = (panelMiddle.Width) / 4;  // 4 cards per row

      foreach (Control ctrl in flowLayoutPanelPictures.Controls)
      {
        if (ctrl is not PictureCard card) continue;
        card.Width = width;
        card.Height = width + 75;
      }
    }

    void TextBoxSearch_TextChanged(object sender, EventArgs e)
    {
      buttonSearch.Enabled = textBoxSearch.Text.Trim().Length > 0;
    }

    async void buttonSearch_Click(object sender, EventArgs e)
    {
      string query = textBoxSearch.Text.Trim();
      if (string.IsNullOrEmpty(query))
      {
        MessageBox.Show("Please enter one or more keywords.", "Nothing to Search For", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      if (apiKey == null)
      {
        MessageBox.Show($"No API key found. To get pictures from unsplash.com you need an API key.\n\n" +
                        $"Get a free key from unsplash.com and save it in a Windows Environment variable named 'UNSPLASH_PHOTO_API_KEY'.", "API Key Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      buttonSearch.Enabled = false;
      textBoxSearch.Enabled = false;
      labelStatusbarMessage.Text = "Searching Unsplash.com...";
      flowLayoutPanelPictures.Controls.Clear();

      try
      {
        string url = $"https://api.unsplash.com/search/photos?query={Uri.EscapeDataString(query)}&per_page=15&client_id={apiKey}";

        HttpResponseMessage response = await http.GetAsync(url);
        response.EnsureSuccessStatusCode();

        using var responseStream = await response.Content.ReadAsStreamAsync();

        UnsplashSearchResponse? searchResult = await JsonSerializer.DeserializeAsync<UnsplashSearchResponse>(responseStream);

        if (searchResult == null || searchResult.Results == null || searchResult.Results.Count == 0)
        {
          labelStatusbarMessage.Text = "No images found.";
          return;
        }

        labelStatusbarMessage.Text = $"Images found: {searchResult.Results.Count}. Double-click an image to see it larger.";

        // display the picture cards
        foreach (UnsplashPhoto picture in searchResult.Results)
        {
          var pictureCard = new PictureCard();
          pictureCard.ShowPicture(picture);
          flowLayoutPanelPictures.Controls.Add(pictureCard);
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show($"Error searching Unsplash.com: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        labelStatusbarMessage.Text = "Search failed.";
      }
      finally
      {
        buttonSearch.Enabled = true;
        textBoxSearch.Enabled = true;
      }
    }
  }
}
