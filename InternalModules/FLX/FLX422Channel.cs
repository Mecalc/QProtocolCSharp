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

namespace QProtocol.InternalModules.FLX
{
    [Serializable]
    public class FLX422Channel : DataChannelItem
    {
        public FLX422Channel(Item itemInfo)
            : base(itemInfo)
        {
        }


        public enum OperationMode
        {
            [RestfulProperties("Disabled")]
            Disabled = 0,

            [RestfulProperties("Enabled")]
            Enabled = 1,
        }

        public struct SettingsDelayCompensationAsByte
        {
            public const Byte UpperLimit = 200;
            public const Byte LowerLimit = 0;
        }

        public struct SettingsMacroInitialOffsetAsByte
        {
            public const Byte UpperLimit = 68;
            public const Byte LowerLimit = 2;
        }

        public struct SettingsMicroInitialOffsetAsByte
        {
            public const Byte UpperLimit = 239;
            public const Byte LowerLimit = 0;
        }

        public interface ISettings
        {
        }

        [Serializable]
        public class FLX422ChannelOperationMode
        {
            [RestfulProperties("Operation Mode")]
            public OperationMode OperationMode { get; set; } = OperationMode.Disabled;
        }

        [Serializable]
        public class EnabledSettings : ISettings
        {

            [RestfulProperties("Fifo Filter Parameters")]
            public GenericDefines.FLXChannel.FifoFilterParameters FifoFilterParameters { get; set; }

            [RestfulProperties("Transmit Buffer Setup")]
            public GenericDefines.FLXChannel.TransmitBuffer TransmitBuffer { get; set; }

            [RestfulProperties("Delay Compensation")]
            public Byte DelayCompensation { get; set; } = 0;

            [RestfulProperties("Macro Initial Offset")]
            public Byte MacroInitialOffset { get; set; } = 2;

            [RestfulProperties("Micro Initial Offset")]
            public Byte MicroInitialOffset { get; set; } = 0;
        }

        [Serializable]
        public class SettingsCollection<T>
            where T : ISettings
        {
            public T Settings { get; set; }

            public Data Data { get; set; }
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
                Settings = Setting.ConvertFrom(new FLX422ChannelOperationMode() {OperationMode = operationMode}),
            };
            
            base.PutItemOperationMode(operationModeSettings);
        }

        public new OperationMode GetItemOperationMode()
        {
            var jsonObject = base.GetItemOperationMode();
            return Setting.ConvertTo<FLX422ChannelOperationMode>(jsonObject.Settings).OperationMode;
        }

        public void FlxTransmitMessage(FLXChannel.TransmitMessage message)
        {
            RestInterface.Put(EndPoints.FlexRayTransmit, message, HttpParameter.ItemId(ItemId));
        }

        public void FlxRequestStatus(FLXChannel.StatusRequestType requestType)
        {
            RestInterface.Put(EndPoints.FlexRayStatus, new FLXChannel.StatusRequestTypeSettings {StatusRequestType = requestType}, HttpParameter.ItemId(ItemId));
        }
    }
}
