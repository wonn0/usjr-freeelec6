using System.Collections.Generic;

namespace Data.Models
{
    public partial class BookGenre
    {
        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }

    }
}
