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
    public class Generic
    {
        public const System.Int32 NodeDisabled = 0;

        public enum Status
        {
            [RestfulProperties("Disabled")]
            Disabled = 0,

            [RestfulProperties("Enabled")]
            Enabled = 1,
        }

        public enum Bool
        {
            [RestfulProperties("False")]
            False = 0,

            [RestfulProperties("True")]
            True = 1,
        }

        public enum DataResolution
        {
            [RestfulProperties("32 bit")]
            _32b = 0,

            [RestfulProperties("24 bit")]
            _24b = 1,

            [RestfulProperties("16 bit")]
            _16b = 2,
        }

        public enum SettingState
        {
            [RestfulProperties("Setting is invalid")]
            Invalid = -1,

            [RestfulProperties("Setting is valid")]
            Valid = 0,

            [RestfulProperties("Setting is valid however intrusive")]
            ValidRequriesRestart = 1,
        }

        public enum DataIntegrity
        {
            [RestfulProperties("Not available")]
            NotAvailable = -1,

            [RestfulProperties("OK")]
            OK = 0,

            [RestfulProperties("Overload")]
            Overload = 1,

            [RestfulProperties("Short circuit")]
            ShortCircuit = 2,

            [RestfulProperties("Open circuit")]
            OpenCircuit = 3,

            [RestfulProperties("ADC error")]
            AdcError = 4,

            [RestfulProperties("Reserved")]
            ReservedForFuture = 5,

            [RestfulProperties("ADC overload")]
            AdcOverload = 6,
        }

        public enum PayloadType
        {
            [RestfulProperties("Data")]
            Data = 0,
        }
    }
}
