using System.Text.Json.Serialization;

namespace MetaPhoto.Dtos
{
    public class Album
    {
        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("user")]
        public User? User { get; set; }
    }
}
