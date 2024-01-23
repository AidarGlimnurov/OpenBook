using Microsoft.EntityFrameworkCore;
using OpenBook.App.Storage;
using OpenBook.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.Adapter.Repository
{
    public class BasketRepository : BaseRepository<Basket>, IBasketRepository
    {
        public BasketRepository(OpenBookContext context) : base(context)
        {

        }
        public async Task AddBook(int userId, int bookId)
        {
            var book = await context.Books.Include(b => b.Cycle).Include(b => b.User).FirstOrDefaultAsync(b => b.Id == bookId);
            var basket = await context.Baskets.FirstOrDefaultAsync(b => b.User.Id == userId);
            BookBasket bookBasket = new()
            {
                Basket = basket,
                Book = book
            };
            context.BookBaskets.Add(bookBasket);
        }

        public async Task Create(int userId)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            Basket basket = new()
            {
                User = user,
                UserId = userId,
            };
            context.Baskets.Add(basket);
        }

        public async IAsyncEnumerable<Book> GetBooks(int userId, int start, int count)
        {
            if (count == null || count == 0) count = 100;

            int skip = start;
            int take = count;

            var books = context.BookBaskets.Include(bb => bb.Basket)
                .Include(bb => bb.Book).ThenInclude(b => b.Cycle)
                .Where(bb => bb.Basket.UserId == userId).Skip(skip).Take(take).ToArray();

            foreach (var item in books)
            {
                yield return item.Book;
            }
        }

        public async Task RemoveBook(int userId, int bookId)
        {
            var bookBasket = await context.BookBaskets.Include(bb => bb.Basket)
                .FirstOrDefaultAsync(bb => bb.Basket.UserId == userId && bb.BasketId == bookId);
            context.BookBaskets.Remove(bookBasket);
        }
    }
}
