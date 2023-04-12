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
    public class CanFdChannel
    {
        public const System.Int32 MaximumNumberOfFilterIds = 32;
        public const System.Int32 MaximumMessageLength = 64;
        public const System.Int32 MaximumSendLogicalIndex = 12;

        public enum FaultModes
        {
            [RestfulProperties("Error Active")]
            ErrorActive = 0,

            [RestfulProperties("Error Passive")]
            ErrorPassive = 1,

            [RestfulProperties("Bus Off")]
            BusOff = 2,
        }

        public enum FaultFlags
        {
            [RestfulProperties("No Error")]
            NoError = 0,

            [RestfulProperties("Transmission Not Acknowledged")]
            TransmissionNotAcknowledged = 1,

            [RestfulProperties("Reception Bus Error")]
            ReceptionBusError = 2,

            [RestfulProperties("Transmission Bit Error")]
            TransmissionBitError = 3,
        }

        public struct MessageSettingsMessageIdAsUInt32
        {
            public const UInt32 UpperLimit = 4294967295;
            public const UInt32 LowerLimit = 0;
        }

        public struct MessageSettingsMessageLengthAsUInt32
        {
            public const UInt32 UpperLimit = 64;
            public const UInt32 LowerLimit = 0;
        }

        public struct MessageSettingsTransmitPeriodInMillisecondsAsUInt32
        {
            public const UInt32 UpperLimit = 4294967295;
            public const UInt32 LowerLimit = 0;
        }

        public struct MessageSettingsHoldPeriodInMillisecondsAsUInt32
        {
            public const UInt32 UpperLimit = 4294967295;
            public const UInt32 LowerLimit = 0;
        }

        [Serializable]
        public class MessageSettings
        {
            [RestfulProperties("Extended Frame")]
            public GenericDefines.Generic.Status ExtendedFrame { get; set; }

            [RestfulProperties("Message ID")]
            public UInt32 MessageId { get; set; }

            [RestfulProperties("Message Length")]
            public UInt32 MessageLength { get; set; }

            [RestfulProperties("Transmit Period In Milliseconds")]
            public UInt32 TransmitPeriodInMilliseconds { get; set; }

            [RestfulProperties("Hold Period In Milliseconds")]
            public UInt32 HoldPeriodInMilliseconds { get; set; }
        }

        [Serializable]
        public class MessageData
        {
            [RestfulProperties("Message Data")]
            public System.Collections.Generic.List<Byte> Data { get; set; }
        }

        [Serializable]
        public class TransmitMessage
        {
            [RestfulProperties("")]
            public MessageSettings Settings { get; set; }

            [RestfulProperties("")]
            public MessageData MessageData { get; set; }
        }

        public struct FaultStatusTransmitErrorCountAsUInt32
        {
            public const UInt32 UpperLimit = 4294967295;
            public const UInt32 LowerLimit = 0;
        }

        public struct FaultStatusReceiveErrorCountAsUInt32
        {
            public const UInt32 UpperLimit = 4294967295;
            public const UInt32 LowerLimit = 0;
        }

        public struct FaultStatusMissedIncomingMessagesAsByte
        {
            public const Byte UpperLimit = 255;
            public const Byte LowerLimit = 0;
        }

        public struct FaultStatusFrozenAsByte
        {
            public const Byte UpperLimit = 255;
            public const Byte LowerLimit = 0;
        }

        [Serializable]
        public class FaultStatus
        {
            [RestfulProperties("Transmit Error Count")]
            public UInt32 TransmitErrorCount { get; set; }

            [RestfulProperties("Receive Error Count")]
            public UInt32 ReceiveErrorCount { get; set; }

            [RestfulProperties("Missed Incoming Messages")]
            public Byte MissedIncomingMessages { get; set; }

            [RestfulProperties("Fault Mode")]
            public FaultModes FaultMode { get; set; }

            [RestfulProperties("CAN Peripheral Is Frozen")]
            public Byte Frozen { get; set; }

            [RestfulProperties("Flags")]
            public FaultFlags Flags { get; set; }
        }
    }
}
