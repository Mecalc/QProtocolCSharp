// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using QProtocol.GenericDefines;
using QProtocol.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QProtocol.Advanced
{
    /// <summary>
    /// A class takes the <see cref="SystemSettings"/> information and extends the features of it.
    /// By implementing the <see cref="IRestfulInterface"/>, this class will be able to send and receive requests directly from QServer.
    /// </summary>
    [Serializable]
    public class Item : ItemInfo
    {
        public IRestfulInterface RestInterface { get; private set; }

        /// <summary>
        /// Gets or sets a list of child instances hosted by this item.
        /// </summary>
        public List<Item> Children { get; set; }

        /// <summary>
        /// Only to be used for auto generated code.
        /// </summary>
        public Item()
            : base()
        {
        }

        internal Item(Item itemInfo)
            : base(itemInfo.ItemId, itemInfo.ItemName, itemInfo.ItemNameIdentifier, itemInfo.ItemType, itemInfo.ItemTypeIdentifier)
        {
            RestInterface = itemInfo.RestInterface;
            Children = itemInfo.Children;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="Item"/> class.
        /// </summary>
        /// <param name="systemSettings">An instance of the <see cref="SystemSettings"/> obtained by calling <see cref="EndPoints.SystemSettings"/> endpoint.</param>
        /// <param name="restfulInterface">an instance of the <see cref="IRestfulInterface"/> implementation which will extend the <see cref="Item"/> features to include command communication to the QServer instance.</param>
        internal Item(SystemSettings systemSettings, IRestfulInterface restfulInterface)
            : base(systemSettings.ItemId, systemSettings.ItemName, systemSettings.ItemNameIdentifier, systemSettings.ItemType, systemSettings.ItemTypeIdentifier)
        {
            if (systemSettings == null)
            {
                throw new ArgumentNullException("SystemSettings argument may not be null.");
            }

            RestInterface = restfulInterface ?? throw new ArgumentNullException("CommandInterface argument may not be null.");
            Children = systemSettings?.Children;
            RegisterInterfaceForChildren(this, restfulInterface);
        }

        /// <summary>
        /// This method will create a new instance of QProtocol defined <see cref="Item"/> class.
        /// The class can be casted to derived types to expose endpoint methods and settings.
        /// </summary>
        /// <param name="systemSettings">An instance of the <see cref="SystemSettings"/> class.</param>
        /// <param name="restfulInterface">An implemented instance of the <see cref="IRestfulInterface"/> interface.</param>
        /// <returns>An instance of <see cref="Item"/> representing the QServer system as a tree structure.</returns>
        public static Item Create(IRestfulInterface restfulInterface)
        {
            if (restfulInterface == null)
            {
                throw new ArgumentNullException(nameof(restfulInterface));
            }

            var systemSettings = restfulInterface.Get<SystemSettings>(EndPoints.SystemSettings);
            var rootItem = new Item(systemSettings, restfulInterface);
            return CastToDefinedItem(rootItem);
        }

        /// <summary>
        /// This method will create a new instance of QProtocol defined <see cref="Item"/> class and return all members as a flat list.
        /// The class can be casted to derived types to expose endpoint methods and settings.
        /// </summary>
        /// <param name="systemSettings">An instance of the <see cref="SystemSettings"/> class.</param>
        /// <param name="restfulInterface">An implemented instance of the <see cref="IRestfulInterface"/> interface.</param>
        /// <returns>A List of instances of <see cref="Item"/> representing the QServer system.</returns>
        public static List<Item> CreateList(IRestfulInterface restfulInterface)
        {
            if (restfulInterface == null)
            {
                throw new ArgumentNullException(nameof(restfulInterface));
            }

            var rootItem = Create(restfulInterface);
            return rootItem.ConvertToList()
                           .ToList();
        }

        /// <summary>
        /// Endpoint: GET /item/settings/
        /// Usage: Fetch the item settings from the QServer.
        /// </summary>
        /// <returns>An instance of the <see cref="ItemSettings"/> class.</returns>
        public ItemSettings GetItemSettings()
        {
            return RestInterface.Get<ItemSettings>(EndPoints.ItemSettings, HttpParameter.ItemId(ItemId));
        }

        /// <summary>
        /// Endpoint: PUT /item/settings/
        /// Usage: To update the QServer with the provided <see cref="ItemSettings"/>.
        /// </summary>
        /// <param name="itemSettings">An instance of the <see cref="ItemSettings"/> class.</param>
        public void PutItemSettings(ItemSettings itemSettings)
        {
            RestInterface.Put(EndPoints.ItemSettings, itemSettings, HttpParameter.ItemId(ItemId));
        }

        /// <summary>
        /// Endpoint: GET /item/settings/defaults/
        /// Usage: Fetch the default item settings from the QServer.
        /// </summary>
        /// <returns>An instance of the <see cref="ItemSettings"/> class with the default values.</returns>
        public ItemSettings GetItemSettingsDefaults()
        {
            return RestInterface.Get<ItemSettings>(EndPoints.ItemSettingsDefaults, HttpParameter.ItemId(ItemId));
        }

        /// <summary>
        /// Endpoint: GET /item/operationMode/
        /// Usage: Fetch the current operation mode from QServer.
        /// </summary>
        /// <returns>An instance of the <see cref="ItemOperationMode"/> class.</returns>
        public ItemOperationMode GetItemOperationMode()
        {
            return RestInterface.Get<ItemOperationMode>(EndPoints.ItemOperationMode, HttpParameter.ItemId(ItemId));
        }

        /// <summary>
        /// Endpoint: PUT /item/operationMode/
        /// Usage: To update the QServer with a new operation mode for this item.
        /// </summary>
        /// <param name="operationMode">An instance of the <see cref="ItemOperationMode"/> class.</param>
        public void PutItemOperationMode(ItemOperationMode operationMode)
        {
            RestInterface.Put(EndPoints.ItemOperationMode, operationMode, HttpParameter.ItemId(ItemId));
        }

        internal void RegisterInterfaceForChildren(Item itemInfo, IRestfulInterface commandInterfaceReference)
        {
            itemInfo.RestInterface = commandInterfaceReference;
            foreach (var child in itemInfo.Children)
            {
                RegisterInterfaceForChildren(child, commandInterfaceReference);
            }
        }

        private IEnumerable<Item> ConvertToList()
        {
            var nodes = new Stack<Item>();
            nodes.Push(this);

            while (nodes.Count > 0)
            {
                var node = nodes.Pop();
                yield return node;

                for (int nodeIndex = node.Children.Count - 1; nodeIndex >= 0; nodeIndex--)
                {
                    nodes.Push(node.Children[nodeIndex]);
                }
            }
        }

        private static Item CastToDefinedItem(Item itemInfo)
        {
            switch ((Types.ItemType)itemInfo.ItemTypeIdentifier)
            {
                case Types.ItemType.Controller:
                    itemInfo = new Controllers.Controller(itemInfo);
                    break;

                case Types.ItemType.Module:
                    itemInfo = CastToModule(itemInfo);
                    break;

                case Types.ItemType.Channel:
                    itemInfo = CastToChannel(itemInfo);
                    break;

                case Types.ItemType.ExternalModule:
                case Types.ItemType.SignalConditioner:
                case Types.ItemType.Uninitialized:
                    break;

                default:
                    throw new NotImplementedException($"Item Type {itemInfo.ItemType} ({itemInfo.ItemTypeIdentifier}) is not supported.");
            }

            for (int childIndex = 0; childIndex < itemInfo.Children.Count; childIndex++)
            {
                itemInfo.Children[childIndex] = CastToDefinedItem(itemInfo.Children[childIndex]);
            }

            return itemInfo;
        }

        private static Item CastToModule(Item itemInfo)
        {
            switch ((Types.ModuleType)itemInfo.ItemNameIdentifier)
            {
                case Types.ModuleType.ICP4211:
                    return new InternalModules.ICP.ICP4211Module(itemInfo);

                case Types.ModuleType.ICP42S11:
                    return new InternalModules.ICP.ICP42S11Module(itemInfo);

                case Types.ModuleType.ICS421:
                    return new InternalModules.ICS.ICS421Module(itemInfo);

                case Types.ModuleType.ICS42L5:
                    return new InternalModules.ICS.ICS42L5Module(itemInfo);

                case Types.ModuleType.ICS425:
                    return new InternalModules.ICS.ICS425Module(itemInfo);

                case Types.ModuleType.ICT426:
                    return new InternalModules.ICT.ICT426Module(itemInfo);

                case Types.ModuleType.ICT42S6:
                    return new InternalModules.ICT.ICT42S6Module(itemInfo);

                case Types.ModuleType.TAC221:
                    return new InternalModules.TAC.TAC221Module(itemInfo);

                case Types.ModuleType.DCH42S2:
                    return new InternalModules.DCH.DCH42S2Module(itemInfo);

                case Types.ModuleType.MIC42X7:
                    return new InternalModules.MIC.MIC42X7Module(itemInfo);

                case Types.ModuleType.CAN42S2:
                    return new InternalModules.CAN.CAN42S2Module(itemInfo);

                case Types.ModuleType.ALO42S4:
                    return new InternalModules.ALO.ALO42S4Module(itemInfo);

                case Types.ModuleType.WSB42X2:
                    return new InternalModules.WSB.WSB42X2Module(itemInfo);

                case Types.ModuleType.THM427:
                    return new InternalModules.THM.THM427Module(itemInfo);

                case Types.ModuleType.SCC42T5:
                    return new InternalModules.SCC.SCC42T5Module(itemInfo);

                case Types.ModuleType.CHS42X4:
                    return new InternalModules.CHS.CHS42X4Module(itemInfo);

                case Types.ModuleType.XMC237:
                    return new InternalChannels.XMC237.XMC237Module(itemInfo);

                case Types.ModuleType.XMC100:
                    return new InternalChannels.XMC1XX.XMC100Module(itemInfo);

                case Types.ModuleType.ALI42X1:
                    return new InternalModules.ALI.ALI42X1Module(itemInfo);

                case Types.ModuleType.ALI42X2:
                    return new InternalModules.ALI.ALI42X2Module(itemInfo);
					
                case Types.ModuleType.UTM42T0:
                    return new InternalModules.UTM.UTM42T0Module(itemInfo);


                default:
                    return itemInfo;
            }
        }

        private static Item CastToChannel(Item itemInfo)
        {
            switch ((Types.ChannelType)itemInfo.ItemNameIdentifier)
            {
                case Types.ChannelType.CAN42S2:
                    return new InternalModules.CAN.CAN42S2Channel(itemInfo);

                case Types.ChannelType.XMC237Icp:
                    return new InternalChannels.XMC237.XMC237IcpChannel(itemInfo);

                case Types.ChannelType.XMC237CanFd:
                    return new InternalChannels.XMC237.XMC237CanFdChannel(itemInfo);

                case Types.ChannelType.ICP4211:
                    return new InternalModules.ICP.ICP4211Channel(itemInfo);

                case Types.ChannelType.ICP42S11:
                    return new InternalModules.ICP.ICP42S11Channel(itemInfo);

                case Types.ChannelType.ICS421:
                    return new InternalModules.ICS.ICS421Channel(itemInfo);

                case Types.ChannelType.ICS425:
                    return new InternalModules.ICS.ICS425Channel(itemInfo);

                case Types.ChannelType.ICS42L5:
                    return new InternalModules.ICS.ICS42L5Channel(itemInfo);

                case Types.ChannelType.ICT42S6Tacho:
                    return new InternalModules.ICT.ICT42S6TachoChannel(itemInfo);

                case Types.ChannelType.ICT426Tacho:
                    return new InternalModules.ICT.ICT426TachoChannel(itemInfo);

                case Types.ChannelType.ICT42S6Scope:
                    return new InternalModules.ICT.ICT42S6ScopeChannel(itemInfo);

                case Types.ChannelType.ICT426Scope:
                    return new InternalModules.ICT.ICT426ScopeChannel(itemInfo);

                case Types.ChannelType.ICT42S6Icp:
                    return new InternalModules.ICT.ICT42S6IcpChannel(itemInfo);

                case Types.ChannelType.ICT426Icp:
                    return new InternalModules.ICT.ICT426IcpChannel(itemInfo);

                case Types.ChannelType.TAC221Tacho:
                    return new InternalModules.TAC.TAC221TachoChannel(itemInfo);

                case Types.ChannelType.TAC221Scope:
                    return new InternalModules.TAC.TAC221ScopeChannel(itemInfo);

                case Types.ChannelType.ALO42S4:
                    return new InternalModules.ALO.ALO42S4Channel(itemInfo);

                case Types.ChannelType.WSB42X2:
                    return new InternalModules.WSB.WSB42X2Channel(itemInfo);

                case Types.ChannelType.CHS42X4:
                    return new InternalModules.CHS.CHS42X4Channel(itemInfo);

                case Types.ChannelType.DCH42S2:
                    return new InternalModules.DCH.DCH42S2Channel(itemInfo);

                case Types.ChannelType.THM427:
                    return new InternalModules.THM.THM427Channel(itemInfo);

                case Types.ChannelType.MIC42X7:
                    return new InternalModules.MIC.MIC42X7Channel(itemInfo);

                case Types.ChannelType.SCC42T5:
                    return new InternalModules.SCC.SCC42T5Channel(itemInfo);

                case Types.ChannelType.ALI42X1:
                    return new InternalModules.ALI.ALI42X1Channel(itemInfo);

                case Types.ChannelType.ALI42X2:
                    return new InternalModules.ALI.ALI42X2Channel(itemInfo);
					
                case Types.ChannelType.UTM42T0:
                    return new InternalModules.UTM.UTM42T0Channel(itemInfo);

                default:
                    return itemInfo;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                RestInterface?.Dispose();
            }

            ItemId = 0;
            ItemName = null;
            ItemNameIdentifier = 0;
            ItemType = null;
            ItemTypeIdentifier = 0;
            Children = null;
            RestInterface = null;
        }

        ~Item()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }
    }
}
