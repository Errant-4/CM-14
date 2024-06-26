﻿using Content.Shared.Inventory;

namespace Content.Shared._CM14.Armor;

[ByRefEvent]
public record struct CMGetArmorEvent(SlotFlags TargetSlots, int Armor = 0, int FrontalArmor = 0) : IInventoryRelayEvent;
