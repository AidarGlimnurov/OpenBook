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

        public async Task CreateWithBasket(User user)
        {

            if (user.Role == null || user.Role.Id == 0)
            {
                user.Role = await context.Roles.FirstOrDefaultAsync(r => r.Id == user.RoleId);
            }
            context.Add(user);
            Basket basket = new Basket()
            {
                User = user,
            };
            context.Add(basket);
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

        public async Task<User> GetByName(string name)
        {
            if (name != null)
            {
                return await context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Name == name);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public async Task Update(User user)
        {
            //var userChange = await context.Users.Include(u => u.Role).FirstOrDefaultAsync(u=>u.Id==user)
            var userChange = await context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == user.Id);
            userChange.Password = user.Password;
            context.Update(userChange);
        }
    }
}
