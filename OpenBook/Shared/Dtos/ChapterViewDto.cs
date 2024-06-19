using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.Shared.Dtos
{
    public class ChapterViewDto
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public UserDto? User { get; set; }
        public int? ChapterId { get; set; }
        public ChapterDto? Chapter { get; set; }
        public int Count { get; set; } = 0;
    }
}
