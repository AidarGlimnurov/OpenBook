using iTextSharp.text.pdf.parser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenBook.Adapter.Repository;
using OpenBook.Adapter.Transaction;
using OpenBook.App.Interactors;
using OpenBook.Domain.Entity;
using OpenBook.Shared.Dtos;
using OpenBook.Shared.OutputData;

namespace OpenBook.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private LikeInteractor interactor;
        public LikeController(LikeInteractor interactor)
        {
            this.interactor = interactor;
        }
        [HttpPost("Create")]
        public async Task<Response> Create(LikeDto like)
        {
            return await interactor.Create(like);
        }
        [HttpGet("CheckLike")]
        public async Task<Response<LikeDto>> CheckLike(int userId, int bookId)
        {
            return await interactor.CheckLike(userId, bookId);
        }
        [HttpGet("GetLikeBooksForUser")]
        public async Task<Response<DataPage<BookDto>>> GetLikeBooksForUser(int user)
        {
            return await interactor.GetLikeBooksForUser(user);
        }
        [HttpGet("GetLikesForBook")]
        public async Task<Response<DataPage<LikeDto>>> GetLikesForBook(int bookId, bool isLastTime)
        {
            return await interactor.GetLikesForBook(bookId, isLastTime);
        }
        [HttpPost("Update")]
        public async Task<Response> Update(LikeDto like)
        {
            return await interactor.Update(like);
        }
        [HttpGet("Delete")]
        public async Task<Response> Delete(int likeId)
        {
            return await interactor.Delete(likeId);
        }
    }
}
