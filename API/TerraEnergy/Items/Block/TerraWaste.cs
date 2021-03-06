﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace TerrariaUltraApocalypse.API.TerraEnergy.Items.Block
{
    class TerraWaste : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Terra Waste");
            Tooltip.SetDefault("A block where the essence was completly drained...");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 48;
            item.maxStack = 999;
            item.consumable = true;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.autoReuse = true;
            item.createTile = mod.TileType("TerraWaste");
        }
    }
}
