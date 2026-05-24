using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Application.DTOs.Response
{
    public class OwnerResponseDTO
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }

        public OwnerResponseDTO(Guid id, string fullName, string cpf, string email, string phone)
        {
            Id = id;
            FullName = fullName;
            CPF = cpf;
            Email = email;
            Phone = phone;
        }
    }
}
