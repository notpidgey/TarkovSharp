using System;

namespace TarkovSharp
{
    [Serializable]
    
    public class TarkovSharpException : Exception
    {
        public TarkovSharpException() : base()
        {
        }
        
        public TarkovSharpException(string message) : base(message)
        {
        }

        public TarkovSharpException(string format, params object[] args) : base(string.Format(format, args))
        {
        }

        public TarkovSharpException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public TarkovSharpException(string format, Exception innerException, params object[] args) : base(string.Format(format, args), innerException)
        {
        }
    }
}