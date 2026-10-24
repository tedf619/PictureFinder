# Picture Finder

A .Net 10 WinForms desktop app find open source pictures online.

## Features

- Great project for getting started with online picture repositories.
- Completely self-contained. No NuGet packages or third-party libraries.
- Uses the Unsplash.com API to get open source pictures.
- Requires an API key to get pictures. Free keys are available for non-commercial work.

The following figure shows PictureFinder in action.

<img width="1023" height="689" alt="image" src="https://github.com/user-attachments/assets/91dfb50b-a908-4dfa-9ac0-e57a0683c21f" />

*Figure 1* - The app showing pictures after searching for the keyword *raccoons*.

## The UI Layout

The main form uses two layers of docked panels for its layout, as shown in the following figure.

<img width="807" height="507" alt="image" src="https://github.com/user-attachments/assets/45aaadb0-e7a8-4f07-ad3c-5ad9af691d72" />

*Figure 2* - The main form PictureCards.

* Layer 1 - Shown in red, this layer divides the screen vertically, with the middle area filling available space.
* Layer 2 - Shown in blue, this layer is hosts a series of picture *cards*, laid out in rows and columns.

To achieve the required layout, the panels in layer 1 must be added in the proper back-to-front order, like this:

  1. PanelTop.
  2. PanelBottom.
  3. PanelMiddle.

As a general rule, components with Dock=Fill must always be added last to their parent container.

Layer 2 is similar, with the last panel having Dock=Fill:

 1. PanelResultsTitle.
 2. FlowLayoutPanel.

The picture cards are UserControls with their own internal layout. Here is how a PictureCard looks like at runtime:

<img width="242" height="264" alt="image" src="https://github.com/user-attachments/assets/6c612200-6bdf-4d43-81ff-e64b8e50be14" />

*Figure 3* - A PictureCard at runtime.

The card shows a picture thumbnail, the name of the author, the full size of the photo and a **Download** button. 
The UI is achieved with two layers of panels and controls as shown in the following figure.

<img width="293" height="371" alt="image" src="https://github.com/user-attachments/assets/398ff07c-1a2c-4162-9ff6-d16087ed777f" />

*Figure 4* - The UI layout of PictureCard.

To achieve the required layout, the panels in layer 1 must be added in the usual back-to-front order, like this:

  1. PanelBottom.
  2. PictureBox.

PanelBottom contains PanelButton with Dock=Bottom. Above PanelButton is room for two Labels, for the photo author and size.
By double-clicking the picture, the app displays an ImageInspector dialog box with the full-sized image, as shown in the next figure.

<img width="679" height="550" alt="image" src="https://github.com/user-attachments/assets/f9cff1af-23fb-4611-b94e-49aaeb5bde2b" />

*Figure 5* - The ImageInspector dialog, showing the full-sized version of a picture.

## How it Works
The main form is used to setup the overall layout and handle user interactions with the UI controls. By entering some keywords and clicking the **Search** button, the app sends a request to Unsplash.com. The response comes back in the form a JSON document listing all the names and URIs of the pictures found. The following Sequence Diagram shows the overall process.

<img width="715" height="477" alt="image" src="https://github.com/user-attachments/assets/18ae0ec9-1425-4df3-9966-375ae7e11cdd" />

*Figure 6* - The Sequence Diagram showing the main operation of PictureFinder.

As PictureCards are added to the UI, a call to PictureCard.ShowPicture downloads the bytes for a small version of the photo assigned to them.
The following listing shows an excerpt of the FormMain code.

```csharp
public partial class FormMain : Form
{
  string? apiKey == ...;
  readonly HttpClient http = new();

  async void buttonSearch_Click(object sender, EventArgs e)
  {
    string query = textBoxSearch.Text.Trim();

    flowLayoutPanelPictures.Controls.Clear();

    string url = $"https://api.unsplash.com/search/photos?query={Uri.EscapeDataString(query)}&per_page=15&client_id={apiKey}";

    HttpResponseMessage response = await http.GetAsync(url);
    using var responseStream = await response.Content.ReadAsStreamAsync();
    UnsplashSearchResponse? searchResult = await JsonSerializer.DeserializeAsync<UnsplashSearchResponse>(responseStream);

    // display the picture cards
    foreach (UnsplashPhoto picture in searchResult.Results)
    {
      var pictureCard = new PictureCard();
      pictureCard.ShowPicture(picture);
      flowLayoutPanelPictures.Controls.Add(pictureCard);
    }
  }
}
```
*Listing 1* - The significant code for the main form.

As you can see, FormMain populates the FlowLayoutPanel with PictureCards. Each card then downloads its photo and displays some photo metadata.
The following listing shows an excerpt of the PictureCard code.

```csharp
public partial class PictureCard : UserControl
{
  readonly HttpClient httpClient = new();

  public async void ShowPicture(UnsplashPhoto photo)
  {
    // download and display the photo thumbnail
    pictureBox.Image = await DownloadImageAsync(photo.Urls.Small);
    pictureBox.Tag = photo;

    // display some photo metadata
    labelBy.Text = $"By: {photo.User.Name}";
    labelSize.Text = $"{photo.Width} x {photo.Height}";
  }

  async void ButtonDownload_Click(object sender, EventArgs e)
  {
    if (pictureBox.Tag is not UnsplashPhoto photo) return;

    // download and save the full-size photo
    using Image? image = await DownloadImageAsync(photo.Urls.Regular);
    if (image == null) return;
    if (!SaveImage(image)) return;
  }

  async Task<Image?> DownloadImageAsync(string imageUri)
  {
    byte[] bytes = await httpClient.GetByteArrayAsync(imageUri);

    using MemoryStream ms = new(bytes);
    return Image.FromStream(ms);
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

    // display a full-sized version of the photo
    using FormImageInspector form = new();
    form.Image = await DownloadImageAsync(photo.Urls.Regular);
    form.Photo = photo;

    form.ShowDialog();
  }
}
```
*Listing 2* - The main code of PictureCard.

## API keys

The Unsplash API requires an api key with each request. Free keys can be used for non-commercial work. You can get your personal key at ```Unsplash.com```. The key can then be used in two different ways:

1. By saving the key as a Windows Environment variable. This way you don't have to embed the key in your code. This is the approach I took. I used the variable name ```UNSPLASH_PHOTO_API_KEY```.
2. By embedding the key directly in the source code in the FormMain constructor. Replace the line:

```csharp
  apiKey = Environment.GetEnvironmentVariable("UNSPLASH_PHOTO_API_KEY");
```
with the line:
```csharp
  apiKey = <your-api-key>;
```

## Handling the Unsplash Response Data
Unsplash.com returns picture metadata in JSON format. There are no actual pictures in the response. You could use this JSON data directly, using System.Text.Json methods to extract the various pieces of picture metadata. This works okay for simple JSON responses. For more complex data, I find it easier to deserialize the JSON into C# objects, often called *Models* or *DTOs* (Data Transfer Objects). I used Google Gemini to generate the Model classes for the Unsplash response. The prompt was:

```Create C# classes I can use to deserialize the JSON code returned by api.unsplash.com/search/photos```. 

Gemini produced a bunch of classes containing properties for all the possible metadata. Since PictureFinder doesn't use most of that metadata, I deleted the unused stuff.
What was left is the code in the following listing.

```csharp
public class UnsplashSearchResponse
{
  [JsonPropertyName("results")]
  public List<UnsplashPhoto> Results { get; set; } = new();
}

public class UnsplashPhoto
{
  [JsonPropertyName("created_at")]
  public DateTime CreatedAt { get; set; }

  [JsonPropertyName("width")]
  public int Width { get; set; }  // in pixels

  [JsonPropertyName("height")]    // in pixels
  public int Height { get; set; }

  [JsonPropertyName("description")]
  public string? Description { get; set; }

  [JsonPropertyName("urls")]
  public PhotoUrls Urls { get; set; } = new();

  [JsonPropertyName("user")]
  public UnsplashUser User { get; set; } = new();     // author of photo
}

public class PhotoUrls
{
  [JsonPropertyName("raw")]
  public string Raw { get; set; } = string.Empty;     // original master

  [JsonPropertyName("full")]
  public string Full { get; set; } = string.Empty;    // high-resolution

  [JsonPropertyName("regular")]
  public string Regular { get; set; } = string.Empty; // ~1080px width

  [JsonPropertyName("small")]
  public string Small { get; set; } = string.Empty;   // ~400px width

  [JsonPropertyName("thumb")]
  public string Thumb { get; set; } = string.Empty;   // ~ 200px width
}

public class UnsplashUser
{
  [JsonPropertyName("name")]
  public string Name { get; set; } = string.Empty;

}
```
*Listing 3* - The Model classes used to handle the Unsplash response JSON.

FormMain uses these classes to automatically deserialize the entire JSON response from Unsplash. All it takes is a few lines of code:

```csharp
  string url = $"https://api.unsplash.com/search/photos?query={Uri.EscapeDataString(query)}&per_page=15&client_id={apiKey}";

  HttpResponseMessage response = await http.GetAsync(url);
  using var responseStream = await response.Content.ReadAsStreamAsync();

  // entire JSON response is deserialized here
  UnsplashSearchResponse? searchResult = await JsonSerializer.DeserializeAsync<UnsplashSearchResponse>(responseStream);
```
*Listing 4* - Deserializing the JSON Unsplash response into C# Model objects.

That's basically it! Two main classes: FormMain and PictureCard. Pretty straightforward.

## Acknowlegements

Many thanks to Google Gemini for the generation of the Model classes.
