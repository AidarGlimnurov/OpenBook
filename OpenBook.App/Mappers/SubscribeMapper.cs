using OpenBook.Domain.Entity;
using OpenBook.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.App.Mappers
{
    public static class SubscribeMapper
    {
        public static SubscribeDto? ToDto(this Subscribe subscribe)
        {
            if (subscribe == null)
            {
                return null;
            }

            SubscribeDto subscribeDto = new SubscribeDto()
            {
                Id = subscribe.Id,
                Auth = subscribe.Auth?.ToDto(),
                AuthorId = subscribe.AuthorId,
                Sub = subscribe.Sub?.ToDto(),
                SubscriberId = subscribe.SubscriberId,
            };

            return subscribeDto;
        }

        public static Subscribe? ToEntity(this SubscribeDto subscribeDto)
        {
            if (subscribeDto == null)
            {
                return null;
            }

            Subscribe subscribe = new Subscribe()
            {
                Id = subscribeDto.Id,
                Auth = subscribeDto.Auth?.ToEntity(),
                AuthorId = subscribeDto.AuthorId,
                Sub = subscribeDto.Sub?.ToEntity(),
                SubscriberId = subscribeDto.SubscriberId,
            };

            return subscribe;
        }
    }
}
