using System.Runtime.Serialization;

namespace FunctionalTest.Common.Exceptions
{
    [Serializable]
    public class FunctionalTestException : Exception
    {
        public FunctionalTestException() { }
        public FunctionalTestException(string message) : base(message) { }
        public FunctionalTestException(string message, Exception inner) : base(message, inner) { }
        protected FunctionalTestException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
