using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ASI.Basecode.Services.Models
{
    /// <summary>
    /// Book View Model
    /// </summary>
    public class BookViewModel
    {
        /// <summary>Book ID</summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>Book Title</summary>
        [JsonPropertyName("name")]
        [Required(ErrorMessage = "Title is required.")]
        public string Name { get; set; }

        /// <summary>Book Description</summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>ISBN Number</summary>
        [JsonPropertyName("authorIds")]
        public List<int> AuthorIds { get; set; }

        /// <summary>ISBN Number</summary>
        [JsonPropertyName("genreIds")]
        public List<int> GenreIds { get; set; }

        /// <summary>Author's Names (For Display)</summary>
        [JsonPropertyName("authorName")]
        public List<string> AuthorNames { get; set; }

        /// <summary>Genre's Names (For Display)</summary>
        [JsonPropertyName("genreName")]
        public List<string> GenreNames { get; set; }

        /// <summary>ISBN Number</summary>
        [JsonPropertyName("isbn")]
        public string ISBN { get; set; }

        /// <summary>Language of the Book</summary>

        [JsonPropertyName("language")]
        public string Language { get; set; }

        /// <summary>Date when the Book was Published</summary>
        [JsonPropertyName("publishedOn")]
        public DateTime PublishedOn { get; set; }

        /// <summary>Number of Pages in the Book</summary>
        [JsonPropertyName("pageCount")]
        public int PageCount { get; set; }

        /// <summary>Date when the Book was Created in the System</summary>
        [JsonPropertyName("created")]
        public DateTime Created { get; set; }

        /// <summary>Date when the Book was Last Updated in the System</summary>
        [JsonPropertyName("updated")]
        public DateTime Updated { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }


    }
}
