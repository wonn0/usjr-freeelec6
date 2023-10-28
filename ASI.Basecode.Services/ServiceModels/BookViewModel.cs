using Microsoft.AspNetCore.Http;
using System;
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

        /// <summary>Author ID</summary>
        [JsonPropertyName("authorId")]
        [Required(ErrorMessage = "Author is required.")]
        public int AuthorId { get; set; }

        /// <summary>Author's Name (For Display)</summary>
        [JsonPropertyName("authorName")]
        public string AuthorName { get; set; }

        /// <summary>Genre ID</summary>
        [JsonPropertyName("genreId")]
        [Required(ErrorMessage = "Genre is required.")]
        public int GenreId { get; set; }

        /// <summary>Genre's Name (For Display)</summary>
        [JsonPropertyName("genreName")]
        public string GenreName { get; set; }

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
