// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using QProtocol.Advanced;
using QProtocol.JsonProperties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QProtocol
{
    /// <summary>
    /// This class can be used with the /item/settings/ endpoint to deserialize the response received and serialize the body sent.
    /// </summary>
    [Serializable]
    public class ItemSettings : ItemInfo
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
        /// Gets or sets a value indicating whether the settings has been synchronized to the hardware.
        /// </summary>
        public bool SettingsApplied { get; set; }

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
        public ItemSettings()
            : base()
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ItemSettings"/> class.
        /// </summary>
        /// <param name="itemInfo">An instance of the item information which will be copied to this instance.</param>
        public ItemSettings(ItemInfo baseInfo)
            : base(baseInfo.ItemId, baseInfo.ItemName, baseInfo.ItemNameIdentifier, baseInfo.ItemType, baseInfo.ItemTypeIdentifier)
        {
        }

        /// <summary>
        /// Boiler plate code for internal functions.
        /// </summary>
        internal ItemSettings(Item baseInfo)
            : base(baseInfo.ItemId, baseInfo.ItemName, baseInfo.ItemNameIdentifier, baseInfo.ItemType, baseInfo.ItemTypeIdentifier)
        {
        }

        /// <summary>
        /// This method can be used to convert the <see cref="Settings"/> property to a QProtocol defined settings class.
        /// </summary>
        /// <typeparam name="T">Type of the QProtocol defined settings class.</typeparam>
        /// <returns>An instance of the QProtocol defined settings class.</returns>
        public T ConvertToSettings<T>()
        {
            return Setting.ConvertTo<T>(this.Settings);
        }

        /// <summary>
        /// This method will update the <see cref="Settings"/> property from an instance of a QProtocol defined settings class.
        /// </summary>
        /// <typeparam name="T">Type of the QProtocol defined settings class.</typeparam>
        /// <param name="definedSettings">An instance of the QProtocol defined settings class.</param>
        public void UpdateFromSettings<T>(T definedSettings)
        {
            this.Settings = Setting.ConvertFrom(definedSettings);
        }

        /// <summary>
        /// This method can be used to convert the <see cref="Data"/> property to an instance of <see cref="QProtocol.Data"/>.
        /// </summary>
        /// <returns>An instance of <see cref="QProtocol.Data"/>.</returns>
        public Data ConvertToData()
        {
            if (Data == null || !Data.Any())
            {
                return null;
            }

            return Setting.ConvertTo<Data>(Data);
        }

        /// <summary>
        /// This method can be used to update the <see cref="Data"/> property from an instance of <see cref="QProtocol.Data"/>.
        /// </summary>
        /// <param name="definedSettings">An instance of <see cref="QProtocol.Data"/>.</param>
        public void UpdateFromData(Data definedSettings)
        {
            if (definedSettings == null)
            {
                this.Data = new List<Setting>();
                return;
            }

            Data = Setting.ConvertFrom(definedSettings);
        }
    }
}
