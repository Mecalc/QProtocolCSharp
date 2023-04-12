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
    public class ICT426TachoChannel : DataChannelItem
    {
        public ICT426TachoChannel(Item itemInfo)
            : base(itemInfo)
        {
        }

        public const System.Double MinimumTriggerDifference2V = 0.05;
        public const System.Double MinimumTriggerDifference12V = 0.15;
        public const System.Double MinimumTriggerDifference30V = 0.2;
        public const System.Double MinimumTriggerDifference60V = 0.3;
        public const System.Double NumberOfScopeChannels = 1;

        public enum OperationMode
        {
            [RestfulProperties("Disabled")]
            Disabled = 0,

            [RestfulProperties("Enabled")]
            Enabled = 1,
        }

        public enum VoltageRange
        {
            [RestfulProperties("2 V", 2, "V")]
            _2V = 0,

            [RestfulProperties("12 V", 12, "V")]
            _12V = 1,

            [RestfulProperties("30 V", 30, "V")]
            _30V = 2,

            [RestfulProperties("60 V", 60, "V")]
            _60V = 3,
        }

        public enum Coupling
        {
            [RestfulProperties("DC")]
            Dc = 0,

            [RestfulProperties("AC")]
            Ac = 1,
        }

        public enum ExcitationVoltage
        {
            [RestfulProperties("12 V")]
            _12V = 0,

            [RestfulProperties("±12 V")]
            PlusMinus12V = 1,
        }

        public enum TriggerPolarity
        {
            [RestfulProperties("Rising Edge")]
            RisingEdge = 0,

            [RestfulProperties("Falling Edge")]
            FallingEdge = 1,
        }

        public struct SettingsTriggerLevelAsDouble
        {
            public const Double UpperLimit = 60;
            public const Double LowerLimit = -60;
        }

        public struct SettingsTriggerArmingLevelAsDouble
        {
            public const Double UpperLimit = 60;
            public const Double LowerLimit = -60;
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
        public class ICT426TachoChannelOperationMode
        {
            [RestfulProperties("Operation Mode")]
            public OperationMode OperationMode { get; set; } = OperationMode.Enabled;
        }

        [Serializable]
        public class EnabledSettings : ISettings
        {

            [RestfulProperties("Voltage Range")]
            public VoltageRange VoltageRange { get; set; } = VoltageRange._30V;

            [RestfulProperties("Coupling")]
            public Coupling Coupling { get; set; } = Coupling.Ac;

            [RestfulProperties("Excitation Voltage")]
            public ExcitationVoltage ExcitationVoltage { get; set; } = ExcitationVoltage._12V;

            [RestfulProperties("Trigger Polarity")]
            public TriggerPolarity TriggerPolarity { get; set; } = TriggerPolarity.RisingEdge;

            [RestfulProperties("Trigger Level")]
            public Double TriggerLevel { get; set; } = 0.2;

            [RestfulProperties("Trigger Arming Level")]
            public Double TriggerArmingLevel { get; set; } = 0;

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
                Settings = Setting.ConvertFrom(new ICT426TachoChannelOperationMode() {OperationMode = operationMode}),
            };
            
            base.PutItemOperationMode(operationModeSettings);
        }

        public new OperationMode GetItemOperationMode()
        {
            var jsonObject = base.GetItemOperationMode();
            return Setting.ConvertTo<ICT426TachoChannelOperationMode>(jsonObject.Settings).OperationMode;
        }
    }
}
