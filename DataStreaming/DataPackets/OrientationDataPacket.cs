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
    /// This class contains the Header and Sample information of an Orientation Channel.
    /// </summary>
    public class OrientationDataPacket
    {
        private readonly uint binarySize = 0;

        /// <summary>
        /// A reference the Generic Channel Header received in the Payload
        /// </summary>
        public GenericChannelHeader GenericChannelHeader { get; }

        public List<OrientationData> OrientationDataList { get; }

        public class OrientationData
        {
            /// <summary>
            /// Milliseconds since the start of the test.
            /// </summary>
            public double TimeStamp { get; }

            /// <summary>
            /// Represents the orientation (tilt) of the device. 
            /// To calculate the device's axis vectors in 3D space, apply the angles in the following order:
            /// roll, then pitch.
            /// </summary>
            public OrientationDeviceState Orientation { get; }

            /// <summary>
            /// Represents the uncertainty of measurement for the orientation of the device. 
            /// </summary>
            public OrientationDeviceState Uncertainty { get; }

            public OrientationData(BinaryReader reader)
            {
                TimeStamp = reader.ReadDouble();
                Orientation = new OrientationDeviceState(reader);
                Uncertainty = new OrientationDeviceState(reader);
            }

            public class OrientationDeviceState
            {
                public float Pitch;

                public float Roll;

                public float PitchRate;

                public float RollRate;

                public OrientationDeviceState(BinaryReader reader)
                {
                    Pitch = reader.ReadSingle();
                    Roll = reader.ReadSingle();
                    PitchRate = reader.ReadSingle();
                    RollRate = reader.ReadSingle();
                }
            }
        }

        /// <summary>
        /// Creates a new instance of the <see cref="OrientationDataMessage"/> class while copying the Message Data from the provided stream.
        /// </summary>
        /// <param name="genericChannelHeader">A reference to the Generic Channel Header.</param>
        /// <param name="reader">The QServer data stream. Samples will be copied into the local property.</param>
        public OrientationDataPacket(GenericChannelHeader genericChannelHeader, BinaryReader reader)
        {
            OrientationDataList = new List<OrientationData>();
            GenericChannelHeader = genericChannelHeader;

            for (uint sampleIndex = 0; sampleIndex < GenericChannelHeader.ChannelDataSize / 40; sampleIndex++)
            {
                var orientationData = new OrientationData(reader);
                OrientationDataList.Add(orientationData);
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