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
        [HttpPost("Create")]
        public async Task<Response> Create([FromBody] PostDto post)
        {
            return await interactor.Create(post);
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
        public async Task<Response<DataPage<PostDto>>> GetAll(int start, int? count)
        {
            return await interactor.GetAll(start, count);
        }
        [HttpGet("GetForUser")]
        public async Task<Response<DataPage<PostDto>>> GetForUser(int userId, int start, int? count)
        {
            return await interactor.GetForUser(userId, start, count);
        }
        [HttpGet("AddView")]
        public async Task<Response> AddView(int userId, int chapterId)
        {
            return await interactor.AddView(userId, chapterId);
        }
        [HttpGet("GetUnicViewForChapter")]
        public async Task<Response> GetUnicViewForChapter(int chapterId)
        {
            return await interactor.GetUnicViewForChapter(chapterId);
        }
        [HttpGet("GetViewForChapter")]
        public async Task<Response> GetViewForChapter(int chapterId)
        {
            return await interactor.GetViewForChapter(chapterId);
        }
    }
}
