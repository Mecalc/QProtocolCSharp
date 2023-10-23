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
    public class UTM42T1Module : Item
    {
        public UTM42T1Module(Item itemInfo)
            : base(itemInfo)
        {
        }

        public const System.Int32 NumberOfChannelsOnModule = 4;
        public const System.Int32 NumberOfWriteConfigurationBytes = 3;
        public const System.Int32 NumberOfReadConfigurationBytes = 9;

        public enum BusABIsolation
        {
            [RestfulProperties("Disconnected")]
            Disconnect = 0,

            [RestfulProperties("Connected [K23,K24]")]
            Connect = 1,
        }

        public enum BusABInvert
        {
            [RestfulProperties("Disconnected")]
            Disconnected = 0,

            [RestfulProperties("Normal [K19,K20]")]
            Normal = 1,

            [RestfulProperties("Inverted [K17,K18]")]
            Inverted = 2,
        }

        public enum BusACIsolation
        {
            [RestfulProperties("Disconnected")]
            Disconnect = 0,

            [RestfulProperties("Connected [K34]")]
            ConnectPositive = 1,

            [RestfulProperties("Connected [K44]")]
            ConnectNegative = 2,

            [RestfulProperties("Connected [K34,K44]")]
            Connect = 3,
        }

        public enum BusGroundConnection
        {
            [RestfulProperties("Floating")]
            Floating = 0,

            [RestfulProperties("Positive Connected [K37]")]
            PositiveConnected = 1,

            [RestfulProperties("Negative Connected [K38]")]
            NegativeConnected = 2,

            [RestfulProperties("Both Connected [K37,K38]")]
            BothConnected = 3,
        }

        public enum BusAnalogGroundConnection
        {
            [RestfulProperties("Floating")]
            Floating = 0,

            [RestfulProperties("Positive Connected [K39]")]
            PositiveConnected = 1,

            [RestfulProperties("Negative Connected [K40]")]
            NegativeConnected = 2,

            [RestfulProperties("Both Connected [K39,K40]")]
            BothConnected = 3,
        }

        public enum AnalogGroundToGround
        {
            [RestfulProperties("Floating")]
            Floating = 0,

            [RestfulProperties("Connected [K45]")]
            Connected = 1,
        }

        public enum BusShort
        {
            [RestfulProperties("Disconnect")]
            Disconnect = 0,

            [RestfulProperties("Limiting Short [K42]")]
            LimitingShort = 1,

            [RestfulProperties("Short [K43]")]
            Short = 2,
        }

        public enum BusAio
        {
            [RestfulProperties("Disconnect")]
            Disconnect = 0,

            [RestfulProperties("Connect Positive [K35]")]
            ConnectPositive = 1,

            [RestfulProperties("Connect Negative [K36]")]
            ConnectNegative = 2,

            [RestfulProperties("Connect Both [K35,K36]")]
            ConnectBoth = 3,
        }

        public enum BusBridge
        {
            [RestfulProperties("Disconnect")]
            Disconnect = 0,

            [RestfulProperties("Connect Signal [K25,K26]")]
            ConnectSignal = 1,

            [RestfulProperties("Connect Sense [K21,K22]")]
            ConnectSense = 2,

            [RestfulProperties("Connect Signal And Sense [K21,K22,K25,K26]")]
            ConnectBoth = 3,
        }

        public enum BusSignal
        {
            [RestfulProperties("Disconnect")]
            Disconnect = 0,

            [RestfulProperties("Connect [K27,K30]")]
            Connect = 1,
        }

        public enum SignalChargeCapacitor
        {
            [RestfulProperties("Bypass [K28,K31]")]
            Bypass = 0,

            [RestfulProperties("Connect Positive [K28]")]
            ConnectPositive = 1,

            [RestfulProperties("Connect Negative [K31]")]
            ConnectNegative = 2,

            [RestfulProperties("Connect Both")]
            ConnectedBoth = 3,
        }

        public enum SignalSeriesResistor
        {
            [RestfulProperties("Bypass [K29,K32]")]
            Bypass = 0,

            [RestfulProperties("Connect Positive [K29]")]
            ConnectPositive = 1,

            [RestfulProperties("Connect Negative [K32]")]
            ConnectNegative = 2,

            [RestfulProperties("Connect Both")]
            ConnectedBoth = 3,
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

            [RestfulProperties("Full Bridge 120 Ω [K2,K3,K6,K7]")]
            FullBridge120Ohm = 1,

            [RestfulProperties("Half Bridge 120 Ω [K3,K7]")]
            HalfBridge120Ohm = 2,

            [RestfulProperties("Quarter Bridge 120 Ω [K3,K8]")]
            QuarterBridge120Ohm = 3,

            [RestfulProperties("Quarter Bridge 350 Ω [K4,K8]")]
            QuarterBridge350Ohm = 4,

            [RestfulProperties("Quarter Bridge 1 kΩ [K5,K8]")]
            QuarterBridge1kOhm = 5,
        }

        public enum BridgeShunt
        {
            [RestfulProperties("None")]
            None = 0,

            [RestfulProperties("Positive 5 Ω [U22B]")]
            Positive5Ohm = 1,

            [RestfulProperties("Positive 129 kΩ [U22CD]")]
            Positive129kOhm = 2,

            [RestfulProperties("Positive 174 kΩ [U22C]")]
            Positive174kOhm = 3,

            [RestfulProperties("Positive 499 kΩ [U22D]")]
            Positive499kOhm = 4,

            [RestfulProperties("Negative 59 kΩ [U22A]")]
            Negative59kOhm = 5,

            [RestfulProperties("Both 129 kΩ and 59 kΩ [U10ACD]")]
            Both129kOhmAnd59kOhm = 6,

            [RestfulProperties("Both 174 kΩ and 59 kΩ [U10AC]")]
            Both174kOhmAnd59kOhm = 7,

            [RestfulProperties("Both 499 kΩ and 59 kΩ [U10AD]")]
            Both499kOhmAnd59kOhm = 8,
        }

        public enum AdcConnection
        {
            [RestfulProperties("Disconnected")]
            Disconnected = 0,

            [RestfulProperties("Connect Positive [K33]")]
            ConnectPositive = 1,

            [RestfulProperties("Connect Negative [K41]")]
            ConnectNegative = 2,

            [RestfulProperties("Connect Both [K33,K41]")]
            ConnectBoth = 3,
        }

        public enum AdcGain
        {
            [RestfulProperties("10 V")]
            _10V = 0,

            [RestfulProperties("1 V [U37AB]")]
            _1V = 1,
        }

        public enum DacConfiguration
        {
            [RestfulProperties("Vcal")]
            Vcal = 0,

            [RestfulProperties("Slow DAC [U34B]")]
            SlowDac = 1,

            [RestfulProperties("Pulse [U33A,U34B]")]
            Pulse = 2,

            [RestfulProperties("Fast DAC [U33D]")]
            FastDac = 3,

            [RestfulProperties("Icp Grounded [U34BD;U35CD]")]
            IcpGrounded = 4,

            [RestfulProperties("ICP [U33B;U34BD;U35CD]")]
            Icp = 5,

            [RestfulProperties("Digital [U33C;U34BD]")]
            Digital = 6,
        }

        public enum DacBiasing
        {
            [RestfulProperties("Short To Ground")]
            ShortToGround = 0,

            [RestfulProperties("Unbalanced Positive Grounded [U35A]")]
            UnbalancedPositiveGrounded = 1,

            [RestfulProperties("Unbalanced Negative Grounded [U34C]")]
            UnbalancedNegativeGrounded = 2,

            [RestfulProperties("Balanced [U34C,U35A]")]
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

        public struct SettingsFastDacSignalAmplitudeAsDouble
        {
            public const Double UpperLimit = 2.5;
            public const Double LowerLimit = -2.499;
        }

        public struct SettingsFastDacSignalAmplitudeChangeTimeAsInt32
        {
            public const Int32 UpperLimit = 3600;
            public const Int32 LowerLimit = 0;
        }

        public struct SettingsFastDacSignalFrequencyAsDouble
        {
            public const Double UpperLimit = 20000;
            public const Double LowerLimit = 0;
        }

        public struct SettingsFastDacSignalFrequencyChangeTimeAsInt32
        {
            public const Int32 UpperLimit = 3600;
            public const Int32 LowerLimit = 0;
        }

        public struct SettingsFastDacSignalOffsetAsDouble
        {
            public const Double UpperLimit = 2.5;
            public const Double LowerLimit = -2.499;
        }

        public interface ISettings
        {
        }

        [Serializable]
        public class UTM42T1ModuleOperationMode
        {
            [RestfulProperties("Operation Mode")]
            public OperationMode OperationMode { get; set; } = OperationMode.Enabled;
        }

        [Serializable]
        public class EnabledSettings : ISettings
        {

            [RestfulProperties("BUS AB Isolation [M1]")]
            public BusABIsolation BusABIsolation { get; set; } = BusABIsolation.Connect;

            [RestfulProperties("BUS AB Invert [M2]")]
            public BusABInvert BusABInvert { get; set; } = BusABInvert.Disconnected;

            [RestfulProperties("BUS AC Isolation [M3]")]
            public BusACIsolation BusACIsolation { get; set; } = BusACIsolation.Connect;

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

            [RestfulProperties("Signal Charge Capacitor [M10]")]
            public SignalChargeCapacitor SignalChargeCapacitor { get; set; } = SignalChargeCapacitor.Bypass;

            [RestfulProperties("Signal Series Resistor [M11]")]
            public SignalSeriesResistor SignalSeriesResistor { get; set; } = SignalSeriesResistor.Bypass;

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

            [RestfulProperties("Fast DAC Signal Function Type")]
            public SignalFunctionType FastDacSignalFunctionType { get; set; } = SignalFunctionType.Dc;

            [RestfulProperties("Fast DAC Signal Amplitude")]
            public Double FastDacSignalAmplitude { get; set; } = 0;

            [RestfulProperties("Fast DAC Signal Amplitude Change Time")]
            public Int32 FastDacSignalAmplitudeChangeTime { get; set; } = 0;

            [RestfulProperties("Fast DAC Signal Frequency")]
            public Double FastDacSignalFrequency { get; set; } = 0;

            [RestfulProperties("Fast DAC Signal Frequency Change Time")]
            public Int32 FastDacSignalFrequencyChangeTime { get; set; } = 0;

            [RestfulProperties("Fast DAC Signal Offset")]
            public Double FastDacSignalOffset { get; set; } = 0;
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
            return Setting.ConvertTo<UTM42T1ModuleOperationMode>(jsonObject.Settings).OperationMode;
        }

        public void PutItemOperationMode(OperationMode operationMode)
        {
            var operationModeSettings = new ItemOperationMode(this)
            {
                Settings = Setting.ConvertFrom(new UTM42T1ModuleOperationMode() {OperationMode = operationMode}),
            };
            
            base.PutItemOperationMode(operationModeSettings);
        }
    }
}
