﻿using Content.Shared._CM14.Inventory;
using Content.Shared.Containers.ItemSlots;
using Robust.Client.GameObjects;

namespace Content.Client._CM14.Inventory;

public sealed class CMInventorySystem : SharedCMInventorySystem
{
    protected override void ContentsUpdated(Entity<CMItemSlotsComponent> ent)
    {
        base.ContentsUpdated(ent);

        if (!TryComp(ent, out SpriteComponent? sprite) ||
            !sprite.LayerMapTryGet(CMItemSlotsLayers.Filled, out var layer))
        {
            return;
        }

        if (!TryComp(ent, out ItemSlotsComponent? itemSlots))
        {
            sprite.LayerSetVisible(layer, false);
            return;
        }

        foreach (var (_, slot) in itemSlots.Slots)
        {
            if (slot.ContainerSlot?.ContainedEntity is { } contained &&
                !TerminatingOrDeleted(contained))
            {
                sprite.LayerSetVisible(layer, true);
                return;
            }
        }

        sprite.LayerSetVisible(layer, false);
    }
}
