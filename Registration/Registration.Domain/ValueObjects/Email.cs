using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Domain.ValueObjects
{
    public class Email
    {
        public string Value { get; private set; }

        public Email(string newEmail)
        {
            if (string.IsNullOrEmpty(newEmail) || !newEmail.Contains("@"))
            {
                throw new Exception("Email invalid");
            }

            Value = newEmail;
        }
    }
}
