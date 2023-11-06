using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ASI.Basecode.Services.Models
{
    /// <summary>
    /// Author View Model
    /// </summary>
    public class AuthorViewModel
    {
        /// <summary>Author ID</summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>First Name</summary>
        [JsonPropertyName("firstName")]
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        /// <summary>Last Name</summary>
        [JsonPropertyName("lastName")]
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }
    }
}
