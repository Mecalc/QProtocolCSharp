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

namespace QProtocol.InternalModules.ICT
{
    [Serializable]
    public class ICT426Module : Item
    {
        public ICT426Module(Item itemInfo)
            : base(itemInfo)
        {
        }

        public const System.Int32 NumberOfChannelsOnModule = 4;
        public const System.Int32 NumberOfIcpChannelsOnModule = 2;
        public const System.Int32 NumberOfTachoChannelsOnModule = 2;
        public const System.Int32 IndexOfTheFirstIcpChannel = 0;
        public const System.Int32 IndexOfTheFirstTachoChannel = 4;
        public const System.Int32 IndexOfTheFirstScopeChannel = 2;

        public enum IcpChannelSampleRate
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

        public enum TachoChannelInputBiasing
        {
            [RestfulProperties("Differential")]
            Differential = 0,

            [RestfulProperties("Single Ended")]
            SingleEnded = 1,
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
        public class ICT426ModuleOperationMode
        {
            [RestfulProperties("Operation Mode")]
            public OperationMode OperationMode { get; set; } = OperationMode.Enabled;
        }

        [Serializable]
        public class EnabledSettings : ISettings
        {

            [RestfulProperties("ICP Channel Sample Rate")]
            public IcpChannelSampleRate IcpChannelSampleRate { get; set; } = IcpChannelSampleRate.MsrDivideBy256;

            [RestfulProperties("Grounding")]
            public Grounding Grounding { get; set; } = Grounding.Floating;

            [RestfulProperties("Tacho Channel Input Biasing")]
            public TachoChannelInputBiasing TachoChannelInputBiasing { get; set; } = TachoChannelInputBiasing.SingleEnded;
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
            return Setting.ConvertTo<ICT426ModuleOperationMode>(jsonObject.Settings).OperationMode;
        }

        public void PutItemOperationMode(OperationMode operationMode)
        {
            var operationModeSettings = new ItemOperationMode(this)
            {
                Settings = Setting.ConvertFrom(new ICT426ModuleOperationMode() {OperationMode = operationMode}),
            };
            
            base.PutItemOperationMode(operationModeSettings);
        }
    }
}
