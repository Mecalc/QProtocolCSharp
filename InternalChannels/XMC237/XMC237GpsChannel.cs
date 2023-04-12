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
    public class XMC237GpsChannel : DataChannelItem
    {
        public XMC237GpsChannel(Item itemInfo)
            : base(itemInfo)
        {
        }

        public const System.Int32 MaximumNumberOfActiveMessages = 20;

        public enum OperationMode
        {
            [RestfulProperties("Disabled")]
            Disabled = 0,

            [RestfulProperties("Enabled")]
            Enabled = 1,
        }

        public enum MessageRate
        {
            [RestfulProperties("1 Hz", 1, "Hz")]
            _1Hz = 0,

            [RestfulProperties("2 Hz", 2, "Hz")]
            _2Hz = 1,

            [RestfulProperties("5 Hz", 5, "Hz")]
            _5Hz = 2,

            [RestfulProperties("10 Hz", 10, "Hz")]
            _10Hz = 3,
        }

        public enum MessageClass
        {
            [RestfulProperties("NMEA")]
            NMEA = 0,
        }

        public enum NmeaMessageId
        {
            [RestfulProperties("NMEA GGA")]
            Gga = 0,

            [RestfulProperties("NMEA GSA")]
            Gsa = 1,

            [RestfulProperties("NMEA RMC")]
            Rmc = 2,

            [RestfulProperties("NMEA VTG")]
            Vtg = 3,
        }

        public interface ISettings
        {
        }

        [Serializable]
        public class XMC237GpsChannelOperationMode
        {
            [RestfulProperties("Operation Mode")]
            public OperationMode OperationMode { get; set; } = OperationMode.Enabled;
        }

        [Serializable]
        public class EnabledSettings : ISettings
        {

            [RestfulProperties("Message rate")]
            public MessageRate MessageRate { get; set; } = MessageRate._1Hz;

            [RestfulProperties("NMEA GGA")]
            public GenericDefines.Generic.Status NmeaGga { get; set; } = GenericDefines.Generic.Status.Disabled;

            [RestfulProperties("NMEA GSA")]
            public GenericDefines.Generic.Status NmeaGsa { get; set; } = GenericDefines.Generic.Status.Disabled;

            [RestfulProperties("NMEA RMC")]
            public GenericDefines.Generic.Status NmeaRmc { get; set; } = GenericDefines.Generic.Status.Disabled;

            [RestfulProperties("NMEA VTG")]
            public GenericDefines.Generic.Status NmeaVtg { get; set; } = GenericDefines.Generic.Status.Disabled;
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
            return Setting.ConvertTo<XMC237GpsChannelOperationMode>(jsonObject.Settings).OperationMode;
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
                Settings = Setting.ConvertFrom(new XMC237GpsChannelOperationMode() {OperationMode = operationMode}),
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
