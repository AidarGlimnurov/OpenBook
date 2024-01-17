using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.Shared.Dtos
{
    public class ChapterDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int Number { get; set; }
        public bool IsPublic { get; set; }
        public int? BookId { get; set; }
        public BookDto? Book { get; set; } = new BookDto();
    }
}
