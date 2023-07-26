// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using System;
using System.IO;

namespace QProtocol.DataStreaming.Headers
{
    /// <summary>
    /// Triggered data can be collected from the Quantus Device by activating the data transfer
    /// on the channel, via the /data/transfer endpoint. Once the data transfer is active
    /// the data in the channels' circular buffer is continuously sent to the client.
    /// </summary>
    public class TriggeredChannelHeader
    {
        private readonly uint binarySize = 0;

        /// <summary>
        /// The current block index, used to track the progress of the data transfer and
        /// to make sure that there are no missing blocks.
        /// BlockIndex / TotalNumberOfBlocks * 100 indicates the progress as percentage
        /// complete.
        /// </summary>
        public UInt64 BlockIndex { get; }

        /// <summary>
        /// The number of samples contained in each block.
        /// </summary>
        public UInt64 SamplesInBlock { get; }

        /// <summary>
        /// The total number of blocks stored in the channels' circular buffer. The
        /// total number of blocks to transfer in order to obtain all the triggered data.
        /// </summary>
        public UInt64 TotalNumberOfBlocks { get; }

        /// <summary>
        /// The scaling factor to be used when converting the raw data into a user-friendly format.
        /// </summary>
        public float ScalingFactor { get; }

        /// <summary>
        /// Creates a new instance of the <see cref="TriggeredChannelHeader"/> class and populates the properties from the stream.
        /// </summary>
        /// <param name="reader">The data stream from QServer.</param>
        public TriggeredChannelHeader(BinaryReader reader)
        {
            BlockIndex = reader.ReadUInt64();
            SamplesInBlock = reader.ReadUInt64();
            TotalNumberOfBlocks = reader.ReadUInt64();
            ScalingFactor = reader.ReadSingle();
            binarySize = 32;
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