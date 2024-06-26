﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenBook.Adapter.Repository;
using OpenBook.App.Interactors;
using OpenBook.Shared.Dtos;
using OpenBook.Shared.OutputData;

namespace OpenBook.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private GenrreInteractor interactor;
        public GenreController(GenrreInteractor interactor)
        {
            this.interactor = interactor;
        }
        [HttpPost("CreateWithEntity")]
        public async Task<Response> CreateWithEntity([FromBody] GenreDto genre)
        {
            return await interactor.CreateWithEntity(genre);
        }
        [HttpGet("Read")]
        public async Task<Response<GenreDto>> Read(int id)
        {
            return await interactor.Read(id);
        }
        [HttpPost("UpdateWithEntity")]
        public async Task<Response> UpdateWithEntity([FromBody] GenreDto genre)
        {
            return await interactor.UpdateWithEntity(genre);
        }
        [HttpGet("Delete")]
        public async Task<Response> Delete(int id)
        {
            return await interactor.Delete(id);
        }
        [HttpGet("GetAll")]
        public async Task<Response<DataPage<GenreDto>>> GetAll(int start, int? count)
        {
            return await interactor.GetAll(start, count);
        }
        [HttpGet("GetGenresForBook")]
        public async Task<Response<DataPage<GenreDto>>> GetGenresForBook(int bookId, int start, int? count)
        {
            return await interactor.GetGenresForBook(bookId, start, count);
        }
    }
}
