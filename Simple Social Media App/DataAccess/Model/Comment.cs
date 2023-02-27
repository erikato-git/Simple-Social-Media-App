using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Simple_Social_Media_App.DataAccess.Model
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int? PostId { get; set; }
        [JsonIgnore]
        public Post? Post { get; set; }
        public int? UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
    }
}
