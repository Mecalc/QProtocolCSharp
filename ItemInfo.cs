// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using System;

namespace QProtocol
{
    /// <summary>
    /// This class provides the basic information for most Item classes.
    /// It can also be used with the /item/list/ endpoint to deserialize the response received to a List<ItemInfo>.
    /// </summary>
    [Serializable]
    public class ItemInfo
    {
        /// <summary>
        /// Gets or sets the Item ID number for this node.
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// Gets or sets the Item's generic Name.
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// Gets or sets the Item's name identifier.
        /// </summary>
        public int ItemNameIdentifier { get; set; }

        /// <summary>
        /// Gets or sets the item type.
        /// </summary>
        public string ItemType { get; set; }

        /// <summary>
        /// Gets or sets the Item's type identifier.
        /// </summary>
        public int ItemTypeIdentifier { get; set; }

        /// <summary>
        /// Creates a new instance of the <see cref="ItemInfo"/> class.
        /// </summary>
        public ItemInfo()
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ItemInfo"/> class.
        /// </summary>
        /// <param name="itemId">The Item unique ID.</param>
        /// <param name="itemName">The Item Name.</param>
        /// <param name="itemNameIdentifier">The Item Name's unique ID.</param>
        /// <param name="itemType">The Item's Type.</param>
        /// <param name="itemTypeIdentifier">The Item Type unique ID.</param>
        public ItemInfo(int itemId, string itemName, int itemNameIdentifier, string itemType, int itemTypeIdentifier)
        {
            ItemId = itemId;
            ItemName = itemName;
            ItemNameIdentifier = itemNameIdentifier;
            ItemType = itemType;
            ItemTypeIdentifier = itemTypeIdentifier;
        }
    }
}
