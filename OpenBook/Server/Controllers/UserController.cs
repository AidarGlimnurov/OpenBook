using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using OpenBook.Adapter.Repository;
using OpenBook.App.Interactors;
using OpenBook.Shared.Dtos;
using OpenBook.Shared.OutputData;
using System.Security.Claims;

namespace OpenBook.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserInteractor interactor;
        private EmailVerifInteractor verifInteractor;
        public UserController(UserInteractor interactor, EmailVerifInteractor verifInteractor)
        {
            this.interactor = interactor;
            this.verifInteractor = verifInteractor;
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
            var user = await interactor.GetByEmail(email);
            if (user.Value != null)
            {
                user.Value.Password = "";
            }
            return user;
        }
        [HttpGet("GetByName")]
        public async Task<Response<UserDto>> GetByName(string name)
        {
            var user = await interactor.GetByName(name);
            if (user.Value != null)
            {
                user.Value.Password = "";
            }
            return user;
        }
        [HttpPost("Update")]
        public async Task<Response> Update(UserDto user)
        {
            return await interactor.Update(user);
        }

        [HttpGet("SendVerifEmail")]
        public async Task<Response> SendVerifEmail(string email)
        {
            Response resp = new();
            try
            {
                //var email = User.Claims.FirstOrDefault(c => c.Type == ClaimsIdentity.DefaultNameClaimType)?.Value;
                resp = await verifInteractor.CreateWithEmail(email);
                if (resp.IsSuccess)
                {
                    var code = resp.Info;
                    using var emailMessage = new MimeMessage();

                    string subject = "Потдверждение почты";
                    string message = "<h2>Благодарим Вас за регистрацию на нашем сайте</h2>" +
                        "<br>" +
                        "<span>Ваш код для подтверждения почты</span>" +
                        "<br>" +
                        $"<strong>{code}<strong>";

                    emailMessage.From.Add(new MailboxAddress("OpenBook Administration", "0ivanovivan00@mail.ru"));
                    emailMessage.To.Add(new MailboxAddress("", email));
                    emailMessage.Subject = subject;
                    emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                    {
                        Text = message,
                    };

                    using (var client = new SmtpClient())
                    {
                        client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                        await client.ConnectAsync("smtp.mail.ru", 465, true);
                        await client.AuthenticateAsync("0ivanovivan00@mail.ru", "1xcgjmZm97Jj3XSJC2Rw");
                        await client.SendAsync(emailMessage);

                        await client.DisconnectAsync(true);
                    }
                }
            }
            catch (Exception ex)
            {
                return new Response()
                {
                    IsSuccess = false,
                    ErrorInfo = ex.Message,
                    ErrorMessage = "Не удалось отправить письмо!",
                };
            }
            resp.Info = "Письмо успешно отправлено! Проверьте почту!";
            return resp;
        }
        [Authorize]
        [HttpGet("VerifEmail")]
        public async Task<Response> Verification(string code)
        {
            var email = User.Claims.FirstOrDefault(c => c.Type == ClaimsIdentity.DefaultNameClaimType)?.Value;
            var resp = await verifInteractor.Verification(email, code);
            return new Response()
            {
                ErrorInfo = resp.ErrorInfo,
                ErrorMessage = resp.ErrorMessage,
                IsSuccess = resp.IsSuccess,
                Info = resp.Info,
            };
        }

        [HttpGet("CheckCode")]
        public async Task<Response> CheckCode(string email, string code)
        {
            var resp = await verifInteractor.Verification(email, code);
            return new Response()
            {
                ErrorInfo = resp.ErrorInfo,
                ErrorMessage = resp.ErrorMessage,
                IsSuccess = resp.IsSuccess,
                Info = resp.Info,
            };
        }

        [HttpGet("ResetPassword")]
        public async Task<Response> ResetPassword(string email, string password)
        {
            var user = await interactor.GetByEmail(email);
            if (user.Value != null)
            {
                user.Value.Password = password;
            }

            return await interactor.Update(user.Value);
        }
    }
}
