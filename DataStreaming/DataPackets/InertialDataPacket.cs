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
    /// This class contains the Header and Sample information of an Inertial Channel.
    /// </summary>
    public class InertialDataPacket
    {
        private readonly uint binarySize = 0;

        /// <summary>
        /// A reference the Generic Channel Header received in the Payload
        /// </summary>
        public GenericChannelHeader GenericChannelHeader { get; }

        public List<InertialData> InertialDataList { get; }

        public class InertialData
        {
            /// <summary>
            /// Milliseconds since the start of the test.
            /// </summary>
            public double TimeStamp { get; }

            /// <summary>
            /// Represents the acceleration and angular speed of the device
            /// </summary>
            public InertialDeviceState Inertial { get; }

            /// <summary>
            /// Represents the uncertainty of measurement for the inertia of the device. 
            /// </summary>
            public InertialDeviceState Uncertainty { get; }

            public InertialData(BinaryReader reader)
            {
                TimeStamp = reader.ReadDouble();
                Inertial = new InertialDeviceState(reader);
                Uncertainty = new InertialDeviceState(reader);
            }

            public class InertialDeviceState
            {
                public float AccelerationX;

                public float AccelerationY;
				
				public float AccelerationZ;

                public float GyroscopeX;

                public float GyroscopeY;
				
				public float GyroscopeZ;

                public InertialDeviceState(BinaryReader reader)
                {
                    AccelerationX = reader.ReadSingle();
                    AccelerationY = reader.ReadSingle();
                    AccelerationZ = reader.ReadSingle();
                    GyroscopeX = reader.ReadSingle();
					GyroscopeY = reader.ReadSingle();
					GyroscopeZ = reader.ReadSingle();
                }
            }
        }

        /// <summary>
        /// Creates a new instance of the <see cref="InertialDataMessage"/> class while copying the Message Data from the provided stream.
        /// </summary>
        /// <param name="genericChannelHeader">A reference to the Generic Channel Header.</param>
        /// <param name="reader">The QServer data stream. Samples will be copied into the local property.</param>
        public InertialDataPacket(GenericChannelHeader genericChannelHeader, BinaryReader reader)
        {
            InertialDataList = new List<InertialData>();
            GenericChannelHeader = genericChannelHeader;

            for (uint sampleIndex = 0; sampleIndex < GenericChannelHeader.ChannelDataSize / 56; sampleIndex++)
            {
                var orientationData = new InertialData(reader);
                InertialDataList.Add(orientationData);
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