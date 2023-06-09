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

namespace QProtocol.InternalModules.WSB
{
    [Serializable]
    public class WSB42X6Module : Item
    {
        public WSB42X6Module(Item itemInfo)
            : base(itemInfo)
        {
        }

        public const System.Int32 NumberOfChannelsOnModule = 4;
        public const System.Double RangeScale = 11.986385;
        public const System.Double GainScale0 = 11.986385;
        public const System.Double GainScale1 = 1.198639;
        public const System.Double GainScale2 = 0.147756;
        public const System.Double GainScale3 = 0.014776;

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

        public enum OperationMode
        {
            [RestfulProperties("Disabled")]
            Disabled = 0,

            [RestfulProperties("Enabled")]
            Enabled = 1,
        }

        public interface ISettings
        {
        }

        [Serializable]
        public class WSB42X6ModuleOperationMode
        {
            [RestfulProperties("Operation Mode")]
            public OperationMode OperationMode { get; set; } = OperationMode.Enabled;
        }

        [Serializable]
        public class EnabledSettings : ISettings
        {

            [RestfulProperties("Sample Rate")]
            public SampleRate SampleRate { get; set; } = SampleRate.MsrDivideBy256;
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
            return Setting.ConvertTo<WSB42X6ModuleOperationMode>(jsonObject.Settings).OperationMode;
        }

        public void PutItemOperationMode(OperationMode operationMode)
        {
            var operationModeSettings = new ItemOperationMode(this)
            {
                Settings = Setting.ConvertFrom(new WSB42X6ModuleOperationMode() {OperationMode = operationMode}),
            };
            
            base.PutItemOperationMode(operationModeSettings);
        }
    }
}
