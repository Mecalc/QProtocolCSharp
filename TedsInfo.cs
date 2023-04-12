// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace QProtocol
{
    /// <summary>
    /// This class can be used to decode the TEDS Endpoint request.
    /// </summary>
    [Serializable]
    public class TedsInfo
    {
        /// <summary>
        /// Gets the Name of the TEDS sensor read.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets a list of byte of the TEDS data.
        /// </summary>
        public List<byte> Value { get; set; }
    }
}
