using System.Text.Json.Serialization;

namespace examen_md.Models
{
    public class Photos
    {
        [JsonPropertyName("albumId")]
        public int AlbumId { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;
        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;
        [JsonPropertyName("thumbnailUrl")]
        public string ThumbnailUrl { get; set; } = string.Empty;

    }
}
