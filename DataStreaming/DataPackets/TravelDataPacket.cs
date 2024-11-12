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
    /// This class contains the Header and Sample information of an Travel Channel.
    /// </summary>
    public class TravelDataPacket
    {
        private readonly uint binarySize = 0;

        /// <summary>
        /// A reference the Generic Channel Header received in the Payload
        /// </summary>
        public GenericChannelHeader GenericChannelHeader { get; }

        public List<TravelData> TravelDataList { get; }

        public class TravelData
        {
            /// <summary>
            /// Milliseconds since the start of the test.
            /// </summary>
            public double TimeStamp { get; }

            /// <summary>
            /// Represents the acceleration and angular speed of the device
            /// </summary>
            public TravelDeviceState Travel { get; }

            /// <summary>
            /// Represents the uncertainty of measurement for the inertia of the device. 
            /// </summary>
            public TravelDeviceState Uncertainty { get; }

            public TravelData(BinaryReader reader)
            {
                TimeStamp = reader.ReadDouble();
                Travel = new TravelDeviceState(reader);
                Uncertainty = new TravelDeviceState(reader);
            }

            public class TravelDeviceState
            {
                public float Speed;

                public float Acceleration;

                public TravelDeviceState(BinaryReader reader)
                {
                    Speed = reader.ReadSingle();
                    Acceleration = reader.ReadSingle();
                }
            }
        }

        /// <summary>
        /// Creates a new instance of the <see cref="TravelDataMessage"/> class while copying the Message Data from the provided stream.
        /// </summary>
        /// <param name="genericChannelHeader">A reference to the Generic Channel Header.</param>
        /// <param name="reader">The QServer data stream. Samples will be copied into the local property.</param>
        public TravelDataPacket(GenericChannelHeader genericChannelHeader, BinaryReader reader)
        {
            TravelDataList = new List<TravelData>();
            GenericChannelHeader = genericChannelHeader;

            for (uint sampleIndex = 0; sampleIndex < GenericChannelHeader.ChannelDataSize / 24; sampleIndex++)
            {
                var orientationData = new TravelData(reader);
                TravelDataList.Add(orientationData);
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