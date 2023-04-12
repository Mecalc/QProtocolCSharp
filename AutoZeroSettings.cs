// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using QProtocol.JsonProperties;
using System;
using System.Collections.Generic;

namespace QProtocol
{
    /// <summary>
    /// This class can be used with the /autoZero/settings/ endpoint to deserialize the response received and serialize the body sent.
    /// </summary>
    [Serializable]
    public class AutoZeroSettings : ItemInfo
    {
        /// <summary>
        /// Gets or sets the AutoZero settings for a given Item.
        /// </summary>
        public List<Setting> Settings { get; set; }

        public AutoZeroSettings()
            : base()
        {

        }

        /// <summary>
        /// Creates a new instance of the <see cref="ItemSettings"/> class.
        /// </summary>
        /// <param name="itemInfo">An instance of the item information which will be copied to this instance.</param>
        public AutoZeroSettings(ItemInfo baseInfo)
            : base(baseInfo.ItemId, baseInfo.ItemName, baseInfo.ItemTypeIdentifier, baseInfo.ItemType, baseInfo.ItemTypeIdentifier)
        {
        }
    }
}
