// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using System;

namespace QProtocol.ErrorHandling
{
    [Serializable]
    public class QProtocolException : Exception
    {
        public StatusCodes StatusCode { get; set; }

        public string StatusMessage { get; set; }

        public QProtocolException()
        {
        }

        public QProtocolException(StatusCodes statusCode)
            : base("QServer Exception: " + statusCode.ToString() + "\n" + Environment.StackTrace)
        {
            StatusCode = statusCode;
        }

        public QProtocolException(StatusCodes statusCode, string message)
            : base($"QServer Exception: {statusCode}\n{message}")
        {
            StatusCode = statusCode;
        }

        public QProtocolException(string message)
            : base(message)
        {
        }

        public QProtocolException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected QProtocolException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
