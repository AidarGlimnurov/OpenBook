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
    public class CycleRepository : BaseRepository<Cycle>, ICycleRepository
    {
        public CycleRepository(OpenBookContext context) : base(context)
        {
        }

        public async Task Create(Cycle cycle)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == cycle.UserId);
            cycle.User = user;
            context.Add(cycle);
        }

        public async IAsyncEnumerable<Cycle> GetAll(int start, int? count)
        {
            if (count == null) count = 100;

            int skip = start;
            int take = count.Value;

            var cycles = context.Cycles.Skip(skip).Take(take);

            foreach (var item in cycles)
            {
                yield return item;
            }
        }

        public async IAsyncEnumerable<Cycle> GetAllForUser(int userId, int start, int? count)
        {
            if (count == null) count = 100;

            int skip = start;
            int take = count.Value;

            var cycles = context.Cycles.Where(c => c.UserId == userId).Skip(skip).Take(take);

            foreach (var item in cycles)
            {
                yield return item;
            }
        }

        public async Task Update(Cycle cycle)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == cycle.UserId);
            cycle.User = user;
            context.Update(cycle);
        }
    }
}
