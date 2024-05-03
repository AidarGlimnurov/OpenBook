using Microsoft.EntityFrameworkCore;
using OpenBook.App.Storage;
using OpenBook.Domain.Entity;
using OpenBook.Shared.SupportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OpenBook.Adapter.Repository
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(OpenBookContext context) : base(context)
        {
        }

        public async Task AddGenre(int bookId, int genreId)
        {
            var book = await context.Books.FirstOrDefaultAsync(b => b.Id == bookId);
            var genre = await context.Genres.FirstOrDefaultAsync(g => g.Id == genreId);

            BookGenre bookGenre = new()
            {
                Book = book,
                Genre = genre,
                GenreId = genreId,
                BookId = bookId
            };
            context.BookGenres.Add(bookGenre);
        }

        public async Task Create(Book book)
        {
            if (book.User == null || book.User.Id == 0)
            {
                book.User = await context.Users.FirstOrDefaultAsync(u => u.Id == book.UserId);
            }
            context.Add(book);
        }

        public async IAsyncEnumerable<Book> GetAllBooks(int start, int? count)
        {
            if (count == null) count = 100;

            int skip = start;
            int take = count.Value;

            var books = context.Books.Include(b => b.User)
                .Include(b => b.Cycle).Skip(skip).Take(take);

            foreach (var item in books)
            {
                yield return item;
            }
        }

        public async Task<Book> GetBook(int Id)
        {
            var book = await context.Books.Include(b => b.Cycle).Include(b => b.User).FirstOrDefaultAsync(b => b.Id == Id);
            return book;
        }

        public async IAsyncEnumerable<Book> GetBooks(int start, int? count, bool? isPublic, string? name)
        {
            if (count == null) count = 100;

            int skip = start;
            int take = count.Value;



            if (name != null)
            {
                var books = context.Books.Include(b => b.User)
                    .Include(b => b.Cycle)
                    .Where(b => b.IsPublished == isPublic && b.Name.ToLower()
                    .Contains(name.ToLower())).Skip(skip).Take(take);
                //var str1 = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(name.ToLower()));
                //List<Book> newbook = books.Where(b => b.Name.Contains(name.ToLower())).ToList();
                foreach (var item in books)
                {
                    yield return item;
                }
            }
            else
            {
                var books = context.Books.Include(b => b.User)
                    .Include(b => b.Cycle).Where(b => b.IsPublished == isPublic).Skip(skip).Take(take);
                foreach (var item in books)
                {
                    yield return item;
                }
            }
        }

        public async IAsyncEnumerable<Book> GetBooksForAuthor(int userId, int start, int? count, bool? isPublic)
        {
            if (count == null) count = 100;

            int skip = start;
            int take = count.Value;

            var books = context.Books.Include(b => b.User)
               .Include(b => b.Cycle).Where(b => b.UserId == userId && b.IsPublished == isPublic).Skip(skip).Take(take);

            foreach (var item in books)
            {
                yield return item;
            }
        }

        public async IAsyncEnumerable<Book> GetBooksForCycle(int cycleId, int start, int? count)
        {
            if (count == null) count = 100;

            int skip = start;
            int take = count.Value;

            var books = context.Books.Include(b => b.User)
                .Include(b => b.Cycle).Where(b => b.CycleId == cycleId).Skip(skip).Take(take);

            foreach (var item in books)
            {
                yield return item;
            }
        }

        public async IAsyncEnumerable<Book> GetSortBooks(SortData sortData, int start, int? count)
        {
            if (count == null) count = 100;

            int skip = start;
            int take = count.Value;

            var lastMonthDate = DateTime.Now.AddMonths(-1);
            IQueryable<Book?>? books;
            if (sortData.Action == 0)
            {
                books = context.Books.Skip(skip).Take(take);
            }
            if (sortData.Action == 1)
            {
                books = context.Likes.Include(l => l.Book).Include(l => l.User)
                    .Where(l => l.Date >= lastMonthDate).GroupBy(l => l.Book).Select(g => new { Book = g.Key, Count = g.Count() })
                    .OrderByDescending(l => l.Count).Skip(skip).Take(take).Select(l => l.Book);
            }
            if (sortData.Action == 2)
            {
                books = context.Likes.Include(l => l.Book).Include(l => l.User)
                    .Where(l => l.Date >= lastMonthDate).GroupBy(l => l.Book).Select(g => new { Book = g.Key, Count = g.Count() })
                    .OrderBy(l => l.Count).Skip(skip).Take(take).Select(l => l.Book);
            }
            if (sortData.Action == 2)
            {
                books = context.Books.Order().Skip(skip).Take(take);
            }


            foreach (var item in likes)
            {
                yield return item;
            }
        }

        public async Task Published(int bookId, bool action)
        {
            var book = await context.Books.FirstOrDefaultAsync(b => b.Id == bookId);
            book.IsPublished = action;
        }

        public async Task RemoveGenre(int bookId, int genreId)
        {
            var bookGenre = await context.BookGenres
                .FirstOrDefaultAsync(g => g.BookId == bookId && g.GenreId == genreId);

            context.BookGenres.Remove(bookGenre);
        }

        public async Task Update(Book book)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == book.UserId);
            book.User = user;
            if (book.CycleId != null && book.CycleId != 0)
            {
                var cycle = await context.Cycles.FirstOrDefaultAsync(c => c.Id == book.CycleId);
                book.Cycle = cycle;
            }
            if (book.CycleId == 0)
            {
                book.CycleId = null;
                book.Cycle = null;
            }
            context.Update(book);
        }
    }
}
