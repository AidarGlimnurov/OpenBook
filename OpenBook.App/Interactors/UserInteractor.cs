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
    public class UserInteractor
    {
        private IUserRepository userRepository;
        private IRoleRepository roleRepository;
        private IUnitWork unitWork;

        public UserInteractor(IUserRepository userRepository, IUnitWork unitWork, IRoleRepository roleRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            this.unitWork = unitWork;
        }
        public async Task<Response> CreateWithEntity(UserDto user)
        {
            var response = new Response<UserDto>();
            try
            {
                await userRepository.CreateWithEntity(user.ToEntity());
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
        public async Task<Response> CreateWithBasket(UserDto user)
        {
            var response = new Response<UserDto>();
            try
            {
                await userRepository.CreateWithBasket(user.ToEntity());
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
        public async Task<Response<UserDto>> Read(int id)
        {
            var response = new Response<UserDto>();
            try
            {
                var user = await userRepository.Read(id);
                response.Value = user.ToDto();
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
        public async Task<Response> UpdateWithEntity(UserDto user)
        {
            var response = new Response<UserDto>();
            try
            {
                await userRepository.UpdateWithEntity(user.ToEntity());
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
            var response = new Response<UserDto>();
            try
            {
                await userRepository.Delete(id);
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
        public async Task<Response<DataPage<UserDto>>> GetAll(int start, int? count)
        {
            var response = new Response<DataPage<UserDto>>();
            try
            {
                var data = userRepository.GetAll(start, count);

                List<UserDto> users = new();
                await foreach (var item in data)
                {
                    users.Add(item.ToDto());
                }
                response.Value.Data = users.ToArray();
                response.Value.Start = start;
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
        public async Task<Response<UserDto>> GetByEmailPassword(string email, string password)
        {
            var response = new Response<UserDto>();
            try
            {
                var user = await userRepository.GetByEmailPassword(email, password);
                response.Value = user.ToDto();
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
        public async Task<Response<UserDto>> GetByEmail(string email)
        {
            var response = new Response<UserDto>();
            try
            {
                var user = await userRepository.GetByEmail(email);
                response.Value = user.ToDto();
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
        public async Task<Response<UserDto>> GetByName(string name)
        {
            var response = new Response<UserDto>();
            try
            {
                var user = await userRepository.GetByName(name);
                response.Value = user.ToDto();
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
        public async Task<Response> Update(UserDto user)
        {
            var response = new Response<UserDto>();
            try
            {
                await userRepository.Update(user.ToEntity());
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
    }
}
