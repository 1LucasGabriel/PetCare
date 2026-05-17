using Registration.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Domain.Entities
{
    public class Owner
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public CPF CPF { get; set; }
        public Email Email { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
