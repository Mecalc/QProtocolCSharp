// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using System;

namespace QProtocol.Attributes
{
    /// <summary>
    /// An attribute which will create QAPI members.
    /// </summary>
    public class RestfulPropertiesAttribute : Attribute
    {
        public string Description { get; private set; }

        public double? Numeric { get; set; }

        public string SIUnit { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="RestfulPropertiesAttribute"/> class.
        /// </summary>
        /// <param name="description">Specify the description which will be used in the JSON settings struct.</param>
        /// <param name="numeric">Specify a optional numeric value to be used in the JSON settings struct.</param>
        /// <param name="unit">Specify a optional SIUnit description to be used in the JSON settings struct.</param>
        public RestfulPropertiesAttribute(string description, double numeric, string unit)
        {
            Description = description;
            Numeric = numeric;
            SIUnit = unit;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RestfulPropertiesAttribute"/> class.
        /// </summary>
        /// <param name="description">Specify the name which will be used in the JSON settings struct.</param>
        /// <param name="numeric">Specify a optional numeric value to be used in the JSON settings struct.</param>
        public RestfulPropertiesAttribute(string description, double numeric)
        {
            Description = description;
            Numeric = numeric;
            SIUnit = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RestfulPropertiesAttribute"/> class.
        /// </summary>
        /// <param name="description">Specify the name which will be used in the JSON settings struct.</param>
        public RestfulPropertiesAttribute(string description)
        {
            Description = description;
            Numeric = null;
            SIUnit = null;
        }
    }
}
