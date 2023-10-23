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
    public class MIC42X7Channel : DataChannelItem
    {
        public MIC42X7Channel(Item itemInfo)
            : base(itemInfo)
        {
        }


        public enum OperationMode
        {
            [RestfulProperties("Disabled")]
            Disabled = 0,

            [RestfulProperties("Voltage Input")]
            VoltageInput = 1,

            [RestfulProperties("ICP® Input")]
            IcpInput = 2,

            [RestfulProperties("Microphone Input")]
            MicrophoneInput = 3,
        }

        public enum VoltageRange
        {
            [RestfulProperties("120 mV", 0.12, "V")]
            _120mV = 0,

            [RestfulProperties("1.2 V", 1.2, "V")]
            _1200mV = 1,

            [RestfulProperties("12 V", 12, "V")]
            _12V = 2,
        }

        public enum VoltageInputBiasing
        {
            [RestfulProperties("Differential")]
            Differential = 0,

            [RestfulProperties("Single Ended")]
            SingleEnded = 1,
        }

        public enum VoltageInputCoupling
        {
            [RestfulProperties("DC")]
            Dc = 0,

            [RestfulProperties("AC")]
            Ac = 1,

            [RestfulProperties("AC With 1 Hz Filter")]
            AcWith1HzFilter = 2,
        }

        public enum IcpInputBiasing
        {
            [RestfulProperties("Single Ended")]
            SingleEnded = 0,
        }

        public enum IcpInputCoupling
        {
            [RestfulProperties("AC")]
            Ac = 0,

            [RestfulProperties("AC With 1 Hz Filter")]
            AcWith1HzFilter = 1,
        }

        public enum IcpInputCurrentSource
        {
            [RestfulProperties("4 mA", 0.004, "A")]
            _4mA = 0,

            [RestfulProperties("8 mA", 0.008, "A")]
            _8mA = 1,

            [RestfulProperties("12 mA", 0.012, "A")]
            _12mA = 2,
        }

        public enum MicrophoneInputBiasing
        {
            [RestfulProperties("Differential")]
            Differential = 0,

            [RestfulProperties("Single Ended")]
            SingleEnded = 1,
        }

        public enum MicrophoneInputCoupling
        {
            [RestfulProperties("DC")]
            Dc = 0,

            [RestfulProperties("AC")]
            Ac = 1,

            [RestfulProperties("AC With 1 Hz Filter")]
            AcWith1HzFilter = 2,
        }

        public enum MicrophoneInputPreampExcitation
        {
            [RestfulProperties("Enabled")]
            Enabled = 0,
        }

        public enum CableShieldGrounding
        {
            [RestfulProperties("Floating From Chassis")]
            Floating = 0,

            [RestfulProperties("Connected To Chassis")]
            Connected = 1,
        }

        public interface ISettings
        {
        }

        [Serializable]
        public class MIC42X7ChannelOperationMode
        {
            [RestfulProperties("Operation Mode")]
            public OperationMode OperationMode { get; set; } = OperationMode.VoltageInput;
        }

        [Serializable]
        public class VoltageInputSettings : ISettings
        {

            [RestfulProperties("Voltage Range")]
            public VoltageRange VoltageRange { get; set; } = VoltageRange._12V;

            [RestfulProperties("Input Biasing")]
            public VoltageInputBiasing VoltageInputBiasing { get; set; } = VoltageInputBiasing.Differential;

            [RestfulProperties("Coupling")]
            public VoltageInputCoupling VoltageInputCoupling { get; set; } = VoltageInputCoupling.Dc;

            [RestfulProperties("Cable Shield Grounding")]
            public CableShieldGrounding CableShieldGrounding { get; set; } = CableShieldGrounding.Connected;
        }

        [Serializable]
        public class IcpInputSettings : ISettings
        {

            [RestfulProperties("Voltage Range")]
            public VoltageRange VoltageRange { get; set; } = VoltageRange._12V;

            [RestfulProperties("Input Biasing")]
            public IcpInputBiasing IcpInputBiasing { get; set; } = IcpInputBiasing.SingleEnded;

            [RestfulProperties("Coupling")]
            public IcpInputCoupling IcpInputCoupling { get; set; } = IcpInputCoupling.AcWith1HzFilter;

            [RestfulProperties("Current Source")]
            public IcpInputCurrentSource IcpInputCurrentSource { get; set; } = IcpInputCurrentSource._4mA;

            [RestfulProperties("Cable Shield Grounding")]
            public CableShieldGrounding CableShieldGrounding { get; set; } = CableShieldGrounding.Connected;
        }

        [Serializable]
        public class MicrophoneInputSettings : ISettings
        {

            [RestfulProperties("Voltage Range")]
            public VoltageRange VoltageRange { get; set; } = VoltageRange._12V;

            [RestfulProperties("Input Biasing")]
            public MicrophoneInputBiasing MicrophoneInputBiasing { get; set; } = MicrophoneInputBiasing.Differential;

            [RestfulProperties("Coupling")]
            public MicrophoneInputCoupling MicrophoneInputCoupling { get; set; } = MicrophoneInputCoupling.AcWith1HzFilter;

            [RestfulProperties("Preamp Excitation")]
            public MicrophoneInputPreampExcitation MicrophoneInputPreampExcitation { get; set; } = MicrophoneInputPreampExcitation.Enabled;

            [RestfulProperties("Cable Shield Grounding")]
            public CableShieldGrounding CableShieldGrounding { get; set; } = CableShieldGrounding.Connected;
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
                Settings = Setting.ConvertFrom(new MIC42X7ChannelOperationMode() {OperationMode = operationMode}),
            };
            
            base.PutItemOperationMode(operationModeSettings);
        }

        public new OperationMode GetItemOperationMode()
        {
            var jsonObject = base.GetItemOperationMode();
            return Setting.ConvertTo<MIC42X7ChannelOperationMode>(jsonObject.Settings).OperationMode;
        }

        public Models.ChannelDeviceInterface.AutoZeroSettings GetAutoZeroSettings()
        {
            var jsonObject = RestInterface.Get<AutoZeroSettings>(EndPoints.AutoZeroSettings, HttpParameter.ItemId(ItemId));
            return Setting.ConvertTo<Models.ChannelDeviceInterface.AutoZeroSettings>(jsonObject.Settings);
        }

        public TedsInfo GetTedsInfo()
        {
            return RestInterface.Get<TedsInfo>(EndPoints.TedsInfo, HttpParameter.ItemId(ItemId));
        }

        public void PutAutoZeroSettings(Models.ChannelDeviceInterface.AutoZeroSettings settings)
        {
            var jsonObject = new AutoZeroSettings(this)
            {
                Settings = Setting.ConvertFrom(settings)
            };

            RestInterface.Put(EndPoints.AutoZeroSettings, jsonObject, HttpParameter.ItemId(ItemId));
        }

        public void PutAutoZeroSettingsApply()
        {
            RestInterface.Put(EndPoints.AutoZeroSettingsApply, HttpParameter.ItemId(ItemId));
        }
    }
}
