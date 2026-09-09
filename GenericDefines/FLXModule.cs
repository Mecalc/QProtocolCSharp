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
    public class FLXModule
    {

        public enum ApplicationStatus
        {
            [RestfulProperties("MSW RX PH2")]
            MswRxPh2 = 0,

            [RestfulProperties("Block B Open")]
            BlockBOpen = 1,

            [RestfulProperties("Dual Channel Mode")]
            DualChannelMode = 2,

            [RestfulProperties("Simulation Mode")]
            SimulationMode = 3,

            [RestfulProperties("SCMD RX PH2")]
            ScmdRxPh2 = 4,

            [RestfulProperties("Channel A Enabled")]
            ChannelAEnabled = 5,

            [RestfulProperties("Channel B Enabled")]
            ChannelBEnabled = 6,

            [RestfulProperties("Test Active")]
            TestActive = 7,

            [RestfulProperties("Channel A Filter Configuration Received")]
            ChannelAFilterConfigurationReceived = 8,

            [RestfulProperties("Channel B Filter Configuration Received")]
            ChannelBFilterConfigurationReceived = 9,

            [RestfulProperties("Transmit Configuration Received")]
            TransmitConfigurationReceived = 10,

            [RestfulProperties("Node Configuration Received")]
            NodeConfigurationReceived = 11,

            [RestfulProperties("Setup State 0 Complete")]
            SetupState0Complete = 12,

            [RestfulProperties("Setup State 1 Complete")]
            SetupState1Complete = 13,

            [RestfulProperties("Setup State 2 Complete")]
            SetupState2Complete = 14,

            [RestfulProperties("Setup State 3 Complete")]
            SetupState3Complete = 15,

            [RestfulProperties("MSW Started")]
            MswStarted = 16,

            [RestfulProperties("Startup Busy")]
            StartupBusy = 17,

            [RestfulProperties("FCC Halt")]
            FccHalt = 18,

            [RestfulProperties("Default Busy")]
            DefaultBusy = 19,

            [RestfulProperties("FCC Interrupt PH2")]
            FccInterruptPh2 = 20,

            [RestfulProperties("FCC Abort")]
            FccAbort = 21,

            [RestfulProperties("IRQ Set")]
            IrqSet = 22,

            [RestfulProperties("Reserved")]
            Reserved = 23,
        }

        public enum ErrorStatus
        {
            [RestfulProperties("MSW PH2 Error")]
            MSswPh2Error = 0,

            [RestfulProperties("DMA1 Busy Error")]
            Dma1BusyError = 1,

            [RestfulProperties("MSW Undefined Error")]
            MswUndefinedError = 2,

            [RestfulProperties("SCMD RX Error")]
            ScCommandRxError = 3,

            [RestfulProperties("Allocation Error")]
            AllocationError = 4,

            [RestfulProperties("Invalid Command Packet")]
            InvalidCommandPacket = 5,

            [RestfulProperties("Transmit Buffer Update Error")]
            TransmitBufferUpdateError = 6,

            [RestfulProperties("Configuration Mode Error")]
            ConfigurationModeError = 7,

            [RestfulProperties("Allocation Error PH2")]
            AllocationErrorPh2 = 8,

            [RestfulProperties("Wakeup Symbol Transmission Error")]
            WakeupSymbolTransmissionError = 9,

            [RestfulProperties("Communication Startup Error")]
            CommunicationStartupError = 10,

            [RestfulProperties("Buffer Overflow Error")]
            BufferOverflowError = 11,

            [RestfulProperties("Communication Halt Error")]
            CommunicationHaltError = 12,

            [RestfulProperties("FCC Buffer Initialization Error")]
            FccBufferInitializationError = 13,

            [RestfulProperties("Leave Configuration Mode Error")]
            LeaveConfigurationModeError = 14,

            [RestfulProperties("FCC Initialization Error")]
            FccInitializationError = 15,

            [RestfulProperties("FCC Configuration Error")]
            FccConfigurationError = 16,

            [RestfulProperties("Channel A Invalid Frame")]
            ChannelAInvalidFrame = 17,

            [RestfulProperties("Channel B Invalid Frame")]
            ChannelBInvalidFrame = 18,

            [RestfulProperties("FCC Reset Error")]
            FccResetError = 19,

            [RestfulProperties("Reserved1")]
            Reserved1 = 20,

            [RestfulProperties("Reserved2")]
            Reserved2 = 21,

            [RestfulProperties("Reserved3")]
            Reserved3 = 22,

            [RestfulProperties("Reserved4")]
            Reserved4 = 23,
        }

        public enum FccProtocolState
        {
            [RestfulProperties("Configuration")]
            Configuration = 0,

            [RestfulProperties("Pre-Configuration")]
            PreConfiguration = 1,

            [RestfulProperties("Halt")]
            Halt = 2,

            [RestfulProperties("Normal Active")]
            NormalActive = 3,

            [RestfulProperties("Normal Passive")]
            NormalPassive = 4,

            [RestfulProperties("Ready")]
            Ready = 5,

            [RestfulProperties("Startup")]
            Startup = 6,

            [RestfulProperties("Wakeup")]
            Wakeup = 7,
        }

        public enum FccWakeupState
        {
            [RestfulProperties("Undefined")]
            Undefined = 0,

            [RestfulProperties("Received Header")]
            ReceivedHeader = 1,

            [RestfulProperties("Received Wakeup Pattern")]
            ReceivedWakeupPattern = 2,

            [RestfulProperties("Collision - Header")]
            CollisionHeader = 3,

            [RestfulProperties("Collision Wakeup Pattern")]
            CollisionWakeupPattern = 4,

            [RestfulProperties("Collision Unknown")]
            CollisionUnknown = 5,

            [RestfulProperties("Transmitted")]
            Transmitted = 6,
        }

        [Serializable]
        public class Status
        {
            [RestfulProperties("Application Status")]
            public ApplicationStatus ApplicationStatus { get; set; }

            [RestfulProperties("Error Status")]
            public ErrorStatus ErrorStatus { get; set; }

            [RestfulProperties("FCC Protocol State")]
            public FccProtocolState FccProtocolState { get; set; }

            [RestfulProperties("FCC Wakeup State")]
            public FccWakeupState FccWakeupState { get; set; }
        }
    }
}
