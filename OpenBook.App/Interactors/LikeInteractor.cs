using OpenBook.App.Data.Transaction;
using OpenBook.App.Mappers;
using OpenBook.App.Storage;
using OpenBook.Shared.Dtos;
using OpenBook.Shared.OutputData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.App.Interactors
{
    public class LikeInteractor
    {
        private ILikeRepository likeRepository;
        private IUserRepository userRepository;
        private IUnitWork unitWork;

        public LikeInteractor(ILikeRepository likeRepository, IUserRepository userRepository, IUnitWork unitWork)
        {
            this.likeRepository = likeRepository;
            this.userRepository = userRepository;
            this.unitWork = unitWork;
        }
        public async Task<Response> Create(LikeDto like)
        {
            var response = new Response<LikeDto>();
            try
            {
                await likeRepository.Create(like.ToEntity());
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
        public async Task<Response<LikeDto>> CheckLike(int userId, int bookId)
        {
            var response = new Response<LikeDto>();
            try
            {
                var book = await likeRepository.CheckLike(userId, bookId);
                response.Value = book.ToDto();
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
        public async Task<Response<DataPage<BookDto>>> GetLikeBooksForUser(int user)
        {
            var response = new Response<DataPage<BookDto>>();
            try
            {
                var data = likeRepository.GetLikeBooksForUser(user);

                List<BookDto> books = new();
                await foreach (var item in data)
                {
                    books.Add(item.ToDto());
                }
                response.Value.Data = books.ToArray();
                response.Value.Start = 0;
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
        public async Task<Response<DataPage<BookDto>>> GetPopularBooks(int start, int? count)
        {
            var response = new Response<DataPage<BookDto>>();
            try
            {
                var data = likeRepository.GetPopularBooks(start, count);

                List<BookDto> books = new();
                await foreach (var item in data)
                {
                    books.Add(item.ToDto());
                }
                response.Value.Data = books.ToArray();
                response.Value.Start = 0;
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
        public async Task<Response<DataPage<LikeDto>>> GetLikesForBook(int bookId, bool isLastTime)
        {
            var response = new Response<DataPage<LikeDto>>();
            try
            {
                var data = likeRepository.GetLikesForBook(bookId, isLastTime);

                List<LikeDto> likes = new();
                await foreach (var item in data)
                {
                    likes.Add(item.ToDto());
                }
                response.Value.Data = likes.ToArray();
                response.Value.Start = 0;
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
        public async Task<Response> Update(LikeDto like)
        {
            var response = new Response<LikeDto>();
            try
            {
                await likeRepository.Update(like.ToEntity());
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
        public async Task<Response> Delete(int likeId)
        {
            var response = new Response<LikeDto>();
            try
            {
                await likeRepository.Delete(likeId);
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
