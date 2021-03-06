﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace TerrariaUltraApocalypse.Items
{
    class TUAGlobalItem : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.SuspiciousLookingEye) {
                item.consumable = false;
                if (NPC.downedMoonlord)
                {
                    item.SetNameOverride("Ultra Suspicious looking eyes");
                }
            }
            else if (item.type == ItemID.WormFood)
            {
                item.consumable = false;
                item.rare = -12;
            }
            base.SetDefaults(item);
        }



        public override bool UseItem(Item item, Player player)
        {
            if (item.type == ItemID.SuspiciousLookingEye)
            {
                Main.NewText("<Eye of cthulhu> - You really think we would let the lord dying from a simple terrarian? Well, welcome to the ultra mode muhahaha", Color.White);
                item = mod.GetItem("SuspiciousBurnedEye").item;
            }
            else if (item.type == ItemID.WormFood)
            {
                Main.NewText("<Eater of the world> - Corruption, waste and plague should be one, the ancient god gace us the power to corrupt a world!", Color.White);
            }

            return base.UseItem(item, player);
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.type == ItemID.SuspiciousLookingEye)
            {
                TooltipLine line = new TooltipLine(mod, "Ultra", "Maybe this isn't a good idea");
                tooltips.Add(line);
            }
            if (item.type == ItemID.WormFood) {
                TooltipLine line = new TooltipLine(mod, "Ultra", "It grew... stronger... and worst...");
                line.overrideColor = Color.DarkRed;
                tooltips.Add(line);
                
            }
            base.ModifyTooltips(item, tooltips);
        }

        public override void Update(Item item, ref float gravity, ref float maxFallSpeed)
        {
            if (item.type == ItemID.SuspiciousLookingEye)
            {
                item = mod.GetItem("SuspiciousBurnedEye").item;
            }
        }

        public override void UpdateInventory(Item item, Player player)
        {
            if (item.type == ItemID.SuspiciousLookingEye)
            {
                for (int i = 0; i < player.inventory.Length; i++) {
                    if (player.inventory[i].type == ItemID.SuspiciousLookingEye) {
                        player.inventory[i].type = mod.ItemType("SuspiciousBurnedEye");
                    }
                }
            }
        }
    }
}
