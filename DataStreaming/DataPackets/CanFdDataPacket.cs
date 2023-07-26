// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using QProtocol.DataStreaming.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace QProtocol.DataStreaming.DataPackets
{
    /// <summary>
    /// This class contains the Header and Message information of a CAN FD Channel.
    /// </summary>
    public class CanFdDataPacket
    {
        private readonly uint binarySize = 0;

        /// <summary>
        /// A reference the Generic Channel Header received in the Payload.
        /// </summary>
        public GenericChannelHeader GenericChannelHeader { get; }

        /// <summary>
        /// A reference to the Specific Channel Header received in the Payload. It contains additional statical information.
        /// </summary>
        public CanFdChannelHeader CanFdChannelHeader { get; }

        /// <summary>
        /// A list of CAN FD Messages received in the Payload.
        /// </summary>
        public List<CanFdDataMessage> MessageList { get; }

        /// <summary>
        /// Creates a new instance of the <see cref="CanFdDataPacket"/> class while copying the Message Data from the provided stream.
        /// </summary>
        /// <param name="genericChannelHeader">A reference to the Generic Channel Header.</param>
        /// <param name="canFdChannelHeader">A reference to the Specific Channel Header.</param>
        /// <param name="reader">The QServer data stream.</param>
        /// <exception cref="NotImplementedException">When an unsupported Sample Type is encountered.</exception>
        public CanFdDataPacket(GenericChannelHeader genericChannelHeader, CanFdChannelHeader canFdChannelHeader, BinaryReader reader)
        {
            GenericChannelHeader = genericChannelHeader;
            CanFdChannelHeader = canFdChannelHeader;
            MessageList = new List<CanFdDataMessage>();

            switch ((CanFdSampleTypes)GenericChannelHeader.SampleType)
            {
                case CanFdSampleTypes.BinaryCanMessage:
                    for (uint byteIndex = 0; byteIndex < GenericChannelHeader.ChannelDataSize;)
                    {
                        MessageList.Add(new CanFdDataMessage(reader));
                        byteIndex += MessageList.Last().GetBinarySize();
                    }

                    break;

                default:
                    throw new NotImplementedException($"Invalid option received the {nameof(CanFdDataPacket)} {nameof(CanFdSampleTypes)} type.");
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