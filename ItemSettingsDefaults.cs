// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using QProtocol.JsonProperties;
using System;
using System.Collections.Generic;

namespace QProtocol
{
    /// <summary>
    /// This class can be used with the /item/settings/defaults/ endpoint to deserialize the response received.
    /// </summary>
    [Serializable]
    public class ItemSettingsDefaults : ItemInfo
    {
        /// <summary>
        /// Gets or sets an array of additional information for this node.
        /// </summary>
        public List<Info> Info { get; set; }

        /// <summary>
        /// Gets or sets an string representing the current mode of operation.
        /// </summary>
        public SupportedValue OperationMode { get; set; }

        /// <summary>
        /// Gets or sets the item settings for the internal cache.
        /// </summary>
        public List<Setting> Settings { get; set; }

        /// <summary>
        /// Gets or sets a value controlling the data states. 
        /// </summary>
        public List<Setting> Data { get; set; }

        /// <summary>
        /// Creates a new instance of the <see cref="ItemSettings"/> class.
        /// </summary>
        public ItemSettingsDefaults()
            : base()
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ItemSettings"/> class.
        /// </summary>
        /// <param name="itemInfo">An instance of the item information which will be copied to this instance.</param>
        public ItemSettingsDefaults(ItemInfo baseInfo)
            : base(baseInfo.ItemId, baseInfo.ItemName, baseInfo.ItemTypeIdentifier, baseInfo.ItemType, baseInfo.ItemTypeIdentifier)
        {
        }

        /// <summary>
        /// This class can be used to convert the deserialized <see cref="Settings"/> property to a QProtocol defined Settings class.
        /// </summary>
        /// <typeparam name="T">Type of the QProtocol defined setting class</typeparam>
        /// <returns>Instance of the QProtocol defined setting class</returns>
        public T GetSettings<T>()
        {
            return Setting.ConvertTo<T>(Settings);
        }
    }
}
