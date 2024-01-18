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
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(OpenBookContext context) : base(context)
        {
        }

        public async IAsyncEnumerable<Genre> GetAll(int start, int? count)
        {
            if (count == null) count = 100;

            int skip = start;
            int take = count.Value;

            var genres = context.Genres.Skip(skip).Take(take);

            foreach (var item in genres)
            {
                yield return item;
            }
        }

        public async IAsyncEnumerable<Genre> GetGenresForBook(int bookId, int start, int? count)
        {
            if (count == null) count = 100;

            int skip = start;
            int take = count.Value;

            var genres = context.BookGenres.Where(g => g.BookId == bookId).Select(g => g.Genre).Skip(skip).Take(take);

            foreach (var item in genres)
            {
                yield return item;
            }
        }
    }
}
