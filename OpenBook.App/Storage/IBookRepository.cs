using OpenBook.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.App.Storage
{
    public interface IBookRepository : IRepository<Book>
    {
        Task Create(Book book);
        Task Update(Book book);
        IAsyncEnumerable<Book> GetBooks(int start, int? count, bool? isPublic, string? name);
        IAsyncEnumerable<Book> GetAllBooks(int start, int? count);
        IAsyncEnumerable<Book> GetBooksForAuthor(int userId, int start, int? count, bool? isPublic);
        Task Published(int bookId, bool action);
        Task AddGenre(int bookId, int genreId);
        Task RemoveGenre(int bookId, int genreId);
        IAsyncEnumerable<Book> GetBooksForCycle(int cycleId, int start, int? count);
        Task<Book> GetBook(int Id);
    }
}
