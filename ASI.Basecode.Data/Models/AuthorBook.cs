using System.Collections.Generic;

namespace Data.Models
{
    public partial class AuthorBook
    {
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}
