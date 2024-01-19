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
    public class BookInteractor
    {
        private IBookRepository bookRepository;
        private IUnitWork unitWork;

        public BookInteractor(IBookRepository bookRepository, IUnitWork unitWork)
        {
            this.bookRepository = bookRepository;
            this.unitWork = unitWork;
        }
        public async Task<Response> CreateWithEntity(BookDto book)
        {
            var response = new Response<BookDto>();
            try
            {
                await bookRepository.CreateWithEntity(book.ToEntity());
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
        public async Task<Response<BookDto>> Read(int id)
        {
            var response = new Response<BookDto>();
            try
            {
                var book = await bookRepository.Read(id);
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
        public async Task<Response> UpdateWithEntity(BookDto book)
        {
            var response = new Response<BookDto>();
            try
            {
                await bookRepository.UpdateWithEntity(book.ToEntity());
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
            var response = new Response<BookDto>();
            try
            {
                await bookRepository.Delete(id);
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
        public async Task<Response<IEnumerable<BookDto>>> GetBooks(int start, int? count)
        {
            var response = new Response<IEnumerable<BookDto>>();
            try
            {
                var data = bookRepository.GetBooks(start, count);

                List<BookDto> books = new();
                await foreach (var item in data)
                {
                    books.Add(item.ToDto());
                }
                response.Value = books.ToList();
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
        public async Task<Response<IEnumerable<BookDto>>> GetBooksForAuthor(int userId, int start, int? count, bool? isPublic)
        {
            var response = new Response<IEnumerable<BookDto>>();
            try
            {
                var data = bookRepository.GetBooksForAuthor(userId, start, count, isPublic);

                List<BookDto> books = new();
                await foreach (var item in data)
                {
                    books.Add(item.ToDto());
                }
                response.Value = books.ToList();
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
        public async Task<Response> Published(int bookId, bool action)
        {
            var response = new Response<BookDto>();
            try
            {
                await bookRepository.Published(bookId, action);
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
        public async Task<Response> AddGenre(int bookId, int genreId)
        {
            var response = new Response<BookDto>();
            try
            {
                await bookRepository.AddGenre(bookId, genreId);
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
        public async Task<Response> RemoveGenre(int bookId, int genreId)
        {
            var response = new Response<BookDto>();
            try
            {
                await bookRepository.RemoveGenre(bookId, genreId);
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
        public async Task<Response<IEnumerable<BookDto>>> GetBooksForCycle(int cycleId, int start, int? count)
        {
            var response = new Response<IEnumerable<BookDto>>();
            try
            {
                var data = bookRepository.GetBooksForCycle(cycleId, start, count);

                List<BookDto> books = new();
                await foreach (var item in data)
                {
                    books.Add(item.ToDto());
                }
                response.Value = books.ToList();
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
