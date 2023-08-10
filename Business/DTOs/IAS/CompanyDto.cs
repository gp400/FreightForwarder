﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.IAS
{
    public class CompanyDto
    {
        public int Id { get; set; }

        public string BusinessName { get; set; } = null!;

        public string Rnc { get; set; } = null!;

        public string? Email { get; set; }

        public string? Logo { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public int UserId { get; set; }
    }
}
