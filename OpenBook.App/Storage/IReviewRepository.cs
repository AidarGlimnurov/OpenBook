using OpenBook.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.App.Storage
{
    public interface IReviewRepository : IRepository<Review>
    {
        Task Create(Review review);
        Task Update(Review review);
        IAsyncEnumerable<Review> GetForUser(int userId, int start, int? count);
        IAsyncEnumerable<Review> GetForBook(int bookId, int start, int? count);
        Task<Review> GetForUserBook(int bookId, int userId);
    }
}
