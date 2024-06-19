using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.Domain.Entity
{
    public class ChapterView
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public int? ChapterId { get; set; }
        public Chapter? Chapter { get; set; }
        public int Count { get; set; } = 0;
    }
}
