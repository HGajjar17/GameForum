using System;

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

        // Filename for uploaded image
        public string ImageFilename { get; set; } = string.Empty;

        // Date when discussion was created
        public DateTime CreateDate { get; set; } = DateTime.Now;

        // Navigation property: List of comments for this discussion
        public ICollection<Comment>? Comments { get; set; } // nullable
    }
}
