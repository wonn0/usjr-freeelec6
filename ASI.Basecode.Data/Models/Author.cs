using System.Collections.Generic;

namespace Data.Models
{
    public partial class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Many-to-Many relationship with Book
        public virtual ICollection<AuthorBook> AuthorBooks { get; set; } = new List<AuthorBook>();
    }
}
