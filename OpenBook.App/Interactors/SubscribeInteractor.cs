using OpenBook.App.Data.Transaction;
using OpenBook.App.Mappers;
using OpenBook.App.Storage;
using OpenBook.Domain.Entity;
using OpenBook.Shared.Dtos;
using OpenBook.Shared.OutputData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.App.Interactors
{
    public class SubscribeInteractor
    {
        private ISubscribeRepository subscribeRepository;
        private IUnitWork unitWork;

        public SubscribeInteractor(ISubscribeRepository subscribeRepository, IUnitWork unitWork)
        {
            this.subscribeRepository = subscribeRepository;
            this.unitWork = unitWork;
        }
        public async Task<Response> Create(SubscribeDto sub)
        {
            var response = new Response<SubscribeDto>();
            try
            {
                await subscribeRepository.Create(sub.ToEntity());
                response.IsSuccess = true;
                await unitWork.Commit();
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Внутренняя ошибка!";
                response.IsSuccess = false;
                response.ErrorInfo = ex.Message;
            }
            return response;
        }
        public async Task<Response> CreateWithEntity(SubscribeDto sub)
        {
            var response = new Response<SubscribeDto>();
            try
            {
                await subscribeRepository.CreateWithEntity(sub.ToEntity());
                response.IsSuccess = true;
                await unitWork.Commit();
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Внутренняя ошибка!";
                response.IsSuccess = false;
                response.ErrorInfo = ex.Message;
            }
            return response;
        }
        public async Task<Response<SubscribeDto>> Read(int id)
        {
            var response = new Response<SubscribeDto>();
            try
            {
                var role = await subscribeRepository.Read(id);
                response.Value = role.ToDto();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Внутренняя ошибка!";
                response.IsSuccess = false;
                response.ErrorInfo = ex.Message;
            }
            return response;
        }
        public async Task<Response> UpdateWithEntity(SubscribeDto sub)
        {
            var response = new Response<SubscribeDto>();
            try
            {
                await subscribeRepository.UpdateWithEntity(sub.ToEntity());
                response.IsSuccess = true;
                await unitWork.Commit();
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Внутренняя ошибка!";
                response.IsSuccess = false;
                response.ErrorInfo = ex.Message;
            }
            return response;
        }
        public async Task<Response> Delete(int id)
        {
            var response = new Response<SubscribeDto>();
            try
            {
                await subscribeRepository.Delete(id);
                response.IsSuccess = true;
                await unitWork.Commit();
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Внутренняя ошибка!";
                response.IsSuccess = false;
                response.ErrorInfo = ex.Message;
            }
            return response;
        }
        public async Task<Response> SubForAuthor(int authorId, int userId)
        {
            var response = new Response<SubscribeDto>();
            try
            {
                await subscribeRepository.SubForAuthor(authorId, userId);
                response.IsSuccess = true;
                await unitWork.Commit();
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Внутренняя ошибка!";
                response.IsSuccess = false;
                response.ErrorInfo = ex.Message;
            }
            return response;
        }
        public async Task<Response> UnsubForAuthor(int authorId, int userId)
        {
            var response = new Response<SubscribeDto>();
            try
            {
                await subscribeRepository.UnsubForAuthor(authorId, userId);
                response.IsSuccess = true;
                await unitWork.Commit();
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Внутренняя ошибка!";
                response.IsSuccess = false;
                response.ErrorInfo = ex.Message;
            }
            return response;
        }
        public async Task<Response<IEnumerable<SubscribeDto>>> GetFollowers(int authorId)
        {
            var response = new Response<IEnumerable<SubscribeDto>>();
            try
            {
                var data = subscribeRepository.GetFollowers(authorId);

                List<SubscribeDto> subsribes = new();
                await foreach (var item in data)
                {
                    subsribes.Add(item.ToDto());
                }
                response.Value = subsribes.ToList();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Внутренняя ошибка!";
                response.IsSuccess = false;
                response.ErrorInfo = ex.Message;
            }
            return response;
        }
        public async Task<Response<IEnumerable<SubscribeDto>>> GetSubs(int userId)
        {
            var response = new Response<IEnumerable<SubscribeDto>>();
            try
            {
                var data = subscribeRepository.GetSubs(userId);

                List<SubscribeDto> subsribes = new();
                await foreach (var item in data)
                {
                    subsribes.Add(item.ToDto());
                }
                response.Value = subsribes.ToList();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Внутренняя ошибка!";
                response.IsSuccess = false;
                response.ErrorInfo = ex.Message;
            }
            return response;
        }
    }
}