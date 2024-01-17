using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.Shared.Dtos
{
    public class BookBasketDto
    {
        public int Id { get; set; }
        public BookDto? Book { get; set; } = new BookDto();
        public int? BookId { get; set; }
        public BasketDto? Basket { get; set; } = new BasketDto();
        public int? BasketId { get; set; }
    }
}
