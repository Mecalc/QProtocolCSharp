// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using QProtocol.DataStreaming.Headers;
using System.IO;

namespace QProtocol.DataStreaming.DataPackets
{
    /// <summary>
    /// Work in progress - Provides extra information for the Triggered Channel, Scope Data Packet.
    /// </summary>
    public class TriggeredScopePacket
    {
        private readonly uint binarySize = 0;

        /// <summary>
        /// A reference the Generic Channel Header received in the Payload.
        /// </summary>
        public GenericChannelHeader GenericChannelHeader { get; }

        /// <summary>
        /// A reference to the Specific Channel Header received in the Payload. It contains additional statical information.
        /// </summary>
        public TriggeredScopeChannelHeader TriggeredScopeChannelHeader { get; }

        /// <summary>
        /// Creates a new instance of the <see cref="AnalogDataPacket"/> class and reads the Sample Data from the stream.
        /// </summary>
        /// <param name="genericChannelHeader">A reference to the Generic Channel Header.</param>
        /// <param name="triggeredScopeChannelHeader">A reference to the Specific Channel Header.</param>
        /// <param name="reader">The QServer data stream. Samples will be copied into the local property.</param>
        /// <exception cref="NotImplementedException">IF an unknown Analog Sample Type was received.</exception>
        public TriggeredScopePacket(GenericChannelHeader genericChannelHeader, TriggeredScopeChannelHeader triggeredScopeChannelHeader, BinaryReader reader)
        {
            GenericChannelHeader = genericChannelHeader;
            TriggeredScopeChannelHeader = triggeredScopeChannelHeader;
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