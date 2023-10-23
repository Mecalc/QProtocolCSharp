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

namespace QProtocol.DeviceFeatures
{
    [Serializable]
    public class LocalStorage
    {
        public const System.String DeviceS0p0_1 = "/s0p0:1";
        public const System.String DeviceS0p1_1 = "/s0p1:1";
        public const System.String DeviceS0p2_1 = "/s0p2:1";
        public const System.String DeviceSDHC = "/sd0:1";

        public enum Device
        {
            [RestfulProperties("/s0p0:1")]
            S0p0_1 = 0,

            [RestfulProperties("/s0p1:1")]
            S0p1_1 = 1,

            [RestfulProperties("/s0p2:1")]
            S0p2_1 = 2,

            [RestfulProperties("/sd0:1")]
            SDHC = 3,
        }

        public enum RecordingStates
        {
            [RestfulProperties("Stopped")]
            Stopped = 0,

            [RestfulProperties("Pre-run")]
            Prerun = 1,

            [RestfulProperties("Recording")]
            Recording = 2,
        }

        public struct SettingsPreRunDurationInSecondsAsSingle
        {
            public const Single UpperLimit = 3600F;
            public const Single LowerLimit = 0F;
        }

        [Serializable]
        public class Settings
        {
            [RestfulProperties("Pre-run Duration")]
            public Single PreRunDurationInSeconds { get; set; }

            [RestfulProperties("Measurement Name")]
            public String MeasurementName { get; set; }

            [RestfulProperties("Measurement Description")]
            public String MeasurementDescription { get; set; }
        }

        [Serializable]
        public class RecordingState
        {
            [RestfulProperties("RecordingState")]
            public RecordingStates CurrentState { get; set; }
        }

        [Serializable]
        public class RecordingStats
        {
            [RestfulProperties("ElapsedSeconds")]
            public UInt32 ElapsedSeconds { get; set; }

            [RestfulProperties("EstimatedSecondsLeft")]
            public UInt32 EstimatedSecondsLeft { get; set; }

            [RestfulProperties("UsagePercentage")]
            public UInt32 UsagePercentage { get; set; }
        }
    }
}
