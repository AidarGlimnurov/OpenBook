using OpenBook.Domain.Entity;
using OpenBook.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.App.Mappers
{
    public static class PostMapper
    {
        public static PostDto? ToDto(this Post post)
        {
            if (post == null)
            {
                return null;
            }

            PostDto postDto = new PostDto()
            {
                Id = post.Id,
                Content = post.Content,
                CreatedAt = post.CreatedAt,
                UserId = post.UserId,
                User = post.User?.ToDto(),
            };

            return postDto;
        }

        public static Post? ToEntity(this PostDto postDto)
        {
            if (postDto == null)
            {
                return null;
            }

            Post post = new Post()
            {
                Id = postDto.Id,
                Content = postDto.Content,
                CreatedAt = postDto.CreatedAt,
                UserId = postDto.UserId,
                User = postDto.User?.ToEntity(),
            };

            return post;
        }
    }
}
