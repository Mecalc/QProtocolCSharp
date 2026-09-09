// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using QProtocol.Attributes;
using System;

namespace QProtocol
{
    [Serializable]
    public class AloOutputStartTime
    {
        public const UInt64 UpperLimit = 18446744073709551615;
        public const UInt64 LowerLimit = 0;

        [RestfulProperties("Start Time")]
        public UInt64 StartTime { get; set; }
    }
}
