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
    /// This class contains the Header and Sample information of an Analog Channel.
    /// </summary>
    public class TachoDataPacket
    {
        private readonly uint binarySize = 0;

        /// <summary>
        /// A reference the Generic Channel Header received in the Payload
        /// </summary>
        public GenericChannelHeader GenericChannelHeader { get; }

        /// <summary>
        /// A list of Timestamps received in the Payload.
        /// </summary>
        public List<double> TimestampList { get; }

        /// <summary>
        /// Creates a new instance of the <see cref="TachoDataPacket"/> class and reads the Timestamp Data from the stream.
        /// </summary>
        /// <param name="genericChannelHeader">A reference to the Generic Channel Header.</param>
        /// <param name="reader">The QServer data stream. Samples will be copied into the local property.</param>
        /// <exception cref="NotImplementedException">IF an unknown Tacho Sample Type was received.</exception>
        public TachoDataPacket(GenericChannelHeader genericChannelHeader, BinaryReader reader)
        {
            GenericChannelHeader = genericChannelHeader;
            TimestampList = new List<double>();
            switch ((TachoSampleTypes)GenericChannelHeader.SampleType)
            {
                case TachoSampleTypes.Timestamps:
                    for (int sampleIndex = 0; sampleIndex < GenericChannelHeader.ChannelDataSize / 8; sampleIndex++)
                    {
                        TimestampList.Add(reader.ReadDouble());
                    }

                    break;

                default:
                    throw new NotImplementedException($"Invalid option received the {nameof(TachoDataPacket)} {nameof(TachoSampleTypes)} type.");
            }

            binarySize = GenericChannelHeader.ChannelDataSize;
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