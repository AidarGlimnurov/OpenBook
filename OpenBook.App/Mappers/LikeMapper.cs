using OpenBook.Domain.Entity;
using OpenBook.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.App.Mappers
{
    public static class LikeMapper
    {
        public static LikeDto? ToDto(this Like like)
        {
            if (like == null)
            {
                return null;
            }

            LikeDto likeDto = new LikeDto()
            {
                Id = like.Id,
                Date = like.Date,
                BookId = like.BookId,
                Book = like.Book?.ToDto(),
                UserId = like.UserId,
                User = like.User?.ToDto(),
            };

            return likeDto;
        }

        public static Like? ToEntity(this LikeDto likeDto)
        {
            if (likeDto == null)
            {
                return null;
            }

            Like like = new Like()
            {
                Id = likeDto.Id,
                Date = likeDto.Date,
                BookId = likeDto.BookId,
                Book = likeDto.Book?.ToEntity(),
                UserId = likeDto.UserId,
                User = likeDto.User?.ToEntity(),
            };

            return like;
        }
    }
}
