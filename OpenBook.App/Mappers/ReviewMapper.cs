using OpenBook.Domain.Entity;
using OpenBook.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.App.Mappers
{
    public static class ReviewMapper
    {
        public static ReviewDto? ToDto(this Review review)
        {
            if (review == null)
            {
                return null;
            }

            ReviewDto reviewDto = new ReviewDto()
            {
                Id = review.Id,
                Text = review.Text,
                CreateDate = review.CreateDate,
                IsEdited = review.IsEdited,
                BookId = review.BookId,
                Book = review.Book?.ToDto(),
                UserId = review.UserId,
                User = review.User?.ToDto(),
            };

            return reviewDto;
        }

        public static Review? ToEntity(this ReviewDto reviewDto)
        {
            if (reviewDto == null)
            {
                return null;
            }

            Review review = new Review()
            {
                Id = reviewDto.Id,
                Text = reviewDto.Text,
                CreateDate = reviewDto.CreateDate,
                IsEdited = reviewDto.IsEdited,
                BookId = reviewDto.BookId,
                Book = reviewDto.Book?.ToEntity(),
                UserId = reviewDto.UserId,
                User = reviewDto.User?.ToEntity(),
            };

            return review;
        }
    }
}
