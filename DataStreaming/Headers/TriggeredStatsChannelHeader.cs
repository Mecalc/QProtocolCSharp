// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using System.IO;

namespace QProtocol.DataStreaming.Headers
{
    public class TriggeredStatsChannelHeader
    {
        public const int BinarySize = 20;

        public float Min { get; }

        public float Max { get; set; }

        public float Rms { get; set; }

        public float Average { get; set; }

        public float StandardDeviation { get; set; }

        public TriggeredStatsChannelHeader(BinaryReader reader)
        {
            Min = reader.ReadSingle();
            Max = reader.ReadSingle();
            Rms = reader.ReadSingle();
            Average = reader.ReadSingle();
            StandardDeviation = reader.ReadSingle();
        }
    }
}
