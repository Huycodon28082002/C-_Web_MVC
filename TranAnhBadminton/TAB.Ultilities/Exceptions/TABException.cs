using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAB.Ultilities.Exceptions
{
    public class TABException : Exception
    {
        public TABException() { }

        public TABException(string message) : base(message) { }

        public TABException(string message, Exception innerException) : base(message, innerException) { }
    }
}
