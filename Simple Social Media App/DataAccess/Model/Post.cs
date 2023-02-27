using System.Text.Json.Serialization;

namespace Simple_Social_Media_App.DataAccess.Model
{
    public class Post
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public byte[]? Image { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int? UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
    }
}
