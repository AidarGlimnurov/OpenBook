using OpenBook.Domain.Entity;
using OpenBook.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.App.Mappers
{
    public static class BookMapper
    {
        public static BookDto? ToDto(this Book book)
        {
            if (book == null)
            {
                return null;
            }

            BookDto bookDto = new BookDto()
            {
                Id = book.Id,
                Cover = book.Cover,
                Name = book.Name,
                Description = book.Description,
                Author = book.Author,
                IsPublished = book.IsPublished,
                UserId = book.UserId,
                User = book.User?.ToDto(),
                CycleId = book.CycleId,
                Cycle = book.Cycle?.ToDto(),
            };

            return bookDto;
        }

        public static Book? ToEntity(this BookDto bookDto)
        {
            if (bookDto == null)
            {
                return null;
            }

            Book book = new Book()
            {
                Id = bookDto.Id,
                Cover = bookDto.Cover,
                Name = bookDto.Name,
                Description = bookDto.Description,
                Author = bookDto.Author,
                IsPublished = bookDto.IsPublished,
                UserId = bookDto.UserId,
                User = bookDto.User?.ToEntity(),
                CycleId = bookDto.CycleId,
                Cycle = bookDto.Cycle?.ToEntity(),
            };

            return book;
        }
    }
}
