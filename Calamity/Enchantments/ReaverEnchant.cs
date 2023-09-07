using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using CalamityMod.Items.Armor.Reaver;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Summon;
using CalamityMod.Items.Pets;
using CalamityMod.Projectiles.Pets;
using CalamityMod.Buffs.Pets;

namespace FargoCalamity.Calamity.Enchantments
{
    public class ReaverEnchant : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public virtual bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Reaver Enchantment");
            /* Tooltip.SetDefault(
@"'A thorny death awaits your enemies...'
Melee projectiles explode on hit
While using a ranged weapon you have a 10% chance to fire a powerful rocket
Your magic projectiles emit a burst of spore gas on enemy hits
Summons a reaver orb that emits spore gas when enemies are near
You emit a cloud of spores when you are hit
Rage activates when you are damaged"); */
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            Item.rare = 7;
            Item.value = 400000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.ReaverEffects))
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("ReaverHeadTank").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("ReaverHeadExplore").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("ReaverHeadMobility").UpdateArmorSet(player);
            }
        }

        public override void AddRecipes()
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddRecipeGroup("FargoCalamity:AnyReaverHelmet");
            recipe.AddIngredient(ModContent.ItemType<ReaverScaleMail>());
            recipe.AddIngredient(ModContent.ItemType<ReaverCuisses>());
            recipe.AddIngredient(ModContent.ItemType<SandSharknadoStaff>());
            //recipe.AddIngredient(ModContent.ItemType<Triploon>());
            recipe.AddIngredient(ModContent.ItemType<MagnaStriker>());

            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();
        }
    }
}
