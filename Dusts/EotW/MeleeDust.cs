﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace TerrariaUltraApocalypse.Dusts.EotW
{
    class MeleeDust : ModDust
    {
        private int timer = 40;


        public override void OnSpawn(Terraria.Dust dust)
        {
            dust.noGravity = true;
            dust.scale *= 1f;
            dust.velocity.Y = Main.rand.Next(1, 2) * 0.1f;
        }

        public override bool MidUpdate(Terraria.Dust dust)
        {
            dust.position += dust.velocity;
            timer--;
            if (timer == 0)
            {
                dust.active = false;
                return false;
            }
            return true;
        }
    }
}
