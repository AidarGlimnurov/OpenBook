using OpenBook.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.App.Storage
{
    public interface IBasketRepository : IRepository<Basket>
    {
        Task Create(int userId);
        Task AddBook(int userId, int bookId);
        Task RemoveBook(int userId, int bookId);
        IAsyncEnumerable<Book> GetBooks(int userId, int start, int count);
        Task<Book> GetBook(int userId, int bookId);
    }
}