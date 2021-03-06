﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.ObjectData;
using TerrariaUltraApocalypse.API.TerraEnergy.Items;
using TerrariaUltraApocalypse.API.TerraEnergy.TileEntities;


namespace TerrariaUltraApocalypse.API.TerraEnergy.Block.FunctionnalBlock
{
    class EnergyCollector : TUABlock
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 18 };
            TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(mod.GetTileEntity<EnergyCollectorEntity>().Hook_AfterPlacement, -1, 0, false);
            TileObjectData.addTile(Type);
            disableSmartCursor = true;
        }

        public override void RightClick(int i, int j)
        {
            Player player = Main.player[Main.myPlayer];
            Item currentSelectedItem = player.inventory[player.selectedItem];

            Tile tile = Main.tile[i, j];

            int left = i - (tile.frameX / 18);
            int top = j - (tile.frameY / 18);

            int index = mod.GetTileEntity<EnergyCollectorEntity>().Find(left, top);

            Main.NewText("X " + i + " Y " + j);

            if (index == -1)
            {
                Main.NewText("false");
                return;
            }
            if (currentSelectedItem.type == mod.ItemType("TerraMeter"))
            {
                StorageEntity se = (StorageEntity)TileEntity.ByID[index];
                Main.NewText(se.getEnergy().getCurrentEnergyLevel() + " / " + se.getEnergy().getMaxEnergyLevel() + " TE");
            }

            if (currentSelectedItem.type == mod.ItemType("RodOfLinking"))
            {
                RodOfLinking it = currentSelectedItem.modItem as RodOfLinking;
                StorageEntity se = (StorageEntity)TileEntity.ByID[index];
                it.saveCollectorLocation(se);
                Main.NewText("Succesfully linked to a collector, now right click on a capacitor to unlink");
            }
        }
    }

}