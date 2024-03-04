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
    public class BasketInteractor
    {
        private IBasketRepository basketRepository;
        private IUnitWork unitWork;

        public BasketInteractor(IBasketRepository basketRepository, IUnitWork unitWork)
        {
            this.basketRepository = basketRepository;
            this.unitWork = unitWork;
        }
        public async Task<Response> CreateWithEntity(BasketDto basket)
        {
            var response = new Response<BasketDto>();
            try
            {
                await basketRepository.CreateWithEntity(basket.ToEntity());
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
        public async Task<Response<BasketDto>> Read(int id)
        {
            var response = new Response<BasketDto>();
            try
            {
                var basket = await basketRepository.Read(id);
                response.Value = basket.ToDto();
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
        public async Task<Response<BookDto>> GetBook(int userId, int bookId)
        {
            var response = new Response<BookDto>();
            try
            {
                var basket = await basketRepository.GetBook(userId, bookId);
                response.Value = basket.ToDto();
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
        public async Task<Response> UpdateWithEntity(BasketDto basket)
        {
            var response = new Response<BasketDto>();
            try
            {
                await basketRepository.UpdateWithEntity(basket.ToEntity());
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
            var response = new Response<BasketDto>();
            try
            {
                await basketRepository.Delete(id);
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
        public async Task<Response> Create(int userId)
        {
            var response = new Response<BasketDto>();
            try
            {
                await basketRepository.Create(userId);
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
        public async Task<Response> AddBook(int userId, int bookId)
        {
            var response = new Response<BasketDto>();
            try
            {
                await basketRepository.AddBook(userId, bookId);
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
        public async Task<Response> RemoveBook(int userId, int bookId)
        {
            var response = new Response<BasketDto>();
            try
            {
                await basketRepository.RemoveBook(userId, bookId);
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
        public async Task<Response<DataPage<BookDto>>> GetBooks(int userId, int start, int count)
        {
            var response = new Response<DataPage<BookDto>>();
            try
            {
                var data = basketRepository.GetBooks(userId, start, count);

                List<BookDto> books = new();
                await foreach (var item in data)
                {
                    books.Add(item.ToDto());
                }
                response.Value.Data = books.ToArray();
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
