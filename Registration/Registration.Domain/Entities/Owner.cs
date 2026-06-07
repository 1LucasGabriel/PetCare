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
        public string Password { get; private set; }
        public string Phone { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public ICollection<Pet> Pets { get; private set; } = new List<Pet>();

        public Owner(string fullName, CPF cpf, Email email, string password, string phone)
        {
            Id = Guid.NewGuid();
            FullName = fullName;
            CPF = cpf;
            Email = email;
            Password = password;
            Phone = phone;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public Owner() { }

        public void Update(Email email, string phone, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("A senha não pode estar vazia.");
            }

            Email = email;
            Phone = phone;
            Password = password;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
