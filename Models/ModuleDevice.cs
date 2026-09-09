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
    public class ModuleDevice
    {

        public enum DacVoltage
        {
            [RestfulProperties("Highest")]
            _0_Highest = 0,

            [RestfulProperties("Second Highest")]
            _1 = 1,

            [RestfulProperties("Third Highest")]
            _2 = 2,

            [RestfulProperties("Fourth Highest")]
            _3 = 3,

            [RestfulProperties("Fifth Highest")]
            _4 = 4,

            [RestfulProperties("Sixth Highest")]
            _5 = 5,

            [RestfulProperties("Seventh Highest")]
            _6 = 6,

            [RestfulProperties("Lowest")]
            _7_Lowest = 7,
        }

        public enum FunctionSettlingTime
        {
            [RestfulProperties("No delay", 0, "s")]
            NoDelay = 0,

            [RestfulProperties("1 ss delay", 1, "s")]
            _1Second = 1,

            [RestfulProperties("2 s delay", 2, "s")]
            _2Seconds = 2,

            [RestfulProperties("5 s delay", 5, "s")]
            _5Seconds = 3,
        }

        public enum AveragerDelay
        {
            [RestfulProperties("No delay", 0, "s")]
            NoDelay = 0,

            [RestfulProperties("1 s delay", 1, "s")]
            _1Second = 1,

            [RestfulProperties("2 s delay", 2, "s")]
            _2Seconds = 2,

            [RestfulProperties("5 s delay", 5, "s")]
            _5Seconds = 3,
        }

        public enum FullCalibration
        {
            [RestfulProperties("Offset Calibration", 0, "")]
            OffsetCalibration = 0,

            [RestfulProperties("131072 Gain Calibration", 1, "")]
            _131072GainCalibration = 1,

            [RestfulProperties("204800 Gain Calibration", 2, "")]
            _204800GainCalibration = 2,
        }

        public enum CalibrationFlag
        {
            [RestfulProperties("Set")]
            Set = 0,

            [RestfulProperties("Clear")]
            Clear = 1,
        }

        public enum FrontPanelType
        {
            [RestfulProperties("Error/Cannot Detect")]
            ErrorOrUndetected = 0,

            [RestfulProperties("ICM45 - 4x MMCXV + 1x 9-pin LEMO")]
            ICM45 = 1,

            [RestfulProperties("ICS45 - 6x MMCXV")]
            ICS45_MMCXV = 2,

            [RestfulProperties("ICS45 - 2x 9-pin LEMO")]
            ICS45_Lemo9Pin = 3,

            [RestfulProperties("ICS45 - 1x DB26")]
            ICS45_DB26 = 4,

            [RestfulProperties("ICT45 - 2x 3-pin LEMO + 2x 4-pin LEMO")]
            ICT45 = 5,

            [RestfulProperties("ICP45 - 4x 3-pin LEMO")]
            ICP45 = 6,

            [RestfulProperties("CHM45 - 4x MMCXV + 1x 9-pin LEMO")]
            CHM45 = 7,

            [RestfulProperties("CHS45 - 6x MMCXV")]
            CHS45_MMCXV = 8,

            [RestfulProperties("CHS45 - 4x 9-pin LEMO")]
            CHS45_Lemo9Pin = 9,

            [RestfulProperties("MIC45 - 2x 7-pin LEMO")]
            MIC45 = 10,

            [RestfulProperties("VIM45 - 6x MMCXV")]
            VIM45 = 11,

            [RestfulProperties("WSB45 - 4x 9-pin LEMO")]
            WSB45 = 12,

            [RestfulProperties("WSB45X - 4x 9-pin LEMO")]
            WSB45X = 13,

            [RestfulProperties("UTM45 - 4x 9-pin LEMO")]
            UTM45 = 14,

            [RestfulProperties("SCC45 - 2x 4-pin LEMO + 2x 9-pin LEMO")]
            SCC45_Mixed = 15,

            [RestfulProperties("SCC45 - 4x SMB")]
            SCC45_SMB = 16,
        }

        [Serializable]
        public class CalibrationSettings
        {
            [RestfulProperties("Function Settling Time")]
            public ModuleDevice.FunctionSettlingTime FunctionSettlingTime { get; set; }

            [RestfulProperties("Average Delay")]
            public ModuleDevice.AveragerDelay AveragerDelay { get; set; }

            [RestfulProperties("Master Sampling Rate")]
            public Controllers.Controller.MasterSamplingRate MasterSamplingRate { get; set; }
        }

        public struct DacVoltageSettingValueAsSingle
        {
            public const Single UpperLimit = 100F;
            public const Single LowerLimit = -100F;
        }

        [Serializable]
        public class DacVoltageSetting
        {
            [RestfulProperties("Value")]
            public Single Value { get; set; }

            [RestfulProperties("DAC Voltage")]
            public ModuleDevice.DacVoltage DacVoltage { get; set; }
        }

        [Serializable]
        public class FrontPanelInfo
        {
            [RestfulProperties("Front Panel Type")]
            public ModuleDevice.FrontPanelType FrontPanelType { get; set; }
        }

        public struct BasicCalibrationInfoYearAsInt32
        {
            public const Int32 UpperLimit = 3000;
            public const Int32 LowerLimit = 1970;
        }

        public struct BasicCalibrationInfoMonthAsInt32
        {
            public const Int32 UpperLimit = 12;
            public const Int32 LowerLimit = 1;
        }

        public struct BasicCalibrationInfoDayAsInt32
        {
            public const Int32 UpperLimit = 32;
            public const Int32 LowerLimit = 1;
        }

        [Serializable]
        public class BasicCalibrationInfo
        {
            [RestfulProperties("Calibration Flag")]
            public ModuleDevice.CalibrationFlag Flag { get; set; }

            [RestfulProperties("Year")]
            public Int32 Year { get; set; }

            [RestfulProperties("Month")]
            public Int32 Month { get; set; }

            [RestfulProperties("Day")]
            public Int32 Day { get; set; }
        }

        public struct DCatCalibrationInfoYearAsInt32
        {
            public const Int32 UpperLimit = 3000;
            public const Int32 LowerLimit = 1970;
        }

        public struct DCatCalibrationInfoMonthAsInt32
        {
            public const Int32 UpperLimit = 12;
            public const Int32 LowerLimit = 1;
        }

        public struct DCatCalibrationInfoDayAsInt32
        {
            public const Int32 UpperLimit = 32;
            public const Int32 LowerLimit = 1;
        }

        public struct DCatCalibrationInfoConversionFactorAsInt32
        {
            public const Int32 UpperLimit = 255;
            public const Int32 LowerLimit = 0;
        }

        [Serializable]
        public class DCatCalibrationInfo
        {
            [RestfulProperties("Calibration Flag")]
            public ModuleDevice.CalibrationFlag Flag { get; set; }

            [RestfulProperties("Year")]
            public Int32 Year { get; set; }

            [RestfulProperties("Month")]
            public Int32 Month { get; set; }

            [RestfulProperties("Day")]
            public Int32 Day { get; set; }

            [RestfulProperties("Conversion Factor")]
            public Int32 ConversionFactor { get; set; }
        }
    }
}
