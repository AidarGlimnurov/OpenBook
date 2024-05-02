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
    public class LikeRepository : BaseRepository<Like>, ILikeRepository
    {
        public LikeRepository(OpenBookContext context) : base(context)
        {

        }

        public async Task<Like> CheckLike(int userId, int bookId)
        {
            return await context.Likes.Include(l => l.User).Include(l => l.Book).FirstOrDefaultAsync() ?? throw new NotImplementedException("Лайк не найден");
        }
        public async Task Create(Like like)
        {
            like.Book = await context.Books.FirstOrDefaultAsync(b => b.Id == like.Id);
            like.User = await context.Users.FirstOrDefaultAsync(u => u.Id == like.Id);

            context.Add(like);
        }
        public async Task<int> GetCountLikesForBook(int bookId, bool isLastTime)
        {
            if (isLastTime)
            {
                var lastMonthDate = DateTime.Now.AddMonths(-1);

                var likes = await context.Likes
                    .Where(l => l.BookId == bookId && l.Date >= lastMonthDate)
                    .ToArrayAsync();

                return likes.Length;
            }
            else
            {
                var likes = await context.Likes.Where(l => l.BookId == bookId).ToArrayAsync();
                return likes.Length;
            }
        }
        public async IAsyncEnumerable<Book> GetLikeBooksForUser(int user)
        {
            var books = context.Likes.Include(l => l.Book).Include(l => l.User)
                .Select(l => l.Book).Where(l => l.UserId == user);
            foreach (var book in books)
            {
                yield return book;
            }
        }
        public async IAsyncEnumerable<Like> GetLikesForBook(int bookId, bool isLastTime)
        {
            if (isLastTime)
            {
                var lastMonthDate = DateTime.Now.AddMonths(-1);

                var likes = context.Likes.Include(l => l.Book).Include(l => l.User)
                    .Where(l => l.BookId == bookId && l.Date >= lastMonthDate)
                    .ToArrayAsync();
            }
            else
            {
                var likes = context.Likes.Include(l => l.Book).Include(l => l.User).Where(l => l.BookId == bookId);

                foreach (var item in likes)
                {
                    yield return item;
                }
            }
        }
        public async Task Update(Like like)
        {
            like.Book = await context.Books.FirstOrDefaultAsync(b => b.Id == like.Id);
            like.User = await context.Users.FirstOrDefaultAsync(u => u.Id == like.Id);

            context.Update(like);
        }
        public async Task Delete(int likeId)
        {
            var like = await context.Likes.FirstOrDefaultAsync(l => l.Id == likeId);
            context.Remove(like);
        }
    }
}
