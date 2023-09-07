﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.Localization;
using CalamityMod.Items.Armor.Tarragon;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Magic;

namespace FargoCalamity.Calamity.Enchantments
{
    public class TarragonEnchant : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public virtual bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Tarragon Enchantment");
            /* Tooltip.SetDefault(
@"'Braelor's undying might flows through you...'
Increased heart pickup range
Enemies have a chance to drop extra hearts on death
You have a 25% chance to regen health quickly when you take damage
Press Y to cloak yourself in life energy that heavily reduces enemy contact damage for 10 seconds
Ranged critical strikes will cause an explosion of leaves
Ranged projectiles have a chance to split into life energy on death
On every 5th critical strike you will fire a leaf storm
Magic projectiles have a 50% chance to heal you on enemy hits
At full health you gain +2 max minions and 10% increased minion damage
Summons a life aura around you that damages nearby enemies
After every 25 rogue critical hits you will gain 5 seconds of damage immunity
While under the effects of a debuff you gain 10% increased rogue damage
Effects of Blazing Core and Dark Sun Ring"); */
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            Item.rare = 10;
            Item.value = 3000000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.TarragonEffects))
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("TarragonHeadMelee").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("TarragonHeadRanged").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("TarragonHeadSummon").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("TarragonHeadMagic").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("TarragonHeadRogue").UpdateArmorSet(player);
            }

            ModLoader.GetMod("CalamityMod").Find<ModItem>("BlazingCore").UpdateAccessory(player, hideVisual);
            //dark sun ring
            ModLoader.GetMod("CalamityMod").Find<ModItem>("DarkSunRing").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddRecipeGroup("FargoCalamity:AnyTarragonHelmet");
            recipe.AddIngredient(ModContent.ItemType<TarragonBreastplate>());
            recipe.AddIngredient(ModContent.ItemType<TarragonLeggings>());
            recipe.AddIngredient(ModContent.ItemType<BlazingCore>());
            recipe.AddIngredient(ModContent.ItemType<DarkSunRing>());
            recipe.AddIngredient(ModContent.ItemType<DefiledGreatsword>());

            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
    }
}
