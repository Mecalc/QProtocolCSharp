// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using System.IO;

namespace QProtocol.DataStreaming.Headers
{
    /// <summary>
    /// Provides extra information for the GPS Channel Data Packet.
    /// </summary>
    public class GpsChannelHeader
    {
        private readonly uint binarySize = 0;

        /// <summary>
        /// Timestamp captured by the GPS device in milliseconds when the message was received, a timestamp value
        /// is relative to the start of the measurement.
        /// </summary>
        public double Timestamp { get; }

        /// <summary>
        /// Time Accuracy Estimate in ns.
        /// </summary>
        public ushort AccuracyInNanoSeconds { get; set; }

        /// <summary>
        /// A validity flag indicating if the leap seconds value is valid.
        /// </summary>
        public byte IsLeapSecondsValid { get; }

        /// <summary>
        /// The GPS leap seconds.
        /// </summary>
        public byte LeapSeconds { get; }

        /// <summary>
        /// Creates a new instance of the <see cref="GpsChannelHeader"/> class and copies the data from stream into the properties.
        /// </summary>
        /// <param name="reader">The binary stream from QServer.</param>
        public GpsChannelHeader(BinaryReader reader)
        {
            Timestamp = reader.ReadDouble();
            AccuracyInNanoSeconds = reader.ReadUInt16();
            IsLeapSecondsValid = reader.ReadByte();
            LeapSeconds = reader.ReadByte();
            binarySize = 12;
        }

        /// <summary>
        /// Returns the number of bytes copied from the stream.
        /// </summary>
        /// <returns>Number of Bytes copied.</returns>
        public uint GetBinarySize()
        {
            return binarySize;
        }
    }
}
