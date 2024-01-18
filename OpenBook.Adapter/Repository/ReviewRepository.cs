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

        public async IAsyncEnumerable<Review> GetForBook(int bookId, int start, int? count)
        {
            if (count == null) count = 100;

            int skip = start;
            int take = count.Value;

            var reviews = context.Reviews.Include(r=>r.User).Include(r=>r.Book)
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
    }
}
