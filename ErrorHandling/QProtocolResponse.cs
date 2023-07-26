// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using System;

namespace QProtocol.ErrorHandling
{
    [Serializable]
    public class QProtocolResponse
    {
        public MessageType Type { get; set; }

        public StatusCodes StatusCode { get; set; }

        public string Message { get; set; }
    }

    public enum MessageType
    {
        StatusMessage,
        InfoMessage,
        ErrorMessage
    }

    public enum StatusCodes
    {
        Failure,
        Success,
        InvalidConfiguration,
        Updated,
        RequiresRestart,
        InvalidId,
        VersionMismatch,
        ActionNotFound,
        ChannelOnly,
        AnalogOutputChannelOnly,
        DataChannelOnly,
        ChannelDisabled,
        ChannelDoesNotSupportTestSignals,
        ChannelDoesNotSupportTeds,
        ActionHasSideEffects,
        AutoZeroNotSupported,
        AutoZeroFailed,
        ReadingStatusRegisterFailed,
        StatusRegisterNotSupported,
        CanFdChannelOnly,
        CanFdChannelParticipateModeOnly,
        WsbChannelOnly,
        GpsChannelOnly,
        InvalidSettings,
        Error
    }
}
