using OpenBook.App.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.Adapter.Repository
{
    public class BaseRepository<T> : IRepository<T>
        where T : class
    {
        protected OpenBookContext context;
        public BaseRepository(OpenBookContext context)
        {
            this.context = context;
        }
        public Task CreateWithEntity(T entity)
        {
            context.Add<T>(entity);
            context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var e = context.Find<T>(id);
            context.Remove<T>(e);
            context.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task<T> Read(int id)
        {
            var e = await context.FindAsync<T>(id);
            context.SaveChanges();
            return e;
        }

        public Task<IAsyncEnumerable<T>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task UpdateWithEntity(T entity)
        {
            context.Update<T>(entity);
            context.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
