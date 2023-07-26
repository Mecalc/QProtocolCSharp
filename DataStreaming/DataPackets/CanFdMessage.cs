// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using System.IO;

namespace QProtocol.DataStreaming.DataPackets
{
    /// <summary>
    /// This class contains the Message information of a single CAN FD Message.
    /// </summary>
    public class CanFdDataMessage
    {
        private readonly uint binarySize = 0;

        /// <summary>
        /// A time-stamp captured by the CAN device when the message was received, a time-stamp value is relative to the start of the measurement.
        /// </summary>
        public double TimeStamp { get; }

        /// <summary>
        /// Unique message identifier.
        /// </summary>
        public uint Id { get; }

        /// <summary>
        /// The CAN FD Message header.
        /// </summary>
        public byte Header { get; }

        /// <summary>
        /// Extended or Standard format.
        /// </summary>
        public byte FrameFormat { get; }

        /// <summary>
        /// Data or Remote type.
        /// </summary>
        public byte FrameType { get; }

        /// <summary>
        /// Number of bytes in the data field.
        /// </summary>
        public byte DataFieldLength { get; }

        /// <summary>
        /// Variable length data (1 to 64 bytes).
        /// </summary>
        public byte[] Data { get; }

        /// <summary>
        /// Creates a new instance of the <see cref="CanFdDataMessage"/> class while copying the Message Data from the provided stream.
        /// </summary>
        /// <param name="reader">The QServer data stream. Samples will be copied into the local property.</param>
        public CanFdDataMessage(BinaryReader reader)
        {
            TimeStamp = reader.ReadDouble();
            Id = reader.ReadUInt32();
            Header = reader.ReadByte();
            FrameFormat = reader.ReadByte();
            FrameType = reader.ReadByte();
            DataFieldLength = reader.ReadByte();
            Data = reader.ReadBytes(DataFieldLength);
            binarySize = 16 + (uint)DataFieldLength;
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