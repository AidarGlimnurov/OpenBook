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
    public class BasketController : ControllerBase
    {
        private BasketInteractor interactor;
        public BasketController(BasketInteractor interactor)
        {
            this.interactor = interactor;
        }
        [HttpPost("CreateWithEntity")]
        public async Task<Response> CreateWithEntity([FromBody] BasketDto basket)
        {
            return await interactor.CreateWithEntity(basket);
        }
        [HttpGet("Read")]
        public async Task<Response<BasketDto>> Read(int id)
        {
            return await interactor.Read(id);
        }
        [HttpPost("UpdateWithEntity")]
        public async Task<Response> UpdateWithEntity(BasketDto basket)
        {
            return await interactor.UpdateWithEntity(basket);
        }
        [HttpGet("Delete")]
        public async Task<Response> Delete(int id)
        {
            return await interactor.Delete(id);
        }
        [HttpGet("Create")]
        public async Task<Response> Create(int userId)
        {
            return await interactor.Create(userId);
        }
        [HttpGet("AddBook")]
        public async Task<Response> AddBook(int userId, int bookId)
        {
            return await interactor.AddBook(userId, bookId);
        }
        [HttpGet("RemoveBook")]
        public async Task<Response> RemoveBook(int userId, int bookId)
        {
            return await interactor.RemoveBook(userId, bookId);
        }
        [HttpGet("GetBooks")]
        public async Task<Response<IEnumerable<BookDto>>> GetBooks(int userId, int start, int count)
        {
            return await interactor.GetBooks(userId, start, count);
        }
    }
}
