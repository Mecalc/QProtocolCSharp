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

namespace QProtocol.InternalModules.ICP
{
    [Serializable]
    public class ICP4211Module : Item
    {
        public ICP4211Module(Item itemInfo)
            : base(itemInfo)
        {
        }

        public const System.Int32 NumberOfChannelsOnModule = 4;

        public enum SampleRate
        {
            [RestfulProperties("MSR Divide by 2", 2, "")]
            MsrDivideBy2 = 0,

            [RestfulProperties("MSR Divide by 4", 4, "")]
            MsrDivideBy4 = 1,

            [RestfulProperties("MSR Divide by 8", 8, "")]
            MsrDivideBy8 = 2,

            [RestfulProperties("MSR Divide by 16", 16, "")]
            MsrDivideBy16 = 3,

            [RestfulProperties("MSR Divide by 32", 32, "")]
            MsrDivideBy32 = 4,

            [RestfulProperties("MSR Divide by 64", 64, "")]
            MsrDivideBy64 = 5,

            [RestfulProperties("MSR Divide by 128", 128, "")]
            MsrDivideBy128 = 6,

            [RestfulProperties("MSR Divide by 256", 256, "")]
            MsrDivideBy256 = 7,
        }

        public enum Grounding
        {
            [RestfulProperties("Floating")]
            Floating = 0,

            [RestfulProperties("Grounded")]
            Grounded = 1,
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
        public class ICP4211ModuleOperationMode
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
        }

        [Serializable]
        public class SettingsCollection<T>
            where T : ISettings
        {
            public T Settings { get; set; }

            public Data Data { get; set; }
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
            return Setting.ConvertTo<ICP4211ModuleOperationMode>(jsonObject.Settings).OperationMode;
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

        public void PutItemOperationMode(OperationMode operationMode)
        {
            var operationModeSettings = new ItemOperationMode(this)
            {
                Settings = Setting.ConvertFrom(new ICP4211ModuleOperationMode() {OperationMode = operationMode}),
            };
            
            base.PutItemOperationMode(operationModeSettings);
        }

        public void PutItemSettings<T>(SettingsCollection<T> settings)
            where T : ISettings
        {
            var jsonObject = new ItemSettings(this);
            jsonObject.UpdateFromSettings(settings.Settings);
            jsonObject.UpdateFromData(settings.Data);
            base.PutItemSettings(jsonObject);
        }
    }
}
