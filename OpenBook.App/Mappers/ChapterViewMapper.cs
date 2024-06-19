using OpenBook.Domain.Entity;
using OpenBook.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.App.Mappers
{
    public static class ChapterViewMapper
    {
        public static ChapterViewDto ToDto(this ChapterView chapterView)
        {
            if (chapterView == null)
            {
                return null;
            }

            return new ChapterViewDto
            {
                Id = chapterView.Id,
                UserId = chapterView.UserId,
                User = chapterView.User?.ToDto(),
                ChapterId = chapterView.ChapterId,
                Chapter = chapterView.Chapter?.ToDto(),
                Count = chapterView.Count
            };
        }

        public static ChapterView ToEntity(this ChapterViewDto chapterViewDto)
        {
            if (chapterViewDto == null)
            {
                return null;
            }

            return new ChapterView
            {
                Id = chapterViewDto.Id,
                UserId = chapterViewDto.UserId,
                User = chapterViewDto.User?.ToEntity(),
                ChapterId = chapterViewDto.ChapterId,
                Chapter = chapterViewDto.Chapter?.ToEntity(),
                Count = chapterViewDto.Count
            };
        }
    }
}
