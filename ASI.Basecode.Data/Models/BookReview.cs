using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public partial class BookReview
    {
        public int Id { get; set; }
        public string ReviewedBy { get; set; }
        public string Description { get; set; }
        public DateTime ReviewedOn { get; set; } = DateTime.Now;
        public int Rating { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}
