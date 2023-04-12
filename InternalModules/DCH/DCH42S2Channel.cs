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

namespace QProtocol.InternalModules.DCH
{
    [Serializable]
    public class DCH42S2Channel : DataChannelItem
    {
        public DCH42S2Channel(Item itemInfo)
            : base(itemInfo)
        {
        }


        public enum OperationMode
        {
            [RestfulProperties("Disabled")]
            Disabled = 0,

            [RestfulProperties("Differential Input")]
            DifferentialInput = 1,

            [RestfulProperties("Single Ended Input")]
            SingleEndedInput = 2,
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

        public enum InputBiasing
        {
            [RestfulProperties("Differential")]
            Differential = 0,

            [RestfulProperties("Single Ended")]
            SingleEnded = 1,
        }

        public enum InputCoupling
        {
            [RestfulProperties("DC")]
            Dc = 0,

            [RestfulProperties("1 Hz Filter")]
            _1HzFilter = 1,
        }

        public enum TimeConstantResistor
        {
            [RestfulProperties("100 MΩ")]
            _100Mohm = 0,

            [RestfulProperties("1 GΩ")]
            _1Gohm = 1,
        }

        public enum DifferentialChargeSensitivity
        {
            [RestfulProperties("200 µV/pC", 0.2, "")]
            _200uVppC = 0,

            [RestfulProperties("2 mV/pC", 2, "")]
            _2mVppC = 1,
        }

        public enum SingleEndedChargeSensitivity
        {
            [RestfulProperties("100 µV/pC", 0.1, "")]
            _100uVppC = 0,

            [RestfulProperties("1 mV/pC", 1, "")]
            _1mVppC = 1,
        }

        public interface ISettings
        {
        }

        [Serializable]
        public class DCH42S2ChannelOperationMode
        {
            [RestfulProperties("Operation Mode")]
            public OperationMode OperationMode { get; set; } = OperationMode.DifferentialInput;
        }

        [Serializable]
        public class DifferentialInputSettings : ISettings
        {

            [RestfulProperties("Voltage Range")]
            public VoltageRange VoltageRange { get; set; } = VoltageRange._10V;

            [RestfulProperties("Coupling")]
            public InputCoupling InputCoupling { get; set; } = InputCoupling.Dc;

            [RestfulProperties("Charge Sensitivity")]
            public DifferentialChargeSensitivity DifferentialChargeSensitivity { get; set; } = DifferentialChargeSensitivity._2mVppC;

            [RestfulProperties("Time Constant Resistor")]
            public TimeConstantResistor TimeConstantResistor { get; set; } = TimeConstantResistor._100Mohm;
        }

        [Serializable]
        public class SingleEndedInputSettings : ISettings
        {

            [RestfulProperties("Voltage Range")]
            public VoltageRange VoltageRange { get; set; } = VoltageRange._10V;

            [RestfulProperties("Coupling")]
            public InputCoupling InputCoupling { get; set; } = InputCoupling.Dc;

            [RestfulProperties("Charge Sensitivity")]
            public SingleEndedChargeSensitivity SingleEndedChargeSensitivity { get; set; } = SingleEndedChargeSensitivity._1mVppC;

            [RestfulProperties("Time Constant Resistor")]
            public TimeConstantResistor TimeConstantResistor { get; set; } = TimeConstantResistor._100Mohm;
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
                Settings = Setting.ConvertFrom(new DCH42S2ChannelOperationMode() {OperationMode = operationMode}),
            };
            
            base.PutItemOperationMode(operationModeSettings);
        }

        public new OperationMode GetItemOperationMode()
        {
            var jsonObject = base.GetItemOperationMode();
            return Setting.ConvertTo<DCH42S2ChannelOperationMode>(jsonObject.Settings).OperationMode;
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
