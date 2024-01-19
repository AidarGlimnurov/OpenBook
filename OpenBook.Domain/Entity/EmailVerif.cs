﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.Domain.Entity
{
    public class EmailVerif
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public bool IsAcivate { get; set; } = false;
        public DateTime CreatAt { get; set; } = DateTime.Now;

        public object ToEntity()
        {
            throw new NotImplementedException();
        }
    }
}
