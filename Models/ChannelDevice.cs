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

namespace QProtocol.Models
{
    [Serializable]
    public class ChannelDeviceInterface
    {
        public const System.Int32 MaxTedsSizeInBytes = 64;
        public const System.Int32 InvalidTestNumber = -1;
        public const System.Int32 InvalidHardwareChannelIndex = -2;

        public enum AutoZeroLevel
        {
            [RestfulProperties("Disabled")]
            Disabled = 0,

            [RestfulProperties("System and Sensor")]
            SystemAndSensor = 1,

            [RestfulProperties("System only")]
            SystemOnly = 2,
        }

        public enum AutoZeroAverageTime
        {
            [RestfulProperties("Quick", 0.1, "s")]
            Quick = 0,

            [RestfulProperties("1 second average", 1, "s")]
            _1Second = 1,

            [RestfulProperties("2 second average", 2, "s")]
            _2Seconds = 2,

            [RestfulProperties("5 second average", 5, "s")]
            _5Seconds = 3,
        }

        [Serializable]
        public class AutoZeroSettings
        {
            [RestfulProperties("Auto-Zero Level")]
            public AutoZeroLevel AutoZeroLevel { get; set; }

            [RestfulProperties("Auto-Zero Average Time")]
            public AutoZeroAverageTime AutoZeroAverageTime { get; set; }
        }

        [Serializable]
        public class SnapshotSettings
        {
            [RestfulProperties("StreamingEnabled")]
            public Boolean StreamingEnabled { get; set; }
        }

        public struct CalibrationValuesChannelNumberAsInt32
        {
            public const Int32 UpperLimit = 8;
            public const Int32 LowerLimit = 0;
        }

        public struct CalibrationValuesOffsetCorrectionAsSingle
        {
            public const Single UpperLimit = 10F;
            public const Single LowerLimit = -10F;
        }

        public struct CalibrationValuesGainCorrectionMsr131072AsSingle
        {
            public const Single UpperLimit = 10F;
            public const Single LowerLimit = -10F;
        }

        public struct CalibrationValuesGainCorrectionMsr204800AsSingle
        {
            public const Single UpperLimit = 10F;
            public const Single LowerLimit = -10F;
        }

        [Serializable]
        public class CalibrationValues
        {
            [RestfulProperties("Channel Number")]
            public Int32 ChannelNumber { get; set; }

            [RestfulProperties("DAC Voltage Range")]
            public ModuleDevice.DacVoltage DacVoltageRange { get; set; }

            [RestfulProperties("Offset Correction")]
            public Single OffsetCorrection { get; set; }

            [RestfulProperties("Gain Correction at 131072")]
            public Single GainCorrectionMsr131072 { get; set; }

            [RestfulProperties("Gain Correction at 204800")]
            public Single GainCorrectionMsr204800 { get; set; }
        }
    }
}
