// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using QProtocol.Attributes;
using QProtocol.GenericDefines;
using System;

namespace QProtocol
{
    [Serializable]
    public class Data
    {
        [RestfulProperties("Streaming State")]
        public Generic.Status? StreamingState { get; set; } = Generic.Status.Enabled;

        [RestfulProperties("Local Storage State")]
        public Generic.Status? LocalStorage { get; set; }
    }
}
