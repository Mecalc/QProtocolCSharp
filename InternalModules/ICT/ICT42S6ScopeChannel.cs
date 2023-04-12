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

namespace QProtocol.InternalModules.ICT
{
    [Serializable]
    public class ICT42S6ScopeChannel : DataChannelItem
    {
        public ICT42S6ScopeChannel(Item itemInfo)
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
            [RestfulProperties("MSR Multiplied by 24", 24, "")]
            MsrMultipliedBy24 = 0,

            [RestfulProperties("MSR Multiplied by 16", 16, "")]
            MsrMultipliedBy16 = 1,

            [RestfulProperties("MSR Multiplied by 12", 12, "")]
            MsrMultipliedBy12 = 2,

            [RestfulProperties("MSR Multiplied by 9.6", 9.6, "")]
            MsrMultipliedBy9_6 = 3,

            [RestfulProperties("MSR Multiplied by 8", 8, "")]
            MsrMultipliedBy8 = 4,

            [RestfulProperties("MSR Multiplied by 6.857", 6.857, "")]
            MsrMultipliedBy6_857 = 5,

            [RestfulProperties("MSR Multiplied by 6", 6, "")]
            MsrMultipliedBy6 = 6,

            [RestfulProperties("MSR Multiplied by 4", 4, "")]
            MsrMultipliedBy4 = 7,

            [RestfulProperties("MSR Multiplied by 2", 2, "")]
            MsrMultipliedBy2 = 8,

            [RestfulProperties("MSR Multiplied by 1", 1, "")]
            MsrMultipliedBy1 = 9,

            [RestfulProperties("MSR Multiplied by 0.5", 0.5, "")]
            MsrMultipliedBy0_5 = 10,

            [RestfulProperties("MSR Multiplied by 0.25", 0.25, "")]
            MsrMultipliedBy0_25 = 11,

            [RestfulProperties("MSR Multiplied by 0.125", 0.125, "")]
            MsrMultipliedBy0_125 = 12,

            [RestfulProperties("MSR Multiplied by 0.0625", 0.0625, "")]
            MsrMultipliedBy0_0625 = 13,

            [RestfulProperties("MSR Multiplied by 0.03125", 0.03125, "")]
            MsrMultipliedBy0_03125 = 14,

            [RestfulProperties("MSR Multiplied by 0.015625", 0.015625, "")]
            MsrMultipliedBy0_015625 = 15,
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
        public class ICT42S6ScopeChannelOperationMode
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
                Settings = Setting.ConvertFrom(new ICT42S6ScopeChannelOperationMode() {OperationMode = operationMode}),
            };
            
            base.PutItemOperationMode(operationModeSettings);
        }

        public new OperationMode GetItemOperationMode()
        {
            var jsonObject = base.GetItemOperationMode();
            return Setting.ConvertTo<ICT42S6ScopeChannelOperationMode>(jsonObject.Settings).OperationMode;
        }
    }
}
