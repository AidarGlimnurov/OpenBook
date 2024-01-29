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
    public class GenrreInteractor
    {
        private IGenreRepository genreRepository;
        private IUnitWork unitWork;

        public GenrreInteractor(IGenreRepository genreRepository, IUnitWork unitWork)
        {
            this.genreRepository = genreRepository;
            this.unitWork = unitWork;
        }
        public async Task<Response> CreateWithEntity(GenreDto genre)
        {
            var response = new Response<GenreDto>();
            try
            {
                await genreRepository.CreateWithEntity(genre.ToEntity());
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
        public async Task<Response<GenreDto>> Read(int id)
        {
            var response = new Response<GenreDto>();
            try
            {
                var genre = await genreRepository.Read(id);
                response.Value = genre.ToDto();
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
        public async Task<Response> UpdateWithEntity(GenreDto genre)
        {
            var response = new Response<GenreDto>();
            try
            {
                await genreRepository.UpdateWithEntity(genre.ToEntity());
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
            var response = new Response<GenreDto>();
            try
            {
                await genreRepository.Delete(id);
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
        public async Task<Response<DataPage<GenreDto>>> GetAll(int start, int? count)
        {
            var response = new Response<DataPage<GenreDto>>();
            try
            {
                var data = genreRepository.GetAll(start, count);

                List<GenreDto> cycle = new();
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
        public async Task<Response<DataPage<GenreDto>>> GetGenresForBook(int bookId, int start, int? count)
        {
            var response = new Response<DataPage<GenreDto>>();
            try
            {
                var data = genreRepository.GetAll(start, count);

                List<GenreDto> cycle = new();
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
