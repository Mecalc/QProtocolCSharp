// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using System;

namespace QProtocol
{
    /// <summary>
    /// This class can be used to decode the info/ping/ Endpoint request.
    /// </summary>
    [Serializable]
    public class InfoPing
    {
        /// <summary>
        /// Gets and error code from when something went wrong.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Gets a status message.
        /// </summary>
        public string Message { get; set; }
    }
}
