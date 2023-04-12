// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using System;

namespace QProtocol.JsonProperties
{
    /// <summary>
    /// This class is used to provide more information on a given Item.
    /// </summary>
    [Serializable]
    public class Info
    {
        /// <summary>
        /// Gets or sets the Info field name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the actual info value.
        /// </summary>
        public string Value { get; set; }
    }
}
