// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using System;

namespace QProtocol.JsonProperties
{
    /// <summary>
    /// This class is used to provide more information on the supported values of a given setting.
    /// </summary>
    [Serializable]
    public class SupportedValue
    {
        /// <summary>
        /// Gets or sets the ID for the supported value which should be used for the <see cref="Setting.Value"/> property.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the setting description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the numerical representation of the supported value.
        /// </summary>
        public double? Numeric { get; set; }

        /// <summary>
        /// Gets or sets the SI Unit symbol of the supported value. 
        /// </summary>
        public string SIUnit { get; set; }
    }
}
