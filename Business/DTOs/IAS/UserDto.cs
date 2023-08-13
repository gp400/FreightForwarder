using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.IAS
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? MiddleName { get; set; }

        public string LastName { get; set; } = null!;

        public string Mail { get; set; } = null!;

        public string? Picture { get; set; }

        public string? Observations { get; set; }

        public DateTime PasswordExpires { get; set; }

        public List<int> Companies { get; set; } = null!;

        public int UserId { get; set; }
    }
}
