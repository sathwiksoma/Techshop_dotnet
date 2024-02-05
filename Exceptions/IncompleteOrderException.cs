using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment.Exceptions
{
    internal class IncompleteOrderException : Exception
    {
        public IncompleteOrderException() { }

        public IncompleteOrderException(string message) : base(message) { }

    }
}
