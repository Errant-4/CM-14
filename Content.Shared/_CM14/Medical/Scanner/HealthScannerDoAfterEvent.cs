﻿using Content.Shared.DoAfter;
using Robust.Shared.Serialization;

namespace Content.Shared._CM14.Medical.Scanner;

[Serializable, NetSerializable]
public sealed partial class HealthScannerDoAfterEvent : SimpleDoAfterEvent
{
    [DataField]
    public NetEntity Scanned;

    public HealthScannerDoAfterEvent(NetEntity scanned)
    {
        Scanned = scanned;
    }
}
