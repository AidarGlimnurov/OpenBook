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
    public class ReviewInteractor
    {
        private IReviewRepository reviewRepository;
        private IUnitWork unitWork;

        public ReviewInteractor(IReviewRepository reviewRepository, IUnitWork unitWork)
        {
            this.reviewRepository = reviewRepository;
            this.unitWork = unitWork;
        }
        public async Task<Response> Create(ReviewDto review)
        {
            var response = new Response<ReviewDto>();
            try
            {
                await reviewRepository.Create(review.ToEntity());
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
        public async Task<Response> CreateWithEntity(ReviewDto review)
        {
            var response = new Response<ReviewDto>();
            try
            {
                await reviewRepository.CreateWithEntity(review.ToEntity());
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
        public async Task<Response<ReviewDto>> Read(int id)
        {
            var response = new Response<ReviewDto>();
            try
            {
                var review = await reviewRepository.Read(id);
                response.Value = review.ToDto();
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
        public async Task<Response<ReviewDto>> GetForUserBook(int bookId, int userId)
        {
            var response = new Response<ReviewDto>();
            try
            {
                var review = await reviewRepository.GetForUserBook(bookId, userId);
                response.Value = review.ToDto();
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
        public async Task<Response> UpdateWithEntity(ReviewDto review)
        {
            var response = new Response<ReviewDto>();
            try
            {
                review.IsEdited = true;
                await reviewRepository.UpdateWithEntity(review.ToEntity());
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
        public async Task<Response> Update(ReviewDto review)
        {
            var response = new Response<ReviewDto>();
            try
            {
                review.IsEdited = true;
                await reviewRepository.Update(review.ToEntity());
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
            var response = new Response<ReviewDto>();
            try
            {
                await reviewRepository.Delete(id);
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
        public async Task<Response<DataPage<ReviewDto>>> GetForUser(int userId, int start, int? count)
        {
            var response = new Response<DataPage<ReviewDto>>();
            try
            {
                var data = reviewRepository.GetForUser(userId, start, count);

                List<ReviewDto> cycle = new();
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
        public async Task<Response<DataPage<ReviewDto>>> GetForBook(int bookId, int start, int? count)
        {
            var response = new Response<DataPage<ReviewDto>>();
            try
            {
                var data = reviewRepository.GetForBook(bookId, start, count);

                List<ReviewDto> cycle = new();
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