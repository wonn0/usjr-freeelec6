using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public partial class BookReviewComment
    {
        public int Id { get; set; }
        public string Commenter { get; set; }
        public string Comment { get; set; }
        public DateTime CommentedOn { get; set; } = DateTime.Now;
        public int ReviewId { get; set; }
        public virtual BookReview Review { get; set; }
    }
}
