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
    }
}
