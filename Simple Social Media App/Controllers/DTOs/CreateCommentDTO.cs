using Simple_Social_Media_App.DataAccess.Model;
using System.ComponentModel.DataAnnotations;

namespace Simple_Social_Media_App.Controllers.DTOs
{
    public class CreateCommentDTO
    {
        [Required]
        public string Content { get; set; } = string.Empty;

        [Required]
        public Guid? PostId { get; set; }

    }
}
