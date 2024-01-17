using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.Shared.Dtos
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public bool IsEdited { get; set; } = false;

        public BookDto? Book { get; set; } = new BookDto();
        public int? BookId { get; set; }
        public UserDto? User { get; set; } = new UserDto();
        public int? UserId { get; set; }
    }
}
