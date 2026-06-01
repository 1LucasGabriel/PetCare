using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Application.DTOs
{
    public class UpdatePetDTO
    {
        public string Name { get; set; }
        public decimal WeightKg { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
