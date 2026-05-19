using Registration.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Domain.Entities
{
    public class Owner
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public CPF CPF { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public ICollection<Pet> Pets { get; private set; } = new List<Pet>();
    }
}
