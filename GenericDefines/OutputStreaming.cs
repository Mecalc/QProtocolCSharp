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
    public class OutputStreaming
    {

        public enum Mode
        {
            [RestfulProperties("Streaming")]
            Streaming = 0,

            [RestfulProperties("Loop")]
            Loop = 1,
        }

        public enum Fallback
        {
            [RestfulProperties("Zero")]
            Zero = 0,

            [RestfulProperties("Fade to zero")]
            FadeToZero = 1,
        }

        public struct OutputStartTimeStartTimeAsUInt64
        {
            public const UInt64 UpperLimit = 18446744073709551615;
            public const UInt64 LowerLimit = 0;
        }

        [Serializable]
        public class OutputStartTime
        {
            [RestfulProperties("Start Time")]
            public UInt64 StartTime { get; set; }
        }
    }
}
