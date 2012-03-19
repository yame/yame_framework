using System;

namespace Yame.Core
{
    [global::System.Serializable]
    public class InformationException : Exception
    {
        public InformationException() { }
        public InformationException(string message) : base(message) { }
        public InformationException(string format, params object[] args) : base(String.Format(format, args)) { }
        public InformationException(string message, Exception inner) : base(message, inner) { }
        protected InformationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
