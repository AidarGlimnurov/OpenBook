using OpenBook.Domain.Entity;
using OpenBook.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.App.Storage
{
    public interface ISubscribeRepository : IRepository<Review>
    {
        Task SubForAuthor(int authorId, int userId);
        Task UnsubForAuthor(int authorId, int userId);
        IAsyncEnumerable<Subscribe> GetFollowers(int authorId);
        IAsyncEnumerable<Subscribe> GetSubs(int userId);
    }
}
