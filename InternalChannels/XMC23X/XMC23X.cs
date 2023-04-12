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
    public class XMC23X : Item
    {
        public XMC23X(Item itemInfo)
            : base(itemInfo)
        {
        }

        public const System.Int32 MaxNumberOfChannels = 63;

        public enum OperationMode
        {
            [RestfulProperties("Disabled")]
            Disabled = 0,

            [RestfulProperties("Enabled")]
            Enabled = 1,
        }

        public enum DevicePresence
        {
            [RestfulProperties("Absent")]
            Absent = 0,

            [RestfulProperties("Present")]
            Present = 1,
        }

        public enum DeviceType
        {
            [RestfulProperties("Invalid")]
            Invalid = 0,

            [RestfulProperties("Config")]
            Config = 1,

            [RestfulProperties("CAN FD")]
            CanFd = 2,

            [RestfulProperties("GPS")]
            Gps = 3,

            [RestfulProperties("Headset PCM Stereo")]
            HeadsetPcmStereo = 4,
        }

        public struct ConfiguredChannelsIDAsUInt32
        {
            public const UInt32 UpperLimit = 4294967295;
            public const UInt32 LowerLimit = 0;
        }

        [Serializable]
        public class ConfiguredChannels
        {
            [RestfulProperties("Channel ID")]
            public UInt32 ID { get; set; }

            [RestfulProperties("Device Type")]
            public DeviceType XMC23XDeviceType { get; set; }

            [RestfulProperties("Device Presence")]
            public DevicePresence DevicePresence { get; set; }
        }

        public interface ISettings
        {
        }

        [Serializable]
        public class XMC23XOperationMode
        {
            [RestfulProperties("Operation Mode")]
            public OperationMode OperationMode { get; set; } = OperationMode.Enabled;
        }

        [Serializable]
        public class EnabledSettings : ISettings
        {

            [RestfulProperties("")]
            public Int32 Reserved { get; set; }
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
                Settings = Setting.ConvertFrom(new XMC23XOperationMode() {OperationMode = operationMode}),
            };
            
            base.PutItemOperationMode(operationModeSettings);
        }

        public new OperationMode GetItemOperationMode()
        {
            var jsonObject = base.GetItemOperationMode();
            return Setting.ConvertTo<XMC23XOperationMode>(jsonObject.Settings).OperationMode;
        }
    }
}
