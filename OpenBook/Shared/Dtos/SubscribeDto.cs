using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.Shared.Dtos
{
    public class SubscribeDto
    {
        public int Id { get; set; }
        public UserDto? Auth { get; set; } = new UserDto();
        public int? AuthorId { get; set; }
        public UserDto? Sub { get; set; } = new UserDto();
        public int? SubscriberId { get; set; }
    }
}
