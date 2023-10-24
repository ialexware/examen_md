using System.Text.Json.Serialization;

namespace examen_md.Models.Dto
{
    public class LocationDto
    {
        [JsonPropertyName("longitud")]
        public double Latitude { get; set; }

        [JsonPropertyName("latitud")]
        public double Longitude { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nombre")]
        public string? Name { get; set; }
    }
}
