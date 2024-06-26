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
    public class PostInteractor
    {
        private IPostRepository postRepository;
        private IUnitWork unitWork;

        public PostInteractor(IPostRepository postRepository, IUnitWork unitWork)
        {
            this.postRepository = postRepository;
            this.unitWork = unitWork;
        }
        public async Task<Response> Create(PostDto post)
        {
            var response = new Response<PostDto>();
            try
            {
                await postRepository.Create(post.ToEntity());
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
        public async Task<Response> CreateWithEntity(PostDto post)
        {
            var response = new Response<PostDto>();
            try
            {
                await postRepository.CreateWithEntity(post.ToEntity());
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
        public async Task<Response<PostDto>> Read(int id)
        {
            var response = new Response<PostDto>();
            try
            {
                var post = await postRepository.Read(id);
                response.Value = post.ToDto();
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
        public async Task<Response> UpdateWithEntity(PostDto post)
        {
            var response = new Response<PostDto>();
            try
            {
                await postRepository.UpdateWithEntity(post.ToEntity());
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
            var response = new Response<PostDto>();
            try
            {
                await postRepository.Delete(id);
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
        public async Task<Response<DataPage<PostDto>>> GetAll(int start, int? count)
        {
            var response = new Response<DataPage<PostDto>>();
            try
            {
                var data = postRepository.GetAll(start, count);

                List<PostDto> cycle = new();
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
        public async Task<Response<DataPage<PostDto>>> GetForUser(int userId, int start, int? count)
        {
            var response = new Response<DataPage<PostDto>>();
            try
            {
                var data = postRepository.GetForUser(userId, start, count);

                List<PostDto> cycle = new();
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

        public async Task<Response> AddView(int userId, int chapterId)
        {
            var response = new Response<PostDto>();
            try
            {
                await postRepository.AddView(userId, chapterId);
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
        public async Task<Response> GetUnicViewForChapter(int chapterId)
        {
            var response = new Response<PostDto>();
            try
            {
                var count = await postRepository.GetUnicViewForChapter(chapterId);
                response.Info = count.ToString();
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
        public async Task<Response> GetViewForChapter(int chapterId)
        {
            var response = new Response<PostDto>();
            try
            {
                var count = await postRepository.GetViewForChapter(chapterId);
                response.Info = count.ToString();
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