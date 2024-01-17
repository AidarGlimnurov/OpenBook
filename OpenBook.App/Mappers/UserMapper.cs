using OpenBook.Domain.Entity;
using OpenBook.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.App.Mappers
{
    public static class UserMapper
    {
        public static UserDto? ToDto(this User user)
        {
            if (user == null)
            {
                return null;
            }

            UserDto userDto = new UserDto()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                Name = user.Name,
                IsVerified = user.IsVerified,
                RoleId = user.RoleId,
                Role = user.Role?.ToDto(),
            };

            return userDto;
        }

        public static User? ToEntity(this UserDto userDto)
        {
            if (userDto == null)
            {
                return null;
            }

            User user = new User()
            {
                Id = userDto.Id,
                Email = userDto.Email,
                Password = userDto.Password,
                Name = userDto.Name,
                IsVerified = userDto.IsVerified,
                RoleId = userDto.RoleId,
                Role = userDto.Role?.ToEntity(),
            };

            return user;
        }
    }
}
