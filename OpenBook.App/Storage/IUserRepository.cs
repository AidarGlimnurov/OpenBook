using OpenBook.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.App.Storage
{
    public interface IUserRepository : IRepository<User>
    {
        public IAsyncEnumerable<User> GetAll(int start, int? count);
        public Task<User> GetByEmailPassword(string email, string password);
        public Task<User> GetByEmail(string email);
        public Task CreateWithBasket(User user);
    }
}
