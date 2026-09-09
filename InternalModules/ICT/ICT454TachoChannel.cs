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
    public class ICT454TachoChannel : DataChannelItem
    {
        public ICT454TachoChannel(Item itemInfo)
            : base(itemInfo)
        {
        }

        public const System.Double NumberOfScopeChannels = 1;

        public enum OperationMode
        {
            [RestfulProperties("Disabled")]
            Disabled = 0,

            [RestfulProperties("Enabled")]
            Enabled = 1,
        }

        public enum DacValueOnLemo
        {
            [RestfulProperties("0 V")]
            _0V = 0,

            [RestfulProperties("100 mV")]
            _100mV = 1,

            [RestfulProperties("1 V")]
            _1V = 2,

            [RestfulProperties("2.5 V")]
            _2_5V = 3,

            [RestfulProperties("5 V")]
            _5V = 4,
        }

        public enum VCalMode
        {
            [RestfulProperties("Off")]
            Off = 0,

            [RestfulProperties("VCal = On, P = VCalMod, N = AGNDM")]
            VCalOn_PVCalMod_NAGNDM = 1,

            [RestfulProperties("VCal = On, P = AGNDM, N = VCalMod")]
            VCalOn_PAGNDM_NVCalMod = 2,

            [RestfulProperties("VCal = On, P = AGNDM, N = AGNDM")]
            VCalOn_PAGNDM_NAGNDM = 3,

            [RestfulProperties("VCal = On, P = TEDS, N = AGNDM")]
            VCalOn_PTEDS_NAGNDM = 4,

            [RestfulProperties("VCal = On, P = AGNDM, N = AGNDM Front-End Disconnected")]
            VCalOn_PAGNDM_NAGNDM_FrontEndDisconnected = 5,

            [RestfulProperties("VCal = Off, Front-End Connected")]
            VCalOff_FrontEndConnected = 6,
        }

        public enum VoltageRange
        {
            [RestfulProperties("10 V", 10, "V")]
            _10V = 0,

            [RestfulProperties("20 V", 20, "V")]
            _20V = 1,

            [RestfulProperties("40 V", 40, "V")]
            _40V = 2,

            [RestfulProperties("80 V", 80, "V")]
            _80V = 3,
        }

        public enum Coupling
        {
            [RestfulProperties("DC")]
            Dc = 0,

            [RestfulProperties("AC")]
            Ac = 1,
        }

        public enum InputBiasing
        {
            [RestfulProperties("Differential")]
            Differential = 0,

            [RestfulProperties("Single Ended")]
            SingleEnded = 1,
        }

        public enum ExcitationVoltage
        {
            [RestfulProperties("11 V")]
            _11V = 0,

            [RestfulProperties("24 V")]
            _24V = 1,
        }

        public enum TriggerPolarity
        {
            [RestfulProperties("Rising Edge")]
            RisingEdge = 0,

            [RestfulProperties("Falling Edge")]
            FallingEdge = 1,
        }

        [Serializable]
        public class DacValueOnLemoSettings
        {
            [RestfulProperties("DAC Value On LEMO")]
            public DacValueOnLemo DacValueOnLemo { get; set; }
        }

        [Serializable]
        public class VCalModeSettings
        {
            [RestfulProperties("VCal mode")]
            public VCalMode VCalMode { get; set; }
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
        public class ICT454TachoChannelOperationMode
        {
            [RestfulProperties("Operation Mode")]
            public OperationMode OperationMode { get; set; } = OperationMode.Enabled;
        }

        [Serializable]
        public class EnabledSettings : ISettings
        {

            [RestfulProperties("Voltage Range")]
            public VoltageRange VoltageRange { get; set; } = VoltageRange._40V;

            [RestfulProperties("Input Biasing")]
            public InputBiasing InputBiasing { get; set; } = InputBiasing.Differential;

            [RestfulProperties("Coupling")]
            public Coupling Coupling { get; set; } = Coupling.Ac;

            [RestfulProperties("Excitation Voltage")]
            public ExcitationVoltage ExcitationVoltage { get; set; } = ExcitationVoltage._11V;

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
                Settings = Setting.ConvertFrom(new ICT454TachoChannelOperationMode() {OperationMode = operationMode}),
            };
            
            base.PutItemOperationMode(operationModeSettings);
        }

        public new OperationMode GetItemOperationMode()
        {
            var jsonObject = base.GetItemOperationMode();
            return Setting.ConvertTo<ICT454TachoChannelOperationMode>(jsonObject.Settings).OperationMode;
        }
    }
}
