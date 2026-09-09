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

namespace QProtocol.InternalModules.GPS
{
    [Serializable]
    public class GPS450Channel : DataChannelItem
    {
        public GPS450Channel(Item itemInfo)
            : base(itemInfo)
        {
        }

        public const System.Int32 MaximumNumberOfActiveMessages = 20;

        public enum OperationMode
        {
            [RestfulProperties("Disabled")]
            Disabled = 0,

            [RestfulProperties("Enabled")]
            Enabled = 1,
        }

        public enum MessageRate
        {
            [RestfulProperties("1 Hz", 1, "Hz")]
            _1Hz = 0,

            [RestfulProperties("4 Hz", 4, "Hz")]
            _4Hz = 1,
        }

        public enum Platform
        {
            [RestfulProperties("Stationary")]
            Stationary = 0,

            [RestfulProperties("Pedestrian")]
            Pedestrian = 1,

            [RestfulProperties("Automotive")]
            Automotive = 2,
        }

        public enum AcquisitionMode
        {
            [RestfulProperties("Auto")]
            Auto = 0,

            [RestfulProperties("Normal")]
            Normal = 1,

            [RestfulProperties("Fast")]
            Fast = 2,

            [RestfulProperties("High Sensitivity")]
            HighSensitivity = 3,
        }

        public interface ISettings
        {
        }

        [Serializable]
        public class GPS450ChannelOperationMode
        {
            [RestfulProperties("Operation Mode")]
            public OperationMode OperationMode { get; set; } = OperationMode.Enabled;
        }

        [Serializable]
        public class EnabledSettings : ISettings
        {

            [RestfulProperties("Message Rate")]
            public MessageRate MessageRate { get; set; } = MessageRate._1Hz;

            [RestfulProperties("Platform")]
            public Platform Platform { get; set; } = Platform.Stationary;

            [RestfulProperties("Acquisition Mode")]
            public AcquisitionMode AcquisitionMode { get; set; } = AcquisitionMode.Auto;
        }

        [Serializable]
        public class SettingsCollection<T>
            where T : ISettings
        {
            public T Settings { get; set; }

            public Data Data { get; set; }
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

        public new OperationMode GetItemOperationMode()
        {
            var jsonObject = base.GetItemOperationMode();
            return Setting.ConvertTo<GPS450ChannelOperationMode>(jsonObject.Settings).OperationMode;
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

        public void PutItemOperationMode(OperationMode operationMode)
        {
            var operationModeSettings = new ItemOperationMode(this)
            {
                Settings = Setting.ConvertFrom(new GPS450ChannelOperationMode() {OperationMode = operationMode}),
            };
            
            base.PutItemOperationMode(operationModeSettings);
        }

        public void PutItemSettings<T>(SettingsCollection<T> settings)
            where T : ISettings
        {
            var jsonObject = new ItemSettings(this);
            jsonObject.UpdateFromSettings(settings.Settings);
            jsonObject.UpdateFromData(settings.Data);
            base.PutItemSettings(jsonObject);
        }
    }
}
