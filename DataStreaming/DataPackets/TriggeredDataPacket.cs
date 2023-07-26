// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using QProtocol.DataStreaming.Headers;
using System;
using System.Collections.Generic;
using System.IO;

namespace QProtocol.DataStreaming.DataPackets
{
    /// <summary>
    /// This class contains the Header and Sample information of a Triggered Channel.
    /// </summary>
    public class TriggeredDataPacket
    {
        private readonly uint binarySize = 0;

        /// <summary>
        /// A reference the Generic Channel Header received in the Payload.
        /// </summary>
        public GenericChannelHeader GenericChannelHeader { get; }

        /// <summary>
        /// A reference to the Specific Channel Header received in the Payload. It contains additional statical information.
        /// </summary>
        public TriggeredChannelHeader TriggeredChannelHeader { get; }

        /// <summary>
        /// A list of Samples received in the Payload.
        /// </summary>
        public List<float> SampleList { get; }

        /// <summary>
        /// Creates a new instance of the <see cref="TriggeredDataPacket"/> class and reads the Sample Data from the stream.
        /// </summary>
        /// <param name="genericChannelHeader">A reference to the Generic Channel Header.</param>
        /// <param name="triggeredChannelHeader">A reference to the Specific Channel Header.</param>
        /// <param name="reader">The QServer data stream. Samples will be copied into the local property.</param>
        /// <exception cref="NotImplementedException">If an unknown triggered Sample Type was received.</exception>
        public TriggeredDataPacket(GenericChannelHeader genericChannelHeader, TriggeredChannelHeader triggeredChannelHeader, BinaryReader reader)
        {
            GenericChannelHeader = genericChannelHeader;
            TriggeredChannelHeader = triggeredChannelHeader;
            SampleList = new List<float>();
            switch ((TriggeredSampleTypes)GenericChannelHeader.SampleType)
            {
                case TriggeredSampleTypes.Float:
                    for (int sampleIndex = 0; sampleIndex < GenericChannelHeader.ChannelDataSize / 4; sampleIndex++)
                    {
                        SampleList.Add(reader.ReadSingle());
                    }

                    break;

                case TriggeredSampleTypes._24BitFixedPoint:
                    for (int sampleIndex = 0; sampleIndex < GenericChannelHeader.ChannelDataSize / 3; sampleIndex++)
                    {
                        var bytes = reader.ReadBytes(3);
                        SampleList.Add((bytes[2] << 24 | (bytes[1] << 16) | (bytes[0] << 8)) * TriggeredChannelHeader.ScalingFactor);
                    }

                    break;

                default:
                    throw new NotImplementedException($"Invalid option received the {nameof(TriggeredDataPacket)} {nameof(TriggeredSampleTypes)} type.");
            }

            binarySize = genericChannelHeader.ChannelDataSize;
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