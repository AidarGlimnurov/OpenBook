using OpenBook.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.App.Storage
{
    public interface IPostRepository : IRepository<Post>
    {
        IAsyncEnumerable<Post> GetAll(int start, int? count);
        IAsyncEnumerable<Post> GetForUser(int userId, int start, int? count);
    }
}
