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
    public class TAC221TachoChannel : DataChannelItem
    {
        public TAC221TachoChannel(Item itemInfo)
            : base(itemInfo)
        {
        }

        public const System.Double MinimumTriggerDifference5V = 0.01;
        public const System.Double MinimumTriggerDifference24V = 0.05;
        public const System.Double NumberOfScopeChannels = 1;

        public enum OperationMode
        {
            [RestfulProperties("Disabled")]
            Disabled = 0,

            [RestfulProperties("Enabled")]
            Enabled = 1,
        }

        public enum InputBiasing
        {
            [RestfulProperties("Differential")]
            Differential = 0,

            [RestfulProperties("Single Ended Grounded")]
            SingleEndedGrounded = 1,
        }

        public enum VoltageRange
        {
            [RestfulProperties("5 V", 5, "V")]
            _5V = 0,

            [RestfulProperties("24 V", 24, "V")]
            _24V = 1,
        }

        public enum Coupling
        {
            [RestfulProperties("DC")]
            Dc = 0,

            [RestfulProperties("AC")]
            Ac = 1,
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
            public const UInt32 LowerLimit = 0;
        }

        public interface ISettings
        {
        }

        [Serializable]
        public class TAC221TachoChannelOperationMode
        {
            [RestfulProperties("Operation Mode")]
            public OperationMode OperationMode { get; set; } = OperationMode.Enabled;
        }

        [Serializable]
        public class EnabledSettings : ISettings
        {

            [RestfulProperties("Voltage Range")]
            public VoltageRange VoltageRange { get; set; } = VoltageRange._24V;

            [RestfulProperties("Input Biasing")]
            public InputBiasing InputBiasing { get; set; } = InputBiasing.SingleEndedGrounded;

            [RestfulProperties("Coupling")]
            public Coupling Coupling { get; set; } = Coupling.Ac;

            [RestfulProperties("Trigger Polarity")]
            public TriggerPolarity TriggerPolarity { get; set; } = TriggerPolarity.RisingEdge;

            [RestfulProperties("Trigger Level")]
            public Double TriggerLevel { get; set; } = 0.05;

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
                Settings = Setting.ConvertFrom(new TAC221TachoChannelOperationMode() {OperationMode = operationMode}),
            };
            
            base.PutItemOperationMode(operationModeSettings);
        }

        public new OperationMode GetItemOperationMode()
        {
            var jsonObject = base.GetItemOperationMode();
            return Setting.ConvertTo<TAC221TachoChannelOperationMode>(jsonObject.Settings).OperationMode;
        }
    }
}
