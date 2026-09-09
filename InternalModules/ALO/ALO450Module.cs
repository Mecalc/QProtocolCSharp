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
    public class ALO450Module : Item
    {
        public ALO450Module(Item itemInfo)
            : base(itemInfo)
        {
        }

        public const System.Int32 NumberOfChannelsOnModule = 4;

        public enum Grounding
        {
            [RestfulProperties("Floating")]
            Floating = 0,

            [RestfulProperties("Grounded")]
            Grounded = 1,
        }

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
        }

        public enum OperationMode
        {
            [RestfulProperties("Disabled")]
            Disabled = 0,

            [RestfulProperties("Enabled")]
            Enabled = 1,

            [RestfulProperties("Mirror Left Module")]
            MirrorLeftModule = 2,

            [RestfulProperties("Arbitrary Waveform")]
            ArbitraryWaveform = 3,
        }

        public interface ISettings
        {
        }

        [Serializable]
        public class ALO450ModuleOperationMode
        {
            [RestfulProperties("Operation Mode")]
            public OperationMode OperationMode { get; set; } = OperationMode.Enabled;
        }

        [Serializable]
        public class EnabledSettings : ISettings
        {

            [RestfulProperties("Grounding")]
            public Grounding Grounding { get; set; } = Grounding.Floating;
        }

        [Serializable]
        public class MirrorLeftModuleSettings : ISettings
        {

            [RestfulProperties("Grounding")]
            public Grounding Grounding { get; set; } = Grounding.Floating;
        }

        [Serializable]
        public class ArbitraryWaveformSettings : ISettings
        {

            [RestfulProperties("Sample Rate")]
            public SampleRate SampleRate { get; set; } = SampleRate.MsrDivideBy64;

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
                Settings = Setting.ConvertFrom(new ALO450ModuleOperationMode() {OperationMode = operationMode}),
            };
            
            base.PutItemOperationMode(operationModeSettings);
        }

        public new OperationMode GetItemOperationMode()
        {
            var jsonObject = base.GetItemOperationMode();
            return Setting.ConvertTo<ALO450ModuleOperationMode>(jsonObject.Settings).OperationMode;
        }

        public class BlockSizeJson
        {
        public UInt32 BlockSize { get; set; }
        }

        public UInt32 GetBlockSize()
        {
            return RestInterface.Get<BlockSizeJson>(EndPoints.AloBlockSize, HttpParameter.ItemId(ItemId)).BlockSize;
        }
    }
}
