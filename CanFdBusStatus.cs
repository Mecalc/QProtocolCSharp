// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using QProtocol.JsonProperties;
using System;

namespace QProtocol
{
    /// <summary>
    /// This class can be used with the /canfd/bus/status/list/ endpoint to deserialize the response received.
    /// </summary>
    [Serializable]
    public class CanFdBusStatus : Setting
    {
    }
}
