using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.Domain.Entity
{
    public class Chapter
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int? Number { get; set; }
        public bool IsPublic { get; set; }
        public int? BookId { get; set; }
        public Book? Book { get; set; } = new Book();
    }
}
