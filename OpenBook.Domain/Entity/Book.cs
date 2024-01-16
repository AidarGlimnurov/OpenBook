using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.Domain.Entity
{
    public class Book
    {
        public int Id { get; set; }
        public byte[] Cover { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public bool IsPublished { get; set; } = false;

        public int? UserId { get; set; }
        public User? User { get; set; } = new User();
        public int? CycleId { get; set; }
        public Cycle? Cycle { get; set; } = new Cycle();
    }
}
