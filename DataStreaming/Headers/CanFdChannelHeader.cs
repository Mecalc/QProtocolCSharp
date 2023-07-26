// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using System.IO;

namespace QProtocol.DataStreaming.Headers
{
    /// <summary>
    /// Reserved to provides extra information for the CAN FD Channel Data Packet.
    /// </summary>
    public class CanFdChannelHeader
    {
        private readonly uint binarySize = 0;

        /// <summary>
        /// This field is currently unsupported and will be fully functional in a future version.
        /// </summary>
        public uint Reserved1 { get; }

        /// <summary>
        /// This field is currently unsupported and will be fully functional in a future version.
        /// </summary>
        public uint Reserved2 { get; }

        /// <summary>
        /// This field is currently unsupported and will be fully functional in a future version.
        /// </summary>
        public uint Reserved3 { get; }

        /// <summary>
        /// This field is currently unsupported and will be fully functional in a future version.
        /// </summary>
        public uint Reserved4 { get; }

        /// <summary>
        /// This field is currently unsupported and will be fully functional in a future version.
        /// </summary>
        public uint Reserved5 { get; }

        /// <summary>
        /// This field is currently unsupported and will be fully functional in a future version.
        /// </summary>
        public uint Reserved6 { get; }

        /// <summary>
        /// Creates a new instance of the <see cref="CanFdChannelHeader"/> class and populates the properties from the stream.
        /// </summary>
        /// <param name="reader">The data stream from QServer.</param>
        public CanFdChannelHeader(BinaryReader reader)
        {
            Reserved1 = reader.ReadUInt32();
            Reserved2 = reader.ReadUInt32();
            Reserved3 = reader.ReadUInt32();
            Reserved4 = reader.ReadUInt32();
            Reserved5 = reader.ReadUInt32();
            Reserved6 = reader.ReadUInt32();
            binarySize = 24;
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