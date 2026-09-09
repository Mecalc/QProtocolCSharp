// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using System;
using QProtocol.DataStreaming.Headers;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.IO;

namespace QProtocol.DataStreaming.DataPackets
{
    /// <summary>
    /// This class contains the Header and Sample information of an Travel Channel.
    /// </summary>
    public class FlexRayDataPacket
    {
        private readonly uint binarySize = 0;

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct MoFLXMSG
        {
            public byte ucHeader; // FlexRay Header
            public UInt32 ulID; // SlotID 18_bit_slot_id
            public UInt16 usStatus; // Slot status (16 bits)
            public byte ucDataFieldLen; // Payload length (8 bits) - Number of two byte data field words

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
            public UInt16[] ausDataField; // Data_0 to Data_127 two byte words

            public UInt32 ulFlexTimeStamp; // Flexray Timestamp - Current cycle and macrotick when read from fifo
            public UInt32 ulTimeStampH; // Modacs Timestamp = MRC Count High
            public UInt32 ulTimeStampL; // Modacs Timestamp = MRC Count Low
            public UInt32 ul64LDAC; // Modacs Timestamp = MRC Count LDAC
        }

        /// <summary>
        /// A reference the Generic Channel Header received in the Payload
        /// </summary>
        public GenericChannelHeader GenericChannelHeader { get; }

        public List<MoFLXMSG> Data { get; } = new List<MoFLXMSG>();
        
        public static MoFLXMSG ReadMoFLXMSG(BinaryReader reader)
        {
            var msg = new MoFLXMSG
            {
                ucHeader = reader.ReadByte(),
                ulID = reader.ReadUInt32(),
                usStatus = reader.ReadUInt16(),
                ucDataFieldLen = reader.ReadByte(),
                ausDataField = new ushort[256]
            };

            // Read the data field array
            for (int i = 0; i < 256; i++)
            {
                msg.ausDataField[i] = reader.ReadUInt16();
            }

            msg.ulFlexTimeStamp = reader.ReadUInt32();
            msg.ulTimeStampH = reader.ReadUInt32();
            msg.ulTimeStampL = reader.ReadUInt32();
            msg.ul64LDAC = reader.ReadUInt32();

            return msg;
        }
        
        /// <summary>
        /// Creates a new instance of the <see cref="FlexRayDataPacket"/> class while copying the Message Data from the provided stream.
        /// </summary>
        /// <param name="genericChannelHeader">A reference to the Generic Channel Header.</param>
        /// <param name="reader">The QServer data stream. Samples will be copied into the local property.</param>
        public FlexRayDataPacket(GenericChannelHeader genericChannelHeader, BinaryReader reader)
        {
            GenericChannelHeader = genericChannelHeader;
            int bytesProcessed = 0;
            while (bytesProcessed < GenericChannelHeader.ChannelDataSize)
            {
                Data.Add(ReadMoFLXMSG(reader));
                bytesProcessed += Marshal.SizeOf<MoFLXMSG>();
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
        
        public static void PrintMoFLXMSG(MoFLXMSG msg)
        {
            Console.WriteLine("MoFLXMSG Values (Hex):");
            Console.WriteLine($"Header: 0x{msg.ucHeader:X2}");
            Console.WriteLine($"ID: 0x{msg.ulID:X8}");
            Console.WriteLine($"Status: 0x{msg.usStatus:X4}");
            Console.WriteLine($"DataFieldLen: 0x{msg.ucDataFieldLen:X2}");
    
            Console.WriteLine("Data Field Values:");
            if (msg.ausDataField != null)
            {
                for (int i = 0; i < msg.ausDataField.Length && i < msg.ucDataFieldLen; i++)
                {
                    Console.Write($"0x{msg.ausDataField[i]:X4} ");
                }
            }
            Console.WriteLine();
    
            Console.WriteLine($"FlexTimeStamp: 0x{msg.ulFlexTimeStamp:X8}");
            Console.WriteLine($"TimeStampH: 0x{msg.ulTimeStampH:X8}");
            Console.WriteLine($"TimeStampL: 0x{msg.ulTimeStampL:X8}");
            Console.WriteLine($"64LDAC: 0x{msg.ul64LDAC:X8}");
        }
    }
    
}