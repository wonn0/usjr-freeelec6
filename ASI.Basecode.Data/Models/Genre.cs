using System.Collections.Generic;

namespace Data.Models
{
    public partial class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Many-to-Many relationship with Book
        public virtual ICollection<BookGenre> BookGenres { get; set; } = new List<BookGenre>();
    }
}
