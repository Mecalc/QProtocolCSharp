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

namespace QProtocol.InternalChannels.XMC237
{
    [Serializable]
    public class XMC237IcpChannel : DataChannelItem
    {
        public XMC237IcpChannel(Item itemInfo)
            : base(itemInfo)
        {
        }

        public const System.Int32 MaxNumberOfCalibrationCorrectionItems = 8;

        public enum OperationMode
        {
            [RestfulProperties("Disabled")]
            Disabled = 0,

            [RestfulProperties("Voltage Input")]
            VoltageInput = 1,

            [RestfulProperties("ICP® Input")]
            IcpInput = 2,
        }

        public enum VoltageRange
        {
            [RestfulProperties("100 mV", 0.1, "V")]
            _100mV = 0,

            [RestfulProperties("1 V", 1, "V")]
            _1V = 1,

            [RestfulProperties("7.5 V", 7.5, "V")]
            _7point5V = 2,
        }

        public enum IcpInputCurrentSource
        {
            [RestfulProperties("4 mA", 0.004, "A")]
            _4mA = 0,

            [RestfulProperties("8 mA", 0.008, "A")]
            _8mA = 1,
        }

        public enum VoltageInputBiasing
        {
            [RestfulProperties("Differential")]
            Differential = 0,

            [RestfulProperties("Single Ended")]
            SingleEnded = 1,
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
        }

        public enum VoltageInputCoupling
        {
            [RestfulProperties("DC")]
            Dc = 0,

            [RestfulProperties("AC")]
            Ac = 1,
        }

        public enum VCalSwitch
        {
            [RestfulProperties("Open")]
            Open = 0,

            [RestfulProperties("Closed")]
            Closed = 1,
        }

        public enum FrontEndSwitch
        {
            [RestfulProperties("Open")]
            Open = 0,

            [RestfulProperties("Closed")]
            Closed = 1,
        }

        public enum Allow12VIcpOptions
        {
            [RestfulProperties("Disallow")]
            Disallow = 0,

            [RestfulProperties("Allow")]
            Allow = 1,
        }

        public enum FrontEndCriticalLimitChecking
        {
            [RestfulProperties("Enable")]
            Enable = 0,

            [RestfulProperties("Disable")]
            Disable = 1,
        }

        public struct DCatSettingsUpperADCOverloadLimitVoltageAsSingle
        {
            public const Single UpperLimit = 100F;
            public const Single LowerLimit = -100F;
        }

        public struct DCatSettingsLowerADCOverloadLimitVoltageAsSingle
        {
            public const Single UpperLimit = 100F;
            public const Single LowerLimit = -100F;
        }

        public struct DCatSettingsOpenIcpSensorIntegrityLimitAsInt32
        {
            public const Int32 UpperLimit = 2147483647;
            public const Int32 LowerLimit = -2147483648;
        }

        public struct DCatSettingsShortedIcpSensorIntegrityLimitAsInt32
        {
            public const Int32 UpperLimit = 2147483647;
            public const Int32 LowerLimit = -2147483648;
        }

        [Serializable]
        public class DCatSettings
        {
            [RestfulProperties("VCal Switch Status")]
            public VCalSwitch VCalSwitch { get; set; }

            [RestfulProperties("Front End Switch Status")]
            public FrontEndSwitch FrontEndSwitch { get; set; }

            [RestfulProperties("Allow 12 V ICP Options")]
            public Allow12VIcpOptions Allow12VIcpOptions { get; set; }

            [RestfulProperties("Front End Critical Limit Checking Status")]
            public FrontEndCriticalLimitChecking FrontEndCriticalLimitChecking { get; set; }

            [RestfulProperties("Upper ADC Overload Voltage Limit")]
            public Single UpperADCOverloadLimitVoltage { get; set; }

            [RestfulProperties("Lower ADC Overload Voltage Limit")]
            public Single LowerADCOverloadLimitVoltage { get; set; }

            [RestfulProperties("Open ICP Sensor Integrity Limit")]
            public Int32 OpenIcpSensorIntegrityLimit { get; set; }

            [RestfulProperties("Shorted ICP Sensor Integrity Limit")]
            public Int32 ShortedIcpSensorIntegrityLimit { get; set; }
        }

        public struct CalibrationCorrectionsOffsetCorrectionAsSingle
        {
            public const Single UpperLimit = 100F;
            public const Single LowerLimit = -100F;
        }

        public struct CalibrationCorrectionsGainCorrectionAsSingle
        {
            public const Single UpperLimit = 100F;
            public const Single LowerLimit = -100F;
        }

        [Serializable]
        public class CalibrationCorrections
        {
            [RestfulProperties("Voltage Range")]
            public VoltageRange VoltageRange { get; set; }

            [RestfulProperties("Offset correction value")]
            public Single OffsetCorrection { get; set; }

            [RestfulProperties("Gain correction value")]
            public Single GainCorrection { get; set; }
        }

        public interface ISettings
        {
        }

        [Serializable]
        public class XMC237IcpChannelOperationMode
        {
            [RestfulProperties("Operation Mode")]
            public OperationMode OperationMode { get; set; } = OperationMode.VoltageInput;
        }

        [Serializable]
        public class VoltageInputSettings : ISettings
        {

            [RestfulProperties("Voltage Range")]
            public VoltageRange VoltageRange { get; set; } = VoltageRange._7point5V;

            [RestfulProperties("Input Biasing")]
            public VoltageInputBiasing VoltageInputBiasing { get; set; } = VoltageInputBiasing.Differential;

            [RestfulProperties("Coupling")]
            public VoltageInputCoupling VoltageInputCoupling { get; set; } = VoltageInputCoupling.Dc;
        }

        [Serializable]
        public class IcpInputSettings : ISettings
        {

            [RestfulProperties("Voltage Range")]
            public VoltageRange VoltageRange { get; set; } = VoltageRange._7point5V;

            [RestfulProperties("Current Source")]
            public IcpInputCurrentSource IcpInputCurrentSource { get; set; } = IcpInputCurrentSource._4mA;

            [RestfulProperties("Input Biasing")]
            public IcpInputBiasing IcpInputBiasing { get; set; } = IcpInputBiasing.SingleEnded;

            [RestfulProperties("Coupling")]
            public IcpInputCoupling IcpInputCoupling { get; set; } = IcpInputCoupling.Ac;
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
                Settings = Setting.ConvertFrom(new XMC237IcpChannelOperationMode() {OperationMode = operationMode}),
            };
            
            base.PutItemOperationMode(operationModeSettings);
        }

        public new OperationMode GetItemOperationMode()
        {
            var jsonObject = base.GetItemOperationMode();
            return Setting.ConvertTo<XMC237IcpChannelOperationMode>(jsonObject.Settings).OperationMode;
        }

        public TedsInfo GetTedsInfo()
        {
            return RestInterface.Get<TedsInfo>(EndPoints.TedsInfo, HttpParameter.ItemId(ItemId));
        }
    }
}
