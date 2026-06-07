using System;

namespace Appointment.Domain.ValueObjects
{
    public class Password
    {
        public string Value { get; private set; }

        public Password(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A senha não pode ser nula, vazia ou conter apenas espaços.");
            }

            if (value.Length < 6)
            {
                throw new ArgumentException("A senha deve ter no mínimo 6 caracteres.");
            }

            Value = value;
        }

        protected Password() { }

        public override string ToString() => Value;
    }
}
