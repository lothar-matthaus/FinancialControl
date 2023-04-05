using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Domain.Records
{
    public record ProfilePicture
    {
        public string Value { get; set; }

        protected ProfilePicture() { }
        private ProfilePicture(string value)
        {
            Value = value;
        }

        public static ProfilePicture Create(string value) => new ProfilePicture(value);
    }
}
