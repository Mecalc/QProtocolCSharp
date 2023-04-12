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

namespace QProtocol.InternalModules.SCC
{
    [Serializable]
    public class SCC42T5Module : Item
    {
        public SCC42T5Module(Item itemInfo)
            : base(itemInfo)
        {
        }

        public const System.Int32 NumberOfChannelsOnModule = 4;
        public const System.Int32 BusRelayCommandD1 = 1;
        public const System.Int32 IsolatedPowerCommandD2 = 2;
        public const System.Int32 NonIsolatedPowerCommandD3 = 3;
        public const System.Int32 SpecialityCommandD5 = 5;
        public const System.Int32 IsolatedLoadsCommandD6 = 6;
        public const System.Int32 IsolatedLoads2CommandD7 = 7;
        public const System.Int32 NonIsolatedLoadsCommandD8 = 8;
        public const System.Int32 VsigHarnessCommandDA = 10;
        public const System.Int32 AioConnectCommandDB = 11;
        public const System.Int32 DefaultSetupCommandDC = 12;
        public const System.Int32 BackPlaneCommandDF = 15;

        public enum SampleRate
        {
            [RestfulProperties("MSR Divide by 2")]
            MsrDivideBy2 = 0,

            [RestfulProperties("MSR Divide by 4")]
            MsrDivideBy4 = 1,

            [RestfulProperties("MSR Divide by 8")]
            MsrDivideBy8 = 2,

            [RestfulProperties("MSR Divide by 16")]
            MsrDivideBy16 = 3,

            [RestfulProperties("MSR Divide by 32")]
            MsrDivideBy32 = 4,

            [RestfulProperties("MSR Divide by 64")]
            MsrDivideBy64 = 5,

            [RestfulProperties("MSR Divide by 128")]
            MsrDivideBy128 = 6,

            [RestfulProperties("MSR Divide by 256")]
            MsrDivideBy256 = 7,
        }

        public enum Aio
        {
            [RestfulProperties("Differential")]
            Differential = 0,

            [RestfulProperties("Single Ended Positive")]
            SingleEndedPositive = 1,

            [RestfulProperties("Single Ended Negative")]
            SingleEndedNegative = 2,

            [RestfulProperties("Disconnected")]
            Disconnected = 3,
        }

        public enum BackPlaneSwitch
        {
            [RestfulProperties("Disconnect")]
            Disconnect = 0,

            [RestfulProperties("Connect")]
            Connect = 1,
        }

        public enum IsolatedPower
        {
            [RestfulProperties("Negative 12 V")]
            Negative12V = 0,

            [RestfulProperties("Positive 25 V")]
            Positive25V = 1,

            [RestfulProperties("Positive 12 V")]
            Positive12V = 2,

            [RestfulProperties("Digital Ground")]
            DigitalGround = 3,

            [RestfulProperties("Analogue Ground")]
            AnalogueGround = 4,

            [RestfulProperties("Positive 5 V")]
            Positive5V = 5,

            [RestfulProperties("Negative 5 V")]
            Negative5V = 6,

            [RestfulProperties("Positive 3.3 V")]
            Positive3V3 = 7,
        }

        public enum NonIsolatedPower
        {
            [RestfulProperties("Positive 3.3 V")]
            Positive3V3 = 0,

            [RestfulProperties("Positive 12 V")]
            Positive12V = 1,

            [RestfulProperties("Positive 5 V")]
            Positive5V = 2,

            [RestfulProperties("Ground")]
            Ground = 3,
        }

        public enum Filter
        {
            [RestfulProperties("Direct Connection")]
            DirectConnection = 0,

            [RestfulProperties("Via Butterworth")]
            ViaButterworth = 1,
        }

        public enum VsigHarness
        {
            [RestfulProperties("Grounded")]
            Grounded = 0,

            [RestfulProperties("Connected")]
            Connected = 1,
        }

        public enum Vcal
        {
            [RestfulProperties("Direct Connection")]
            DirectConnection = 0,

            [RestfulProperties("Via 0.1 gain inverter")]
            ViaInverter = 1,

            [RestfulProperties("Via 0.0909 divider")]
            ViaDivider = 2,
        }

        public enum PowerLoads
        {
            [RestfulProperties("Disconnected")]
            Disconnected = 0,

            [RestfulProperties("Connected")]
            Connected = 1,
        }

        public enum OperationMode
        {
            [RestfulProperties("Disabled")]
            Disabled = 0,

            [RestfulProperties("Connect AIO")]
            ConnectAio = 1,

            [RestfulProperties("Connect Isolated Power")]
            ConnectIsolatedPower = 2,

            [RestfulProperties("Connect Non-isolated Power")]
            ConnectNonisolatedPower = 3,

            [RestfulProperties("Connect VSIG")]
            ConnectVsig = 4,

            [RestfulProperties("Connect VCAL")]
            ConnectVcal = 5,

            [RestfulProperties("Data generator")]
            DataGenerator = 6,
        }

        public interface ISettings
        {
        }

        [Serializable]
        public class SCC42T5ModuleOperationMode
        {
            [RestfulProperties("Operation Mode")]
            public OperationMode OperationMode { get; set; } = OperationMode.Disabled;
        }

        [Serializable]
        public class AioSettings : ISettings
        {

            [RestfulProperties("AIO")]
            public Aio Aio { get; set; } = Aio.Disconnected;
        }

        [Serializable]
        public class IsolatedPowerSettings : ISettings
        {

            [RestfulProperties("AIO")]
            public Aio Aio { get; set; } = Aio.Disconnected;

            [RestfulProperties("Isolated Power")]
            public IsolatedPower IsolatedPower { get; set; } = IsolatedPower.AnalogueGround;

            [RestfulProperties("Isolated 24 V Load 1")]
            public PowerLoads Isolated24VLoad1 { get; set; } = PowerLoads.Disconnected;

            [RestfulProperties("Isolated 24 V Load 2")]
            public PowerLoads Isolated24VLoad2 { get; set; } = PowerLoads.Disconnected;

            [RestfulProperties("Isolated 12 V Load 1")]
            public PowerLoads Isolated12VLoad1 { get; set; } = PowerLoads.Disconnected;

            [RestfulProperties("Isolated 12 V Load 2")]
            public PowerLoads Isolated12VLoad2 { get; set; } = PowerLoads.Disconnected;

            [RestfulProperties("Isolated -12 V Load 1")]
            public PowerLoads IsolatedNegative12VLoad1 { get; set; } = PowerLoads.Disconnected;

            [RestfulProperties("Isolated -12 V Load 2")]
            public PowerLoads IsolatedNegative12VLoad2 { get; set; } = PowerLoads.Disconnected;

            [RestfulProperties("Isolated 5 V Load 1")]
            public PowerLoads Isolated5VLoad1 { get; set; } = PowerLoads.Disconnected;

            [RestfulProperties("Isolated 5 V Load 2")]
            public PowerLoads Isolated5VLoad2 { get; set; } = PowerLoads.Disconnected;

            [RestfulProperties("Isolated -5 V Load 1")]
            public PowerLoads IsolatedNegative5VLoad1 { get; set; } = PowerLoads.Disconnected;

            [RestfulProperties("Isolated -5 V Load 2")]
            public PowerLoads IsolatedNegative5VLoad2 { get; set; } = PowerLoads.Disconnected;

            [RestfulProperties("Isolated 3.3 V Load 1")]
            public PowerLoads Isolated3V3Load1 { get; set; } = PowerLoads.Disconnected;

            [RestfulProperties("Isolated 3.3 V Load 2")]
            public PowerLoads Isolated3V3Load2 { get; set; } = PowerLoads.Disconnected;

            [RestfulProperties("Isolated 3.3 V Load 3")]
            public PowerLoads Isolated3V3Load3 { get; set; } = PowerLoads.Disconnected;
        }

        [Serializable]
        public class NonIsolatedPowerSettings : ISettings
        {

            [RestfulProperties("AIO")]
            public Aio Aio { get; set; } = Aio.Disconnected;

            [RestfulProperties("Non-isolated Power")]
            public NonIsolatedPower NonIsolatedPower { get; set; } = NonIsolatedPower.Ground;

            [RestfulProperties("Non-isolated 12 V Load 1")]
            public PowerLoads NonIsolated12VLoad1 { get; set; } = PowerLoads.Disconnected;

            [RestfulProperties("Non-isolated 5 V Load 1")]
            public PowerLoads NonIsolated5VLoad1 { get; set; } = PowerLoads.Disconnected;

            [RestfulProperties("Non-isolated 3.3 V Load 1")]
            public PowerLoads NonIsolated3V3Load1 { get; set; } = PowerLoads.Disconnected;

            [RestfulProperties("Non-isolated 3.3 V Load 2")]
            public PowerLoads NonIsolated3V3Load2 { get; set; } = PowerLoads.Disconnected;

            [RestfulProperties("Non-isolated 3.3 V Load 3")]
            public PowerLoads NonIsolated3V3Load3 { get; set; } = PowerLoads.Disconnected;
        }

        [Serializable]
        public class VsigSettings : ISettings
        {

            [RestfulProperties("Sample Rate")]
            public SampleRate SampleRate { get; set; } = SampleRate.MsrDivideBy8;

            [RestfulProperties("AIO")]
            public Aio Aio { get; set; } = Aio.Disconnected;

            [RestfulProperties("Filter")]
            public Filter Filter { get; set; } = Filter.DirectConnection;

            [RestfulProperties("VSig Line 0 to Harness")]
            public VsigHarness VSigLine0ToHarness { get; set; } = VsigHarness.Grounded;

            [RestfulProperties("VSig Line 1 to Harness")]
            public VsigHarness VSigLine1ToHarness { get; set; } = VsigHarness.Grounded;

            [RestfulProperties("VSig Line 2 to Harness")]
            public VsigHarness VSigLine2ToHarness { get; set; } = VsigHarness.Grounded;

            [RestfulProperties("VSig Line 3 to Harness")]
            public VsigHarness VSigLine3ToHarness { get; set; } = VsigHarness.Grounded;
        }

        [Serializable]
        public class VcalSettings : ISettings
        {

            [RestfulProperties("AIO")]
            public Aio Aio { get; set; } = Aio.Disconnected;

            [RestfulProperties("VCAL")]
            public Vcal Vcal { get; set; } = Vcal.DirectConnection;
        }

        [Serializable]
        public class DataGeneratorSettings : ISettings
        {

            [RestfulProperties("Sample Rate")]
            public SampleRate SampleRate { get; set; } = SampleRate.MsrDivideBy8;
        }

        [Serializable]
        public class SettingsCollection<T>
            where T : ISettings
        {
            public T Settings { get; set; }

            public Data Data { get; set; }
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
            return Setting.ConvertTo<SCC42T5ModuleOperationMode>(jsonObject.Settings).OperationMode;
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

        public void PutItemOperationMode(OperationMode operationMode)
        {
            var operationModeSettings = new ItemOperationMode(this)
            {
                Settings = Setting.ConvertFrom(new SCC42T5ModuleOperationMode() {OperationMode = operationMode}),
            };
            
            base.PutItemOperationMode(operationModeSettings);
        }

        public void PutItemSettings<T>(SettingsCollection<T> settings)
            where T : ISettings
        {
            var jsonObject = new ItemSettings(this);
            jsonObject.UpdateFromSettings(settings.Settings);
            jsonObject.UpdateFromData(settings.Data);
            base.PutItemSettings(jsonObject);
        }
    }
}
