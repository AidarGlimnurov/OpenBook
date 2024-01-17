using OpenBook.Domain.Entity;
using OpenBook.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.App.Mappers
{
    public static class ChapterMapper
    {
        public static ChapterDto? ToDto(this Chapter chapter)
        {
            if (chapter == null)
            {
                return null;
            }

            ChapterDto chapterDto = new ChapterDto()
            {
                Id = chapter.Id,
                Name = chapter.Name,
                Content = chapter.Content,
                Number = chapter.Number,
                BookId = chapter.BookId,
                Book = chapter.Book?.ToDto(),
            };

            return chapterDto;
        }

        public static Chapter? ToEntity(this ChapterDto chapterDto)
        {
            if (chapterDto == null)
            {
                return null;
            }

            Chapter chapter = new Chapter()
            {
                Id = chapterDto.Id,
                Name = chapterDto.Name,
                Content = chapterDto.Content,
                Number = chapterDto.Number,
                BookId = chapterDto.BookId,
                Book = chapterDto.Book?.ToEntity(),
            };

            return chapter;
        }
    }
}
