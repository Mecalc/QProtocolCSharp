// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using QProtocol.JsonProperties;
using System;
using System.Collections.Generic;

namespace QProtocol
{
    /// <summary>
    /// This class can be used with the /item/operationMode/ endpoint to deserialize the response received and serialize the body sent.
    /// </summary>
    [Serializable]
    public class ItemOperationMode : ItemInfo
    {
        /// <summary>
        /// Gets or sets an array of additional information for this node.
        /// </summary>
        public List<Info> Info { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the settings has been synchronized to the hardware.
        /// </summary>
        public bool SettingsApplied { get; set; }

        /// <summary>
        /// Gets or sets the item settings for the internal cache.
        /// </summary>
        public List<Setting> Settings { get; set; }

        /// <summary>
        /// Creates a new instance of the <see cref="ItemOperationMode"/> class.
        /// </summary>
        public ItemOperationMode()
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ItemOperationMode"/> class.
        /// </summary>
        /// <param name="itemInfo">An instance of the item information which will be copied to this instance.</param>
        public ItemOperationMode(ItemInfo itemInfo)
            : base(itemInfo.ItemId, itemInfo.ItemName, itemInfo.ItemTypeIdentifier, itemInfo.ItemType, itemInfo.ItemTypeIdentifier)
        {
        }
    }
}
