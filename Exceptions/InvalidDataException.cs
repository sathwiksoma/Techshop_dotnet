using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment.Exceptions
{
    internal class InvalidDataException : Exception
    {
        public InvalidDataException() { }

        public InvalidDataException(string message) : base(message) { }
    }
}
