// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using QProtocol.Advanced;
using QProtocol.Attributes;
using QProtocol.GenericDefines;
using QProtocol.Interfaces;
using QProtocol.JsonProperties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QProtocol.GenericDefines
{
    [Serializable]
    public class Types
    {

        public enum ItemType
        {
            [RestfulProperties("Controller")]
            Controller = 0,

            [RestfulProperties("SignalConditioner")]
            SignalConditioner = 1,

            [RestfulProperties("Module")]
            Module = 2,

            [RestfulProperties("External Module")]
            ExternalModule = 3,

            [RestfulProperties("Channel")]
            Channel = 4,

            [RestfulProperties("Uninitialized")]
            Uninitialized = 255,
        }

        public enum ModuleType
        {
            [RestfulProperties("SCC42T5")]
            SCC42T5 = 1,

            [RestfulProperties("ICP4211")]
            ICP4211 = 211,

            [RestfulProperties("ICS421")]
            ICS421 = 213,

            [RestfulProperties("ICS42L5")]
            ICS42L5 = 182,

            [RestfulProperties("ICS425")]
            ICS425 = 217,

            [RestfulProperties("ICT426")]
            ICT426 = 218,

            [RestfulProperties("TAC221")]
            TAC221 = 222,

            [RestfulProperties("DCH42S2")]
            DCH42S2 = 149,

            [RestfulProperties("MIC42X7")]
            MIC42X7 = 180,

            [RestfulProperties("CAN42S2")]
            CAN42S2 = 157,

            [RestfulProperties("ALO42S4")]
            ALO42S4 = 151,

            [RestfulProperties("WSB42X2")]
            WSB42X2 = 227,

            [RestfulProperties("WSBM42X5")]
            WSBM42X5 = 229,

            [RestfulProperties("WSB42X6")]
            WSB42X6 = 230,

            [RestfulProperties("GPS42S5")]
            GPS42S5 = 162,

            [RestfulProperties("THM427")]
            THM427 = 170,

            [RestfulProperties("CHS42X4")]
            CHS42X4 = 184,

            [RestfulProperties("UTM42T0")]
            UTM42T0 = 192,

            [RestfulProperties("ALI42X1")]
            ALI42X1 = 239,

            [RestfulProperties("ALI42X2")]
            ALI42X2 = 238,

            [RestfulProperties("Empty")]
            Empty = 240,

            [RestfulProperties("Unsupported")]
            Unsupported = 253,

            [RestfulProperties("ICP42S11")]
            ICP42S11 = 65747,

            [RestfulProperties("ICT42S6")]
            ICT42S6 = 65754,

            [RestfulProperties("XMC237")]
            XMC237 = 20005,

            [RestfulProperties("XMC100")]
            XMC100 = 20006,
        }

        public enum ScType
        {
            [RestfulProperties("None")]
            TEMP_None = 0,

            [RestfulProperties("SC42 G2")]
            SC428 = 10070,

            [RestfulProperties("SC42S G2")]
            SC42S8 = 10080,

            [RestfulProperties("SC10")]
            SC104 = 10101,
        }

        public enum ControllerType
        {
            [RestfulProperties("PQ20G2")]
            PQ20G2 = 30080,

            [RestfulProperties("PQ30G2")]
            PQ30G2 = 30090,

            [RestfulProperties("MicroQ")]
            MicroQ = 30100,

            [RestfulProperties("PQ45")]
            PQ45 = 30110,
        }

        public enum ChannelType
        {
            [RestfulProperties("CAN42S2")]
            CAN42S2 = 0,

            [RestfulProperties("XMC237 ICP")]
            XMC237Icp = 7,

            [RestfulProperties("ICP4211")]
            ICP4211 = 11,

            [RestfulProperties("ICP42S11")]
            ICP42S11 = 12,

            [RestfulProperties("ICS421")]
            ICS421 = 13,

            [RestfulProperties("ICS425")]
            ICS425 = 15,

            [RestfulProperties("ICT42S6 Tacho")]
            ICT42S6Tacho = 16,

            [RestfulProperties("ICT426 Tacho")]
            ICT426Tacho = 17,

            [RestfulProperties("ICT42S6 Scope")]
            ICT42S6Scope = 18,

            [RestfulProperties("ICT426 Scope")]
            ICT426Scope = 19,

            [RestfulProperties("ICT42S6 ICP")]
            ICT42S6Icp = 20,

            [RestfulProperties("ICT426 ICP")]
            ICT426Icp = 21,

            [RestfulProperties("TAC221 Tacho")]
            TAC221Tacho = 23,

            [RestfulProperties("ALO42S4")]
            ALO42S4 = 24,

            [RestfulProperties("UTM42T0", 29, "")]
            UTM42T0 = 29,

            [RestfulProperties("WSB42X2")]
            WSB42X2 = 30,

            [RestfulProperties("SCC42T5")]
            SCC42T5 = 31,

            [RestfulProperties("TAC221 Scope")]
            TAC221Scope = 33,

            [RestfulProperties("XMC237 CAN FD")]
            XMC237CanFd = 34,

            [RestfulProperties("XMC237 GPS")]
            XMC237Gps = 36,

            [RestfulProperties("CHS42X4")]
            CHS42X4 = 40,

            [RestfulProperties("DCH42S2")]
            DCH42S2 = 41,

            [RestfulProperties("XMC100 Icp")]
            XMC100Icp = 43,

            [RestfulProperties("XMC100 CAN FD")]
            XMC100CanFd = 44,

            [RestfulProperties("THM427")]
            THM427 = 45,

            [RestfulProperties("ICS42L5")]
            ICS42L5 = 46,

            [RestfulProperties("MIC42X7")]
            MIC42X7 = 47,

            [RestfulProperties("ALI42X1")]
            ALI42X1 = 48,

            [RestfulProperties("ALI42X2")]
            ALI42X2 = 49,

            [RestfulProperties("WSB42X5")]
            WSB42X5 = 50,

            [RestfulProperties("WSB42X6")]
            WSB42X6 = 51,

            [RestfulProperties("Unsupported")]
            Unsupported = 253,
        }
    }
}
