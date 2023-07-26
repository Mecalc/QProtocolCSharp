// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using QProtocol.GenericDefines;
using System;

namespace QProtocol.Interfaces
{
    /// <summary>
    /// This class is used to configure parameters for the JSON requests to QServer.
    /// </summary>
    [Serializable]
    public class HttpParameter
    {
        /// <summary>
        /// Gets a name for the parameter.
        /// </summary>
        public string Name { get; internal set; }
        
        /// <summary>
        /// Gets a value for the parameter.
        /// </summary>
        public object Value { get; internal set; }

        /// <summary>
        /// This method will construct an instance of <see cref="HttpParameter"/> class which can be used to configure requests which require an ItemID to the QServer.
        /// </summary>
        /// <param name="itemId">Specify an Item Id.</param>
        /// <returns>An ItemId <see cref="HttpParameter"/> class.</returns>
        public static HttpParameter ItemId(int itemId)
        {
            return new HttpParameter { Name = EndPoints.ItemId, Value = itemId };
        }

        /// <summary>
        /// This method will construct an instance of <see cref="HttpParameter"/> class which can be used to configure requests which require a MessageIndex to the QServer.
        /// </summary>
        /// <param name="itemId">Specify an MessageIndex.</param>
        /// <returns>An MessageIndex <see cref="HttpParameter"/> class.</returns>
        public static HttpParameter MessageIndex(int messageIndex)
        {
            return new HttpParameter { Name = EndPoints.MessageIndex, Value = messageIndex };
        }
    }
}
