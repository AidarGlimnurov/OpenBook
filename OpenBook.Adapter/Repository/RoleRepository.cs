using OpenBook.App.Storage;
using OpenBook.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.Adapter.Repository
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(OpenBookContext context) : base(context)
        {
        }

        public async IAsyncEnumerable<Role> GetAll(int start, int? count)
        {
            if (count == null) count = 100;

            int skip = start;
            int take = count.Value;

            var roles = context.Roles.Skip(skip).Take(take);

            foreach (var item in roles)
            {
                yield return item;
            }
        }
    }
}
