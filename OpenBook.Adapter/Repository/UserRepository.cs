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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(OpenBookContext context) : base(context)
        {
        }

        public async IAsyncEnumerable<User> GetAll(int start, int? count)
        {
            if (count == null) count = 100;

            int skip = start;
            int take = count.Value;

            var users = context.Users.Include(u => u.Role).Skip(skip).Take(take);

            foreach (var item in users)
            {
                yield return item;
            }
        }

        public async Task<User> GetByEmail(string email)
        {
            if (email != null)
            {
                return await context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == email);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public async Task<User> GetByEmailPassword(string email, string password)
        {
            if (email != null && password != null)
            {
                return await context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
