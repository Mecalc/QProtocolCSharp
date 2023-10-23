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
    public class SystemStates
    {

        public enum SystemState
        {
            [RestfulProperties("Initializing")]
            Initialized = 16,

            [RestfulProperties("Booting")]
            BootLoader = 17,

            [RestfulProperties("Booting Past 33 %")]
            BootingPast33 = 18,

            [RestfulProperties("Booting Past 66 %")]
            BootingPast66 = 19,

            [RestfulProperties("Booting Done")]
            BootingDone = 20,

            [RestfulProperties("System Fault")]
            SystemFault = 21,

            [RestfulProperties("System Shutting Down")]
            SystemOff = 22,

            [RestfulProperties("System Idle")]
            SystemIdle = 23,

            [RestfulProperties("Self-Calibration in Progress")]
            ApplicationSelfCalibration = 24,

            [RestfulProperties("Application Running State 1")]
            Application1 = 25,

            [RestfulProperties("Application Running State 2")]
            Application2 = 26,

            [RestfulProperties("Application Running State 3")]
            Application3 = 27,

            [RestfulProperties("Application Fault State 1")]
            ApplicationFault1 = 28,

            [RestfulProperties("Application Fault State 2")]
            ApplicationFault2 = 29,

            [RestfulProperties("Application Fault State 3")]
            ApplicationFault3 = 30,

            [RestfulProperties("Application Fault State 4")]
            ApplicationFault4 = 31,

            [RestfulProperties("Application Fault State 5")]
            ApplicationFault5 = 32,

            [RestfulProperties("Identifying System")]
            IdentifySystem = 33,

            [RestfulProperties("Testing User LEDs")]
            TestUserLeds = 34,
        }
    }
}
