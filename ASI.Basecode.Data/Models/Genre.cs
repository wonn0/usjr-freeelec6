using System.Collections.Generic;

namespace Data.Models
{
    public partial class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Reference to Book (One Genre can have many Books)
        public virtual ICollection<Book> Books { get; set; }
    }
}
