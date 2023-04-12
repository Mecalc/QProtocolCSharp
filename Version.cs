// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using System;

namespace QProtocol
{
    /// <summary>
    /// This class can be used to decode the Version Endpoint request.
    /// </summary>
    [Serializable]
    public class VersionInfo
    {
        /// <summary>
        /// Gets the version string of the QServer
        /// </summary>
        public string Version { get; set; }
    }
}
