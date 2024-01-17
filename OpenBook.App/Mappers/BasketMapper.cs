using OpenBook.Domain.Entity;
using OpenBook.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.App.Mappers
{
    public static class BasketMapper
    {
        public static BasketDto? ToDto(this Basket basket)
        {
            if (basket == null)
            {
                return null;
            }

            BasketDto basketDto = new BasketDto()
            {
                Id = basket.Id,
                UserId = basket.UserId,
                User = basket.User?.ToDto(),
            };

            return basketDto;
        }

        public static Basket? ToEntity(this BasketDto basketDto)
        {
            if (basketDto == null)
            {
                return null;
            }

            Basket basket = new Basket()
            {
                Id = basketDto.Id,
                UserId = basketDto.UserId,
                User = basketDto.User?.ToEntity(),
            };

            return basket;
        }
    }
}
