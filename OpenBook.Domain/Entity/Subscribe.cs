using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.Domain.Entity
{
    public class Subscribe
    {
        public int Id { get; set; }
        public User? Auth { get; set; } = new User();
        public int? AuthorId { get; set; }
        public User? Sub { get; set; } = new User();
        public int? SubscriberId { get; set; }
    }
}
