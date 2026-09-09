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
        public const System.String SystemStatus = "/SystemStatus/";
        public const System.String Endpoints = "/endpoints/";
        public const System.String Version = "/version/";
        public const System.String ItemId = "itemId";
        public const System.String TedsInfo = "/tedsInfo/";
        public const System.String MessageIndex = "MessageIndex";
        public const System.String ModuleFrontPanel = "/module/frontPanel/";
        public const System.String ChannelUserDefinedName = "/channel/userDefinedName/";
        public const System.String RecordingStart = "/recording/start/";
        public const System.String RecordingStop = "/recording/stop/";
        public const System.String RecordingStartPreRun = "/recording/startPreRun/";
        public const System.String RecordingState = "/recording/state/";
        public const System.String RecordingStats = "/recording/stats/";
        public const System.String AloBlockSize = "/alo/blockSize/";
        public const System.String AloClearData = "/alo/clearData/";
        public const System.String AloStartDataStreaming = "/alo/startDataStreaming/";
        public const System.String AloStopDataStreaming = "/alo/stopDataStreaming/";
        public const System.String AloPort = "/alo/Port/";
        public const System.String LocalStorageSettings = "/localStorage/settings/";
        public const System.String LocalStorageMeasurementList = "/localStorage/measurement/list/";
        public const System.String SystemSettings = "/system/settings/";
        public const System.String SystemCalibrate = "/system/Calibrate/";
        public const System.String SystemSettingsApply = "/system/settings/apply/";
        public const System.String SystemSettingsResetToDefaults = "/system/settings/resetToDefaults/";
        public const System.String SystemTime = "/system/time/";
        public const System.String SystemUpTime = "/system/Uptime/";
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
        public const System.String FlexRayTransmit = "/flexRay/transmit/";
        public const System.String FlexRayStatus = "/flexRay/status/";
        public const System.String FlexRayModuleStatus = "/flexRay/module/status/";
        public const System.String FlexRayReadEventQueue = "/flexRay/events/";
        public const System.String CanFdMessageList = "/canfd/message/list/";
        public const System.String CanFdMessageTransmit = "/canfd/message/transmit/";
        public const System.String CanFdMessageAbortTransmission = "/canfd/message/abortTransmission/";
        public const System.String CanFdBusStatusList = "/canfd/bus/status/list/";
        public const System.String BridgeBalanceApply = "/wsb/bridgeBalance/apply/";
        public const System.String BridgeBalanceReset = "/wsb/bridgeBalance/reset/";
        public const System.String InfoPing = "/info/ping/";
    }
}
