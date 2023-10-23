// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using QProtocol.GenericDefines;
using System;

namespace QProtocol
{
    /// <summary>
    /// Use this class with the provided endpoint to query the system status information on port 80.
    /// </summary>
    [Serializable]
    public class SystemStatus
    {
        public static string Endpoint { get; } = EndPoints.SystemStatus.TrimEnd('/');

        /// <summary>
        /// Gets the boot percentage of the system. 
        /// </summary>
        public int BootPercentage { get; set; }

        /// <summary>
        /// Gets the system state.
        /// </summary>
        public SystemStates.SystemState SystemState { get; set; }

        /// <summary>
        /// Gets a description of the system state.
        /// </summary>
        public string SystemStateDescription { get; set; }

        /// <summary>
        /// Gets the application state if an application is running.
        /// </summary>
        public ApplicationStates.ApplicationStatus ApplicationStatus { get; set; }

        /// <summary>
        /// Gets a description of the application state.
        /// </summary>
        public string ApplicationStatusDescription { get; set; }
    }
}
