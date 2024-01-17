using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.Shared.Dtos
{
    public class BookGenreDto
    {
        public int Id { get; set; }
        public BookDto? Book { get; set; } = new BookDto();
        public int? BookId { get; set; }
        public GenreDto? Genre { get; set; } = new GenreDto();
        public int? GenreId { get; set; }
    }
}
