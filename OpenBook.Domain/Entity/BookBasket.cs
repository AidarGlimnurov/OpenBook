using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.Domain.Entity
{
    public class BookBasket
    {
        public int Id { get; set; }
        public Book? Book { get; set; } = new Book();
        public int? BookId { get; set; }
        public Basket? Basket { get; set; } = new Basket();
        public int? BasketId { get; set; }

    }
}
