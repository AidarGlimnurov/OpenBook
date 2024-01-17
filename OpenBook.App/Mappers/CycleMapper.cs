using OpenBook.Domain.Entity;
using OpenBook.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.App.Mappers
{
    public static class CycleMapper
    {
        public static CycleDto? ToDto(this Cycle cycle)
        {
            if (cycle == null)
            {
                return null;
            }

            CycleDto cycleDto = new CycleDto()
            {
                Id = cycle.Id,
                Name = cycle.Name,
            };

            return cycleDto;
        }

        public static Cycle? ToEntity(this CycleDto cycleDto)
        {
            if (cycleDto == null)
            {
                return null;
            }

            Cycle cycle = new Cycle()
            {
                Id = cycleDto.Id,
                Name = cycleDto.Name,
            };

            return cycle;
        }
    }
}
