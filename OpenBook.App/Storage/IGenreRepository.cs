using OpenBook.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.App.Storage
{
    public interface IGenreRepository : IRepository<Genre>
    {
        IAsyncEnumerable<Genre> GetAll(int start, int? count);
        IAsyncEnumerable<Genre> GetGenresForBook(int bookId, int start, int? count);
    }
}
