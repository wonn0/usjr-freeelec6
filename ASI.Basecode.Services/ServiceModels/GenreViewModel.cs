using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ASI.Basecode.Services.Models
{
    /// <summary>
    /// Genre View Model
    /// </summary>
    public class GenreViewModel
    {
        /// <summary>Genre ID</summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>Name</summary>
        [JsonPropertyName("name")]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
    }
}
