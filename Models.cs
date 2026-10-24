using System.Text.Json.Serialization;

namespace PictureFinder;

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
