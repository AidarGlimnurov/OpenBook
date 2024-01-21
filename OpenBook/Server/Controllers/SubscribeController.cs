using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenBook.Adapter.Transaction;
using OpenBook.App.Interactors;
using OpenBook.Shared.Dtos;
using OpenBook.Shared.OutputData;

namespace OpenBook.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private SubscribeInteractor interactor;
        public SubscribeController(SubscribeInteractor interactor)
        {
            this.interactor = interactor;
        }
        [HttpPost("CreateWithEntity")]
        public async Task<Response> CreateWithEntity([FromBody] SubscribeDto subscribe)
        {
            return await interactor.CreateWithEntity(subscribe);
        }
        [HttpGet("Read")]
        public async Task<Response<SubscribeDto>> Read(int id)
        {
            return await interactor.Read(id);
        }
        [HttpPost("UpdateWithEntity")]
        public async Task<Response> UpdateWithEntity([FromBody] SubscribeDto subscribe)
        {
            return await interactor.UpdateWithEntity(subscribe);
        }
        [HttpGet("Delete")]
        public async Task<Response> Delete(int id)
        {
            return await interactor.Delete(id);
        }
        [HttpGet("SubForAuthor")]
        public async Task<Response> SubForAuthor(int authorId, int userId)
        {
            return await interactor.SubForAuthor(authorId, userId);
        }
        [HttpGet("UnsubForAuthor")]
        public async Task<Response> UnsubForAuthor(int authorId, int userId)
        {
            return await interactor.UnsubForAuthor(authorId, userId);
        }
        [HttpGet("GetFollowers")]
        public async Task<Response<IEnumerable<SubscribeDto>>> GetFollowers(int authorId)
        {
            return await interactor.GetFollowers(authorId);
        }
        [HttpGet("GetSubs")]
        public async Task<Response<IEnumerable<SubscribeDto>>> GetSubs(int userId)
        {
            return await interactor.GetSubs(userId);
        }
    }
}
