// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using QProtocol.Attributes;
using QProtocol.JsonProperties;
using System;
using System.Collections.Generic;

namespace QProtocol
{
    /// <summary>
    /// This class can be used with various endpoints to serialize the body sent.
    /// </summary>
    [Serializable]
    public class GenericSettings
	{
		/// <summary>
		/// Gets or sets a value indicating whether the settings has been synchronized to the hardware.
		/// </summary>
		public bool? SettingsApplied { get; set; }

		/// <summary>
		/// Gets or sets the generic settings.
		/// </summary>
		public List<Setting> Settings { get; set; }
	}
}