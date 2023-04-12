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
    public class UTM42T0Module : Item
    {
        public UTM42T0Module(Item itemInfo)
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

            [RestfulProperties("Connected [K7,8]")]
            Connect = 1,
        }

        public enum BusABInvert
        {
            [RestfulProperties("Disconnected")]
            Disconnected = 0,

            [RestfulProperties("Normal [K3,4]")]
            Normal = 1,

            [RestfulProperties("Inverted [K1,2]")]
            Inverted = 2,
        }

        public enum BusACIsolation
        {
            [RestfulProperties("Disconnected")]
            Disconnect = 0,

            [RestfulProperties("Connected [K17,26]")]
            Connect = 1,
        }

        public enum BusGroundConnection
        {
            [RestfulProperties("Floating")]
            Floating = 0,

            [RestfulProperties("Positive Connected [K20]")]
            PositiveConnected = 1,

            [RestfulProperties("Negative Connected [K21]")]
            NegativeConnected = 2,

            [RestfulProperties("Both Connected [K20,21]")]
            BothConnected = 3,
        }

        public enum BusAnalogGroundConnection
        {
            [RestfulProperties("Floating")]
            Floating = 0,

            [RestfulProperties("Positive Connected [K22]")]
            PositiveConnected = 1,

            [RestfulProperties("Negative Connected [K23]")]
            NegativeConnected = 2,

            [RestfulProperties("Both Connected [K22,23]")]
            BothConnected = 3,
        }

        public enum AnalogGroundToGround
        {
            [RestfulProperties("Floating")]
            Floating = 0,

            [RestfulProperties("Connected [K27]")]
            Connected = 1,
        }

        public enum BusShort
        {
            [RestfulProperties("Disconnect")]
            Disconnect = 0,

            [RestfulProperties("Limiting Short [K25]")]
            LimitingShort = 1,

            [RestfulProperties("Short [K24]")]
            Short = 2,
        }

        public enum BusAio
        {
            [RestfulProperties("Disconnect")]
            Disconnect = 0,

            [RestfulProperties("Connect Positive [K18]")]
            ConnectPositive = 1,

            [RestfulProperties("Connect Negative [K19]")]
            ConnectNegative = 2,

            [RestfulProperties("Connect Both [K18,19]")]
            ConnectBoth = 3,
        }

        public enum BusBridge
        {
            [RestfulProperties("Disconnect")]
            Disconnect = 0,

            [RestfulProperties("Connect Signal [K9,10]")]
            ConnectSignal = 1,

            [RestfulProperties("Connect Sense [K5,6]")]
            ConnectSense = 2,

            [RestfulProperties("Connect Signal And Sense [K5,6,9,10]")]
            ConnectBoth = 3,
        }

        public enum BusSignal
        {
            [RestfulProperties("Disconnect")]
            Disconnect = 0,

            [RestfulProperties("Connect [K11,14]")]
            Connect = 1,
        }

        public enum SignalChargeCapacitor
        {
            [RestfulProperties("Bypass [K12,15]")]
            Bypass = 0,

            [RestfulProperties("Connect Positive [K15]")]
            ConnectPositive = 1,

            [RestfulProperties("Connect Negative [K12]")]
            ConnectNegative = 2,

            [RestfulProperties("Connect Both")]
            ConnectedBoth = 3,
        }

        public enum SignalSeriesResistor
        {
            [RestfulProperties("Bypass [K13,16]")]
            Bypass = 0,

            [RestfulProperties("Connect Positive [K13]")]
            ConnectPositive = 1,

            [RestfulProperties("Connect Negative [K16]")]
            ConnectNegative = 2,

            [RestfulProperties("Connect Both")]
            ConnectedBoth = 3,
        }

        public enum SignalTeds
        {
            [RestfulProperties("Disconnected")]
            Disconnected = 0,

            [RestfulProperties("Type 1 Connected [U3A,B;U13A,B,C,D]")]
            Type1Connected = 1,

            [RestfulProperties("Type 2 Connected [U3A,B]")]
            Type2Connected = 2,
        }

        public enum BridgeSetup
        {
            [RestfulProperties("None")]
            None = 0,

            [RestfulProperties("Full Bridge 120 Ω [K28,29,32,33]")]
            FullBridge120Ohm = 1,

            [RestfulProperties("Half Bridge 120 Ω [K28,29]")]
            HalfBridge120Ohm = 2,

            [RestfulProperties("Quarter Bridge 120 Ω [K29,34]")]
            QuarterBridge120Ohm = 3,

            [RestfulProperties("Quarter Bridge 350 Ω [K30,34]")]
            QuarterBridge350Ohm = 4,

            [RestfulProperties("Quarter Bridge 1 kΩ [K31,34]")]
            QuarterBridge1kOhm = 5,
        }

        public enum BridgeShunt
        {
            [RestfulProperties("None")]
            None = 0,

            [RestfulProperties("Positive 5 Ω [U10B]")]
            Positive5Ohm = 1,

            [RestfulProperties("Positive 100 kΩ [U10C]")]
            Positive100kOhm = 2,

            [RestfulProperties("Negative 100 kΩ [U10A]")]
            Negative100kOhm = 3,

            [RestfulProperties("Both 100 kΩ [U10A,C]")]
            Both100kOhm = 4,
        }

        public enum DacConfiguration
        {
            [RestfulProperties("Vcal [U3D]")]
            Vcal = 0,

            [RestfulProperties("Slow DAC [U1B]")]
            SlowDac = 1,

            [RestfulProperties("Pulse [U1A;U3D]")]
            Pulse = 2,

            [RestfulProperties("Fast DAC [U1D;U3D]")]
            FastDac = 3,

            [RestfulProperties("Icp Grounded [U1B;U2D;U3D]")]
            IcpGrounded = 4,

            [RestfulProperties("ICP [U1B;U2B,D;U3C,D]")]
            Icp = 5,

            [RestfulProperties("Digital [U1B;U2D;U3D]")]
            Digital = 6,
        }

        public enum DacBiasing
        {
            [RestfulProperties("Short To Ground")]
            ShortToGround = 0,

            [RestfulProperties("Unbalanced Positive Grounded [U1C]")]
            UnbalancedPositiveGrounded = 1,

            [RestfulProperties("Unbalanced Negative Grounded [U2A]")]
            UnbalancedNegativeGrounded = 2,

            [RestfulProperties("Unbalanced Positive Floating [U1C,U2A]")]
            UnbalancedPositiveFloating = 3,

            [RestfulProperties("Unbalanced Negative Floating [U1C,U2A]")]
            UnbalancedNegativeFloating = 4,

            [RestfulProperties("Balanced [U1C,U2A]")]
            Balanced = 5,
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
            public const Double UpperLimit = 10000;
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
        public class UTM42T0ModuleOperationMode
        {
            [RestfulProperties("Operation Mode")]
            public OperationMode OperationMode { get; set; } = OperationMode.Enabled;
        }

        [Serializable]
        public class EnabledSettings : ISettings
        {

            [RestfulProperties("BUS AB Isolation [K7,8]")]
            public BusABIsolation BusABIsolation { get; set; } = BusABIsolation.Connect;

            [RestfulProperties("BUS AB Invert [K1,2,3,4]")]
            public BusABInvert BusABInvert { get; set; } = BusABInvert.Disconnected;

            [RestfulProperties("BUS AC Isolation [K17,26]")]
            public BusACIsolation BusACIsolation { get; set; } = BusACIsolation.Connect;

            [RestfulProperties("BUS Ground Connection [K20,21]")]
            public BusGroundConnection BusGroundConnection { get; set; } = BusGroundConnection.Floating;

            [RestfulProperties("BUS Analog Ground Connection [K22,22]")]
            public BusAnalogGroundConnection BusAnalogGroundConnection { get; set; } = BusAnalogGroundConnection.Floating;

            [RestfulProperties("Analog Ground to Ground [K27]")]
            public AnalogGroundToGround AnalogGroundToGround { get; set; } = AnalogGroundToGround.Floating;

            [RestfulProperties("Bus Short [K24,25]")]
            public BusShort BusShort { get; set; } = BusShort.Disconnect;

            [RestfulProperties("Bus AIO [K18,19]")]
            public BusAio BusAio { get; set; } = BusAio.Disconnect;

            [RestfulProperties("Bus Bridge [K5,6,9,10]")]
            public BusBridge BusBridge { get; set; } = BusBridge.Disconnect;

            [RestfulProperties("Bus Signal [K11,14]")]
            public BusSignal BusSignal { get; set; } = BusSignal.Disconnect;

            [RestfulProperties("Signal Charge Capacitor [K12,15]")]
            public SignalChargeCapacitor SignalChargeCapacitor { get; set; } = SignalChargeCapacitor.Bypass;

            [RestfulProperties("Signal Series Resistor [K13,16]")]
            public SignalSeriesResistor SignalSeriesResistor { get; set; } = SignalSeriesResistor.Bypass;

            [RestfulProperties("Signal TEDS [U3A,B;U13A,B,C,D]")]
            public SignalTeds SignalTeds { get; set; } = SignalTeds.Disconnected;

            [RestfulProperties("Bridge Setup [K28,29,30,31,32,33,34]")]
            public BridgeSetup BridgeSetup { get; set; } = BridgeSetup.None;

            [RestfulProperties("Bridge Shunt [U10A,B,C]")]
            public BridgeShunt BridgeShunt { get; set; } = BridgeShunt.None;

            [RestfulProperties("DAC Configuration [U1A,B,D;U2B,C,D;U3C,D]")]
            public DacConfiguration DacConfiguration { get; set; } = DacConfiguration.SlowDac;

            [RestfulProperties("DAC Biasing [U1C;U2A]")]
            public DacBiasing DacBiasing { get; set; } = DacBiasing.Balanced;

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

            [RestfulProperties("Fast DAC Signal Function Type")]
            public SignalFunctionType FastDacSignalFunctionType { get; set; } = SignalFunctionType.Dc;
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
            return Setting.ConvertTo<UTM42T0ModuleOperationMode>(jsonObject.Settings).OperationMode;
        }

        public void PutItemOperationMode(OperationMode operationMode)
        {
            var operationModeSettings = new ItemOperationMode(this)
            {
                Settings = Setting.ConvertFrom(new UTM42T0ModuleOperationMode() {OperationMode = operationMode}),
            };
            
            base.PutItemOperationMode(operationModeSettings);
        }
    }
}
