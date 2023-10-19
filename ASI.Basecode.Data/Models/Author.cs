using System.Collections.Generic;

namespace Data.Models
{
    public partial class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Reference to Book (One Author can have many Books)
        public virtual ICollection<Book> Books { get; set; }
    }
}
