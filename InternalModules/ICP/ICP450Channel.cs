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
    public class ICP450Channel : DataChannelItem
    {
        public ICP450Channel(Item itemInfo)
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
        }

        public enum VCalMode
        {
            [RestfulProperties("Off")]
            Off = 0,

            [RestfulProperties("VCal = On, P = VCalMod, N = AGNDM")]
            VCalOn_PVCalMod_NAGNDM = 1,

            [RestfulProperties("VCal = On, P = AGNDM, N = VCalMod")]
            VCalOn_PAGNDM_NVCalMod = 2,

            [RestfulProperties("VCal = On, P = AGNDM, N = AGNDM")]
            VCalOn_PAGNDM_NAGNDM = 3,

            [RestfulProperties("VCal = On, P = TEDS, N = AGNDM")]
            VCalOn_PTEDS_NAGNDM = 4,

            [RestfulProperties("VCal = On, P = AGNDM, N = AGNDM Front-End Disconnected")]
            VCalOn_PAGNDM_NAGNDM_FrontEndDisconnected = 5,

            [RestfulProperties("VCal = Off, Front-End Connected")]
            VCalOff_FrontEndConnected = 6,
        }

        public enum VoltageInputVoltageRange
        {
            [RestfulProperties("1 V", 1, "V")]
            _1V = 0,

            [RestfulProperties("5 V", 5, "V")]
            _5V = 1,

            [RestfulProperties("10 V", 10, "V")]
            _10V = 2,

            [RestfulProperties("60 V", 60, "V")]
            _60V = 3,
        }

        public enum VoltageRange
        {
            [RestfulProperties("1 V", 1, "V")]
            _1V = 0,

            [RestfulProperties("5 V", 5, "V")]
            _5V = 1,

            [RestfulProperties("10 V", 10, "V")]
            _10V = 2,
        }

        public enum LedState
        {
            [RestfulProperties("Off")]
            Off = 0,

            [RestfulProperties("Red")]
            Red = 1,

            [RestfulProperties("Green")]
            Green = 2,

            [RestfulProperties("Blue")]
            Blue = 3,

            [RestfulProperties("Purple")]
            Purple = 4,

            [RestfulProperties("Orange")]
            Orange = 5,

            [RestfulProperties("Flashing")]
            Flashing = 6,
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

        public enum IcpInputCoupling
        {
            [RestfulProperties("AC")]
            Ac = 0,

            [RestfulProperties("AC with 1 Hz Filter")]
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

        public enum DacValueOnLemo
        {
            [RestfulProperties("0 V")]
            _0V = 0,

            [RestfulProperties("100 mV")]
            _100mV = 1,

            [RestfulProperties("1 V")]
            _1V = 2,

            [RestfulProperties("2.5 V")]
            _2_5V = 3,

            [RestfulProperties("5 V")]
            _5V = 4,
        }

        public enum InputBiasing
        {
            [RestfulProperties("Differential")]
            Differential = 0,

            [RestfulProperties("Single Ended: Negative line connected to analog ground")]
            SingleEnded_AGNDM = 1,

            [RestfulProperties("Single Ended: Negative line connected to chassis ground")]
            SingleEnded_CGNDM = 2,
        }

        [Serializable]
        public class DacValueOnLemoSettings
        {
            [RestfulProperties("DAC Value On LEMO")]
            public DacValueOnLemo DacValueOnLemo { get; set; }
        }

        [Serializable]
        public class VCalModeSettings
        {
            [RestfulProperties("VCal mode")]
            public VCalMode VCalMode { get; set; }
        }

        public interface ISettings
        {
        }

        [Serializable]
        public class ICP450ChannelOperationMode
        {
            [RestfulProperties("Operation Mode")]
            public OperationMode OperationMode { get; set; } = OperationMode.VoltageInput;
        }

        [Serializable]
        public class VoltageInputSettings : ISettings
        {

            [RestfulProperties("Voltage Range")]
            public VoltageInputVoltageRange VoltageInputVoltageRange { get; set; } = VoltageInputVoltageRange._10V;

            [RestfulProperties("Input Biasing")]
            public InputBiasing InputBiasing { get; set; } = InputBiasing.Differential;

            [RestfulProperties("Coupling")]
            public VoltageInputCoupling VoltageInputCoupling { get; set; } = VoltageInputCoupling.Dc;
        }

        [Serializable]
        public class IcpInputSettings : ISettings
        {

            [RestfulProperties("Voltage Range")]
            public VoltageRange VoltageRange { get; set; } = VoltageRange._10V;

            [RestfulProperties("Input Biasing")]
            public InputBiasing InputBiasing { get; set; } = InputBiasing.Differential;

            [RestfulProperties("Coupling")]
            public IcpInputCoupling IcpInputCoupling { get; set; } = IcpInputCoupling.Ac;

            [RestfulProperties("Current Source")]
            public IcpInputCurrentSource IcpInputCurrentSource { get; set; } = IcpInputCurrentSource._4mA;
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
                Settings = Setting.ConvertFrom(new ICP450ChannelOperationMode() {OperationMode = operationMode}),
            };
            
            base.PutItemOperationMode(operationModeSettings);
        }

        public new OperationMode GetItemOperationMode()
        {
            var jsonObject = base.GetItemOperationMode();
            return Setting.ConvertTo<ICP450ChannelOperationMode>(jsonObject.Settings).OperationMode;
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
