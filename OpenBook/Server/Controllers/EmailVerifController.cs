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
    public class EmailVerifController : ControllerBase
    {
        private EmailVerifInteractor interactor;
        public EmailVerifController(EmailVerifInteractor interactor)
        {
            this.interactor = interactor;
        }
        [HttpGet("CreateWithEntity")]
        public async Task<Response> CreateWithEmail(string email)
        {
            return await interactor.CreateWithEmail(email);
        }
        [HttpGet("CreateWithEntity")]
        public async Task<Response<EmailVerifDto>> Verification(string email, string code)
        {
            return await interactor.Verification(email, code);
        }
    }
}
