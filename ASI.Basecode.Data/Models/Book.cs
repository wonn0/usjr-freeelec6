using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public partial class Book
    {
         public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string ISBN { get; set; }
        public string Language { get; set; }
        public DateTime PublishedOn { get; set; }
        public int PageCount { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; }

        //Foreign key reference to Author
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        //Foreign key reference to Genre
        [ForeignKey("Genre")]
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
