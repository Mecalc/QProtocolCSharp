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
    public class UTM450Channel : Item
    {
        public UTM450Channel(Item itemInfo)
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

        public enum FrontendToBusA
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

        public enum FrontendToBusB
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

        public enum FrontendToBusBSig456Positive
        {
            [RestfulProperties("Disconnect")]
            Disconnect = 0,

            [RestfulProperties("Connect Positive")]
            ConnectPositive = 1,
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

        public enum Frontend200VDividerToBusBPositive
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
        public class UTM450ChannelOperationMode
        {
            [RestfulProperties("Operation Mode")]
            public OperationMode OperationMode { get; set; } = OperationMode.Enabled;
        }

        [Serializable]
        public class EnabledSettings : ISettings
        {

            [RestfulProperties("Frontend Signal Pair 1 to BUS B [K8, K10 etc.]")]
            public FrontendToBusB FrontendSignalPair1ToBusB { get; set; } = FrontendToBusB.Disconnect;

            [RestfulProperties("Frontend Signal Pair 2 to BUS B [K12, K14 etc.]")]
            public FrontendToBusB FrontendSignalPair2ToBusB { get; set; } = FrontendToBusB.Disconnect;

            [RestfulProperties("Frontend Signal Pair 3 to BUS A [K16, K18 etc.]")]
            public FrontendToBusA FrontendSignalPair3ToBusA { get; set; } = FrontendToBusA.Disconnect;

            [RestfulProperties("Frontend Signal 4 to BUS B Positive [U34C etc.]")]
            public FrontendToBusBSig456Positive FrontendSignal4ToBusBPositive { get; set; } = FrontendToBusBSig456Positive.Disconnect;

            [RestfulProperties("Frontend Signal 5 to BUS B Positive [U34A etc.]")]
            public FrontendToBusBSig456Positive FrontendSignal5ToBusBPositive { get; set; } = FrontendToBusBSig456Positive.Disconnect;

            [RestfulProperties("Frontend Signal 6 to BUS B Positive [U34B etc.]")]
            public FrontendToBusBSig456Positive FrontendSignal6ToBusBPositive { get; set; } = FrontendToBusBSig456Positive.Disconnect;

            [RestfulProperties("Frontend Signal 1 Negative To Ground [K11 etc.]")]
            public FrontendNegativeToGround FrontendSignal1NegativeToGround { get; set; } = FrontendNegativeToGround.Floating;

            [RestfulProperties("Frontend Signal 2 Negative To Ground [K15 etc.]")]
            public FrontendNegativeToGround FrontendSignal2NegativeToGround { get; set; } = FrontendNegativeToGround.Floating;

            [RestfulProperties("Frontend Signal 3 Negative To Ground [K19 etc.]")]
            public FrontendNegativeToGround FrontendSignal3NegativeToGround { get; set; } = FrontendNegativeToGround.Floating;

            [RestfulProperties("Frontend Signal Pair 1 Short [K9 etc.]")]
            public FrontendShort FrontendSignalPair1Short { get; set; } = FrontendShort.Open;

            [RestfulProperties("Frontend Signal Pair 2 Short [K13 etc.]")]
            public FrontendShort FrontendSignalPair2Short { get; set; } = FrontendShort.Open;

            [RestfulProperties("Frontend Signal Pair 3 Short [K17 etc.]")]
            public FrontendShort FrontendSignalPair3Short { get; set; } = FrontendShort.Open;

            [RestfulProperties("Frontend Shield [K24 Or K50]")]
            public FrontendShield FrontendShield { get; set; } = FrontendShield.Floating;

            [RestfulProperties("Frontend 200V Divider to BUS B [K29]")]
            public Frontend200VDividerToBusBPositive Frontend200VDividerToBusBPositive { get; set; } = Frontend200VDividerToBusBPositive.Divided;
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
                Settings = Setting.ConvertFrom(new UTM450ChannelOperationMode() {OperationMode = operationMode}),
            };
            
            base.PutItemOperationMode(operationModeSettings);
        }

        public new OperationMode GetItemOperationMode()
        {
            var jsonObject = base.GetItemOperationMode();
            return Setting.ConvertTo<UTM450ChannelOperationMode>(jsonObject.Settings).OperationMode;
        }
    }
}
