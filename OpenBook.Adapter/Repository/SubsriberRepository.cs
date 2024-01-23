using Microsoft.EntityFrameworkCore;
using OpenBook.App.Storage;
using OpenBook.Domain.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.Adapter.Repository
{
    public class SubsriberRepository : BaseRepository<Subscribe>, ISubscribeRepository
    {
        public SubsriberRepository(OpenBookContext context) : base(context)
        {
        }

        public async Task Create(Subscribe subscribe)
        {
            if (subscribe.Auth == null || subscribe.Auth.Id == 0)
            {
                subscribe.Auth = await context.Users.FirstOrDefaultAsync(u => u.Id == subscribe.AuthorId);
            }
            if (subscribe.Sub == null || subscribe.Sub.Id == 0)
            {
                subscribe.Sub = await context.Users.FirstOrDefaultAsync(u => u.Id == subscribe.SubscriberId);
            }
            context.Add(subscribe);
        }

        public async IAsyncEnumerable<Subscribe> GetFollowers(int authorId)
        {
            var subs = context.Subscribes.Include(s => s.Auth).Include(s => s.Sub)
                .Where(s => s.AuthorId == authorId);

            foreach (var item in subs)
            {
                yield return item;
            }
        }

        public async IAsyncEnumerable<Subscribe> GetSubs(int userId)
        {
            var subs = context.Subscribes.Include(s => s.Auth).Include(s => s.Sub)
                .Where(s => s.SubscriberId == userId);

            foreach (var item in subs)
            {
                yield return item;
            }
        }

        public async Task SubForAuthor(int authorId, int userId)
        {
            var sub = await context.Users.FirstOrDefaultAsync(s => s.Id == userId);
            var auth = await context.Users.FirstOrDefaultAsync(s => s.Id == authorId);

            Subscribe subscribe = new()
            {
                Sub = sub,
                Auth = auth,
                SubscriberId = sub.Id,
                AuthorId = auth.Id
            };

            context.Subscribes.Add(subscribe);
        }

        public async Task UnsubForAuthor(int authorId, int userId)
        {
            var sub = await context.Subscribes.FirstOrDefaultAsync(s => s.SubscriberId == userId
                 && s.AuthorId == authorId);
            context.Subscribes.Remove(sub);
        }
    }
}
