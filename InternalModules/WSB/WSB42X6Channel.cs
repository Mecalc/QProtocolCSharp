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
    public class WSB42X6Channel : DataChannelItem
    {
        public WSB42X6Channel(Item itemInfo)
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

            [RestfulProperties("WSB Input: Voltage Excitation")]
            WsbInputVoltageExcitation = 3,

            [RestfulProperties("WSB Input: 4 Wire Current Excitation")]
            WsbInputFourWireCurrentExcitation = 4,

            [RestfulProperties("WSB Input: 2 Wire Current Excitation")]
            WsbInputTwoWireCurrentExcitation = 5,
        }

        public enum VoltageRange
        {
            [RestfulProperties("10 mV", 0.01, "V")]
            _10mV = 0,

            [RestfulProperties("100 mV", 0.1, "V")]
            _100mV = 1,

            [RestfulProperties("1 V", 1, "V")]
            _1V = 2,

            [RestfulProperties("10 V", 10, "V")]
            _10V = 3,
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

        public enum IcpInputCoupling
        {
            [RestfulProperties("AC")]
            Ac = 0,

            [RestfulProperties("AC with 1 Hz Filter")]
            AcWith1HzFilter = 1,
        }

        public enum VoltageInputCoupling
        {
            [RestfulProperties("DC")]
            Dc = 0,

            [RestfulProperties("AC")]
            Ac = 1,

            [RestfulProperties("AC with 1 Hz Filter")]
            AcWith1HzFilter = 2,
        }

        public enum BridgeMode
        {
            [RestfulProperties("Full Bridge")]
            Full = 0,

            [RestfulProperties("Half Bridge")]
            Half = 1,

            [RestfulProperties("Quarter Bridge 120 Ω")]
            Quarter120 = 2,

            [RestfulProperties("Quarter Bridge 350 Ω")]
            Quarter350 = 3,
        }

        public enum FourWireCurrentSourceBridgeMode
        {
            [RestfulProperties("Full Bridge")]
            Full = 0,

            [RestfulProperties("Quarter Bridge")]
            Quarter = 1,
        }

        public enum FourWireCurrentSource
        {
            [RestfulProperties("4 mA", 0.004, "A")]
            _4mA = 0,

            [RestfulProperties("8 mA", 0.008, "A")]
            _8mA = 1,

            [RestfulProperties("12 mA", 0.012, "A")]
            _12mA = 2,
        }

        public enum TwoWireCurrentSource
        {
            [RestfulProperties("4 mA", 0.004, "A")]
            _4mA = 0,

            [RestfulProperties("8 mA", 0.008, "A")]
            _8mA = 1,

            [RestfulProperties("12 mA", 0.012, "A")]
            _12mA = 2,
        }

        public enum ExcitationSensePoint
        {
            [RestfulProperties("External")]
            External = 0,

            [RestfulProperties("Internal")]
            Internal = 1,
        }

        public enum ShuntCalibrationResistor
        {
            [RestfulProperties("None")]
            None = 0,

            [RestfulProperties("4 Wire 100 kΩ")]
            _4Wire100kOhm = 1,

            [RestfulProperties("6 Wire 100 kΩ")]
            _6Wire100kOhm = 2,
        }

        public struct SettingsExcitationAmplitudeAsDouble
        {
            public const Double UpperLimit = 10;
            public const Double LowerLimit = 0;
        }

        public interface ISettings
        {
        }

        [Serializable]
        public class WSB42X6ChannelOperationMode
        {
            [RestfulProperties("Operation Mode")]
            public OperationMode OperationMode { get; set; } = OperationMode.VoltageInput;
        }

        [Serializable]
        public class VoltageInputSettings : ISettings
        {

            [RestfulProperties("Voltage Range")]
            public VoltageRange VoltageRange { get; set; } = VoltageRange._10V;

            [RestfulProperties("Coupling")]
            public VoltageInputCoupling VoltageInputCoupling { get; set; } = VoltageInputCoupling.Dc;
        }

        [Serializable]
        public class IcpInputSettings : ISettings
        {

            [RestfulProperties("Voltage Range")]
            public VoltageRange VoltageRange { get; set; } = VoltageRange._10V;

            [RestfulProperties("Current Source")]
            public IcpInputCurrentSource IcpInputCurrentSource { get; set; } = IcpInputCurrentSource._4mA;

            [RestfulProperties("Coupling")]
            public IcpInputCoupling IcpInputCoupling { get; set; } = IcpInputCoupling.AcWith1HzFilter;
        }

        [Serializable]
        public class WsbInputVoltageExcitationSettings : ISettings
        {

            [RestfulProperties("Voltage Range")]
            public VoltageRange VoltageRange { get; set; } = VoltageRange._10V;

            [RestfulProperties("Coupling")]
            public VoltageInputCoupling VoltageInputCoupling { get; set; } = VoltageInputCoupling.Dc;

            [RestfulProperties("Bridge Mode")]
            public BridgeMode BridgeMode { get; set; } = BridgeMode.Full;

            [RestfulProperties("Excitation Amplitude")]
            public Double ExcitationAmplitude { get; set; } = 0;

            [RestfulProperties("Excitation Sense Point")]
            public ExcitationSensePoint ExcitationSensePoint { get; set; } = ExcitationSensePoint.External;

            [RestfulProperties("Shunt Calibration Resistor")]
            public ShuntCalibrationResistor ShuntCalibrationResistor { get; set; } = ShuntCalibrationResistor.None;
        }

        [Serializable]
        public class WsbInputFourWireCurrentExcitationSettings : ISettings
        {

            [RestfulProperties("Voltage Range")]
            public VoltageRange VoltageRange { get; set; } = VoltageRange._10V;

            [RestfulProperties("Coupling")]
            public VoltageInputCoupling VoltageInputCoupling { get; set; } = VoltageInputCoupling.Dc;

            [RestfulProperties("Bridge Mode")]
            public FourWireCurrentSourceBridgeMode FourWireCurrentSourceBridgeMode { get; set; } = FourWireCurrentSourceBridgeMode.Full;

            [RestfulProperties("Excitation Source")]
            public FourWireCurrentSource FourWireCurrentSource { get; set; } = FourWireCurrentSource._4mA;
        }

        [Serializable]
        public class WsbInputTwoWireCurrentExcitationSettings : ISettings
        {

            [RestfulProperties("Voltage Range")]
            public VoltageRange VoltageRange { get; set; } = VoltageRange._10V;

            [RestfulProperties("Coupling")]
            public IcpInputCoupling IcpInputCoupling { get; set; } = IcpInputCoupling.AcWith1HzFilter;

            [RestfulProperties("Excitation Source")]
            public TwoWireCurrentSource TwoWireCurrentSource { get; set; } = TwoWireCurrentSource._4mA;
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
                Settings = Setting.ConvertFrom(new WSB42X6ChannelOperationMode() {OperationMode = operationMode}),
            };
            
            base.PutItemOperationMode(operationModeSettings);
        }

        public new OperationMode GetItemOperationMode()
        {
            var jsonObject = base.GetItemOperationMode();
            return Setting.ConvertTo<WSB42X6ChannelOperationMode>(jsonObject.Settings).OperationMode;
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
