// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using System;

namespace QProtocol.JsonProperties
{
    /// <summary>
    /// Specify an upper and lower limit constraint for a value.
    /// </summary>
    [Serializable]
    public class ValidationLimits
    {
        /// <summary>
        /// Gets or sets the upper limitation value.
        /// </summary>
        public double Upper { get; set; }

        /// <summary>
        /// Gets or sets the lower limitation value.
        /// </summary>
        public double Lower { get; set; }
    }
}
