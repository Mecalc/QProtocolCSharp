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

namespace QProtocol.InternalModules.FLX
{
    [Serializable]
    public class FLX422Module : Item
    {
        public FLX422Module(Item itemInfo)
            : base(itemInfo)
        {
        }

        public const System.Int32 NumberOfChannelsOnModule = 2;

        public enum OperationMode
        {
            [RestfulProperties("Disabled")]
            Disabled = 0,

            [RestfulProperties("Participate")]
            Participate = 1,

            [RestfulProperties("ListenOnly")]
            ListenOnly = 2,

            [RestfulProperties("Simulate")]
            Simulate = 3,
        }

        public enum BusTermination
        {
            [RestfulProperties("Disabled")]
            Disabled = 0,

            [RestfulProperties("Enabled")]
            Enabled = 1,

            [RestfulProperties("Check")]
            Check = 2,
        }

        public enum FlexRayChannelConfiguration
        {
            [RestfulProperties("Single Channel Mode: Connector1 connected to Channel A")]
            SingleChannelModeConnector1ConnectedToChannelA = 0,

            [RestfulProperties("Single Channel Mode: Connector1 connected to Channel B")]
            SingleChannelModeConnector1ConnectedToChannelB = 1,

            [RestfulProperties("Dual Channel Mode")]
            DualChannelMode = 2,
        }

        public enum DataBitrate
        {
            [RestfulProperties("2.5 MHz", 2500000, "Hz")]
            _2500000 = 0,

            [RestfulProperties("5 MHz", 5000000, "Hz")]
            _5000000 = 1,

            [RestfulProperties("8 MHz", 8000000, "Hz")]
            _8000000 = 2,

            [RestfulProperties("10 MHz", 10000000, "Hz")]
            _10000000 = 3,
        }

        public struct SettingsColdStartAttemptsAsByte
        {
            public const Byte UpperLimit = 31;
            public const Byte LowerLimit = 2;
        }

        public struct SettingsActionPointOffsetAsByte
        {
            public const Byte UpperLimit = 63;
            public const Byte LowerLimit = 1;
        }

        public struct SettingsCasUpperLimitAcceptanceWindowAsByte
        {
            public const Byte UpperLimit = 99;
            public const Byte LowerLimit = 67;
        }

        public struct SettingsDynamicSlotIdlePhaseAsByte
        {
            public const Byte UpperLimit = 2;
            public const Byte LowerLimit = 0;
        }

        public struct SettingsMiniSlotAsByte
        {
            public const Byte UpperLimit = 63;
            public const Byte LowerLimit = 2;
        }

        public struct SettingsMiniSlotActionPointOffsetAsByte
        {
            public const Byte UpperLimit = 31;
            public const Byte LowerLimit = 1;
        }

        public struct SettingsSymbolWindowAsByte
        {
            public const Byte UpperLimit = 142;
            public const Byte LowerLimit = 0;
        }

        public struct SettingsNumberOfBitsInTransmissionStartSequenceAsByte
        {
            public const Byte UpperLimit = 15;
            public const Byte LowerLimit = 3;
        }

        public struct SettingsWakeupSymbolRxIdleAsByte
        {
            public const Byte UpperLimit = 59;
            public const Byte LowerLimit = 14;
        }

        public struct SettingsWakeupSymbolRxLowAsByte
        {
            public const Byte UpperLimit = 59;
            public const Byte LowerLimit = 11;
        }

        public struct SettingsWakeupSymbolTxIdleAsByte
        {
            public const Byte UpperLimit = 180;
            public const Byte LowerLimit = 45;
        }

        public struct SettingsWakeupSymbolTxLowAsByte
        {
            public const Byte UpperLimit = 60;
            public const Byte LowerLimit = 15;
        }

        public struct SettingsListenNoiseAsByte
        {
            public const Byte UpperLimit = 16;
            public const Byte LowerLimit = 2;
        }

        public struct SettingsMaxWithoutClockCorrectionPassiveAsByte
        {
            public const Byte UpperLimit = 15;
            public const Byte LowerLimit = 1;
        }

        public struct SettingsMaxWithoutClockCorrectionFatalAsByte
        {
            public const Byte UpperLimit = 15;
            public const Byte LowerLimit = 1;
        }

        public struct SettingsPayloadLengthOfStaticFrameAsByte
        {
            public const Byte UpperLimit = 127;
            public const Byte LowerLimit = 0;
        }

        public struct SettingsSyncNodeMaxAsByte
        {
            public const Byte UpperLimit = 15;
            public const Byte LowerLimit = 2;
        }

        public struct SettingsNetworkManagementVectorLengthAsByte
        {
            public const Byte UpperLimit = 12;
            public const Byte LowerLimit = 0;
        }

        public struct SettingsAllowPassiveToActiveAsByte
        {
            public const Byte UpperLimit = 31;
            public const Byte LowerLimit = 0;
        }

        public struct SettingsClusterDriftDampingAsByte
        {
            public const Byte UpperLimit = 20;
            public const Byte LowerLimit = 0;
        }

        public struct SettingsDecodingCorrectionAsByte
        {
            public const Byte UpperLimit = 143;
            public const Byte LowerLimit = 14;
        }

        public struct SettingsExternOffsetCorrectionAsByte
        {
            public const Byte UpperLimit = 7;
            public const Byte LowerLimit = 0;
        }

        public struct SettingsExternalRateCorrectionAsByte
        {
            public const Byte UpperLimit = 7;
            public const Byte LowerLimit = 0;
        }

        public struct SettingsWakeupPatternAsByte
        {
            public const Byte UpperLimit = 63;
            public const Byte LowerLimit = 2;
        }

        public struct SettingsMicroTicksPerMacroNominalAsByte
        {
            public const Byte UpperLimit = 240;
            public const Byte LowerLimit = 40;
        }

        public struct SettingsMaximumPayloadLengthForDynamicFramesAsByte
        {
            public const Byte UpperLimit = 127;
            public const Byte LowerLimit = 0;
        }

        public struct SettingsMacroPerCycleAsUInt16
        {
            public const UInt16 UpperLimit = 16000;
            public const UInt16 LowerLimit = 10;
        }

        public struct SettingsStaticSlotAsUInt16
        {
            public const UInt16 UpperLimit = 661;
            public const UInt16 LowerLimit = 4;
        }

        public struct SettingsWakeupSymbolRxWindowAsUInt16
        {
            public const UInt16 UpperLimit = 301;
            public const UInt16 LowerLimit = 76;
        }

        public struct SettingsNumberOfMiniSlotsAsUInt16
        {
            public const UInt16 UpperLimit = 7986;
            public const UInt16 LowerLimit = 0;
        }

        public struct SettingsNumberOfStaticSlotsAsUInt16
        {
            public const UInt16 UpperLimit = 1023;
            public const UInt16 LowerLimit = 2;
        }

        public struct SettingsOffsetCorrectionStartAsUInt16
        {
            public const UInt16 UpperLimit = 15999;
            public const UInt16 LowerLimit = 9;
        }

        public struct SettingsAcceptedStartupRangeAsUInt16
        {
            public const UInt16 UpperLimit = 1875;
            public const UInt16 LowerLimit = 0;
        }

        public struct SettingsMaxDriftAsUInt16
        {
            public const UInt16 UpperLimit = 1923;
            public const UInt16 LowerLimit = 2;
        }

        public struct SettingsKeySlotIdAsUInt16
        {
            public const UInt16 UpperLimit = 1023;
            public const UInt16 LowerLimit = 1;
        }

        public struct SettingsKeySlotHeaderCrcAsUInt16
        {
            public const UInt16 UpperLimit = 65535;
            public const UInt16 LowerLimit = 0;
        }

        public struct SettingsLatestTxAsUInt16
        {
            public const UInt16 UpperLimit = 7980;
            public const UInt16 LowerLimit = 0;
        }

        public struct SettingsOffsetCorrectionOutAsUInt16
        {
            public const UInt16 UpperLimit = 15567;
            public const UInt16 LowerLimit = 13;
        }

        public struct SettingsRateCorrectionOutAsUInt16
        {
            public const UInt16 UpperLimit = 1923;
            public const UInt16 LowerLimit = 2;
        }

        public struct SettingsListenTimeOutAsUInt32
        {
            public const UInt32 UpperLimit = 1283846;
            public const UInt32 LowerLimit = 1284;
        }

        public struct SettingsMicroTicksPerCycleAsUInt32
        {
            public const UInt32 UpperLimit = 640000;
            public const UInt32 LowerLimit = 640;
        }

        public interface ISettings
        {
        }

        [Serializable]
        public class FLX422ModuleOperationMode
        {
            [RestfulProperties("Operation Mode")]
            public OperationMode OperationMode { get; set; } = OperationMode.Disabled;
        }

        [Serializable]
        public class ListenOnlySettings : ISettings
        {

            [RestfulProperties("Bus Termination")]
            public BusTermination BusTermination { get; set; } = BusTermination.Disabled;

            [RestfulProperties("Data Rate")]
            public DataBitrate DataBitrate { get; set; } = DataBitrate._2500000;

            [RestfulProperties("FlexRay Channel Configuration")]
            public FlexRayChannelConfiguration FlexRayChannelConfiguration { get; set; } = FlexRayChannelConfiguration.SingleChannelModeConnector1ConnectedToChannelA;

            [RestfulProperties("Sync Frame Filtering")]
            public GenericDefines.Generic.Status SyncFrameFiltering { get; set; } = GenericDefines.Generic.Status.Disabled;

            [RestfulProperties("Cold Start Enable")]
            public GenericDefines.Generic.Status ColdStartEnable { get; set; } = GenericDefines.Generic.Status.Disabled;

            [RestfulProperties("Cold Start Attempts")]
            public Byte ColdStartAttempts { get; set; } = 2;

            [RestfulProperties("Action Point Offset")]
            public Byte ActionPointOffset { get; set; } = 1;

            [RestfulProperties("CAS Upper Limit Acceptance Window")]
            public Byte CasUpperLimitAcceptanceWindow { get; set; } = 67;

            [RestfulProperties("Dynamic Slot Idle Phase")]
            public Byte DynamicSlotIdlePhase { get; set; } = 0;

            [RestfulProperties("Mini Slot")]
            public Byte MiniSlot { get; set; } = 2;

            [RestfulProperties("Mini Slot Action Point Offset")]
            public Byte MiniSlotActionPointOffset { get; set; } = 1;

            [RestfulProperties("Symbol Window")]
            public Byte SymbolWindow { get; set; } = 0;

            [RestfulProperties("Number Of Bits In Transmission Start Sequence")]
            public Byte NumberOfBitsInTransmissionStartSequence { get; set; } = 3;

            [RestfulProperties("Wake Up Channel")]
            public GenericDefines.FLXChannel.ChannelSelect WakeUpChannel { get; set; } = GenericDefines.FLXChannel.ChannelSelect.A;

            [RestfulProperties("Wake Up Symbol RX Idle")]
            public Byte WakeupSymbolRxIdle { get; set; } = 14;

            [RestfulProperties("Wake Up Symbol RX Low")]
            public Byte WakeupSymbolRxLow { get; set; } = 11;

            [RestfulProperties("Wake Up Symbol TX Idle")]
            public Byte WakeupSymbolTxIdle { get; set; } = 45;

            [RestfulProperties("Wake Up Symbol TX Low")]
            public Byte WakeupSymbolTxLow { get; set; } = 15;

            [RestfulProperties("Listen Noise")]
            public Byte ListenNoise { get; set; } = 2;

            [RestfulProperties("Max Without Clock Correction Passive")]
            public Byte MaxWithoutClockCorrectionPassive { get; set; } = 1;

            [RestfulProperties("Max Without Clock Correction Fatal")]
            public Byte MaxWithoutClockCorrectionFatal { get; set; } = 1;

            [RestfulProperties("Payload Length Of Static Frame")]
            public Byte PayloadLengthOfStaticFrame { get; set; } = 0;

            [RestfulProperties("Sync Node Max")]
            public Byte SyncNodeMax { get; set; } = 2;

            [RestfulProperties("Network Management Vector Length")]
            public Byte NetworkManagementVectorLength { get; set; } = 0;

            [RestfulProperties("Allow Halt Due To Clock")]
            public GenericDefines.Generic.Status AllowHaltDueToClock { get; set; } = GenericDefines.Generic.Status.Disabled;

            [RestfulProperties("Allow Passive To Active")]
            public Byte AllowPassiveToActive { get; set; } = 0;

            [RestfulProperties("Cluster Drift Damping")]
            public Byte ClusterDriftDamping { get; set; } = 0;

            [RestfulProperties("Decoding Correction")]
            public Byte DecodingCorrection { get; set; } = 14;

            [RestfulProperties("External Offset Correction")]
            public Byte ExternOffsetCorrection { get; set; } = 0;

            [RestfulProperties("External Rate Correction")]
            public Byte ExternalRateCorrection { get; set; } = 0;

            [RestfulProperties("Key Slot Used For Startup")]
            public GenericDefines.Generic.Status KeySlotUsedForStartup { get; set; } = GenericDefines.Generic.Status.Disabled;

            [RestfulProperties("Key Slot Used For Sync")]
            public GenericDefines.Generic.Status KeySlotUsedForSync { get; set; } = GenericDefines.Generic.Status.Disabled;

            [RestfulProperties("Single Slot Enabled")]
            public GenericDefines.Generic.Status SingleSlotEnabled { get; set; } = GenericDefines.Generic.Status.Disabled;

            [RestfulProperties("Wake Up Pattern")]
            public Byte WakeupPattern { get; set; } = 2;

            [RestfulProperties("Micro Ticks Per Macro Nominal")]
            public Byte MicroTicksPerMacroNominal { get; set; } = 40;

            [RestfulProperties("Maximum Payload Length For Dynamic Frames")]
            public Byte MaximumPayloadLengthForDynamicFrames { get; set; } = 0;

            [RestfulProperties("Macro Ticks Per Cycle")]
            public UInt16 MacroPerCycle { get; set; } = 10;

            [RestfulProperties("Static Slot")]
            public UInt16 StaticSlot { get; set; } = 4;

            [RestfulProperties("Wake Up Symbol RX Window")]
            public UInt16 WakeupSymbolRxWindow { get; set; } = 76;

            [RestfulProperties("Number Of Mini Slots")]
            public UInt16 NumberOfMiniSlots { get; set; } = 0;

            [RestfulProperties("Number Of Static Slots")]
            public UInt16 NumberOfStaticSlots { get; set; } = 4;

            [RestfulProperties("Offset Correction Start")]
            public UInt16 OffsetCorrectionStart { get; set; } = 9;

            [RestfulProperties("Accepted Startup Range")]
            public UInt16 AcceptedStartupRange { get; set; } = 0;

            [RestfulProperties("Max Drift")]
            public UInt16 MaxDrift { get; set; } = 2;

            [RestfulProperties("Key Slot Id")]
            public UInt16 KeySlotId { get; set; } = 1;

            [RestfulProperties("Key Slot Header CRC")]
            public UInt16 KeySlotHeaderCrc { get; set; } = 0;

            [RestfulProperties("Latest TX")]
            public UInt16 LatestTx { get; set; } = 0;

            [RestfulProperties("Offset Correction Out")]
            public UInt16 OffsetCorrectionOut { get; set; } = 13;

            [RestfulProperties("Rate Correction Out")]
            public UInt16 RateCorrectionOut { get; set; } = 2;

            [RestfulProperties("Listen Time Out")]
            public UInt32 ListenTimeOut { get; set; } = 1284;

            [RestfulProperties("Micro Ticks Per Cycle")]
            public UInt32 MicroTicksPerCycle { get; set; } = 640;
        }

        [Serializable]
        public class ParticipateSettings : ISettings
        {

            [RestfulProperties("Bus Termination")]
            public BusTermination BusTermination { get; set; } = BusTermination.Disabled;

            [RestfulProperties("Data Rate")]
            public DataBitrate DataBitrate { get; set; } = DataBitrate._2500000;

            [RestfulProperties("FlexRay Channel Configuration")]
            public FlexRayChannelConfiguration FlexRayChannelConfiguration { get; set; } = FlexRayChannelConfiguration.SingleChannelModeConnector1ConnectedToChannelA;

            [RestfulProperties("Sync Frame Filtering")]
            public GenericDefines.Generic.Status SyncFrameFiltering { get; set; } = GenericDefines.Generic.Status.Disabled;

            [RestfulProperties("Cold Start Enable")]
            public GenericDefines.Generic.Status ColdStartEnable { get; set; } = GenericDefines.Generic.Status.Disabled;

            [RestfulProperties("Cold Start Attempts")]
            public Byte ColdStartAttempts { get; set; } = 2;

            [RestfulProperties("Action Point Offset")]
            public Byte ActionPointOffset { get; set; } = 1;

            [RestfulProperties("CAS Upper Limit Acceptance Window")]
            public Byte CasUpperLimitAcceptanceWindow { get; set; } = 67;

            [RestfulProperties("Dynamic Slot Idle Phase")]
            public Byte DynamicSlotIdlePhase { get; set; } = 0;

            [RestfulProperties("Mini Slot")]
            public Byte MiniSlot { get; set; } = 2;

            [RestfulProperties("Mini Slot Action Point Offset")]
            public Byte MiniSlotActionPointOffset { get; set; } = 1;

            [RestfulProperties("Symbol Window")]
            public Byte SymbolWindow { get; set; } = 0;

            [RestfulProperties("Number Of Bits In Transmission Start Sequence")]
            public Byte NumberOfBitsInTransmissionStartSequence { get; set; } = 3;

            [RestfulProperties("Wake Up Channel")]
            public GenericDefines.FLXChannel.ChannelSelect WakeUpChannel { get; set; } = GenericDefines.FLXChannel.ChannelSelect.A;

            [RestfulProperties("Wake Up Symbol RX Idle")]
            public Byte WakeupSymbolRxIdle { get; set; } = 14;

            [RestfulProperties("Wake Up Symbol RX Low")]
            public Byte WakeupSymbolRxLow { get; set; } = 11;

            [RestfulProperties("Wake Up Symbol TX Idle")]
            public Byte WakeupSymbolTxIdle { get; set; } = 45;

            [RestfulProperties("Wake Up Symbol TX Low")]
            public Byte WakeupSymbolTxLow { get; set; } = 15;

            [RestfulProperties("Listen Noise")]
            public Byte ListenNoise { get; set; } = 2;

            [RestfulProperties("Max Without Clock Correction Passive")]
            public Byte MaxWithoutClockCorrectionPassive { get; set; } = 1;

            [RestfulProperties("Max Without Clock Correction Fatal")]
            public Byte MaxWithoutClockCorrectionFatal { get; set; } = 1;

            [RestfulProperties("Payload Length Of Static Frame")]
            public Byte PayloadLengthOfStaticFrame { get; set; } = 0;

            [RestfulProperties("Sync Node Max")]
            public Byte SyncNodeMax { get; set; } = 2;

            [RestfulProperties("Network Management Vector Length")]
            public Byte NetworkManagementVectorLength { get; set; } = 0;

            [RestfulProperties("Allow Halt Due To Clock")]
            public GenericDefines.Generic.Status AllowHaltDueToClock { get; set; } = GenericDefines.Generic.Status.Disabled;

            [RestfulProperties("Allow Passive To Active")]
            public Byte AllowPassiveToActive { get; set; } = 0;

            [RestfulProperties("Cluster Drift Damping")]
            public Byte ClusterDriftDamping { get; set; } = 0;

            [RestfulProperties("Decoding Correction")]
            public Byte DecodingCorrection { get; set; } = 14;

            [RestfulProperties("External Offset Correction")]
            public Byte ExternOffsetCorrection { get; set; } = 0;

            [RestfulProperties("External Rate Correction")]
            public Byte ExternalRateCorrection { get; set; } = 0;

            [RestfulProperties("Key Slot Used For Startup")]
            public GenericDefines.Generic.Status KeySlotUsedForStartup { get; set; } = GenericDefines.Generic.Status.Disabled;

            [RestfulProperties("Key Slot Used For Sync")]
            public GenericDefines.Generic.Status KeySlotUsedForSync { get; set; } = GenericDefines.Generic.Status.Disabled;

            [RestfulProperties("Single Slot Enabled")]
            public GenericDefines.Generic.Status SingleSlotEnabled { get; set; } = GenericDefines.Generic.Status.Disabled;

            [RestfulProperties("Wake Up Pattern")]
            public Byte WakeupPattern { get; set; } = 2;

            [RestfulProperties("Micro Ticks Per Macro Nominal")]
            public Byte MicroTicksPerMacroNominal { get; set; } = 40;

            [RestfulProperties("Maximum Payload Length For Dynamic Frames")]
            public Byte MaximumPayloadLengthForDynamicFrames { get; set; } = 0;

            [RestfulProperties("Macro Ticks Per Cycle")]
            public UInt16 MacroPerCycle { get; set; } = 10;

            [RestfulProperties("Static Slot")]
            public UInt16 StaticSlot { get; set; } = 4;

            [RestfulProperties("Wake Up Symbol RX Window")]
            public UInt16 WakeupSymbolRxWindow { get; set; } = 76;

            [RestfulProperties("Number Of Mini Slots")]
            public UInt16 NumberOfMiniSlots { get; set; } = 0;

            [RestfulProperties("Number Of Static Slots")]
            public UInt16 NumberOfStaticSlots { get; set; } = 4;

            [RestfulProperties("Offset Correction Start")]
            public UInt16 OffsetCorrectionStart { get; set; } = 9;

            [RestfulProperties("Accepted Startup Range")]
            public UInt16 AcceptedStartupRange { get; set; } = 0;

            [RestfulProperties("Max Drift")]
            public UInt16 MaxDrift { get; set; } = 2;

            [RestfulProperties("Key Slot Id")]
            public UInt16 KeySlotId { get; set; } = 1;

            [RestfulProperties("Key Slot Header CRC")]
            public UInt16 KeySlotHeaderCrc { get; set; } = 0;

            [RestfulProperties("Latest TX")]
            public UInt16 LatestTx { get; set; } = 0;

            [RestfulProperties("Offset Correction Out")]
            public UInt16 OffsetCorrectionOut { get; set; } = 13;

            [RestfulProperties("Rate Correction Out")]
            public UInt16 RateCorrectionOut { get; set; } = 2;

            [RestfulProperties("Listen Time Out")]
            public UInt32 ListenTimeOut { get; set; } = 1284;

            [RestfulProperties("Micro Ticks Per Cycle")]
            public UInt32 MicroTicksPerCycle { get; set; } = 640;
        }

        [Serializable]
        public class SimulateSettings : ISettings
        {

            [RestfulProperties("Sync Frame Filtering")]
            public GenericDefines.Generic.Status SyncFrameFiltering { get; set; } = GenericDefines.Generic.Status.Disabled;

            [RestfulProperties("FlexRay Channel Configuration")]
            public FlexRayChannelConfiguration FlexRayChannelConfiguration { get; set; } = FlexRayChannelConfiguration.SingleChannelModeConnector1ConnectedToChannelA;

            [RestfulProperties("Cold Start Enable")]
            public GenericDefines.Generic.Status ColdStartEnable { get; set; } = GenericDefines.Generic.Status.Disabled;

            [RestfulProperties("Cold Start Attempts")]
            public Byte ColdStartAttempts { get; set; } = 2;

            [RestfulProperties("Action Point Offset")]
            public Byte ActionPointOffset { get; set; } = 1;

            [RestfulProperties("CAS Upper Limit Acceptance Window")]
            public Byte CasUpperLimitAcceptanceWindow { get; set; } = 67;

            [RestfulProperties("Dynamic Slot Idle Phase")]
            public Byte DynamicSlotIdlePhase { get; set; } = 0;

            [RestfulProperties("Mini Slot")]
            public Byte MiniSlot { get; set; } = 2;

            [RestfulProperties("Mini Slot Action Point Offset")]
            public Byte MiniSlotActionPointOffset { get; set; } = 1;

            [RestfulProperties("Symbol Window")]
            public Byte SymbolWindow { get; set; } = 0;

            [RestfulProperties("Number Of Bits In Transmission Start Sequence")]
            public Byte NumberOfBitsInTransmissionStartSequence { get; set; } = 3;

            [RestfulProperties("Wake Up Channel")]
            public GenericDefines.FLXChannel.ChannelSelect WakeUpChannel { get; set; } = GenericDefines.FLXChannel.ChannelSelect.A;

            [RestfulProperties("Wake Up Symbol RX Idle")]
            public Byte WakeupSymbolRxIdle { get; set; } = 14;

            [RestfulProperties("Wake Up Symbol RX Low")]
            public Byte WakeupSymbolRxLow { get; set; } = 11;

            [RestfulProperties("Wake Up Symbol TX Idle")]
            public Byte WakeupSymbolTxIdle { get; set; } = 45;

            [RestfulProperties("Wake Up Symbol TX Low")]
            public Byte WakeupSymbolTxLow { get; set; } = 15;

            [RestfulProperties("Listen Noise")]
            public Byte ListenNoise { get; set; } = 2;

            [RestfulProperties("Max Without Clock Correction Passive")]
            public Byte MaxWithoutClockCorrectionPassive { get; set; } = 1;

            [RestfulProperties("Max Without Clock Correction Fatal")]
            public Byte MaxWithoutClockCorrectionFatal { get; set; } = 1;

            [RestfulProperties("Payload Length Of Static Frame")]
            public Byte PayloadLengthOfStaticFrame { get; set; } = 0;

            [RestfulProperties("Sync Node Max")]
            public Byte SyncNodeMax { get; set; } = 2;

            [RestfulProperties("Network Management Vector Length")]
            public Byte NetworkManagementVectorLength { get; set; } = 0;

            [RestfulProperties("Allow Halt Due To Clock")]
            public GenericDefines.Generic.Status AllowHaltDueToClock { get; set; } = GenericDefines.Generic.Status.Disabled;

            [RestfulProperties("Allow Passive To Active")]
            public Byte AllowPassiveToActive { get; set; } = 0;

            [RestfulProperties("Cluster Drift Damping")]
            public Byte ClusterDriftDamping { get; set; } = 0;

            [RestfulProperties("Decoding Correction")]
            public Byte DecodingCorrection { get; set; } = 14;

            [RestfulProperties("External Offset Correction")]
            public Byte ExternOffsetCorrection { get; set; } = 0;

            [RestfulProperties("External Rate Correction")]
            public Byte ExternalRateCorrection { get; set; } = 0;

            [RestfulProperties("Key Slot Used For Startup")]
            public GenericDefines.Generic.Status KeySlotUsedForStartup { get; set; } = GenericDefines.Generic.Status.Disabled;

            [RestfulProperties("Key Slot Used For Sync")]
            public GenericDefines.Generic.Status KeySlotUsedForSync { get; set; } = GenericDefines.Generic.Status.Disabled;

            [RestfulProperties("Single Slot Enabled")]
            public GenericDefines.Generic.Status SingleSlotEnabled { get; set; } = GenericDefines.Generic.Status.Disabled;

            [RestfulProperties("Wake Up Pattern")]
            public Byte WakeupPattern { get; set; } = 2;

            [RestfulProperties("Micro Ticks Per Macro Nominal")]
            public Byte MicroTicksPerMacroNominal { get; set; } = 40;

            [RestfulProperties("Maximum Payload Length For Dynamic Frames")]
            public Byte MaximumPayloadLengthForDynamicFrames { get; set; } = 0;

            [RestfulProperties("Macro Ticks Per Cycle")]
            public UInt16 MacroPerCycle { get; set; } = 10;

            [RestfulProperties("Static Slot")]
            public UInt16 StaticSlot { get; set; } = 4;

            [RestfulProperties("Wake Up Symbol RX Window")]
            public UInt16 WakeupSymbolRxWindow { get; set; } = 76;

            [RestfulProperties("Number Of Mini Slots")]
            public UInt16 NumberOfMiniSlots { get; set; } = 0;

            [RestfulProperties("Number Of Static Slots")]
            public UInt16 NumberOfStaticSlots { get; set; } = 4;

            [RestfulProperties("Offset Correction Start")]
            public UInt16 OffsetCorrectionStart { get; set; } = 9;

            [RestfulProperties("Accepted Startup Range")]
            public UInt16 AcceptedStartupRange { get; set; } = 0;

            [RestfulProperties("Max Drift")]
            public UInt16 MaxDrift { get; set; } = 2;

            [RestfulProperties("Key Slot Id")]
            public UInt16 KeySlotId { get; set; } = 1;

            [RestfulProperties("Key Slot Header CRC")]
            public UInt16 KeySlotHeaderCrc { get; set; } = 0;

            [RestfulProperties("Latest Tx")]
            public UInt16 LatestTx { get; set; } = 0;

            [RestfulProperties("Offset Correction Out")]
            public UInt16 OffsetCorrectionOut { get; set; } = 13;

            [RestfulProperties("Rate Correction Out")]
            public UInt16 RateCorrectionOut { get; set; } = 2;

            [RestfulProperties("Listen Time Out")]
            public UInt32 ListenTimeOut { get; set; } = 1284;

            [RestfulProperties("Micro Ticks Per Cycle")]
            public UInt32 MicroTicksPerCycle { get; set; } = 640;
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
            return Setting.ConvertTo<FLX422ModuleOperationMode>(jsonObject.Settings).OperationMode;
        }

        public void PutItemOperationMode(OperationMode operationMode)
        {
            var operationModeSettings = new ItemOperationMode(this)
            {
                Settings = Setting.ConvertFrom(new FLX422ModuleOperationMode() {OperationMode = operationMode}),
            };
            
            base.PutItemOperationMode(operationModeSettings);
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

        public void PutItemSettings<T>(SettingsCollection<T> settings)
            where T : ISettings
        {
            var jsonObject = new ItemSettings(this);
            jsonObject.UpdateFromSettings(settings.Settings);
            jsonObject.UpdateFromData(settings.Data);
            base.PutItemSettings(jsonObject);
        }

        public FLXModule.Status GetStatus()
        {
            return RestInterface.Get<FLXModule.Status>(EndPoints.FlexRayModuleStatus, HttpParameter.ItemId(ItemId));
        }
    }
}
