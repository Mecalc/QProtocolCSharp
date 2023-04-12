// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace QProtocol.JsonProperties.Properties
{
    /// <summary>
    /// This class is used to for the socket configuration settings.
    /// </summary>
    [Serializable]
    public class SocketInfo
    {
        /// <summary>
        /// Gets a list of IP Addresses available to connect to.
        /// </summary>
        public List<string> IpAddresses { get; set; }

        /// <summary>
        /// Gets a port to be used for the connection.
        /// </summary>
        public int Port { get; set; }
    }
}