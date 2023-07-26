// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using QProtocol.Advanced;
using System;
using System.Collections.Generic;

namespace QProtocol
{
    /// <summary>
    /// This class can be used with the /system/settings/ endpoint to deserialize the response received.
    /// </summary>
    [Serializable]
    public class SystemSettings : ItemSettings
    {
        /// <summary>
        /// Gets or sets a list of child instances hosted by this item.
        /// </summary>
        public List<Item> Children { get; set; }

        /// <summary>
        /// Creates a new instance of the <see cref="SystemSettings"/> class.
        /// </summary>
        public SystemSettings()
            : base()
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="SystemSettings"/> class.
        /// </summary>
        /// <param name="itemInfo">An instance of the item information which will be copied to this instance.</param>
        public SystemSettings(ItemInfo itemInfo)
            : base(itemInfo)
        {
        }
    }
}
