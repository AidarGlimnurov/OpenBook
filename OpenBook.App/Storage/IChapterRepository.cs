using OpenBook.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.App.Storage
{
    public interface IChapterRepository : IRepository<Chapter>
    {
        Task Published(int chapterId, bool action);
        IAsyncEnumerable<Chapter> GetForBook(int bookId, int start, int? count, bool? isPublic);
    }
}
