using System;
using System.Collections.Generic;
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

        // Many-to-Many relationship with Author
        public virtual ICollection<AuthorBook> AuthorBooks { get; set; } = new List<AuthorBook>();

        // Many-to-Many relationship with Genre
        public virtual ICollection<BookGenre> BookGenres { get; set; } = new List<BookGenre>();

        // One-to-Many relationship with BookReview (can have many reviews)
        public virtual ICollection<BookReview> BookReviews { get; set; } = new List<BookReview>();
    }
}
