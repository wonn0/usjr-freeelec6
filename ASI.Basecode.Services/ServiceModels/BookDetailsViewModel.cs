using System.Collections.Generic;
using ASI.Basecode.Services.Models;


namespace ASI.Basecode.Services.Models
{
    public class BookDetailsViewModel
    {
        public BookViewModel Book { get; set; }
        public List<BookReviewViewModel> Reviews { get; set; }

        public BookViewModel[] RelatedBooks { get; set; }
    }
}
