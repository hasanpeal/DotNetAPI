using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DOTNETBACKEND.Dtos.Comment
{
    public class CommentCreateReqDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Content must be at least 5 characters long")]
        [MaxLength(500, ErrorMessage = "Content cannot exceed 500 characters")]
        public string Content { get; set; } = string.Empty;
    }
}