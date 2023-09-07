﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using FargoCalamity.Calamity.Enchantments;

namespace FargoCalamity.Calamity.Forces
{
    public class AnnihilationForce : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public virtual bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Force of Annihilation");
            /* Tooltip.SetDefault(
@"'Where once there was life and light, only ruin remains...'
All armor bonuses from Aerospec, Statigel, and Hydrothermic
All armor bonuses from Xeroc and Fearmonger
Effects of Gladiator's Locket and Unstable Prism
Effects of Counter Scarf and Fungal Symbiote
Effects of Hallowed Rune, Ethereal Extorter, and The Community
Effects of Spectral Veil and Statis' Void Sash"); */
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            Item.rare = 11;
            Item.value = 600000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            ModLoader.GetMod("FargoCalamity").Find<ModItem>("AerospecEnchant").UpdateAccessory(player, hideVisual);
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("StatigelEnchant").UpdateAccessory(player, hideVisual);
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("AtaxiaEnchant").UpdateAccessory(player, hideVisual);
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("XerocEnchant").UpdateAccessory(player, hideVisual);
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("FearmongerEnchant").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(null, "AerospecEnchant");
            recipe.AddIngredient(null, "StatigelEnchant");
            recipe.AddIngredient(null, "AtaxiaEnchant");
            recipe.AddIngredient(null, "XerocEnchant");
            recipe.AddIngredient(null, "FearmongerEnchant");

            recipe.AddTile(ModLoader.GetMod("Fargowiltas").Find<ModTile>("CrucibleCosmosSheet").Type);
            recipe.Register();
        }
    }
}
