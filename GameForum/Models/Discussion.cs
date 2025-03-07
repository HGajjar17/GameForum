using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GameForum.Data;

namespace GameForum.Models
{
    public class Discussion
    {
        // Primary Key
        public int DiscussionId { get; set; }

        // Title of the discussion thread
        public string Title { get; set; } = string.Empty;

        // Discussion content
        public string Content { get; set; } = string.Empty;

        [Display(Name = "Image Filename")]
        // Filename for uploaded image
        public string ImageFilename { get; set; } = string.Empty;

        // Property for file uploda, not mapped in EF
        [NotMapped]
        [Display(Name = "Upload Image")]
        // File for upload image
        public IFormFile? ImageFile { get; set; } // nullable

        [Display(Name = "Create Date")]
        // Date when discussion was created
        public DateTime CreateDate { get; set; } = DateTime.Now;

        // Navigation property: List of comments for this discussion
        public ICollection<Comment>? Comments { get; set; } // nullable!!

        // Foreign key (AspNetUsers table)
        public string ApplicationUserId { get; set; } = string.Empty;
        // Navigation property
        public ApplicationUser? ApplicationUser { get; set; } // nullable!!!
    }
}
