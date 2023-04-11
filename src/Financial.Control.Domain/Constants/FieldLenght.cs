using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Domain.Constants
{
    public class FieldLenght
    {
        public class UserFieldsLenght
        {
            public const int Name = 2;
            public const int Password = 8;
        }
        public class CardFieldsLenght
        {
            public const int Name = 4;
            public const int CardNumber = 16;
        }
    }
}
