// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace QProtocol
{
    /// <summary>
    /// This class can be used with the /dataStream/setup/ endpoint to deserialize the response received.
    /// </summary>
    [Serializable]
    public class DataStreamSetup
    {
        /// <summary>
        /// Gets a list of available IP Addresses to connect to.
        /// </summary>
        public List<string> IPAddresses { get; set; }

        /// <summary>
        /// Gets the TCP socket port.
        /// </summary>
        public int TCPPort { get; set; }

        /// <summary>
        /// Gets the Web Socket port.
        /// </summary>
        public int WebSocketPort { get; set; }
    }
}
