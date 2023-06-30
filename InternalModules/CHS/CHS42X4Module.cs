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

namespace QProtocol.InternalModules.CHS
{
    [Serializable]
    public class CHS42X4Module : Item
    {
        public CHS42X4Module(Item itemInfo)
            : base(itemInfo)
        {
        }

        public const System.Int32 NumberOfChannelsOnModule = 6;
        public const System.Int32 NumberOfChannelGroups = 2;
        public const System.Int32 NumberOfChannelsInAGroup = 3;
        public const System.Int32 FirstChannelGroupStartIndex = 0;
        public const System.Int32 SecondChannelGroupStartIndex = 3;

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

        public enum BridgeNegativeChannels1And3
        {
            [RestfulProperties("Open")]
            Open = 0,

            [RestfulProperties("Closed")]
            Closed = 1,
        }

        public enum BridgeNegativeChannels4And6
        {
            [RestfulProperties("Open")]
            Open = 0,

            [RestfulProperties("Closed")]
            Closed = 1,
        }

        public enum HighSampleRate
        {
            [RestfulProperties("MSR Divide by 1", 1, "")]
            MsrDivideBy1 = 0,
        }

        public enum OperationMode
        {
            [RestfulProperties("Disabled")]
            Disabled = 0,

            [RestfulProperties("Enabled")]
            Enabled = 1,

            [RestfulProperties("Four Channel High Sample Rate")]
            EnableHighSampleRate = 2,
        }

        public interface ISettings
        {
        }

        [Serializable]
        public class CHS42X4ModuleOperationMode
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

            [RestfulProperties("Bridge Negative Channels 1:3")]
            public BridgeNegativeChannels1And3 BridgeNegativeChannels1And3 { get; set; } = BridgeNegativeChannels1And3.Open;

            [RestfulProperties("Bridge Negative Channels 4:6")]
            public BridgeNegativeChannels4And6 BridgeNegativeChannels4And6 { get; set; } = BridgeNegativeChannels4And6.Open;

            [RestfulProperties("Channel 1, 2 and 3 Operation Mode")]
            public InternalModules.CHS.CHS42X4Channel.OperationMode Channel123OperationMode { get; set; } = InternalModules.CHS.CHS42X4Channel.OperationMode.VoltageInput;

            [RestfulProperties("Channel 4, 5 and 6 Operation Mode")]
            public InternalModules.CHS.CHS42X4Channel.OperationMode Channel456OperationMode { get; set; } = InternalModules.CHS.CHS42X4Channel.OperationMode.VoltageInput;
        }

        [Serializable]
        public class EnableHighSampleRateSettings : ISettings
        {

            [RestfulProperties("High Sample Rate")]
            public HighSampleRate HighSampleRate { get; set; } = HighSampleRate.MsrDivideBy1;

            [RestfulProperties("Grounding")]
            public Grounding Grounding { get; set; } = Grounding.Floating;

            [RestfulProperties("Bridge Negative Channels 1:3")]
            public BridgeNegativeChannels1And3 BridgeNegativeChannels1And3 { get; set; } = BridgeNegativeChannels1And3.Open;

            [RestfulProperties("Bridge Negative Channels 4:6")]
            public BridgeNegativeChannels4And6 BridgeNegativeChannels4And6 { get; set; } = BridgeNegativeChannels4And6.Open;

            [RestfulProperties("Channel 1 and 3 Operation Mode")]
            public InternalModules.CHS.CHS42X4Channel.OperationMode Channel1And3OperationMode { get; set; } = InternalModules.CHS.CHS42X4Channel.OperationMode.VoltageInput;

            [RestfulProperties("Channel 4 and 6 Operation Mode")]
            public InternalModules.CHS.CHS42X4Channel.OperationMode Channel4And6OperationMode { get; set; } = InternalModules.CHS.CHS42X4Channel.OperationMode.VoltageInput;
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
            return Setting.ConvertTo<CHS42X4ModuleOperationMode>(jsonObject.Settings).OperationMode;
        }

        public void PutItemOperationMode(OperationMode operationMode)
        {
            var operationModeSettings = new ItemOperationMode(this)
            {
                Settings = Setting.ConvertFrom(new CHS42X4ModuleOperationMode() {OperationMode = operationMode}),
            };
            
            base.PutItemOperationMode(operationModeSettings);
        }
    }
}
