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

namespace QProtocol.InternalModules.UTM
{
    [Serializable]
    public class UTM42T1Channel : Item
    {
        public UTM42T1Channel(Item itemInfo)
            : base(itemInfo)
        {
        }


        public enum OperationMode
        {
            [RestfulProperties("Disabled")]
            Disabled = 0,

            [RestfulProperties("Enabled")]
            Enabled = 1,
        }

        public enum FrontendToBusAB
        {
            [RestfulProperties("Disconnect")]
            Disconnect = 0,

            [RestfulProperties("Connect Positive")]
            ConnectPositive = 1,

            [RestfulProperties("Connect Negative")]
            ConnectNegative = 2,

            [RestfulProperties("ConnectBoth")]
            ConnectBoth = 3,
        }

        public enum FrontendToBusA
        {
            [RestfulProperties("Disconnect")]
            Disconnect = 0,

            [RestfulProperties("Connect")]
            Connect = 1,
        }

        public enum FrontendToBusAC
        {
            [RestfulProperties("Disconnect")]
            Disconnect = 0,

            [RestfulProperties("ConnectBoth")]
            ConnectBoth = 1,
        }

        public enum FrontendNegativeToGround
        {
            [RestfulProperties("Floating")]
            Floating = 0,

            [RestfulProperties("Grounded")]
            Grounded = 1,
        }

        public enum FrontendShort
        {
            [RestfulProperties("Open")]
            Open = 0,

            [RestfulProperties("Shorted")]
            Shorted = 1,
        }

        public enum FrontendShield
        {
            [RestfulProperties("Floating")]
            Floating = 0,

            [RestfulProperties("Grounded")]
            Grounded = 1,

            [RestfulProperties("Connected To Bus")]
            ConnectedToBus = 2,

            [RestfulProperties("Grounded And Connected To Bus")]
            GroundedConnectedToBus = 3,
        }

        public enum Frontend200VDividerToBusA
        {
            [RestfulProperties("Divided")]
            Divided = 0,

            [RestfulProperties("Pass Through")]
            PassThrough = 1,
        }

        public interface ISettings
        {
        }

        [Serializable]
        public class UTM42T1ChannelOperationMode
        {
            [RestfulProperties("Operation Mode")]
            public OperationMode OperationMode { get; set; } = OperationMode.Enabled;
        }

        [Serializable]
        public class EnabledSettings : ISettings
        {

            [RestfulProperties("Frontend Signal Pair 1 to BUS AB [C1]")]
            public FrontendToBusAB FrontendSignalPair1ToBusAB { get; set; } = FrontendToBusAB.Disconnect;

            [RestfulProperties("Frontend Signal Pair 2 to BUS AB [C2]")]
            public FrontendToBusAB FrontendSignalPair2ToBusAB { get; set; } = FrontendToBusAB.Disconnect;

            [RestfulProperties("Frontend Signal 4 to BUS A [C3]")]
            public FrontendToBusA FrontendSignal4ToBusA { get; set; } = FrontendToBusA.Disconnect;

            [RestfulProperties("Frontend Signal Pair 3 to BUS AC [C4]")]
            public FrontendToBusAC FrontendSignalPair3ToBusAC { get; set; } = FrontendToBusAC.Disconnect;

            [RestfulProperties("Frontend Signal 1 Negative To Ground [C5]")]
            public FrontendNegativeToGround FrontendSignal1NegativeToGround { get; set; } = FrontendNegativeToGround.Floating;

            [RestfulProperties("Frontend Signal 2 Negative To Ground [C6]")]
            public FrontendNegativeToGround FrontendSignal2NegativeToGround { get; set; } = FrontendNegativeToGround.Floating;

            [RestfulProperties("Frontend Signal 3 Negative To Ground [C7]")]
            public FrontendNegativeToGround FrontendSignal3NegativeToGround { get; set; } = FrontendNegativeToGround.Floating;

            [RestfulProperties("Frontend Signal Pair 1 Short [C8]")]
            public FrontendShort FrontendSignalPair1Short { get; set; } = FrontendShort.Open;

            [RestfulProperties("Frontend Signal Pair 2 Short [C9]")]
            public FrontendShort FrontendSignalPair2Short { get; set; } = FrontendShort.Open;

            [RestfulProperties("Frontend Signal Pair 3 Short [C10]")]
            public FrontendShort FrontendSignalPair3Short { get; set; } = FrontendShort.Open;

            [RestfulProperties("Frontend Shield [C11]")]
            public FrontendShield FrontendShield { get; set; } = FrontendShield.Floating;

            [RestfulProperties("Frontend 200V Divider to BUS A [C12]")]
            public Frontend200VDividerToBusA Frontend200VDividerToBusA { get; set; } = Frontend200VDividerToBusA.Divided;
        }

        [Serializable]
        public class SettingsCollection<T>
            where T : ISettings
        {
            public T Settings { get; set; }

            public Data Data { get; set; }
        }


        public void PutItemSettings<T>(SettingsCollection<T> settings)
            where T : ISettings
        {
            var jsonObject = new ItemSettings(this);
            jsonObject.UpdateFromSettings(settings.Settings);
            jsonObject.UpdateFromData(settings.Data);
            base.PutItemSettings(jsonObject);
        }

        public SettingsCollection<T> GetItemSettings<T>()
            where T : ISettings
        {
            var jsonObject = base.GetItemSettings();
            return new SettingsCollection<T>
            {
                Settings = jsonObject.ConvertToSettings<T>(),
                Data = jsonObject.ConvertToData()
            };
        }

        public SettingsCollection<T> GetItemSettingsDefaults<T>()
            where T : ISettings
        {
            var jsonObject = base.GetItemSettingsDefaults();
            return new SettingsCollection<T>
            {
                Settings = jsonObject.ConvertToSettings<T>(),
                Data = jsonObject.ConvertToData()
            };
        }

        public void PutItemOperationMode(OperationMode operationMode)
        {
            var operationModeSettings = new ItemOperationMode(this)
            {
                Settings = Setting.ConvertFrom(new UTM42T1ChannelOperationMode() {OperationMode = operationMode}),
            };
            
            base.PutItemOperationMode(operationModeSettings);
        }

        public new OperationMode GetItemOperationMode()
        {
            var jsonObject = base.GetItemOperationMode();
            return Setting.ConvertTo<UTM42T1ChannelOperationMode>(jsonObject.Settings).OperationMode;
        }
    }
}
