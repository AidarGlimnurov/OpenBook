using OpenBook.Domain.Entity;
using OpenBook.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.App.Mappers
{
    public static class BookGenreMapper
    {
        public static BookGenreDto? ToDto(this BookGenre bookGenre)
        {
            if (bookGenre == null)
            {
                return null;
            }

            BookGenreDto bookGenreDto = new BookGenreDto()
            {
                Id = bookGenre.Id,
                Book = bookGenre.Book?.ToDto(),
                BookId = bookGenre.BookId,
                Genre = bookGenre.Genre?.ToDto(),
                GenreId = bookGenre.GenreId,
            };

            return bookGenreDto;
        }

        public static BookGenre? ToEntity(this BookGenreDto bookGenreDto)
        {
            if (bookGenreDto == null)
            {
                return null;
            }

            BookGenre bookGenre = new BookGenre()
            {
                Id = bookGenreDto.Id,
                Book = bookGenreDto.Book?.ToEntity(),
                BookId = bookGenreDto.BookId,
                Genre = bookGenreDto.Genre?.ToEntity(),
                GenreId = bookGenreDto.GenreId,
            };

            return bookGenre;
        }
    }
}
