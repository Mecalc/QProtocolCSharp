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

namespace QProtocol.InternalModules.THM
{
    [Serializable]
    public class THM427Module : Item
    {
        public THM427Module(Item itemInfo)
            : base(itemInfo)
        {
        }

        public const System.Int32 NumberOfChannelOnModule = 8;

        public enum SampleRate
        {
            [RestfulProperties("MSR Divide by 8", 8, "")]
            MsrDivideBy8 = 0,

            [RestfulProperties("MSR Divide by 16", 16, "")]
            MsrDivideBy16 = 1,

            [RestfulProperties("MSR Divide by 32", 32, "")]
            MsrDivideBy32 = 2,

            [RestfulProperties("MSR Divide by 64", 64, "")]
            MsrDivideBy64 = 3,

            [RestfulProperties("MSR Divide by 128", 128, "")]
            MsrDivideBy128 = 4,

            [RestfulProperties("MSR Divide by 256", 256, "")]
            MsrDivideBy256 = 5,
        }

        public enum OperationMode
        {
            [RestfulProperties("Disabled")]
            Disabled = 0,

            [RestfulProperties("Enabled")]
            Enabled = 1,
        }

        public interface ISettings
        {
        }

        [Serializable]
        public class THM427ModuleOperationMode
        {
            [RestfulProperties("Operation Mode")]
            public OperationMode OperationMode { get; set; } = OperationMode.Enabled;
        }

        [Serializable]
        public class EnabledSettings : ISettings
        {

            [RestfulProperties("Sample Rate")]
            public SampleRate SampleRate { get; set; } = SampleRate.MsrDivideBy256;

            [RestfulProperties("Channel 1 and 2 Operation Mode")]
            public InternalModules.THM.THM427Channel.OperationMode ChannelPair12OperationMode { get; set; } = InternalModules.THM.THM427Channel.OperationMode.VoltageInput;

            [RestfulProperties("Channel 3 and 4 Operation Mode")]
            public InternalModules.THM.THM427Channel.OperationMode ChannelPair34OperationMode { get; set; } = InternalModules.THM.THM427Channel.OperationMode.VoltageInput;

            [RestfulProperties("Channel 5 and 6 Operation Mode")]
            public InternalModules.THM.THM427Channel.OperationMode ChannelPair56OperationMode { get; set; } = InternalModules.THM.THM427Channel.OperationMode.VoltageInput;

            [RestfulProperties("Channel 7 and 8 Operation Mode")]
            public InternalModules.THM.THM427Channel.OperationMode ChannelPair78OperationMode { get; set; } = InternalModules.THM.THM427Channel.OperationMode.VoltageInput;
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

        public new OperationMode GetItemOperationMode()
        {
            var jsonObject = base.GetItemOperationMode();
            return Setting.ConvertTo<THM427ModuleOperationMode>(jsonObject.Settings).OperationMode;
        }

        public void PutItemOperationMode(OperationMode operationMode)
        {
            var operationModeSettings = new ItemOperationMode(this)
            {
                Settings = Setting.ConvertFrom(new THM427ModuleOperationMode() {OperationMode = operationMode}),
            };
            
            base.PutItemOperationMode(operationModeSettings);
        }
    }
}
