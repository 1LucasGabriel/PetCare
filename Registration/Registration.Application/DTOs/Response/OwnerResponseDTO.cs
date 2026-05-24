using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Application.DTOs.Response
{
    public class OwnerResponseDTO
    {
        public string FullName { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }

        public OwnerResponseDTO(string fullName, string cpf, string email, string phone)
        {
            FullName = fullName;
            CPF = cpf;
            Email = email;
            Phone = phone;
        }
    }
}
