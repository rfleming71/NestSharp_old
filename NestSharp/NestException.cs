namespace NestSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Common base exception for Nest exceptions
    /// </summary>
    public class NestException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NestException" /> class.
        /// </summary>
        public NestException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NestException" /> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public NestException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NestException" /> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception</param>
        public NestException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
