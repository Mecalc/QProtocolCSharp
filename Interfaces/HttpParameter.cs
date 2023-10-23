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
        /// Creates a new instance of the <see cref="HttpParameter"/> class with custom Name and Value.
        /// </summary>
        /// <param name="name">Specify a name for the parameter</param>
        /// <param name="value">Specify the value of the parameter</param>
        public HttpParameter(string name, int value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// This method will construct an instance of <see cref="HttpParameter"/> class which can be used to configure requests which require an ItemID to the QServer.
        /// </summary>
        /// <param name="itemId">Specify an Item Id.</param>
        /// <returns>An ItemId <see cref="HttpParameter"/> class.</returns>
        public static HttpParameter ItemId(int itemId)
        {
            return new HttpParameter(EndPoints.ItemId, itemId);
        }

        /// <summary>
        /// This method will construct an instance of <see cref="HttpParameter"/> class which can be used to configure requests which require a MessageIndex to the QServer.
        /// </summary>
        /// <param name="itemId">Specify an MessageIndex.</param>
        /// <returns>An MessageIndex <see cref="HttpParameter"/> class.</returns>
        public static HttpParameter MessageIndex(int messageIndex)
        {
            return new HttpParameter(EndPoints.MessageIndex, messageIndex);
        }
    }
}
