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
    public class UserController : ControllerBase
    {
        private UserInteractor interactor;
        public UserController(UserInteractor interactor)
        {
            this.interactor = interactor;
        }
        //[HttpPost("CreateWithEntity")]
        //public async Task<Response> CreateWithEntity([FromBody] UserDto user)
        //{
        //    return await interactor.CreateWithEntity(user);
        //}
        [HttpPost("CreateWithBasket")]
        public async Task<Response> CreateWithBasket(UserDto user)
        {
            return await interactor.CreateWithBasket(user);
        }
        [HttpGet("Read")]
        public async Task<Response<UserDto>> Read(int id)
        {
            return await interactor.Read(id);
        }
        [HttpPost("UpdateWithEntity")]
        public async Task<Response> UpdateWithEntity([FromBody] UserDto user)
        {
            return await interactor.UpdateWithEntity(user);
        }
        [HttpGet("Delete")]
        public async Task<Response> Delete(int id)
        {
            return await interactor.Delete(id);
        }
        [HttpGet("GetAll")]
        public async Task<Response<DataPage<UserDto>>> GetAll(int start, int? count)
        {
            return await interactor.GetAll(start, count);
        }
        [HttpGet("GetByEmailPassword")]
        public async Task<Response<UserDto>> GetByEmailPassword(string email, string password)
        {
            return await interactor.GetByEmailPassword(email, password);
        }
        [HttpGet("GetByEmail")]
        public async Task<Response<UserDto>> GetByEmail(string email)
        {
            return await interactor.GetByEmail(email);
        }
    }
}
