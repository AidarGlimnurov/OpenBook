﻿using OpenBook.App.Data.Transaction;
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
        private IUnitWork unitWork;

        public UserInteractor(IUserRepository userRepository, IUnitWork unitWork)
        {
            this.userRepository = userRepository;
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
        public async Task<Response<IEnumerable<UserDto>>> GetAll(int start, int? count)
        {
            var response = new Response<IEnumerable<UserDto>>();
            try
            {
                var data = userRepository.GetAll(start, count);

                List<UserDto> users = new();
                await foreach (var item in data)
                {
                    users.Add(item.ToDto());
                }
                response.Value = users.ToList();
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
    }
}