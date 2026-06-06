using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment.Domain.ValueObjects
{
    public class Email
    {
        public string Value { get; private set; }

        public Email(string newEmail)
        {
            if (string.IsNullOrEmpty(newEmail) || !newEmail.Contains("@"))
            {
                throw new Exception("E-mail inválido.");
            }

            Value = newEmail;
        }

        protected Email() { }

        public override string ToString() => Value;
    }
}
