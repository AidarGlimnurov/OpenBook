using Microsoft.EntityFrameworkCore;
using OpenBook.App.Storage;
using OpenBook.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.Adapter.Repository
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(OpenBookContext context) : base(context)
        {
        }

        public async Task Create(Review review)
        {
            review.Book = await context.Books.FirstOrDefaultAsync(r => r.Id == review.BookId);
            review.User = await context.Users.FirstOrDefaultAsync(u => u.Id == review.UserId);

            //if (review.Book == null || review.Book.Id == 0)
            //{
            //    review.Book = await context.Books.FirstOrDefaultAsync(r => r.Id == review.BookId);
            //}
            //if (review.User == null || review.User.Id == 0)
            //{
            //    review.User = await context.Users.FirstOrDefaultAsync(u => u.Id == review.UserId);
            //}
            context.Add(review);
        }
        public async Task Update(Review review)
        {
            review.Book = await context.Books.FirstOrDefaultAsync(r => r.Id == review.BookId);
            review.User = await context.Users.FirstOrDefaultAsync(u => u.Id == review.UserId);

            context.Update(review);
        }

        public async IAsyncEnumerable<Review> GetForBook(int bookId, int start, int? count)
        {
            if (count == null) count = 100;

            int skip = start;
            int take = count.Value;

            var reviews = context.Reviews.Include(r => r.User).Include(r => r.Book)
                .Where(r => r.BookId == bookId).Take(take);

            foreach (var item in reviews)
            {
                yield return item;
            }
        }

        public async IAsyncEnumerable<Review> GetForUser(int userId, int start, int? count)
        {
            if (count == null) count = 100;

            int skip = start;
            int take = count.Value;

            var reviews = context.Reviews.Include(r => r.User).Include(r => r.Book)
                .Where(r => r.UserId == userId).Take(take);

            foreach (var item in reviews)
            {
                yield return item;
            }
        }

        public async Task<Review> GetForUserBook(int bookId, int userId)
        {
            var review = await context.Reviews.Include(r => r.User).Include(r => r.Book)
                .FirstOrDefaultAsync(r => r.UserId == userId && r.BookId == bookId);
            return review;
        }

    }
}
