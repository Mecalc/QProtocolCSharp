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

namespace QProtocol.Controllers
{
    [Serializable]
    public class Controller : Item
    {
        public Controller(Item itemInfo)
            : base(itemInfo)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="Controller"/> class.
        /// This instance can be used to send Restful commands to the Item.
        /// </summary>
        /// <param name="systemSettings">An instance of the <see cref="SystemSettings"/> obtained by calling <see cref="EndPoints.SystemSettings"/> endpoint.</param>
        /// <param name="restfulInterface">an instance of the <see cref="IRestfulInterface"/> implementation which will extend the <see cref="Item"/> features to include command communication to the QServer instance.</param>
        public Controller(SystemSettings systemSettings, IRestfulInterface restfulInterface)
            : base(systemSettings, restfulInterface)
        {
        }

        public enum MasterSamplingRate
        {
            [RestfulProperties("131072 Hz", 131072, "Hz")]
            _131072Hz = 0,

            [RestfulProperties("160000 Hz", 160000, "Hz")]
            _160000Hz = 1,

            [RestfulProperties("163840 Hz", 163840, "Hz")]
            _163840Hz = 2,

            [RestfulProperties("176400 Hz", 176400, "Hz")]
            _176400Hz = 3,

            [RestfulProperties("192000 Hz", 192000, "Hz")]
            _192000Hz = 4,

            [RestfulProperties("200000 Hz", 200000, "Hz")]
            _200000Hz = 5,

            [RestfulProperties("204800 Hz", 204800, "Hz")]
            _204800Hz = 6,
        }

        public enum AnalogDataStreamingFormat
        {
            [RestfulProperties("Processed")]
            Processed = 0,

            [RestfulProperties("Raw")]
            Raw = 1,
        }

        public enum OperationMode
        {
            [RestfulProperties("Disabled")]
            Disabled = 0,

            [RestfulProperties("Enabled")]
            Enabled = 1,
        }

        public enum SynchronisationPulseSource
        {
            [RestfulProperties("Sc")]
            Sc = 0,

            [RestfulProperties("SPort")]
            SPort = 1,

            [RestfulProperties("Xmc")]
            Xmc = 2,
        }

        public enum SynchronisationPulseRate
        {
            [RestfulProperties("1Hz")]
            _1Hz = 0,

            [RestfulProperties("4Hz")]
            _4Hz = 1,

            [RestfulProperties("10Hz")]
            _10Hz = 2,
        }

        public interface ISettings
        {
        }

        [Serializable]
        public class ControllerOperationMode
        {
            [RestfulProperties("Operation Mode")]
            public OperationMode OperationMode { get; set; } = OperationMode.Enabled;
        }

        [Serializable]
        public class EnabledSettings : ISettings
        {

            [RestfulProperties("Master Sampling Rate")]
            public MasterSamplingRate MasterSamplingRate { get; set; } = MasterSamplingRate._204800Hz;

            [RestfulProperties("Analog Data Streaming Format")]
            public AnalogDataStreamingFormat AnalogDataStreamingFormat { get; set; } = AnalogDataStreamingFormat.Processed;
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
                Settings = Setting.ConvertFrom(new ControllerOperationMode() {OperationMode = operationMode}),
            };
            
            base.PutItemOperationMode(operationModeSettings);
        }

        public new OperationMode GetItemOperationMode()
        {
            var jsonObject = base.GetItemOperationMode();
            return Setting.ConvertTo<ControllerOperationMode>(jsonObject.Settings).OperationMode;
        }
    }
}
