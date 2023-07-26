// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using System.IO;

namespace QProtocol.DataStreaming.Headers
{
    public class TriggeredScopeChannelHeader
    {
        public const int BinarySize = 24;

        public TriggerStatus TriggerStatus { get; }

        public float Min { get; }

        public float Max { get; set; }

        public float Rms { get; set; }

        public float Average { get; set; }

        public float StandardDeviation { get; set; }

        public TriggeredScopeChannelHeader(BinaryReader reader)
        {
            TriggerStatus = (TriggerStatus)reader.ReadUInt32();
            Min = reader.ReadSingle();
            Max = reader.ReadSingle();
            Rms = reader.ReadSingle();
            Average = reader.ReadSingle();
            StandardDeviation = reader.ReadSingle();
        }
    }

    public enum TriggerStatus
    {
        /// <summary>
        /// All Triggers disabled and state machines places in RESET states.
        /// </summary>
        Reset = 0,

        /// <summary>
        /// Start trigger state machines - release from RESET state.
        /// </summary>
        Start = 1,

        /// <summary>
        /// Start collecting PreTrigger samples.
        /// </summary>
        Pretrigger = 2,

        /// <summary>
        /// PreTrigger full, continue collecting samples in a circular buffer. Wait for trigger to be ARMED (Can't trigger in this state).
        /// </summary>
        Ready = 3,

        /// <summary>
        /// Start testing for a trigger condition. (Will trigger if condition is met).
        /// </summary>
        Armed = 4,

        /// <summary>
        /// Trigger condition met and triggered. Continue collecting post trigger data until post trigger buffer is filled.
        /// </summary>
        Triggered = 5,

        /// <summary>
        /// Buffered is filled. Stop all processes and wait for data to be downloaded.
        /// </summary>
        Finished = 6,
    }
}
