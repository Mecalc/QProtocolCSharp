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

namespace QProtocol.InternalModules.ALO
{
    [Serializable]
    public class ALO450Channel : Item
    {
        public ALO450Channel(Item itemInfo)
            : base(itemInfo)
        {
        }


        public enum OperationMode
        {
            [RestfulProperties("Disabled")]
            Disabled = 0,

            [RestfulProperties("DC Generator")]
            DcGenerator = 1,

            [RestfulProperties("Sine Wave Generator")]
            SineWaveGenerator = 2,

            [RestfulProperties("Square Wave Generator")]
            SquareWaveGenerator = 3,

            [RestfulProperties("Triangular Wave Generator")]
            TriangularWaveGenerator = 4,

            [RestfulProperties("White Noise Generator")]
            WhiteNoiseGenerator = 5,

            [RestfulProperties("Mirror Left Module")]
            MirrorLeftModule = 6,

            [RestfulProperties("Streaming")]
            Streaming = 7,

            [RestfulProperties("Buffered")]
            Buffered = 8,
        }

        public enum SignalConnection
        {
            [RestfulProperties("Grounded")]
            Grounded = 0,

            [RestfulProperties("Connected")]
            Connected = 1,
        }

        public enum OutputVoltageLevel
        {
            [RestfulProperties("5 V Out")]
            _5V = 0,

            [RestfulProperties("12 V Out")]
            _12V = 1,
        }

        public enum ModuleStatusOutput
        {
            [RestfulProperties("Short circuit")]
            ShortCircuit = 0,

            [RestfulProperties("Open circuit")]
            OpenCircuit = 1,

            [RestfulProperties("Output Voltage")]
            OutputVoltage = 2,
        }

        public enum Fallback
        {
            [RestfulProperties("Zero")]
            Zero = 0,

            [RestfulProperties("Fade to zero")]
            FadeToZero = 1,
        }

        public struct SettingsSignalAmplitudeAsDouble
        {
            public const Double UpperLimit = 10;
            public const Double LowerLimit = -9.999;
        }

        public struct SettingsSignalAmplitudeChangeTimeAsUInt32
        {
            public const UInt32 UpperLimit = 3600;
            public const UInt32 LowerLimit = 0;
        }

        public struct SettingsSignalFrequencyAsDouble
        {
            public const Double UpperLimit = 10000;
            public const Double LowerLimit = 0;
        }

        public struct SettingsSignalFrequencyChangeTimeAsUInt32
        {
            public const UInt32 UpperLimit = 3600;
            public const UInt32 LowerLimit = 0;
        }

        public struct SettingsSignalOffsetAsDouble
        {
            public const Double UpperLimit = 10;
            public const Double LowerLimit = -9.999;
        }

        public struct SettingsSignalPhaseAsDouble
        {
            public const Double UpperLimit = 360;
            public const Double LowerLimit = -360;
        }

        public struct SettingsSampleCountAsUInt32
        {
            public const UInt32 UpperLimit = 6144000;
            public const UInt32 LowerLimit = 1;
        }

        public interface ISettings
        {
        }

        [Serializable]
        public class ALO450ChannelOperationMode
        {
            [RestfulProperties("Operation Mode")]
            public OperationMode OperationMode { get; set; } = OperationMode.DcGenerator;
        }

        [Serializable]
        public class DcGeneratorSettings : ISettings
        {

            [RestfulProperties("Signal Connection")]
            public SignalConnection SignalConnection { get; set; } = SignalConnection.Connected;

            [RestfulProperties("Signal Amplitude")]
            public Double SignalAmplitude { get; set; } = 0;

            [RestfulProperties("Signal Amplitude Change Time")]
            public UInt32 SignalAmplitudeChangeTime { get; set; } = 0;

            [RestfulProperties("Output Voltage Level")]
            public OutputVoltageLevel OutputVoltageLevel { get; set; } = OutputVoltageLevel._5V;

            [RestfulProperties("Module Status Output")]
            public ModuleStatusOutput ModuleStatusOutput { get; set; } = ModuleStatusOutput.OpenCircuit;
        }

        [Serializable]
        public class SineWaveGeneratorSettings : ISettings
        {

            [RestfulProperties("Signal Connection")]
            public SignalConnection SignalConnection { get; set; } = SignalConnection.Connected;

            [RestfulProperties("Signal Amplitude")]
            public Double SignalAmplitude { get; set; } = 0;

            [RestfulProperties("Signal Amplitude Change Time")]
            public UInt32 SignalAmplitudeChangeTime { get; set; } = 0;

            [RestfulProperties("Signal Frequency")]
            public Double SignalFrequency { get; set; } = 0;

            [RestfulProperties("Signal Frequency Change Time")]
            public UInt32 SignalFrequencyChangeTime { get; set; } = 0;

            [RestfulProperties("Signal Offset")]
            public Double SignalOffset { get; set; } = 0;

            [RestfulProperties("Signal Phase")]
            public Double SignalPhase { get; set; } = 0;

            [RestfulProperties("Output Voltage Level")]
            public OutputVoltageLevel OutputVoltageLevel { get; set; } = OutputVoltageLevel._5V;

            [RestfulProperties("Module Status Output")]
            public ModuleStatusOutput ModuleStatusOutput { get; set; } = ModuleStatusOutput.OpenCircuit;
        }

        [Serializable]
        public class SquareWaveGeneratorSettings : ISettings
        {

            [RestfulProperties("Signal Connection")]
            public SignalConnection SignalConnection { get; set; } = SignalConnection.Connected;

            [RestfulProperties("Signal Amplitude")]
            public Double SignalAmplitude { get; set; } = 0;

            [RestfulProperties("Signal Amplitude Change Time")]
            public UInt32 SignalAmplitudeChangeTime { get; set; } = 0;

            [RestfulProperties("Signal Frequency")]
            public Double SignalFrequency { get; set; } = 0;

            [RestfulProperties("Signal Frequency Change Time")]
            public UInt32 SignalFrequencyChangeTime { get; set; } = 0;

            [RestfulProperties("Signal Offset")]
            public Double SignalOffset { get; set; } = 0;

            [RestfulProperties("Signal Phase")]
            public Double SignalPhase { get; set; } = 0;

            [RestfulProperties("Output Voltage Level")]
            public OutputVoltageLevel OutputVoltageLevel { get; set; } = OutputVoltageLevel._5V;

            [RestfulProperties("Module Status Output")]
            public ModuleStatusOutput ModuleStatusOutput { get; set; } = ModuleStatusOutput.OpenCircuit;
        }

        [Serializable]
        public class TriangularWaveGeneratorSettings : ISettings
        {

            [RestfulProperties("Signal Connection")]
            public SignalConnection SignalConnection { get; set; } = SignalConnection.Connected;

            [RestfulProperties("Signal Amplitude")]
            public Double SignalAmplitude { get; set; } = 0;

            [RestfulProperties("Signal Amplitude Change Time")]
            public UInt32 SignalAmplitudeChangeTime { get; set; } = 0;

            [RestfulProperties("Signal Frequency")]
            public Double SignalFrequency { get; set; } = 0;

            [RestfulProperties("Signal Frequency Change Time")]
            public UInt32 SignalFrequencyChangeTime { get; set; } = 0;

            [RestfulProperties("Signal Offset")]
            public Double SignalOffset { get; set; } = 0;

            [RestfulProperties("Signal Phase")]
            public Double SignalPhase { get; set; } = 0;

            [RestfulProperties("Output Voltage Level")]
            public OutputVoltageLevel OutputVoltageLevel { get; set; } = OutputVoltageLevel._5V;

            [RestfulProperties("Module Status Output")]
            public ModuleStatusOutput ModuleStatusOutput { get; set; } = ModuleStatusOutput.OpenCircuit;
        }

        [Serializable]
        public class WhiteNoiseGeneratorSettings : ISettings
        {

            [RestfulProperties("Signal Connection")]
            public SignalConnection SignalConnection { get; set; } = SignalConnection.Connected;

            [RestfulProperties("Signal Amplitude")]
            public Double SignalAmplitude { get; set; } = 0;

            [RestfulProperties("Signal Amplitude Change Time")]
            public UInt32 SignalAmplitudeChangeTime { get; set; } = 0;

            [RestfulProperties("Signal Offset")]
            public Double SignalOffset { get; set; } = 0;

            [RestfulProperties("Signal Phase")]
            public Double SignalPhase { get; set; } = 0;

            [RestfulProperties("Output Voltage Level")]
            public OutputVoltageLevel OutputVoltageLevel { get; set; } = OutputVoltageLevel._5V;

            [RestfulProperties("Module Status Output")]
            public ModuleStatusOutput ModuleStatusOutput { get; set; } = ModuleStatusOutput.OpenCircuit;
        }

        [Serializable]
        public class MirrorLeftModuleSettings : ISettings
        {
        }

        [Serializable]
        public class StreamingSettings : ISettings
        {

            [RestfulProperties("Fallback Mode")]
            public Fallback Fallback { get; set; } = Fallback.FadeToZero;

            [RestfulProperties("Output Voltage Level")]
            public OutputVoltageLevel OutputVoltageLevel { get; set; } = OutputVoltageLevel._5V;

            [RestfulProperties("Module Status Output")]
            public ModuleStatusOutput ModuleStatusOutput { get; set; } = ModuleStatusOutput.OpenCircuit;
        }

        [Serializable]
        public class BufferedSettings : ISettings
        {

            [RestfulProperties("Sample Count")]
            public UInt32 SampleCount { get; set; } = 1024;

            [RestfulProperties("Output Voltage Level")]
            public OutputVoltageLevel OutputVoltageLevel { get; set; } = OutputVoltageLevel._5V;

            [RestfulProperties("Module Status Output")]
            public ModuleStatusOutput ModuleStatusOutput { get; set; } = ModuleStatusOutput.OpenCircuit;
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
                Settings = Setting.ConvertFrom(new ALO450ChannelOperationMode() {OperationMode = operationMode}),
            };
            
            base.PutItemOperationMode(operationModeSettings);
        }

        public new OperationMode GetItemOperationMode()
        {
            var jsonObject = base.GetItemOperationMode();
            return Setting.ConvertTo<ALO450ChannelOperationMode>(jsonObject.Settings).OperationMode;
        }

        public class PortJson
        {
        public UInt32 Port { get; set; }
        }

        public UInt32 GetPortNumber()
        {
            return RestInterface.Get<PortJson>(EndPoints.AloPort, HttpParameter.ItemId(ItemId)).Port;
        }

        public void ClearData()
        {
            RestInterface.Put(EndPoints.AloClearData, HttpParameter.ItemId(ItemId));
        }
    }
}
