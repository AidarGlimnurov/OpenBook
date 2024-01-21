using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenBook.App.Interactors;
using OpenBook.Shared.Dtos;
using OpenBook.Shared.OutputData;

namespace OpenBook.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private RoleInteractor interactor;
        public RoleController(RoleInteractor interactor)
        {
            this.interactor = interactor;
        }
        [HttpPost("CreateWithEntity")]
        public async Task<Response> CreateWithEntity([FromBody] RoleDto role)
        {
            return await interactor.CreateWithEntity(role);
        }
        [HttpGet("Read")]
        public async Task<Response<RoleDto>> Read(int id)
        {
            return await interactor.Read(id);
        }
        [HttpPost("UpdateWithEntity")]
        public async Task<Response> UpdateWithEntity([FromBody] RoleDto role)
        {
            return await interactor.UpdateWithEntity(role);
        }
        [HttpGet("Delete")]
        public async Task<Response> Delete(int id)
        {
            return await interactor.Delete(id);
        }
        [HttpGet("GetAll")]
        public async Task<Response<IEnumerable<RoleDto>>> GetAll(int start, int? count)
        {
            return await interactor.GetAll(start, count);
        }
    }
}
