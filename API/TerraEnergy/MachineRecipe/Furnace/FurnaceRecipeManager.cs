﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace TerrariaUltraApocalypse.API.TerraEnergy.MachineRecipe.Furnace
{
    class FurnaceRecipeManager
    {
        private static List<FurnaceRecipe> furnaceRecipeList = new List<FurnaceRecipe>();
        private static FurnaceRecipeManager instance;
        private FurnaceRecipe currentRecipe;

        public static FurnaceRecipeManager getInstance()
        {
            if (instance == null)
            {
                instance = new FurnaceRecipeManager();
            }
            return instance;
        }

        private FurnaceRecipeManager()
        {

        }

        public static FurnaceRecipe CreateRecipe(Mod mod)
        {
            FurnaceRecipe newRecipe = new FurnaceRecipe(mod);
            return newRecipe;
        }

        internal static void addRecipe(FurnaceRecipe recipe)
        {

            furnaceRecipeList.Add(recipe);
        }

        public bool validRecipe(Item ingredient)
        {
            foreach (FurnaceRecipe i in furnaceRecipeList)
            {
                if (i.checkItem(ingredient) && i.checkQuantity(ingredient.stack))
                {
                    currentRecipe = i;
                    return true;
                }
            }
            return false;
        }

        public FurnaceRecipe GetRecipe()
        {
            return currentRecipe;
        }
    }
}
