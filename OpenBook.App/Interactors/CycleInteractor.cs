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
    public class CycleInteractor
    {
        private ICycleRepository cycleRepository;
        private IUnitWork unitWork;

        public CycleInteractor(ICycleRepository cycleRepository, IUnitWork unitWork)
        {
            this.cycleRepository = cycleRepository;
            this.unitWork = unitWork;
        }
        public async Task<Response> CreateWithEntity(CycleDto cycle)
        {
            var response = new Response<CycleDto>();
            try
            {
                await cycleRepository.CreateWithEntity(cycle.ToEntity());
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
        public async Task<Response<CycleDto>> Read(int id)
        {
            var response = new Response<CycleDto>();
            try
            {
                var cycle = await cycleRepository.Read(id);
                response.Value = cycle.ToDto();
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
        public async Task<Response> UpdateWithEntity(CycleDto cycle)
        {
            var response = new Response<CycleDto>();
            try
            {
                await cycleRepository.UpdateWithEntity(cycle.ToEntity());
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
            var response = new Response<CycleDto>();
            try
            {
                await cycleRepository.Delete(id);
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
        public async Task<Response<DataPage<CycleDto>>> GetAll(int start, int? count)
        {
            var response = new Response<DataPage<CycleDto>>();
            try
            {
                var data = cycleRepository.GetAll(start, count);

                List<CycleDto> cycle = new();
                await foreach (var item in data)
                {
                    cycle.Add(item.ToDto());
                }
                response.Value.Data = cycle.ToArray();
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
    }
}
