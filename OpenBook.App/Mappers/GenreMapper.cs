using OpenBook.Domain.Entity;
using OpenBook.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.App.Mappers
{
    public static class GenreMapper
    {
        public static GenreDto? ToDto(this Genre genre)
        {
            if (genre == null)
            {
                return null;
            }

            GenreDto genreDto = new GenreDto()
            {
                Id = genre.Id,
                Name = genre.Name,
            };

            return genreDto;
        }

        public static Genre? ToEntity(this GenreDto genreDto)
        {
            if (genreDto == null)
            {
                return null;
            }

            Genre genre = new Genre()
            {
                Id = genreDto.Id,
                Name = genreDto.Name,
            };

            return genre;
        }
    }
}
