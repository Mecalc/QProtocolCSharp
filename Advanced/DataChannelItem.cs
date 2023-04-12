// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using System;

namespace QProtocol.Advanced
{
    [Serializable]
    public class DataChannelItem : Item
    {
        public DataChannelItem(Item item)
            : base(item)
        {
        }

        /// <summary>
        /// This wrapper function will fetch the Item settings from the QServer and enable the Data Streaming setting.
        /// Usually used in loops where you want to enable streaming on bulk channels. Ideal setup would be to enable
        /// the streaming state during the channel setup.
        /// </summary>
        /// <param name="enableLocalStorage">Set to true to enable local storage as well.</param>
        public void EnableDataStreaming(bool enableLocalStorage = false)
        {
            var jsonObject = GetItemSettings();
            var dataSettings = jsonObject.ConvertToData();
            if (dataSettings != null)
            {
                dataSettings.StreamingState = GenericDefines.Generic.Status.Enabled;
                if (enableLocalStorage && dataSettings.LocalStorage != null)
                {
                    dataSettings.LocalStorage = GenericDefines.Generic.Status.Enabled;
                }
            }

            jsonObject.UpdateFromData(dataSettings);
            PutItemSettings(jsonObject);
        }

        /// <summary>
        /// This wrapper function will fetch the Item settings from the QServer and disable the Data Streaming setting.
        /// Usually used in loops where you want to disable streaming on bulk channels. Ideal setup would be to disable
        /// the streaming state during the channel tear down.
        /// </summary>
        /// <param name="disableLocalStorage">Set to true to disable local storage as well.</param>
        public void DisableDataStreaming(bool disableLocalStorage = false)
        {
            var jsonObject = GetItemSettings();
            var dataSettings = jsonObject.ConvertToData();
            if (dataSettings != null)
            {
                dataSettings.StreamingState = GenericDefines.Generic.Status.Disabled;
                if (disableLocalStorage && dataSettings.LocalStorage != null)
                {
                    dataSettings.LocalStorage = GenericDefines.Generic.Status.Disabled;
                }
            }

            jsonObject.UpdateFromData(dataSettings);
            PutItemSettings(jsonObject);
        }

        /// <summary>
        /// This wrapper function will fetch the Item settings from the QServer and enable the Local Storage setting.
        /// Usually used in loops where you want to Local Storage streaming on bulk channels. Ideal setup would be to enable
        /// the streaming state during the channel setup.
        /// </summary>
        public void EnableLocalStorage()
        {
            var jsonObject = GetItemSettings();
            var dataSettings = jsonObject.ConvertToData();
            if (dataSettings.LocalStorage != null)
            {
                dataSettings.LocalStorage = GenericDefines.Generic.Status.Enabled;
            }
            else
            {
                throw new InvalidOperationException($"Unable to enable Local Storage on Item {ItemId} since the option is not available for this Item.");
            }

            jsonObject.UpdateFromData(dataSettings);
            PutItemSettings(jsonObject);
        }

        /// <summary>
        /// This wrapper function will fetch the Item settings from the QServer and disable the Local Storage setting.
        /// Usually used in loops where you want to disable Local Storage on bulk channels. Ideal setup would be to disable
        /// the streaming state during the channel tear down.
        /// </summary>
        public void DisableLocalStorage()
        {
            var jsonObject = GetItemSettings();
            var dataSettings = jsonObject.ConvertToData();
            if (dataSettings.LocalStorage != null)
            {
                dataSettings.LocalStorage = GenericDefines.Generic.Status.Disabled;
            }
            else
            {
                throw new InvalidOperationException($"Unable to disable Local Storage on Item {ItemId} since the option is not available for this Item.");
            }

            jsonObject.UpdateFromData(dataSettings);
            PutItemSettings(jsonObject);
        }
    }
}
