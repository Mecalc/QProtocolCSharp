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

namespace QProtocol.Models
{
    [Serializable]
    public class _45SeriesModule
    {

        public enum LedState
        {
            [RestfulProperties("Off")]
            Off = 0,

            [RestfulProperties("Red")]
            Red = 1,

            [RestfulProperties("Green")]
            Green = 2,

            [RestfulProperties("Blue")]
            Blue = 3,

            [RestfulProperties("Purple")]
            Purple = 4,

            [RestfulProperties("Orange")]
            Orange = 5,

            [RestfulProperties("Flashing")]
            Flashing = 6,
        }
    }
}
