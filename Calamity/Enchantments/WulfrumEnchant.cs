using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using CalamityMod.Items.Armor.Wulfrum;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Fishing;

namespace FargoCalamity.Calamity.Enchantments
{
    public class WulfrumEnchant : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public virtual bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Wulfrum Enchantment");
            /* Tooltip.SetDefault(
@"'Not to be confused with Tungsten Enchantment…'
+5 defense when below 50% life
Effects of Trinket of Chi"); */
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            Item.rare = 1;
            Item.value = 40000;
            Item.defense = 3;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            if (player.statLife <= (int)(player.statLifeMax2 * 0.5))
            {
                player.statDefense += 5;
            }
            //trinket of chi
            ModLoader.GetMod("CalamityMod").Find<ModItem>("TrinketofChi").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ModContent.ItemType<WulfrumHat>());
            recipe.AddIngredient(ModContent.ItemType<WulfrumJacket>());
            recipe.AddIngredient(ModContent.ItemType<WulfrumOveralls>());
            recipe.AddIngredient(ModContent.ItemType<TrinketofChi>());
            recipe.AddIngredient(ModContent.ItemType<SparkSpreader>());
            recipe.AddIngredient(ModContent.ItemType<Pumpler>());

            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }
    }
}
