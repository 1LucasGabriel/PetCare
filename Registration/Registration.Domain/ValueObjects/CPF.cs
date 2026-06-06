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
                throw new Exception("O CPF não pode ser nulo ou vazio.");
            }

            if (newCPF.Length > 11 || newCPF.Length < 11)
            {
                throw new Exception("O CPF deve ter exatamente 11 caracteres.");
            }

            Value = newCPF;
        }

        protected CPF() { }

        public override string ToString() => Value;
    }
}
