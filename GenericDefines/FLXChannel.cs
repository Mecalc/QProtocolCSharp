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
    public class FLXChannel
    {
        public const System.Int32 MaximumRangeFilters = 2;
        public const System.Int32 MaximumMessageLength = 127;

        public enum StatusRequestType
        {
            [RestfulProperties("FlexRay")]
            FlexRay = 0,

            [RestfulProperties("Application")]
            Application = 1,
        }

        public enum ChannelSelect
        {
            [RestfulProperties("Channel A")]
            A = 0,

            [RestfulProperties("Channel B")]
            B = 1,

            [RestfulProperties("Channel A and B")]
            AAndB = 2,

            [RestfulProperties("None")]
            None = 3,
        }

        public enum RingFilterType
        {
            [RestfulProperties("Acceptance Filter")]
            AcceptanceFilter = 0,

            [RestfulProperties("Rejection Filter")]
            RejectionFilter = 1,
        }

        public struct FrameIdRangeFilterStartFrameIdAsUInt16
        {
            public const UInt16 UpperLimit = 30;
            public const UInt16 LowerLimit = 0;
        }

        public struct FrameIdRangeFilterStopFrameIdAsUInt16
        {
            public const UInt16 UpperLimit = 30;
            public const UInt16 LowerLimit = 0;
        }

        [Serializable]
        public class FrameIdRangeFilter
        {
            [RestfulProperties("Status")]
            public GenericDefines.Generic.Status Status { get; set; }

            [RestfulProperties("Filter Type")]
            public RingFilterType FilterType { get; set; }

            [RestfulProperties("Start Frame ID")]
            public UInt16 StartFrameId { get; set; }

            [RestfulProperties("Stop Frame ID")]
            public UInt16 StopFrameId { get; set; }
        }

        public struct FilterParametersValueAsUInt16
        {
            public const UInt16 UpperLimit = 65535;
            public const UInt16 LowerLimit = 0;
        }

        public struct FilterParametersMaskAsUInt16
        {
            public const UInt16 UpperLimit = 65535;
            public const UInt16 LowerLimit = 0;
        }

        [Serializable]
        public class FilterParameters
        {
            [RestfulProperties("Value")]
            public UInt16 Value { get; set; }

            [RestfulProperties("Mask")]
            public UInt16 Mask { get; set; }
        }

        [Serializable]
        public class FifoFilterParameters
        {
            [RestfulProperties("Frame ID Reject filter")]
            public FilterParameters FrameIdRejectFilter { get; set; }

            [RestfulProperties("Message ID Accept filter")]
            public FilterParameters MessageIdAcceptFilter { get; set; }

            [RestfulProperties("Frame ID Range Filter")]
            public List<FrameIdRangeFilter> FrameIdRangeFilter { get; set; }
        }

        [Serializable]
        public class TransmitMessage
        {
            [RestfulProperties("MessageData")]
            public System.Collections.Generic.List<Int16> MessageData { get; set; }
        }

        [Serializable]
        public class StatusRequestTypeSettings
        {
            [RestfulProperties("Status Request Type")]
            public StatusRequestType StatusRequestType { get; set; }
        }

        public struct EventNumberAsInt32
        {
            public const Int32 UpperLimit = 2147483647;
            public const Int32 LowerLimit = 0;
        }

        [Serializable]
        public class Event
        {
            [RestfulProperties("Number")]
            public Int32 Number { get; set; }

            [RestfulProperties("Data")]
            public System.Collections.Generic.List<Int16> Data { get; set; }
        }

        [Serializable]
        public class MessageData
        {
            [RestfulProperties("Message Data")]
            public System.Collections.Generic.List<UInt16> Data { get; set; }
        }

        public struct TransmitBufferFrameIdAsUInt16
        {
            public const UInt16 UpperLimit = 65535;
            public const UInt16 LowerLimit = 0;
        }

        public struct TransmitBufferFrameHeaderCrcAsUInt16
        {
            public const UInt16 UpperLimit = 65535;
            public const UInt16 LowerLimit = 0;
        }

        public struct TransmitBufferPayloadLengthAsByte
        {
            public const Byte UpperLimit = 255;
            public const Byte LowerLimit = 0;
        }

        public struct TransmitBufferPayloadPreambleAsByte
        {
            public const Byte UpperLimit = 1;
            public const Byte LowerLimit = 0;
        }

        public struct TransmitBufferTransmitCycleCounterFilterEnableAsByte
        {
            public const Byte UpperLimit = 1;
            public const Byte LowerLimit = 0;
        }

        public struct TransmitBufferTransmitCycleCounterFilterValueAsByte
        {
            public const Byte UpperLimit = 63;
            public const Byte LowerLimit = 0;
        }

        public struct TransmitBufferTransmitCycleCounterFilterMaskAsByte
        {
            public const Byte UpperLimit = 63;
            public const Byte LowerLimit = 0;
        }

        [Serializable]
        public class TransmitBuffer
        {
            [RestfulProperties("Frame ID")]
            public UInt16 FrameId { get; set; }

            [RestfulProperties("Frame Header CRC")]
            public UInt16 FrameHeaderCrc { get; set; }

            [RestfulProperties("Payload Length")]
            public Byte PayloadLength { get; set; }

            [RestfulProperties("Channel Select")]
            public ChannelSelect ChannelSelect { get; set; }

            [RestfulProperties("Payload Preamble")]
            public Byte PayloadPreamble { get; set; }

            [RestfulProperties("Transmit Cycle Counter Filter Enable")]
            public Byte TransmitCycleCounterFilterEnable { get; set; }

            [RestfulProperties("Transmit Cycle Counter Filter Value")]
            public Byte TransmitCycleCounterFilterValue { get; set; }

            [RestfulProperties("Transmit Cycle Counter Filter Mask")]
            public Byte TransmitCycleCounterFilterMask { get; set; }
        }
    }
}
