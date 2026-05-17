using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Domain.ValueObjects
{
    public class CPF
    {
        public string Value { get; private set; }

        public CPF(string newCPF)
        {
            if (string.IsNullOrEmpty(newCPF))
            {
                throw new Exception("CPF cannot be null or empty.");
            }

            if (newCPF.Length > 11 || newCPF.Length < 11)
            {
                throw new Exception("CPF must be exactly 11 characters long.");
            }

            Value = newCPF;
        }
    }
}
