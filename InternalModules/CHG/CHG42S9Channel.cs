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

namespace QProtocol.InternalModules.CHG
{
    [Serializable]
    public class CHG42S9Channel : DataChannelItem
    {
        public CHG42S9Channel(Item itemInfo)
            : base(itemInfo)
        {
        }


        public enum OperationMode
        {
            [RestfulProperties("Disabled")]
            Disabled = 0,

            [RestfulProperties("Charge Input")]
            ChargeInput = 1,
        }

        public enum VoltageRange
        {
            [RestfulProperties("100 mV", 0.1, "V")]
            _100mV = 0,

            [RestfulProperties("1 V", 1, "V")]
            _1V = 1,

            [RestfulProperties("10 V", 10, "V")]
            _10V = 2,
        }

        public enum InputCoupling
        {
            [RestfulProperties("No Filter")]
            NoFilter = 0,

            [RestfulProperties("1 Hz Filter")]
            _1HzFilter = 1,
        }

        public enum CableShieldGrounding
        {
            [RestfulProperties("Floating")]
            Floating = 0,

            [RestfulProperties("Grounded")]
            Grounded = 1,
        }

        public enum ChargeSensitivity
        {
            [RestfulProperties("100 µV/pC", 0.1, "")]
            _10uVppC = 0,

            [RestfulProperties("1 mV/pC", 1, "")]
            _1mVppC = 1,

            [RestfulProperties("10 mV/pC", 10, "")]
            _10mVppC = 2,
        }

        public interface ISettings
        {
        }

        [Serializable]
        public class CHG42S9ChannelOperationMode
        {
            [RestfulProperties("Operation Mode")]
            public OperationMode OperationMode { get; set; } = OperationMode.ChargeInput;
        }

        [Serializable]
        public class ChargeInputSettings : ISettings
        {

            [RestfulProperties("Voltage Range")]
            public VoltageRange VoltageRange { get; set; } = VoltageRange._10V;

            [RestfulProperties("Charge Sensitivity")]
            public ChargeSensitivity ChargeSensitivity { get; set; } = ChargeSensitivity._1mVppC;

            [RestfulProperties("Cable Shield Grounding")]
            public CableShieldGrounding CableShieldGrounding { get; set; } = CableShieldGrounding.Floating;

            [RestfulProperties("Input Coupling")]
            public InputCoupling InputCoupling { get; set; } = InputCoupling._1HzFilter;
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
                Settings = Setting.ConvertFrom(new CHG42S9ChannelOperationMode() {OperationMode = operationMode}),
            };
            
            base.PutItemOperationMode(operationModeSettings);
        }

        public new OperationMode GetItemOperationMode()
        {
            var jsonObject = base.GetItemOperationMode();
            return Setting.ConvertTo<CHG42S9ChannelOperationMode>(jsonObject.Settings).OperationMode;
        }

        public Models.ChannelDeviceInterface.AutoZeroSettings GetAutoZeroSettings()
        {
            var jsonObject = RestInterface.Get<AutoZeroSettings>(EndPoints.AutoZeroSettings, HttpParameter.ItemId(ItemId));
            return Setting.ConvertTo<Models.ChannelDeviceInterface.AutoZeroSettings>(jsonObject.Settings);
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
