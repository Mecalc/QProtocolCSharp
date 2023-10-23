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
    public class ApplicationStates
    {

        public enum ApplicationStatus
        {
            [RestfulProperties("Uninitialized")]
            Uninitialized = 0,

            [RestfulProperties("Startup")]
            Startup = 1,

            [RestfulProperties("Terminating")]
            Terminating = 2,

            [RestfulProperties("Suspending")]
            Suspending = 3,

            [RestfulProperties("Self-calibration Progress: ")]
            SelfCalibrationProgress = 4,

            [RestfulProperties("QServer Initializing")]
            Initializing = 5,

            [RestfulProperties("QServer Applying")]
            Applying = 6,

            [RestfulProperties("QServer Reset to Defaults")]
            ResetToDefaults = 7,

            [RestfulProperties("QServer Running, Streaming Disabled")]
            RunningStreamingDisabled = 8,

            [RestfulProperties("QServer Running, Streaming Enabled")]
            RunningStreamingEnabled = 9,

            [RestfulProperties("QServer Running, Streaming Error")]
            RunningStreamingError = 10,

            [RestfulProperties("QServer Error, Streaming Disabled")]
            ErrorStreamingDisabled = 11,

            [RestfulProperties("QServer Error, Streaming Enabled")]
            ErrorStreamingEnabled = 12,

            [RestfulProperties("QServer Error, Streaming Error")]
            ErrorStreamingError = 13,
        }
    }
}
