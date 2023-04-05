using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Domain.Records
{
    public record Email
    {
        public string Value { get; set; }

        protected Email() { }
        private Email(string value)
        {
            Value = value;
        }
        public static Email Create(string value) => new Email(value);
    }
}
