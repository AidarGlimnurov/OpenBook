using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.Shared.Dtos
{
    public class LikeDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public UserDto? User { get; set; }
        public int BookId { get; set; }
        public BookDto? Book { get; set; }
    }
}
