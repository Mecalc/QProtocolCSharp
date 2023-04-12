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

namespace QProtocol.InternalModules.TAC
{
    [Serializable]
    public class TAC221ScopeChannel : DataChannelItem
    {
        public TAC221ScopeChannel(Item itemInfo)
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

        public enum SampleRate
        {
            [RestfulProperties("MSR Multiplied by 32", 32, "")]
            MsrMultipliedBy32 = 0,

            [RestfulProperties("MSR Multiplied by 16", 16, "")]
            MsrMultipliedBy16 = 1,

            [RestfulProperties("MSR Multiplied by 8", 8, "")]
            MsrMultipliedBy8 = 2,

            [RestfulProperties("MSR Multiplied by 4", 4, "")]
            MsrMultipliedBy4 = 3,

            [RestfulProperties("MSR Multiplied by 2", 2, "")]
            MsrMultipliedBy2 = 4,

            [RestfulProperties("MSR Multiplied by 1", 1, "")]
            MsrMultipliedBy1 = 5,

            [RestfulProperties("MSR Multiplied by 0.5", 0.5, "")]
            MsrMultipliedBy0_5 = 6,

            [RestfulProperties("MSR Multiplied by 0.25", 0.25, "")]
            MsrMultipliedBy0_25 = 7,

            [RestfulProperties("MSR Multiplied by 0.125", 0.125, "")]
            MsrMultipliedBy0_125 = 8,

            [RestfulProperties("MSR Multiplied by 0.0625", 0.0625, "")]
            MsrMultipliedBy0_0625 = 9,

            [RestfulProperties("MSR Multiplied by 0.03125", 0.03125, "")]
            MsrMultipliedBy0_03125 = 10,

            [RestfulProperties("MSR Multiplied by 0.015625", 0.015625, "")]
            MsrMultipliedBy0_015625 = 11,
        }

        public struct SettingsTriggerPositionAsUInt32
        {
            public const UInt32 UpperLimit = 1023;
            public const UInt32 LowerLimit = 0;
        }

        public struct SettingsTriggerEdgeCountAsUInt32
        {
            public const UInt32 UpperLimit = 1024;
            public const UInt32 LowerLimit = 1;
        }

        public interface ISettings
        {
        }

        [Serializable]
        public class TAC221ScopeChannelOperationMode
        {
            [RestfulProperties("Operation Mode")]
            public OperationMode OperationMode { get; set; } = OperationMode.Enabled;
        }

        [Serializable]
        public class EnabledSettings : ISettings
        {

            [RestfulProperties("Sample Rate")]
            public SampleRate SampleRate { get; set; } = SampleRate.MsrMultipliedBy0_5;

            [RestfulProperties("Trigger Position")]
            public UInt32 TriggerPosition { get; set; } = 0;

            [RestfulProperties("Trigger On nth Edge")]
            public UInt32 TriggerEdgeCount { get; set; } = 1;
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
                Settings = Setting.ConvertFrom(new TAC221ScopeChannelOperationMode() {OperationMode = operationMode}),
            };
            
            base.PutItemOperationMode(operationModeSettings);
        }

        public new OperationMode GetItemOperationMode()
        {
            var jsonObject = base.GetItemOperationMode();
            return Setting.ConvertTo<TAC221ScopeChannelOperationMode>(jsonObject.Settings).OperationMode;
        }
    }
}
