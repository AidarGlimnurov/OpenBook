using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.App.Storage
{
    public interface IRepository<T>
        where T : class
    {
        public Task CreateWithEntity(T entity);
        public Task<T> Read(int id);
        public Task<IAsyncEnumerable<T>> ReadAll();
        public Task UpdateWithEntity(T entity);
        public Task Delete(int id);
    }

}
