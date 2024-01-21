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
    public class PostController : ControllerBase
    {
        private PostInteractor interactor;
        public PostController(PostInteractor interactor)
        {
            this.interactor = interactor;
        }
        [HttpPost("CreateWithEntity")]
        public async Task<Response> CreateWithEntity([FromBody] PostDto post)
        {
            return await interactor.CreateWithEntity(post);
        }
        [HttpGet("Read")]
        public async Task<Response<PostDto>> Read(int id)
        {
            return await interactor.Read(id);
        }
        [HttpPost("UpdateWithEntity")]
        public async Task<Response> UpdateWithEntity([FromBody] PostDto post)
        {
            return await interactor.UpdateWithEntity(post);
        }
        [HttpGet("Delete")]
        public async Task<Response> Delete(int id)
        {
            return await interactor.Delete(id);
        }
        [HttpGet("GetAll")]
        public async Task<Response<IEnumerable<PostDto>>> GetAll(int start, int? count)
        {
            return await interactor.GetAll(start, count);
        }
        [HttpGet("GetForUser")]
        public async Task<Response<IEnumerable<PostDto>>> GetForUser(int userId, int start, int? count)
        {
            return await interactor.GetForUser(userId, start, count);
        }
    }
}
