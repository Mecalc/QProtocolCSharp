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

namespace QProtocol.InternalModules.UTM
{
    [Serializable]
    public class UTM450Module : Item
    {
        public UTM450Module(Item itemInfo)
            : base(itemInfo)
        {
        }

        public const System.Int32 NumberOfChannelsOnModule = 4;
        public const System.Int32 NumberOfWriteConfigurationBytes = 3;
        public const System.Int32 NumberOfReadConfigurationBytes = 9;

        public enum BusBIsolation
        {
            [RestfulProperties("Disconnected")]
            Disconnect = 0,

            [RestfulProperties("Connected [K2]")]
            Connect = 1,
        }

        public enum BusGroundConnection
        {
            [RestfulProperties("Floating")]
            Floating = 0,

            [RestfulProperties("Positive Connected [U32D]")]
            PositiveConnected = 1,

            [RestfulProperties("Negative Connected [U32C]")]
            NegativeConnected = 2,

            [RestfulProperties("Both Connected [U32CD]")]
            BothConnected = 3,
        }

        public enum BusAnalogGroundConnection
        {
            [RestfulProperties("Floating")]
            Floating = 0,

            [RestfulProperties("Positive Connected [U32B]")]
            PositiveConnected = 1,

            [RestfulProperties("Negative Connected [U32A]")]
            NegativeConnected = 2,

            [RestfulProperties("Both Connected [U32AB]")]
            BothConnected = 3,
        }

        public enum AnalogGroundToGround
        {
            [RestfulProperties("Floating")]
            Floating = 0,

            [RestfulProperties("Connected [K7]")]
            Connected = 1,
        }

        public enum BusShort
        {
            [RestfulProperties("Disconnect")]
            Disconnect = 0,

            [RestfulProperties("Limiting Short [K5]")]
            LimitingShort = 1,

            [RestfulProperties("Short [K6]")]
            Short = 2,
        }

        public enum BusAio
        {
            [RestfulProperties("Disconnect")]
            Disconnect = 0,

            [RestfulProperties("Connect Positive [K3]")]
            ConnectPositive = 1,

            [RestfulProperties("Connect Negative [K4]")]
            ConnectNegative = 2,

            [RestfulProperties("Connect Both [K3, K4]")]
            ConnectBoth = 3,
        }

        public enum BusBridge
        {
            [RestfulProperties("Disconnect")]
            Disconnect = 0,

            [RestfulProperties("Connect Signal [U27C, U30D]")]
            ConnectSignal = 1,

            [RestfulProperties("Connect Sense [U27AB]")]
            ConnectSense = 2,

            [RestfulProperties("Connect Signal And Sense [U27ABC, U30D]")]
            ConnectBoth = 3,
        }

        public enum BusSignal
        {
            [RestfulProperties("Disconnect")]
            Disconnect = 0,

            [RestfulProperties("Connect [U30BD]")]
            Connect = 1,
        }

        public enum SignalTeds
        {
            [RestfulProperties("Disconnected")]
            Disconnected = 0,

            [RestfulProperties("Type 1 Connected [U34AB,U26]")]
            Type1Connected = 1,

            [RestfulProperties("Type 2 Connected [U34AB]")]
            Type2Connected = 2,
        }

        public enum BridgeSetup
        {
            [RestfulProperties("None")]
            None = 0,

            [RestfulProperties("Full Bridge 120 Ω [U18CD, U20AB]")]
            FullBridge120Ohm = 1,

            [RestfulProperties("Half Bridge 120 Ω [U18C, U20A]")]
            HalfBridge120Ohm = 2,

            [RestfulProperties("Quarter Bridge 120 Ω [U18AC]")]
            QuarterBridge120Ohm = 3,

            [RestfulProperties("Quarter Bridge 350 Ω [U18AB]")]
            QuarterBridge350Ohm = 4,

            [RestfulProperties("Quarter Bridge 1 kΩ [K5, U18A]")]
            QuarterBridge1kOhm = 5,
        }

        public enum BridgeShunt
        {
            [RestfulProperties("None")]
            None = 0,

            [RestfulProperties("Positive 5 Ω [U22B]")]
            Positive5Ohm = 1,

            [RestfulProperties("Positive 129 kΩ [U19D, U20C]")]
            Positive129kOhm = 2,

            [RestfulProperties("Positive 174 kΩ [U20C]")]
            Positive174kOhm = 3,

            [RestfulProperties("Positive 499 kΩ [U19D]")]
            Positive499kOhm = 4,

            [RestfulProperties("Negative 59 kΩ [U19A]")]
            Negative59kOhm = 5,

            [RestfulProperties("Both 129 kΩ and 59 kΩ [U19AD, U20C]")]
            Both129kOhmAnd59kOhm = 6,

            [RestfulProperties("Both 174 kΩ and 59 kΩ [U19A, U20C]")]
            Both174kOhmAnd59kOhm = 7,

            [RestfulProperties("Both 499 kΩ and 59 kΩ [U19AD]")]
            Both499kOhmAnd59kOhm = 8,
        }

        public enum AdcConnection
        {
            [RestfulProperties("Disconnected")]
            Disconnected = 0,

            [RestfulProperties("Connect Positive [U30A]")]
            ConnectPositive = 1,

            [RestfulProperties("Connect Negative [U30C]")]
            ConnectNegative = 2,

            [RestfulProperties("Connect Both [U30AC]")]
            ConnectBoth = 3,
        }

        public enum AdcGain
        {
            [RestfulProperties("10 V")]
            _10V = 0,

            [RestfulProperties("1 V [U38AB]")]
            _1V = 1,
        }

        public enum DacGain
        {
            [RestfulProperties("10 V")]
            _10V = 0,

            [RestfulProperties("1 V [U40AB]")]
            _1V = 1,
        }

        public enum DacConfiguration
        {
            [RestfulProperties("Vcal [U28ACD]")]
            Vcal = 0,

            [RestfulProperties("Slow DAC [U28D, U29D]")]
            SlowDac = 1,

            [RestfulProperties("Pulse [U28ACD]")]
            Pulse = 2,

            [RestfulProperties("Icp Grounded [U28ABCD; U29CD; U31C]")]
            IcpGrounded = 3,

            [RestfulProperties("ICP [U28ABCD; U29CD; U31C]")]
            Icp = 4,

            [RestfulProperties("Digital [U33C;U34BD]")]
            Digital = 5,
        }

        public enum DacBiasing
        {
            [RestfulProperties("Short To Ground")]
            ShortToGround = 0,

            [RestfulProperties("Unbalanced Negative Grounded [U29B]")]
            UnbalancedNegativeGrounded = 1,

            [RestfulProperties("Unbalanced Positive Grounded [U31A]")]
            UnbalancedPositiveGrounded = 2,

            [RestfulProperties("Balanced [U29B,U31A]")]
            Balanced = 3,
        }

        public enum SignalFunctionType
        {
            [RestfulProperties("DC")]
            Dc = 0,

            [RestfulProperties("Sine")]
            Sine = 1,

            [RestfulProperties("Square")]
            Square = 2,

            [RestfulProperties("Triangular")]
            Triangular = 3,

            [RestfulProperties("White Noise")]
            WhiteNoise = 4,
        }

        public enum OperationMode
        {
            [RestfulProperties("Disabled")]
            Disabled = 0,

            [RestfulProperties("Enabled")]
            Enabled = 1,
        }

        public struct SettingsSlowDacSignalAmplitudeAsDouble
        {
            public const Double UpperLimit = 10;
            public const Double LowerLimit = -9.999;
        }

        public struct SettingsSlowDacSignalAmplitudeChangeTimeAsInt32
        {
            public const Int32 UpperLimit = 3600;
            public const Int32 LowerLimit = 0;
        }

        public struct SettingsSlowDacSignalFrequencyAsDouble
        {
            public const Double UpperLimit = 48000;
            public const Double LowerLimit = 0;
        }

        public struct SettingsSlowDacSignalFrequencyChangeTimeAsInt32
        {
            public const Int32 UpperLimit = 3600;
            public const Int32 LowerLimit = 0;
        }

        public struct SettingsSlowDacSignalOffsetAsDouble
        {
            public const Double UpperLimit = 10;
            public const Double LowerLimit = -9.999;
        }

        public interface ISettings
        {
        }

        [Serializable]
        public class UTM450ModuleOperationMode
        {
            [RestfulProperties("Operation Mode")]
            public OperationMode OperationMode { get; set; } = OperationMode.Enabled;
        }

        [Serializable]
        public class EnabledSettings : ISettings
        {

            [RestfulProperties("BUS AB Isolation [M1]")]
            public BusBIsolation BusBIsolation { get; set; } = BusBIsolation.Connect;

            [RestfulProperties("BUS Ground Connection [M4]")]
            public BusGroundConnection BusGroundConnection { get; set; } = BusGroundConnection.Floating;

            [RestfulProperties("BUS Analog Ground Connection [M5]")]
            public BusAnalogGroundConnection BusAnalogGroundConnection { get; set; } = BusAnalogGroundConnection.Floating;

            [RestfulProperties("Analog Ground to Ground [K45]")]
            public AnalogGroundToGround AnalogGroundToGround { get; set; } = AnalogGroundToGround.Floating;

            [RestfulProperties("Bus Short [M6]")]
            public BusShort BusShort { get; set; } = BusShort.Disconnect;

            [RestfulProperties("Bus AIO [M7]")]
            public BusAio BusAio { get; set; } = BusAio.Disconnect;

            [RestfulProperties("Bus Bridge [M8]")]
            public BusBridge BusBridge { get; set; } = BusBridge.Disconnect;

            [RestfulProperties("Bus Signal [M9]")]
            public BusSignal BusSignal { get; set; } = BusSignal.Disconnect;

            [RestfulProperties("Signal TEDS [M12]")]
            public SignalTeds SignalTeds { get; set; } = SignalTeds.Disconnected;

            [RestfulProperties("Bridge Setup [M13]")]
            public BridgeSetup BridgeSetup { get; set; } = BridgeSetup.None;

            [RestfulProperties("Bridge Shunt [M14]")]
            public BridgeShunt BridgeShunt { get; set; } = BridgeShunt.None;

            [RestfulProperties("DAC Configuration [M15]")]
            public DacConfiguration DacConfiguration { get; set; } = DacConfiguration.SlowDac;

            [RestfulProperties("DAC Biasing [M16]")]
            public DacBiasing DacBiasing { get; set; } = DacBiasing.Balanced;

            [RestfulProperties("ADC Connection [M17]")]
            public AdcConnection AdcConnection { get; set; } = AdcConnection.Disconnected;

            [RestfulProperties("ADC Gain [M18]")]
            public AdcGain AdcGain { get; set; } = AdcGain._10V;

            [RestfulProperties("DAC Gain")]
            public DacGain DacGain { get; set; } = DacGain._10V;

            [RestfulProperties("Slow DAC Signal Function Type")]
            public SignalFunctionType SlowDacSignalFunctionType { get; set; } = SignalFunctionType.Dc;

            [RestfulProperties("Slow DAC Signal Amplitude")]
            public Double SlowDacSignalAmplitude { get; set; } = 0;

            [RestfulProperties("Slow DAC Signal Amplitude Change Time")]
            public Int32 SlowDacSignalAmplitudeChangeTime { get; set; } = 0;

            [RestfulProperties("Slow DAC Signal Frequency")]
            public Double SlowDacSignalFrequency { get; set; } = 0;

            [RestfulProperties("Slow DAC Signal Frequency Change Time")]
            public Int32 SlowDacSignalFrequencyChangeTime { get; set; } = 0;

            [RestfulProperties("Slow DAC Signal Offset")]
            public Double SlowDacSignalOffset { get; set; } = 0;
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
            return Setting.ConvertTo<UTM450ModuleOperationMode>(jsonObject.Settings).OperationMode;
        }

        public void PutItemOperationMode(OperationMode operationMode)
        {
            var operationModeSettings = new ItemOperationMode(this)
            {
                Settings = Setting.ConvertFrom(new UTM450ModuleOperationMode() {OperationMode = operationMode}),
            };
            
            base.PutItemOperationMode(operationModeSettings);
        }
    }
}
