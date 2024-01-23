using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenBook.Adapter.Repository;
using OpenBook.Adapter.Transaction;
using OpenBook.App.Interactors;
using OpenBook.Shared.Dtos;
using OpenBook.Shared.OutputData;

namespace OpenBook.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChapterController : ControllerBase
    {
        private ChapterInteractor interactor;
        public ChapterController(ChapterInteractor interactor)
        {
            this.interactor = interactor;
        }
        [HttpPost("Create")]
        public async Task<Response> Create([FromBody] ChapterDto chapter)
        {
            return await interactor.Create(chapter);
        }
        [HttpPost("CreateWithEntity")]
        public async Task<Response> CreateWithEntity([FromBody] ChapterDto chapter)
        {
            return await interactor.CreateWithEntity(chapter);
        }
        [HttpGet("Read")]
        public async Task<Response<ChapterDto>> Read(int id)
        {
            return await interactor.Read(id);
        }
        [HttpPost("UpdateWithEntity")]
        public async Task<Response> UpdateWithEntity([FromBody] ChapterDto chapter)
        {
            return await interactor.UpdateWithEntity(chapter);
        }
        [HttpGet("Delete")]
        public async Task<Response> Delete(int id)
        {
            return await interactor.Delete(id);
        }
        [HttpGet("Published")]
        public async Task<Response> Published(int chapterId, bool action)
        {
            return await interactor.Published(chapterId, action);
        }
        [HttpGet("GetForBook")]
        public async Task<Response<IEnumerable<ChapterDto>>> GetForBook(int bookId, int start, int? count, bool? isPublic)
        {
            return await interactor.GetForBook(bookId, start, count, isPublic);
        }
    }
}
