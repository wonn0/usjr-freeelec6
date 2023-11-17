using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ASI.Basecode.Services.Models
{
    /// <summary>
    /// Book View Model
    /// </summary>
    public class BookReviewCommentViewModel
    {
        /// <summary>Comment ID</summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>Commenter</summary>
        [JsonPropertyName("commenter")]
        [Required(ErrorMessage = "Commenter is required.")]
        public string Commenter { get; set; }

        /// <summary>Comment</summary>
        [JsonPropertyName("comment")]
        [Required(ErrorMessage = "Comment is required.")]
        public string Comment { get; set; }

        /// <summary>Commented On</summary>
        [JsonPropertyName("commentedOn")]
        public DateTime CommentedOn { get; set; }

        /// <summary>Review ID</summary>
        [JsonPropertyName("reviewId")]
        [Required(ErrorMessage = "Review ID is required.")]
        public int ReviewId { get; set; }

        /// <summary>Review</summary>
        [JsonPropertyName("reviewedBy")]
        [Required(ErrorMessage = "Reviewed By is required.")]
        public string ReviewedBy { get; set; }
    }
}
