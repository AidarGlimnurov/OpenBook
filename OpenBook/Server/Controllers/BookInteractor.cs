using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenBook.Adapter.Repository;
using OpenBook.Adapter.Transaction;
using OpenBook.App.Interactors;
using OpenBook.App.Mappers;
using OpenBook.Shared.Dtos;
using OpenBook.Shared.OutputData;

namespace OpenBook.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookInteractor : ControllerBase
    {
        private BookInteractor interactor;
        public BookInteractor(BookInteractor interactor)
        {
            this.interactor = interactor;
        }
        [HttpPost("CreateWithEntity")]
        public async Task<Response> CreateWithEntity([FromBody] BookDto book)
        {
            return await interactor.CreateWithEntity(book);
        }
        [HttpGet("Read")]
        public async Task<Response<BookDto>> Read(int id)
        {
            return await interactor.Read(id);
        }
        [HttpPost("UpdateWithEntity")]
        public async Task<Response> UpdateWithEntity([FromBody] BookDto book)
        {
            return await interactor.UpdateWithEntity(book);
        }
        [HttpGet("Delete")]
        public async Task<Response> Delete(int id)
        {
            return await interactor.Delete(id);
        }
        [HttpGet("GetBooks")]
        public async Task<Response<IEnumerable<BookDto>>> GetBooks(int start, int? count)
        {
            return await interactor.GetBooks(start, count);
        }
        [HttpGet("GetBooksForAuthor")]
        public async Task<Response<IEnumerable<BookDto>>> GetBooksForAuthor(int userId, int start, int? count, bool? isPublic)
        {
            return await interactor.GetBooksForAuthor( userId,  start,  count,  isPublic);
        }
        [HttpGet("Published")]
        public async Task<Response> Published(int bookId, bool action)
        {
            return await interactor.Published( bookId,  action);
        }
        [HttpGet("AddGenre")]
        public async Task<Response> AddGenre(int bookId, int genreId)
        {
            return await interactor.AddGenre( bookId,  genreId);
        }
        [HttpGet("RemoveGenre")]
        public async Task<Response> RemoveGenre(int bookId, int genreId)
        {
            return await interactor.RemoveGenre( bookId,  genreId);
        }
        [HttpGet("GetBooksForCycle")]
        public async Task<Response<IEnumerable<BookDto>>> GetBooksForCycle(int cycleId, int start, int? count)
        {
            return await interactor.GetBooksForCycle(cycleId, start, count);
        }
    }
}
