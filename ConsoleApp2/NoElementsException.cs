using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    [Serializable]
    class NoElementsException : ApplicationException
    {
        public NoElementsException() : base("No elements here!") { }
        public NoElementsException(string message) : base(message) { }
        public NoElementsException(string message, Exception inner) : base(message, inner) { }
        protected NoElementsException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
