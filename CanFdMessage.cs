// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using QProtocol.GenericDefines;
using QProtocol.JsonProperties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QProtocol
{
    /// <summary>
    /// This class can be used with the /canfd/message/list/ endpoint to deserialize the response received and serialize the body sent.
    /// </summary>
    [Serializable]
    public class CanFdTransmitMessage
    {
        /// <summary>
        /// Gets or sets the settings applicable to the current message.
        /// </summary>
        public List<Setting> Settings { get; set; }

        /// <summary>
        /// Gets or sets the data packet of the message.
        /// </summary>
        public Setting MessageData { get; set; }

        /// <summary>
        /// Creates a new instance of the <see cref="CanFdTransmitMessage"/> class.
        /// </summary>
        public CanFdTransmitMessage()
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="CanFdTransmitMessage"/> class from the QProtocol defined <see cref="CanFdChannel.TransmitMessage"/> class.
        /// </summary>
        /// <param name="transmitMessage">An instance of the <see cref="CanFdChannel.TransmitMessage"/> class.</param>
        public CanFdTransmitMessage(CanFdChannel.TransmitMessage transmitMessage)
        {
            UpdateFromSettings(transmitMessage.Settings);
            UpdateFromMessageData(transmitMessage.MessageData);
        }

        /// <summary>
        /// This method can be used to convert the <see cref="Settings"/> property to <see cref="CanFdChannel.MessageSettings"/> class.
        /// </summary>
        /// <typeparam name="T">Type of the QProtocol defined settings class.</typeparam>
        /// <returns>An instance of the <see cref="CanFdChannel.MessageSettings"/> class.</returns>
        public CanFdChannel.MessageSettings ConvertToSettings()
        {
            return Setting.ConvertTo<CanFdChannel.MessageSettings>(this.Settings);
        }

        /// <summary>
        /// This method will update the <see cref="Settings"/> property from an instance of <see cref="CanFdChannel.MessageSettings"/> class.
        /// </summary>
        /// <param name="definedSettings">An instance of the <see cref="CanFdChannel.MessageSettings"/> class.</param>
        public void UpdateFromSettings(CanFdChannel.MessageSettings definedSettings)
        {
            this.Settings = Setting.ConvertFrom(definedSettings);
        }

        /// <summary>
        /// This method can be used to convert the <see cref="Data"/> property to an instance of <see cref="Data"/>.
        /// </summary>
        /// <returns>An instance of <see cref="Data"/>.</returns>
        public CanFdChannel.MessageData ConvertToMessageData()
        {
            return Setting.ConvertTo<CanFdChannel.MessageData>(new List<Setting> { this.MessageData });
        }

        /// <summary>
        /// This method can be used to update the <see cref="Data"/> property from an instance of <see cref="Data"/>.
        /// </summary>
        /// <param name="definedSettings">An instance of <see cref="Data"/>.</param>
        public void UpdateFromMessageData(CanFdChannel.MessageData definedSettings)
        {
            this.MessageData = Setting.ConvertFrom(definedSettings).First();
        }
    }
}
