// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using System.IO;

namespace QProtocol.DataStreaming.Headers
{
    /// <summary>
    /// The Generic Channel Header supplies the information required to start parsing the data. It specifies the sample type, the channel type and size of the samples.
    /// </summary>
    public class GenericChannelHeader
    {
        public const uint BinarySize = 24;

        /// <summary>
        /// Unique identifier for the channel.
        /// </summary>
        public int ChannelId { get; }

        /// <summary>
        /// Unique enumeration which will indicate the specific Data Type based on the Channel Type.
        /// See enumeration below for supported SampleType for each ChannelType.
        /// </summary>
        public int SampleType { get; }

        /// <summary>
        /// Unique enumeration for the Channel type.
        /// </summary>
        public ChannelTypes ChannelType { get; }

        /// <summary>
        /// Size of the channel data in bytes.
        /// </summary>
        public uint ChannelDataSize { get; }

        /// <summary>
        /// Timestamp - Analog data: Indicates the elapsed time in nanoseconds from the PTP Master clock’s epoch for the first sample of analog data. If PTP synchronization is not active, it indicates the elapsed time in nanoseconds from the start of the measurement.
        /// Offset - Digital data  : Indicates the offset in nanoseconds to be added to each sample for digital channels.
        /// </summary>
        public ulong Timestamp { get; }

        /// <summary>
        /// Creates a new instance of the <see cref="GenericChannelHeader"/> with the properties set from the provided stream.
        /// </summary>
        /// <param name="reader">A BinaryReader stream which reads from the QServer data stream.</param>
        public GenericChannelHeader(BinaryReader reader)
        {
            ChannelId = reader.ReadInt32();
            SampleType = reader.ReadInt32();
            ChannelType = (ChannelTypes)reader.ReadInt32();
            ChannelDataSize = reader.ReadUInt32();
            Timestamp = reader.ReadUInt64();
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
    /// An enum listing the different supported Channel data types.
    /// </summary>
    public enum ChannelTypes
    {
        Analog = 0,
        Tacho = 1,
        CanFd = 2,
        TriggeredData = 4,
        TriggeredScope = 5
    }

    /// <summary>
    /// An enum listing the supported sample types for an Analog Channel.
    /// </summary>
    public enum AnalogSampleTypes
    {
        Float = 0,
        _16BitFixedPoint,
        _24BitFixedPoint,
        _32BitFixedPoint
    }

    /// <summary>
    /// An enum listing the supported sample types for a Tacho Channel.
    /// </summary>
    public enum TachoSampleTypes
    {
        Timestamps = 0,
    }

    /// <summary>
    /// An enum listing the supported sample types for a CAN FD Channel.
    /// </summary>
    public enum CanFdSampleTypes
    {
        BinaryCanMessage = 0,
    }

    /// <summary>
    /// An enum listing the supported sample types for a Trigger channel.
    /// </summary>
    public enum TriggeredSampleTypes
    {
        Float = 0,
        _24BitFixedPoint,
    }
}
