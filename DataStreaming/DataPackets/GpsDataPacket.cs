// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using QProtocol.DataStreaming.Headers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace QProtocol.DataStreaming.DataPackets
{
    public class GpsDataPacket
    {
        private readonly uint binarySize = 0;

        /// <summary>
        /// A reference the Generic Channel Header received in the Payload.
        /// </summary>
        public GenericChannelHeader GenericChannelHeader { get; }

        /// <summary>
        /// A reference to the Specific Channel Header received in the Payload. It contains additional statical information.
        /// </summary>
        public GpsChannelHeader GpsChannelHeader { get; }

        /// <summary>
        /// The message string received in the Payload.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Creates a new instance of the <see cref="GpsDataPacket"/> class and copies the data from the payload into the properties.
        /// </summary>
        /// <param name="genericChannelHeader">An instance of the generic channel header.</param>
        /// <param name="gpsChannelHeader">An instance of the specific channel header.</param>
        /// <param name="reader">The binary reader used to copy the data from.</param>
        public GpsDataPacket(GenericChannelHeader genericChannelHeader, GpsChannelHeader gpsChannelHeader, BinaryReader reader)
        {
            GenericChannelHeader = genericChannelHeader;
            GpsChannelHeader = gpsChannelHeader;
            Message = Encoding.ASCII.GetString(reader.ReadBytes((int)genericChannelHeader.ChannelDataSize));
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
