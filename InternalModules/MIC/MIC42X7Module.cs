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

namespace QProtocol.InternalModules.MIC
{
    [Serializable]
    public class MIC42X7Module : Item
    {
        public MIC42X7Module(Item itemInfo)
            : base(itemInfo)
        {
        }

        public const System.Int32 NumberOfChannelsOnModule = 2;

        public enum SampleRate
        {
            [RestfulProperties("MSR Divide by 1", 1, "")]
            MsrDivideBy1 = 0,

            [RestfulProperties("MSR Divide by 2", 2, "")]
            MsrDivideBy2 = 1,

            [RestfulProperties("MSR Divide by 4", 4, "")]
            MsrDivideBy4 = 2,

            [RestfulProperties("MSR Divide by 8", 8, "")]
            MsrDivideBy8 = 3,

            [RestfulProperties("MSR Divide by 16", 16, "")]
            MsrDivideBy16 = 4,

            [RestfulProperties("MSR Divide by 32", 32, "")]
            MsrDivideBy32 = 5,

            [RestfulProperties("MSR Divide by 64", 64, "")]
            MsrDivideBy64 = 6,

            [RestfulProperties("MSR Divide by 128", 128, "")]
            MsrDivideBy128 = 7,

            [RestfulProperties("MSR Divide by 256", 256, "")]
            MsrDivideBy256 = 8,
        }

        public enum Grounding
        {
            [RestfulProperties("Floating")]
            Floating = 0,

            [RestfulProperties("Grounded")]
            Grounded = 1,
        }

        public enum PolarizationVoltage
        {
            [RestfulProperties("Disabled")]
            Disabled = 0,

            [RestfulProperties("Enabled")]
            Enabled = 1,
        }

        public enum OperationMode
        {
            [RestfulProperties("Disabled")]
            Disabled = 0,

            [RestfulProperties("Enabled")]
            Enabled = 1,
        }

        public struct SettingsCalibrationSignalAmplitudeAsDouble
        {
            public const Double UpperLimit = 10;
            public const Double LowerLimit = 0;
        }

        public struct SettingsCalibrationSignalFrequencyAsDouble
        {
            public const Double UpperLimit = 10000;
            public const Double LowerLimit = 0;
        }

        public interface ISettings
        {
        }

        [Serializable]
        public class MIC42X7ModuleOperationMode
        {
            [RestfulProperties("Operation Mode")]
            public OperationMode OperationMode { get; set; } = OperationMode.Enabled;
        }

        [Serializable]
        public class EnabledSettings : ISettings
        {

            [RestfulProperties("Sample Rate")]
            public SampleRate SampleRate { get; set; } = SampleRate.MsrDivideBy256;

            [RestfulProperties("Grounding")]
            public Grounding Grounding { get; set; } = Grounding.Floating;

            [RestfulProperties("200 V Polarization Voltage")]
            public PolarizationVoltage PolarizationVoltage { get; set; } = PolarizationVoltage.Disabled;

            [RestfulProperties("Calibration Signal Amplitude")]
            public Double CalibrationSignalAmplitude { get; set; } = 0;

            [RestfulProperties("Calibration Signal Frequency")]
            public Double CalibrationSignalFrequency { get; set; } = 0;
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
                Settings = Setting.ConvertFrom(new MIC42X7ModuleOperationMode() {OperationMode = operationMode}),
            };
            
            base.PutItemOperationMode(operationModeSettings);
        }

        public new OperationMode GetItemOperationMode()
        {
            var jsonObject = base.GetItemOperationMode();
            return Setting.ConvertTo<MIC42X7ModuleOperationMode>(jsonObject.Settings).OperationMode;
        }
    }
}
