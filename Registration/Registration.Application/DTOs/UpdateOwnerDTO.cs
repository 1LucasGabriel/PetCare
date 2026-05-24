using Registration.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Application.DTOs
{
    public class UpdateOwnerDTO
    {
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
