using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.Localization;
using CalamityMod.Items.Armor.SnowRuffian;
using CalamityMod.Items.Fishing.BrimstoneCragCatches;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Summon;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Fishing.FishingRods;
using CalamityMod.Items.Pets;
using CalamityMod.Items.Mounts;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Magic;

namespace FargoCalamity.Calamity.Enchantments
{
    public class SnowRuffianEnchant : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");
        private bool shouldBoost;

        public virtual bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Snow Ruffian Enchantment");
            /* Tooltip.SetDefault(
@"''
You can glide to negate fall damage
Effects of Scuttler's Jewel"); */
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
            Item.rare = 2;
            Item.value = 10000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            //set bonus
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.SnowRuffianWings))
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("SnowRuffianMask").UpdateArmorSet(player);
                if (player.controlJump)
            {
                player.noFallDmg = true;
                player.UpdateJumpHeight();
                if (this.shouldBoost)
                {
                    player.velocity.X = player.velocity.X * 1.3f;
                    this.shouldBoost = false;
                    return;
                }
            }
            else if (!this.shouldBoost && player.velocity.Y == 0f)
            {
                this.shouldBoost = true;
            }
            }

            ModLoader.GetMod("CalamityMod").Find<ModItem>("ScuttlersJewel").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ModContent.ItemType<SnowRuffianMask>()); //private REE, fix later
            recipe.AddIngredient(ModContent.ItemType<SnowRuffianChestplate>());
            recipe.AddIngredient(ModContent.ItemType<SnowRuffianGreaves>());
            recipe.AddIngredient(ModContent.ItemType<ScuttlersJewel>());
            //recipe.AddIngredient(ModContent.ItemType<Waraxe>());
            recipe.AddIngredient(ModContent.ItemType<TundraLeash>());

            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }
    }
}
