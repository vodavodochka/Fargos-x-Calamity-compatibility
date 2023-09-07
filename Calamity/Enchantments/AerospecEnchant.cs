﻿using Microsoft.Xna.Framework;
using System.Collections.ObjectModel;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI.Chat;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using CalamityMod.Items.Armor.Aerospec;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Pets;
using CalamityMod.Buffs.Pets;
using CalamityMod.Projectiles.Pets;

namespace FargoCalamity.Calamity.Enchantments
{
    public class AerospecEnchant : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public virtual bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Aerospec Enchantment");
            /* Tooltip.SetDefault(
@"'The sky comes to your aid…'
You fall quicker and are immune to fall damage
Taking over 25 damage in one hit causes several homing feathers to fall
Effects of Gladiator's Locket and Unstable Prism"); */
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            Item.rare = 3;
            Item.value = 200000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;
            ModLoader.GetMod("CalamityMod").Find<ModItem>("AerospecHelm").UpdateArmorSet(player);
            ModLoader.GetMod("CalamityMod").Find<ModItem>("AerospecHat").UpdateArmorSet(player);
            ModLoader.GetMod("CalamityMod").Find<ModItem>("AerospecHood").UpdateArmorSet(player);
            ModLoader.GetMod("CalamityMod").Find<ModItem>("AerospecHeadgear").UpdateArmorSet(player);
            ModLoader.GetMod("CalamityMod").Find<ModItem>("AerospecHelmet").UpdateArmorSet(player);
            player.noFallDmg = true;

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.GladiatorLocket))
                ModLoader.GetMod("CalamityMod").Find<ModItem>("GladiatorsLocket").UpdateAccessory(player, hideVisual);
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.UnstablePrism))
                ModLoader.GetMod("CalamityMod").Find<ModItem>("UnstablePrism").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddRecipeGroup("FargoCalamity:AnyAerospecHelmet");
            recipe.AddIngredient(ModContent.ItemType<AerospecBreastplate>());
            recipe.AddIngredient(ModContent.ItemType<AerospecLeggings>());
            recipe.AddIngredient(ModContent.ItemType<GladiatorsLocket>());
            recipe.AddIngredient(ModContent.ItemType<UnstableGraniteCore>());
            recipe.AddIngredient(ModContent.ItemType<StormSurge>());

            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }
    }
}
