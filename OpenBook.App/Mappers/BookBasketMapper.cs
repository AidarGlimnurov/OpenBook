using OpenBook.Domain.Entity;
using OpenBook.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.App.Mappers
{
    public static class BookBasketMapper
    {
        public static BookBasketDto? ToDto(this BookBasket bookBasket)
        {
            if (bookBasket == null)
            {
                return null;
            }

            BookBasketDto bookBasketDto = new BookBasketDto()
            {
                Id = bookBasket.Id,
                Book = bookBasket.Book?.ToDto(),
                BookId = bookBasket.BookId,
                Basket = bookBasket.Basket?.ToDto(),
                BasketId = bookBasket.BasketId,
            };

            return bookBasketDto;
        }

        public static BookBasket? ToEntity(this BookBasketDto bookBasketDto)
        {
            if (bookBasketDto == null)
            {
                return null;
            }

            BookBasket bookBasket = new BookBasket()
            {
                Id = bookBasketDto.Id,
                Book = bookBasketDto.Book?.ToEntity(),
                BookId = bookBasketDto.BookId,
                Basket = bookBasketDto.Basket?.ToEntity(),
                BasketId = bookBasketDto.BasketId,
            };

            return bookBasket;
        }
    }
}
