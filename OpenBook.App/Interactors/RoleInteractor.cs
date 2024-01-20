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
    public class RoleInteractor
    {
        private IRoleRepository roleRepository;
        private IUnitWork unitWork;

        public RoleInteractor(IRoleRepository roleRepository, IUnitWork unitWork)
        {
            this.roleRepository = roleRepository;
            this.unitWork = unitWork;
        }
        public async Task<Response> CreateWithEntity(RoleDto role)
        {
            var response = new Response<RoleDto>();
            try
            {
                await roleRepository.CreateWithEntity(role.ToEntity());
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
        public async Task<Response<RoleDto>> Read(int id)
        {
            var response = new Response<RoleDto>();
            try
            {
                var role = await roleRepository.Read(id);
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
        public async Task<Response> UpdateWithEntity(RoleDto role)
        {
            var response = new Response<RoleDto>();
            try
            {
                await roleRepository.UpdateWithEntity(role.ToEntity());
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
            var response = new Response<RoleDto>();
            try
            {
                await roleRepository.Delete(id);
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
        public async Task<Response<IEnumerable<RoleDto>>> GetAll(int start, int? count)
        {
            var response = new Response<IEnumerable<RoleDto>>();
            try
            {
                var data = roleRepository.GetAll(start, count);

                List<RoleDto> roles = new();
                await foreach (var item in data)
                {
                    roles.Add(item.ToDto());
                }
                response.Value = roles.ToList();
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
