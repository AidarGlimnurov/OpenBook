﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.Domain.Entity
{
    public class BookGenre
    {
        public int Id { get; set; }
        public Book? Book { get; set; } = new Book();
        public int? BookId { get; set; }
        public Genre? Genre { get; set; } = new Genre();
        public int? GenreId { get; set; }
    }
}
