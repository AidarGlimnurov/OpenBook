using OpenBook.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.App.Storage
{
    public interface ILikeRepository
    {
        Task Create(Like like);
        Task Update(Like like);
        Task<Like> CheckLike(int userId, int bookId);
        IAsyncEnumerable<Like> GetLikesForBook(int bookId, bool isLastTime);
        IAsyncEnumerable<Book> GetLikeBooksForUser(int user);
        Task<int> GetCountLikesForBook(int bookId, bool isLastTime = false);
        Task Delete(int likeId);
    }
}
