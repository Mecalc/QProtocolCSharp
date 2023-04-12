// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using QProtocol.Advanced;
using QProtocol.Attributes;
using QProtocol.GenericDefines;
using QProtocol.Interfaces;
using QProtocol.JsonProperties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QProtocol.InternalChannels.XMC23X
{
    [Serializable]
    public class XMC23XCanFdChannel : DataChannelItem
    {
        public XMC23XCanFdChannel(Item itemInfo)
            : base(itemInfo)
        {
        }


        public enum OperationMode
        {
            [RestfulProperties("Disabled")]
            Disabled = 0,

            [RestfulProperties("Listen Only")]
            ListenOnly = 1,

            [RestfulProperties("Participate")]
            Participate = 2,
        }

        public enum ArbitrationBitrate
        {
            [RestfulProperties("50 KHz", 50000, "Hz")]
            _50000 = 0,

            [RestfulProperties("83 KHz", 83000, "Hz")]
            _83000 = 1,

            [RestfulProperties("100 KHz", 100000, "Hz")]
            _100000 = 2,

            [RestfulProperties("125 KHz", 125000, "Hz")]
            _125000 = 3,

            [RestfulProperties("250 KHz", 250000, "Hz")]
            _250000 = 4,

            [RestfulProperties("500 KHz", 500000, "Hz")]
            _500000 = 5,

            [RestfulProperties("660 KHz", 660000, "Hz")]
            _666000 = 6,

            [RestfulProperties("800 KHz", 800000, "Hz")]
            _800000 = 7,

            [RestfulProperties("1 MHz", 1000000, "Hz")]
            _1000000 = 8,
        }

        public enum FastDataBitrate
        {
            [RestfulProperties("500 KHz", 500000, "Hz")]
            _500000 = 0,

            [RestfulProperties("1 MHz", 1000000, "Hz")]
            _1000000 = 1,

            [RestfulProperties("2 MHz", 2000000, "Hz")]
            _2000000 = 2,

            [RestfulProperties("4 MHz", 4000000, "Hz")]
            _4000000 = 3,

            [RestfulProperties("5 MHz", 5000000, "Hz")]
            _5000000 = 4,

            [RestfulProperties("8 MHz", 8000000, "Hz")]
            _8000000 = 5,
        }

        public interface ISettings
        {
        }

        [Serializable]
        public class XMC23XCanFdChannelOperationMode
        {
            [RestfulProperties("Operation Mode")]
            public OperationMode OperationMode { get; set; } = OperationMode.ListenOnly;
        }

        [Serializable]
        public class ListenOnlySettings : ISettings
        {

            [RestfulProperties("Arbitration Bitrate")]
            public ArbitrationBitrate ArbitrationBitrate { get; set; } = ArbitrationBitrate._50000;

            [RestfulProperties("Fast Data Bitrate")]
            public FastDataBitrate FastDataBitrate { get; set; } = FastDataBitrate._500000;
        }

        [Serializable]
        public class ParticipateSettings : ISettings
        {

            [RestfulProperties("Arbitration Bitrate")]
            public ArbitrationBitrate ArbitrationBitrate { get; set; } = ArbitrationBitrate._50000;

            [RestfulProperties("Fast Data Bitrate")]
            public FastDataBitrate FastDataBitrate { get; set; } = FastDataBitrate._500000;

            [RestfulProperties("Send At Fast Bitrate")]
            public GenericDefines.Generic.Status SendAtFastBitrate { get; set; } = GenericDefines.Generic.Status.Disabled;

            [RestfulProperties("Receive Own Messages")]
            public GenericDefines.Generic.Status ReceiveOwnMessages { get; set; } = GenericDefines.Generic.Status.Disabled;
        }

        [Serializable]
        public class SettingsCollection<T>
            where T : ISettings
        {
            public T Settings { get; set; }

            public Data Data { get; set; }
        }


        public List<CanFdTransmitMessage> GetCanFdMessageList()
        {
            return RestInterface.Get<List<CanFdTransmitMessage>>(EndPoints.CanFdMessageList, HttpParameter.ItemId(ItemId));
        }

        public void PutCanFdMessageList(List<CanFdTransmitMessage> transmitMessages)
        {
            RestInterface.Put(EndPoints.CanFdMessageList, transmitMessages, HttpParameter.ItemId(ItemId));
        }

        public void DeleteCanFdMessageList()
        {
            RestInterface.Delete(EndPoints.CanFdMessageList, HttpParameter.ItemId(ItemId));
        }

        public void PutCanFdMessageTransmit(int messageIndex)
        {
            RestInterface.Put(EndPoints.CanFdMessageTransmit, HttpParameter.ItemId(ItemId), HttpParameter.MessageIndex(messageIndex));
        }

        public List<CanFdBusStatus> GetCanFdBusStatusList()
        {
            return RestInterface.Get<List<CanFdBusStatus>>(EndPoints.CanFdBusStatusList, HttpParameter.ItemId(ItemId));
        }

        public void PutItemSettings<T>(SettingsCollection<T> settings)
            where T : ISettings
        {
            var jsonObject = new ItemSettings(this);
            jsonObject.UpdateFromSettings(settings.Settings);
            jsonObject.UpdateFromData(settings.Data);
            base.PutItemSettings(jsonObject);
        }

        public SettingsCollection<T> GetItemSettings<T>()
            where T : ISettings
        {
            var jsonObject = base.GetItemSettings();
            return new SettingsCollection<T>
            {
                Settings = jsonObject.ConvertToSettings<T>(),
                Data = jsonObject.ConvertToData()
            };
        }

        public SettingsCollection<T> GetItemSettingsDefaults<T>()
            where T : ISettings
        {
            var jsonObject = base.GetItemSettingsDefaults();
            return new SettingsCollection<T>
            {
                Settings = jsonObject.ConvertToSettings<T>(),
                Data = jsonObject.ConvertToData()
            };
        }

        public void PutItemOperationMode(OperationMode operationMode)
        {
            var operationModeSettings = new ItemOperationMode(this)
            {
                Settings = Setting.ConvertFrom(new XMC23XCanFdChannelOperationMode() {OperationMode = operationMode}),
            };
            
            base.PutItemOperationMode(operationModeSettings);
        }

        public new OperationMode GetItemOperationMode()
        {
            var jsonObject = base.GetItemOperationMode();
            return Setting.ConvertTo<XMC23XCanFdChannelOperationMode>(jsonObject.Settings).OperationMode;
        }
    }
}
