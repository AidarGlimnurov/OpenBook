using OpenBook.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.App.Storage
{
    public interface ICycleRepository : IRepository<Cycle>
    {
        IAsyncEnumerable<Cycle> GetAll(int start, int? count);
        IAsyncEnumerable<Cycle> GetAllForUser(int userId, int start, int? count);
        Task Create(Cycle cycle);
        Task Update(Cycle cycle);
    }
}