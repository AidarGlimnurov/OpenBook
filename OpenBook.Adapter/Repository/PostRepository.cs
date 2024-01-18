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
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(OpenBookContext context) : base(context)
        {
        }

        public async IAsyncEnumerable<Post> GetAll(int start, int? count)
        {
            if (count == null) count = 100;

            int skip = start;
            int take = count.Value;

            var cycles = context.Posts.Skip(skip).Take(take);

            foreach (var item in cycles)
            {
                yield return item;
            }
        }

        public async IAsyncEnumerable<Post> GetForUser(int userId, int start, int? count)
        {
            if (count == null) count = 100;

            int skip = start;
            int take = count.Value;

            var posts = context.Posts.Include(p => p.User)
                .Where(p => p.UserId == userId).Skip(skip).Take(take);

            foreach (var item in posts)
            {
                yield return item;
            }
        }
    }
}
