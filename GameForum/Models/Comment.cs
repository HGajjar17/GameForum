using GameForum.Data;

namespace GameForum.Models
{
    public class Comment
    {
        // Primary Key
        public int CommentId { get; set; }
        // Content of the comment
        public string Content { get; set; }
        // Date when the comment was posted
        public DateTime CreateDate { get; set; }
        // Foreign Key and Navigation Property linking the comment to its parent discussion
        public int DiscussionId { get; set; }
        // Navigation property : Parent Discussion
        public Discussion? Discussion { get; set; }
        // Foreign key (AspNetUsers table)
        public string ApplicationUserId { get; set; } = string.Empty;
        // Navigation property
        public ApplicationUser? ApplicationUser { get; set; }
    }
}
