using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenBook.Adapter.Repository;
using OpenBook.App.Interactors;
using OpenBook.Shared.Dtos;
using OpenBook.Shared.OutputData;

namespace OpenBook.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private ReviewInteractor interactor;
        public ReviewController(ReviewInteractor interactor)
        {
            this.interactor = interactor;
        }
        [HttpPost("Create")]
        public async Task<Response> Create([FromBody] ReviewDto review)
        {
            return await interactor.Create(review);
        }
        [HttpPost("CreateWithEntity")]
        public async Task<Response> CreateWithEntity([FromBody] ReviewDto review)
        {
            return await interactor.CreateWithEntity(review);
        }
        [HttpGet("Read")]
        public async Task<Response<ReviewDto>> Read(int id)
        {
            return await interactor.Read(id);
        }
        [HttpPost("UpdateWithEntity")]
        public async Task<Response> UpdateWithEntity([FromBody] ReviewDto review)
        {
            return await interactor.UpdateWithEntity(review);
        }
        [HttpGet("Delete")]
        public async Task<Response> Delete(int id)
        {
            return await interactor.Delete(id);
        }
        [HttpGet("GetForUser")]
        public async Task<Response<DataPage<ReviewDto>>> GetForUser(int userId, int start, int? count)
        {
            return await interactor.GetForUser(userId, start, count);
        }
        [HttpGet("GetForBook")]
        public async Task<Response<DataPage<ReviewDto>>> GetForBook(int bookId, int start, int? count)
        {
            return await interactor.GetForBook(bookId, start, count);
        }
    }
}
