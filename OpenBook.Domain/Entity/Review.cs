using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.Domain.Entity
{
    public class Review
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public bool IsEdited { get; set; } = false;

        public Book? Book { get; set; } = new Book();
        public int? BookId { get; set; }
        public User? User { get; set; } = new User();
        public int? UserId { get; set; }
    }
}
