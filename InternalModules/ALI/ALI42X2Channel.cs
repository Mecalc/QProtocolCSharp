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

namespace QProtocol.InternalModules.ALI
{
    [Serializable]
    public class ALI42X2Channel : DataChannelItem
    {
        public ALI42X2Channel(Item itemInfo)
            : base(itemInfo)
        {
        }


        public enum OperationMode
        {
            [RestfulProperties("Disabled")]
            Disabled = 0,

            [RestfulProperties("Voltage Input - Master Trigger")]
            VoltageInputMasterTrigger = 1,

            [RestfulProperties("Voltage Input - Slave Trigger")]
            VoltageInputSlaveTrigger = 2,
        }

        public enum TriggerStatus
        {
            [RestfulProperties("Reset")]
            Reset = 0,

            [RestfulProperties("Start")]
            Start = 1,

            [RestfulProperties("PreTrigger")]
            PreTrigger = 2,

            [RestfulProperties("Ready")]
            Ready = 3,

            [RestfulProperties("Armed")]
            Armed = 4,

            [RestfulProperties("Triggered")]
            Triggered = 5,

            [RestfulProperties("Finished")]
            Finished = 6,
        }

        public enum VoltageRange
        {
            [RestfulProperties("5.46 V", 5.46, "V")]
            _5_47V = 0,

            [RestfulProperties("2.73 V", 2.73, "V")]
            _2_73V = 1,

            [RestfulProperties("1.36 V", 1.36, "V")]
            _1_37V = 2,

            [RestfulProperties("683 mV", 0.683, "V")]
            _0_68V = 3,

            [RestfulProperties("341 mV", 0.341, "V")]
            _0_34V = 4,

            [RestfulProperties("170 mV", 0.17, "V")]
            _0_17V = 5,

            [RestfulProperties("85.4 mV", 0.0854, "V")]
            _0_09V = 6,

            [RestfulProperties("42.7 mV", 0.0427, "V")]
            _0_04V = 7,

            [RestfulProperties("21.3 mV", 0.0213, "V")]
            _0_02V = 8,

            [RestfulProperties("10.6 mV", 0.0106, "V")]
            _0_01V = 9,
        }

        public enum Polarity
        {
            [RestfulProperties("Rising Edge")]
            RisingEdge = 0,

            [RestfulProperties("Falling Edge")]
            FallingEdge = 1,
        }

        [Serializable]
        public class TriggerStatusSettings
        {
            [RestfulProperties("Trigger Status")]
            public TriggerStatus TriggerStatus { get; set; }
        }

        public struct OffsetVoltageSettingsVoltageAsUInt32
        {
            public const UInt32 UpperLimit = 65536;
            public const UInt32 LowerLimit = 0;
        }

        [Serializable]
        public class OffsetVoltageSettings
        {
            [RestfulProperties("Offset Voltage")]
            public UInt32 Voltage { get; set; }
        }

        public struct ExcitationVoltageSettingsVoltageAsSingle
        {
            public const Single UpperLimit = 22.443F;
            public const Single LowerLimit = 0F;
        }

        [Serializable]
        public class ExcitationVoltageSettings
        {
            [RestfulProperties("Excitation Voltage")]
            public Single Voltage { get; set; }
        }

        public struct SettingsPreTriggerBufferSizeAsInt32
        {
            public const Int32 UpperLimit = 65536;
            public const Int32 LowerLimit = 0;
        }

        public struct SettingsTotalBufferSizeAsInt32
        {
            public const Int32 UpperLimit = 65536;
            public const Int32 LowerLimit = 0;
        }

        public struct SettingsDataLevelTriggerPercentageAsUInt32
        {
            public const UInt32 UpperLimit = 100;
            public const UInt32 LowerLimit = 0;
        }

        public interface ISettings
        {
        }

        [Serializable]
        public class ALI42X2ChannelOperationMode
        {
            [RestfulProperties("Operation Mode")]
            public OperationMode OperationMode { get; set; } = OperationMode.VoltageInputSlaveTrigger;
        }

        [Serializable]
        public class VoltageInputSlaveTriggerSettings : ISettings
        {

            [RestfulProperties("Voltage Range")]
            public VoltageRange VoltageRange { get; set; } = VoltageRange._5_47V;

            [RestfulProperties("Pre-trigger Buffer Size")]
            public Int32 PreTriggerBufferSize { get; set; } = 8192;

            [RestfulProperties("Total Buffer Size")]
            public Int32 TotalBufferSize { get; set; } = 65536;
        }

        [Serializable]
        public class VoltageInputMasterTriggerSettings : ISettings
        {

            [RestfulProperties("Voltage Range")]
            public VoltageRange VoltageRange { get; set; } = VoltageRange._5_47V;

            [RestfulProperties("Software Trigger")]
            public GenericDefines.Generic.Status SoftwareTriggerMode { get; set; } = GenericDefines.Generic.Status.Disabled;

            [RestfulProperties("Data Level Trigger")]
            public GenericDefines.Generic.Status DataLevelTriggerMode { get; set; } = GenericDefines.Generic.Status.Disabled;

            [RestfulProperties("Data Level Trigger Percentage")]
            public UInt32 DataLevelTriggerPercentage { get; set; } = 0;

            [RestfulProperties("TTL Trigger")]
            public GenericDefines.Generic.Status TtlTriggerMode { get; set; } = GenericDefines.Generic.Status.Disabled;

            [RestfulProperties("TTL Trigger Polarity")]
            public Polarity TtlPolarity { get; set; } = Polarity.RisingEdge;

            [RestfulProperties("Pre-trigger Buffer Size")]
            public Int32 PreTriggerBufferSize { get; set; } = 8192;

            [RestfulProperties("Total Buffer Size")]
            public Int32 TotalBufferSize { get; set; } = 65536;
        }

        [Serializable]
        public class SettingsCollection<T>
            where T : ISettings
        {
            public T Settings { get; set; }

            public Data Data { get; set; }
        }


        public void DisableTrigger()
        {
            RestInterface.Put(EndPoints.Ali42xTriggerDisable, HttpParameter.ItemId(ItemId));
        }

        public void EnableTrigger()
        {
            RestInterface.Put(EndPoints.Ali42xTriggerEnable, HttpParameter.ItemId(ItemId));
        }

        public void ArmTrigger()
        {
            RestInterface.Put(EndPoints.Ali42xTriggerArm, HttpParameter.ItemId(ItemId));
        }

        public void SoftwareTrigger()
        {
            RestInterface.Put(EndPoints.Ali42xTriggerSoftwareTrigger, HttpParameter.ItemId(ItemId));
        }

        public void StartDataTransfer()
        {
            RestInterface.Put(EndPoints.Ali42xDataTransfer, HttpParameter.ItemId(ItemId));
        }

        public void ClearBuffer()
        {
            RestInterface.Put(EndPoints.Ali42xDataClearBuffer, HttpParameter.ItemId(ItemId));
        }

        public void StopDataTransfer()
        {
            RestInterface.Put(EndPoints.Ali42xDataStopTransfer, HttpParameter.ItemId(ItemId));
        }

        public void PutOffsetVoltage(OffsetVoltageSettings offsetVoltageSettings)
        {
            var jsonObject = new GenericSettings()
            {
                Settings = Setting.ConvertFrom(offsetVoltageSettings)
            };
            RestInterface.Put(EndPoints.Ali42xOffsetVoltage, jsonObject, HttpParameter.ItemId(ItemId));
        }

        public OffsetVoltageSettings GetOffsetVoltage()
        {
            var jsonObject = RestInterface.Get<GenericSettings>(EndPoints.Ali42xOffsetVoltage, HttpParameter.ItemId(ItemId));
            return Setting.ConvertTo<OffsetVoltageSettings>(jsonObject.Settings);
        }

        public void PutExcitationVoltage(ExcitationVoltageSettings excitationVoltageSettings)
        {
            var jsonObject = new GenericSettings()
            {
                Settings = Setting.ConvertFrom(excitationVoltageSettings)
            };
            RestInterface.Put(EndPoints.Ali42xExcitationVoltage, jsonObject, HttpParameter.ItemId(ItemId));
        }

        public ExcitationVoltageSettings GetExcitationVoltage()
        {
            var jsonObject = RestInterface.Get<GenericSettings>(EndPoints.Ali42xExcitationVoltage, HttpParameter.ItemId(ItemId));
            return Setting.ConvertTo<ExcitationVoltageSettings>(jsonObject.Settings);
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
                Settings = Setting.ConvertFrom(new ALI42X2ChannelOperationMode() {OperationMode = operationMode}),
            };
            
            base.PutItemOperationMode(operationModeSettings);
        }

        public new OperationMode GetItemOperationMode()
        {
            var jsonObject = base.GetItemOperationMode();
            return Setting.ConvertTo<ALI42X2ChannelOperationMode>(jsonObject.Settings).OperationMode;
        }

        public TriggerStatusSettings GetDataStatus()
        {
            var jsonObject = RestInterface.Get<GenericSettings>(EndPoints.Ali42xDataStatus, HttpParameter.ItemId(ItemId));
            return Setting.ConvertTo<TriggerStatusSettings>(jsonObject.Settings);
        }
    }
}
