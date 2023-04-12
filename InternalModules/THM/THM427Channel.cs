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

namespace QProtocol.InternalModules.THM
{
    [Serializable]
    public class THM427Channel : DataChannelItem
    {
        public THM427Channel(Item itemInfo)
            : base(itemInfo)
        {
        }


        public enum OperationMode
        {
            [RestfulProperties("Disabled")]
            Disabled = 0,

            [RestfulProperties("Voltage Input")]
            VoltageInput = 1,

            [RestfulProperties("Thermocouple Type E Input")]
            ThermocoupleTypeEInput = 2,

            [RestfulProperties("Thermocouple Type J Input")]
            ThermocoupleTypeJInput = 3,

            [RestfulProperties("Thermocouple Type K Input")]
            ThermocoupleTypeKInput = 4,

            [RestfulProperties("Thermocouple Type T Input")]
            ThermocoupleTypeTInput = 5,

            [RestfulProperties("Thermocouple Type U Input")]
            ThermocoupleTypeUInput = 6,

            [RestfulProperties("PT100 Input")]
            Pt100Input = 7,
        }

        public enum VoltageRange
        {
            [RestfulProperties("100 mV", 0.1, "V")]
            _100mV = 0,

            [RestfulProperties("10 V", 10, "V")]
            _10V = 1,
        }

        public enum TemperatureModeVoltageRange
        {
            [RestfulProperties("100 mV")]
            _100mV = 0,
        }

        public enum TemperatureSIUnits
        {
            [RestfulProperties("Celsius")]
            Celsius = 0,

            [RestfulProperties("Kelvin")]
            Kelvin = 1,
        }

        public interface ISettings
        {
        }

        [Serializable]
        public class THM427ChannelOperationMode
        {
            [RestfulProperties("Operation Mode")]
            public OperationMode OperationMode { get; set; } = OperationMode.VoltageInput;
        }

        [Serializable]
        public class VoltageInputSettings : ISettings
        {

            [RestfulProperties("Voltage Range")]
            public VoltageRange VoltageRange { get; set; } = VoltageRange._10V;
        }

        [Serializable]
        public class ThermocoupleTypeEInput : ISettings
        {

            [RestfulProperties("Voltage Range")]
            public TemperatureModeVoltageRange TemperatureModeVoltageRange { get; set; } = TemperatureModeVoltageRange._100mV;

            [RestfulProperties("Temperature SI Unit")]
            public TemperatureSIUnits TemperatureSIUnits { get; set; } = TemperatureSIUnits.Celsius;
        }

        [Serializable]
        public class ThermocoupleTypeJInput : ISettings
        {

            [RestfulProperties("Voltage Range")]
            public TemperatureModeVoltageRange TemperatureModeVoltageRange { get; set; } = TemperatureModeVoltageRange._100mV;

            [RestfulProperties("Temperature SI Unit")]
            public TemperatureSIUnits TemperatureSIUnits { get; set; } = TemperatureSIUnits.Celsius;
        }

        [Serializable]
        public class ThermocoupleTypeKInput : ISettings
        {

            [RestfulProperties("Voltage Range")]
            public TemperatureModeVoltageRange TemperatureModeVoltageRange { get; set; } = TemperatureModeVoltageRange._100mV;

            [RestfulProperties("Temperature SI Unit")]
            public TemperatureSIUnits TemperatureSIUnits { get; set; } = TemperatureSIUnits.Celsius;
        }

        [Serializable]
        public class ThermocoupleTypeTInput : ISettings
        {

            [RestfulProperties("Voltage Range")]
            public TemperatureModeVoltageRange TemperatureModeVoltageRange { get; set; } = TemperatureModeVoltageRange._100mV;

            [RestfulProperties("Temperature SI Unit")]
            public TemperatureSIUnits TemperatureSIUnits { get; set; } = TemperatureSIUnits.Celsius;
        }

        [Serializable]
        public class ThermocoupleTypeUInput : ISettings
        {

            [RestfulProperties("Voltage Range")]
            public TemperatureModeVoltageRange TemperatureModeVoltageRange { get; set; } = TemperatureModeVoltageRange._100mV;

            [RestfulProperties("Temperature SI Unit")]
            public TemperatureSIUnits TemperatureSIUnits { get; set; } = TemperatureSIUnits.Celsius;
        }

        [Serializable]
        public class Pt100Input : ISettings
        {

            [RestfulProperties("Voltage Range")]
            public TemperatureModeVoltageRange TemperatureModeVoltageRange { get; set; } = TemperatureModeVoltageRange._100mV;

            [RestfulProperties("Temperature SI Unit")]
            public TemperatureSIUnits TemperatureSIUnits { get; set; } = TemperatureSIUnits.Celsius;
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
                Settings = Setting.ConvertFrom(new THM427ChannelOperationMode() {OperationMode = operationMode}),
            };
            
            base.PutItemOperationMode(operationModeSettings);
        }

        public new OperationMode GetItemOperationMode()
        {
            var jsonObject = base.GetItemOperationMode();
            return Setting.ConvertTo<THM427ChannelOperationMode>(jsonObject.Settings).OperationMode;
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
