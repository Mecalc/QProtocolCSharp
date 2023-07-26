// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using System;
using System.IO;

namespace QProtocol.DataStreaming.Headers
{
    /// <summary>
    /// The Packet Header is the first section of each packet. It contains important information about the current packet, such as size, type and sequence number.
    /// </summary>
    public class PacketHeader
    {
        public const uint BinarySize = 32;

        /// <summary>
        /// The number of the packet, useful to ensure the User receives all packets. Should also be used to determine whether the QuantusSoftware has discarded any data due to buffering. The sequence number is set to 0 when a measurement is started.
        /// </summary>
        public ulong SequenceNumber { get; }

        /// <summary>
        /// The time stamp generated when the packet was filled and marked for sending. This can be used in conjunction with the Sequence number to determine if there is missing data. The timestamp is set to 0 when a measurement is started.
        /// </summary>
        public double TransmitTimestamp { get; }

        /// <summary>
        /// The level of the buffer used on the system, useful to ensure the User is collecting data fast enough. Once this value exceeds 45% the QuantusSoftware will start discarding data to protect the system.
        /// </summary>
        public float BufferLevel { get; }

        /// <summary>
        /// The total size of the payload in bytes.
        /// </summary>
        public uint PayloadSize { get; }

        /// <summary>
        /// QuantusSoftware assumes Little Endian; therefore, this value should equate to 0xFFFE. If it does not, the User will need to do endian conversions on the headers, stats and data.
        /// </summary>
        public uint ByteOrderMarker { get; }

        /// <summary>
        /// The payload type is used to identify the type of payload being transmitted by QServer.
        /// </summary>
        public PayloadTypes PayloadType { get; }

        /// <summary>
        /// Creates a new instance of the <see cref="PacketHeader"/> class with the properties set from the provided stream.
        /// </summary>
        /// <param name="reader">A BinaryReader stream which reads from the QServer data stream.</param>
        /// <exception cref="InvalidOperationException">When the ByteOrderMarker is incorrect.</exception>
        public PacketHeader(BinaryReader reader)
        {
            SequenceNumber = reader.ReadUInt64();
            TransmitTimestamp = reader.ReadDouble();
            BufferLevel = reader.ReadSingle();
            PayloadSize = reader.ReadUInt32();
            ByteOrderMarker = reader.ReadUInt32();
            if (ByteOrderMarker != 0xFFFE)
            {
                throw new InvalidOperationException($"{nameof(PacketHeader)} is corrupt");
            }

            PayloadType = (PayloadTypes)reader.ReadUInt32();
        }

        /// <summary>
        /// Returns the number of bytes copied from the stream.
        /// </summary>
        /// <returns>Number of Bytes copied.</returns>
        public uint GetBinarySize()
        {
            return BinarySize;
        }
    }

    /// <summary>
    /// An enum listing the different supported payload types.
    /// </summary>
    public enum PayloadTypes : uint
    {
        Data = 0,
    }
}