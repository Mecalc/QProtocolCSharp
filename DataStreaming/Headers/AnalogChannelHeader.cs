// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using QProtocol.DataStreaming.DataPackets;
using System;
using System.IO;

namespace QProtocol.DataStreaming.Headers
{
    /// <summary>
    /// Provides extra information for the Analog Channel Data Packet.
    /// </summary>
    public class AnalogChannelHeader
    {
        private readonly uint binarySize = 0;

        /// <summary>
        /// Enumeration indicating the integrity status of the channel.
        /// </summary>
        public ChannelIntegrity ChannelIntegrity { get; }

        /// <summary>
        /// This field is currently unsupported and will be fully functional in a future version.
        /// </summary>
        public LevelCrossingErrors LevelCrossingOccurred { get; }

        /// <summary>
        /// A value between 0 and 1 that represents the signal level as a percentage of the full-scale level.
        /// </summary>
        public float Level { get; }

        /// <summary>
        /// The minimum value for this block of data.
        /// </summary>
        public float Min { get; }

        /// <summary>
        /// The maximum value for this block of data.
        /// </summary>
        public float Max { get; }

        /// <summary>
        /// The scaling factor to be used when converting the raw data into a user-friendly format.
        /// </summary>
        public float ScalingFactor { get; }

        /// <summary>
        /// Creates a new instance of the <see cref="AnalogChannelHeader"/> class and populates the properties from the stream.
        /// </summary>
        /// <param name="genericChannelHeader">The generic channel header which was read before this header.</param>
        /// <param name="reader">The data stream from QServer.</param>
        public AnalogChannelHeader(GenericChannelHeader genericChannelHeader, BinaryReader reader)
        {
            ChannelIntegrity = (ChannelIntegrity)reader.ReadInt32();
            LevelCrossingOccurred = (LevelCrossingErrors)reader.ReadInt32();
            Level = reader.ReadSingle();
            Min = reader.ReadSingle();
            Max = reader.ReadSingle();
            binarySize = 20;

            switch ((AnalogSampleTypes)genericChannelHeader.SampleType)
            {
                case AnalogSampleTypes.Float:
                    ScalingFactor = 1.0f;
                    break;

                case AnalogSampleTypes._16BitFixedPoint:
                case AnalogSampleTypes._24BitFixedPoint:
                case AnalogSampleTypes._32BitFixedPoint:
                    ScalingFactor = reader.ReadSingle();
                    binarySize += 4;
                    break;

                default:
                    throw new NotImplementedException($"Invalid option received the {nameof(AnalogDataPacket)} {nameof(AnalogSampleTypes)} type.");
            }
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

    /// <summary>
    /// An enum acting as an placeholder for future feature.
    /// </summary>
    public enum LevelCrossingErrors
    {
        OK = 0,
        CrossingHasOccurred = 1,
    }

    /// <summary>
    /// An enum listing the different types of data integrity states.
    /// </summary>
    public enum ChannelIntegrity
    {
        NotAvailable = -1,
        OK = 0,
        OverloadHasOccurred = 1,
        ShortCircuit = 2,
        OpenCircuit = 3,
        ADCError = 4
    }
}
