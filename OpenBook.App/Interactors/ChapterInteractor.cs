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
    public class ChapterInteractor
    {
        private IChapterRepository chapterRepository;
        private IUnitWork unitWork;

        public ChapterInteractor(IChapterRepository chapterRepository, IUnitWork unitWork)
        {
            this.chapterRepository = chapterRepository;
            this.unitWork = unitWork;
        }
        public async Task<Response> CreateWithEntity(ChapterDto chapter)
        {
            var response = new Response<ChapterDto>();
            try
            {
                await chapterRepository.CreateWithEntity(chapter.ToEntity());
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
        public async Task<Response<ChapterDto>> Read(int id)
        {
            var response = new Response<ChapterDto>();
            try
            {
                var book = await chapterRepository.Read(id);
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
        public async Task<Response> UpdateWithEntity(ChapterDto chapter)
        {
            var response = new Response<ChapterDto>();
            try
            {
                await chapterRepository.UpdateWithEntity(chapter.ToEntity());
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
            var response = new Response<ChapterDto>();
            try
            {
                await chapterRepository.Delete(id);
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
        public async Task<Response> Published(int chapterId, bool action)
        {
            var response = new Response<ChapterDto>();
            try
            {
                await chapterRepository.Published(chapterId, action);
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
        public async Task<Response<IEnumerable<ChapterDto>>> GetForBook(int bookId, int start, int? count, bool? isPublic)
        {
            var response = new Response<IEnumerable<ChapterDto>>();
            try
            {
                var data = chapterRepository.GetForBook(bookId, start, count, isPublic);

                List<ChapterDto> chapters = new();
                await foreach (var item in data)
                {
                    chapters.Add(item.ToDto());
                }
                response.Value = chapters.ToList();
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
