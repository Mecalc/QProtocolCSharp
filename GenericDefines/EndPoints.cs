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

namespace QProtocol.GenericDefines
{
    [Serializable]
    public class EndPoints
    {
        public const System.String Endpoints = "/endpoints/";
        public const System.String Version = "/version/";
        public const System.String ItemId = "itemId";
        public const System.String TedsInfo = "/tedsInfo/";
        public const System.String MessageIndex = "MessageIndex";
        public const System.String RecordingStart = "/recording/start/";
        public const System.String RecordingStop = "/recording/stop/";
        public const System.String RecordingStartPreRun = "/recording/startPreRun/";
        public const System.String RecordingState = "/recording/state/";
        public const System.String LocalStorageSettings = "/localStorage/settings/";
        public const System.String SystemSettings = "/system/settings/";
        public const System.String SystemSettingsApply = "/system/settings/apply/";
        public const System.String SystemSettingsResetToDefaults = "/system/settings/resetToDefaults/";
        public const System.String SystemTime = "/system/time/";
        public const System.String ItemList = "/item/list/";
        public const System.String DataStreamSetup = "/dataStream/setup/";
        public const System.String DataStreamSuspend = "/dataStream/suspend/";
        public const System.String DataStreamResume = "/dataStream/resume/";
        public const System.String ItemOperationMode = "/item/operationMode/";
        public const System.String ItemSettings = "/item/settings/";
        public const System.String ItemSettingsDefaults = "/item/settings/defaults/";
        public const System.String AutoZeroSettings = "/autoZero/settings/";
        public const System.String AutoZeroSettingsApply = "/autoZero/settings/apply/";
        public const System.String AloFaultCondition = "/alo/FaultCondition/";
        public const System.String CanFdMessageList = "/canfd/message/list/";
        public const System.String CanFdMessageTransmit = "/canfd/message/transmit/";
        public const System.String CanFdMessageAbortTransmission = "/canfd/message/abortTransmission/";
        public const System.String CanFdBusStatusList = "/canfd/bus/status/list/";
        public const System.String BridgeBalanceApply = "/wsb/bridgeBalance/apply/";
        public const System.String BridgeBalanceReset = "/wsb/bridgeBalance/reset/";
        public const System.String InfoPing = "/info/ping/";
        public const System.String Ali42xTriggerDisable = "/ali42x/trigger/disable/";
        public const System.String Ali42xTriggerEnable = "/ali42x/trigger/enable/";
        public const System.String Ali42xTriggerArm = "/ali42x/trigger/arm/";
        public const System.String Ali42xTriggerSoftwareTrigger = "/ali42x/trigger/softwareTrigger/";
        public const System.String Ali42xDataTransfer = "/ali42x/data/transfer/";
        public const System.String Ali42xDataStopTransfer = "/ali42x/data/stopTransfer/";
        public const System.String Ali42xDataStatus = "/ali42x/data/status/";
        public const System.String Ali42xDataClearBuffer = "/ali42x/data/clearBuffer/";
        public const System.String Ali42xOffsetVoltage = "/ali42x/offsetVoltage/";
        public const System.String Ali42xExcitationVoltage = "/ali42x/excitationVoltage/";
    }
}
