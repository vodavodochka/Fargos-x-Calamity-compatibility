﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.Localization;
using CalamityMod.Items.Armor.Brimflame;
using CalamityMod.Items.Fishing.BrimstoneCragCatches;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Summon;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Fishing.FishingRods;
using CalamityMod.Items.Pets;

namespace FargoCalamity.Calamity.Enchantments
{
    public class BrimflameEnchant : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public virtual bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Brimflame Enchantment");
            /* Tooltip.SetDefault(
@"''
Press Y to trigger a brimflame frenzy effect
While under this effect, your damage is significantly boosted
However, this comes at the cost of rapid life loss and no mana regeneration"); */
        }

        /*public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(191, 68, 59);
                }
            }
        }*/

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            Item.rare = 7;
            Item.value = 600000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            //set bonus
            ModLoader.GetMod("CalamityMod").Find<ModItem>("BrimflameScowl").UpdateArmorSet(player);
        }

        public override void AddRecipes()
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ModContent.ItemType<BrimflameScowl>());
            recipe.AddIngredient(ModContent.ItemType<BrimflameRobes>());
            recipe.AddIngredient(ModContent.ItemType<BrimflameBoots>());

            recipe.AddIngredient(ModContent.ItemType<Butcher>());
            recipe.AddIngredient(ModContent.ItemType<IgneousExaltation>());
            recipe.AddIngredient(ModContent.ItemType<BlazingStar>());

            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();
        }
    }
}
