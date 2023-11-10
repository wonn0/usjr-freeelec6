using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ASI.Basecode.Services.Models
{
    /// <summary>
    /// Book View Model
    /// </summary>
    public class BookReviewViewModel
    {
        /// <summary>Book ID</summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>Reviewed By</summary>
        [JsonPropertyName("reviewedBy")]
        [Required(ErrorMessage = "Reviewed By is required.")]
        public string ReviewedBy { get; set; }

        /// <summary>Description</summary>
        [JsonPropertyName("description")]
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        /// <summary>Reviewed On</summary>
        [JsonPropertyName("reviewedOn")]
        public DateTime ReviewedOn { get; set; }

        /// <summary>Rating</summary>
        [JsonPropertyName("reviewedOn")]
        [Required(ErrorMessage = "Rating is required.")]
        public int Rating { get; set; }

        /// <summary>Book ID</summary>
        [JsonPropertyName("bookId")]
        [Required(ErrorMessage = "Book ID is required.")]
        public int BookId { get; set; }

        /// <summary>Book (Model)</summary>
        [JsonPropertyName("bookName")]
        [Required(ErrorMessage = "Book is required.")]
        public String BookName { get; set; }

    }
}

