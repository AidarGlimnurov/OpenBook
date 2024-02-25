using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.Domain.Entity
{
    public class Cycle
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public byte[]? Cover { get; set; } = new byte[10];
        public string? Description { get; set; } = string.Empty;

        public int? UserId { get; set; }
        public User? User { get; set; } = new User();
    }
}
