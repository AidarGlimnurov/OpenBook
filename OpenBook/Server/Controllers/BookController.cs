﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenBook.Adapter.Repository;
using OpenBook.Adapter.Transaction;
using OpenBook.App.Interactors;
using OpenBook.App.Mappers;
using OpenBook.Shared.Dtos;
using OpenBook.Shared.OutputData;
using OpenBook.Shared.SupportData;

namespace OpenBook.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private BookInteractor interactor;
        public BookController(BookInteractor interactor)
        {
            this.interactor = interactor;
        }
        [HttpPost("Create")]
        public async Task<Response> Create([FromBody] BookDto book)
        {
            return await interactor.Create(book);
        }
        [HttpPost("CreateWithEntity")]
        public async Task<Response> CreateWithEntity([FromBody] BookDto book)
        {
            return await interactor.CreateWithEntity(book);
        }
        [HttpGet("Read")]
        public async Task<Response<BookDto>> Read(int id)
        {
            return await interactor.Read(id);
        }
        [HttpGet("GetBook")]
        public async Task<Response<BookDto>> GetBook(int id)
        {
            return await interactor.GetBook(id);
        }
        [HttpPost("UpdateWithEntity")]
        public async Task<Response> UpdateWithEntity([FromBody] BookDto book)
        {
            return await interactor.UpdateWithEntity(book);
        }
        [HttpPost("Update")]
        public async Task<Response> Update([FromBody] BookDto book)
        {
            return await interactor.Update(book);
        }
        [HttpGet("Delete")]
        public async Task<Response> Delete(int id)
        {
            return await interactor.Delete(id);
        }
        [HttpGet("GetBooks")]
        public async Task<Response<DataPage<BookDto>>> GetBooksGetBooks(int start, int? count, bool? isPublic, string? name)
        {
            return await interactor.GetBooks(start, count, isPublic, name);
        }
        [HttpGet("GetBooksForAuthor")]
        public async Task<Response<DataPage<BookDto>>> GetBooksForAuthor(int userId, int start, int? count, bool? isPublic)
        {
            return await interactor.GetBooksForAuthor(userId, start, count, isPublic);
        }
        [HttpGet("Published")]
        public async Task<Response> Published(int bookId, bool action)
        {
            return await interactor.Published(bookId, action);
        }
        [HttpGet("AddGenre")]
        public async Task<Response> AddGenre(int bookId, int genreId)
        {
            return await interactor.AddGenre(bookId, genreId);
        }
        [HttpGet("RemoveGenre")]
        public async Task<Response> RemoveGenre(int bookId, int genreId)
        {
            return await interactor.RemoveGenre(bookId, genreId);
        }
        [HttpGet("GetBooksForCycle")]
        public async Task<Response<DataPage<BookDto>>> GetBooksForCycle(int cycleId, int start, int? count)
        {
            return await interactor.GetBooksForCycle(cycleId, start, count);
        }
        [HttpGet("GetAllBooks")]
        public async Task<Response<DataPage<BookDto>>> GetAllBooks(int start, int? count)
        {
            return await interactor.GetAllBooks(start, count);
        }
        [HttpPost("GetSortBooks")]
        public async Task<Response<DataPage<BookDto>>> GetSortBooks([FromBody] SortData sortData)
        {
            return await interactor.GetSortBooks(sortData, sortData.Start.Value, sortData.Count);
        }
    }
}