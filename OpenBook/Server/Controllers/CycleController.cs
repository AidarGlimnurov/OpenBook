﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenBook.App.Interactors;
using OpenBook.Shared.Dtos;
using OpenBook.Shared.OutputData;

namespace OpenBook.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CycleController : ControllerBase
    {
        private CycleInteractor interactor;
        public CycleController(CycleInteractor interactor)
        {
            this.interactor = interactor;
        }
        [HttpPost("CreateWithEntity")]
        public async Task<Response> CreateWithEntity([FromBody] CycleDto cycle)
        {
            return await interactor.CreateWithEntity(cycle);
        }
        [HttpGet("Read")]
        public async Task<Response<CycleDto>> Read(int id)
        {
            return await interactor.Read(id);
        }
        [HttpPost("UpdateWithEntity")]
        public async Task<Response> UpdateWithEntity([FromBody] CycleDto cycle)
        {
            return await interactor.UpdateWithEntity(cycle);
        }
        [HttpGet("Delete")]
        public async Task<Response> Delete(int id)
        {
            return await interactor.Delete(id);
        }
        [HttpGet("GetAll")]
        public async Task<Response<IEnumerable<CycleDto>>> GetAll(int start, int? count)
        {
            return await interactor.GetAll(start, count);
        }
    }
}