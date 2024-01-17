using OpenBook.Domain.Entity;
using OpenBook.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.App.Mappers
{
    public static class RoleMapper
    {
        public static RoleDto? ToDto(this Role role)
        {
            if (role == null)
            {
                return null;
            }

            RoleDto roleDto = new RoleDto()
            {
                Id = role.Id,
                Name = role.Name,
            };

            return roleDto;
        }

        public static Role? ToEntity(this RoleDto roleDto)
        {
            if (roleDto == null)
            {
                return null;
            }

            Role role = new Role()
            {
                Id = roleDto.Id,
                Name = roleDto.Name,
            };

            return role;
        }
    }
}
