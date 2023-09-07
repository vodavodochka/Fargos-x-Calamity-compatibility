using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using CalamityMod.Items.Armor.Victide;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Fishing.SunkenSeaCatches;

namespace FargoCalamity.Calamity.Enchantments
{
    public class VictideEnchant : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public virtual bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Victide Enchantment");
            /* Tooltip.SetDefault(
@"'The former seas have energized you…'
When using any weapon you have a 10% chance to throw a returning seashell projectile
This seashell does true damage and does not benefit from any damage class
Summons a sea urchin to protect you
Effects of Ocean's Crest and Luxor's Gift"); */
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            Item.rare = 2;
            Item.value = 80000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            //all
            ModLoader.GetMod("CalamityMod").Find<ModItem>("VictideHeadMelee").UpdateArmorSet(player);
            ModLoader.GetMod("CalamityMod").Find<ModItem>("VictideHeadRanged").UpdateArmorSet(player);
            ModLoader.GetMod("CalamityMod").Find<ModItem>("VictideHeadMagic").UpdateArmorSet(player);
            ModLoader.GetMod("CalamityMod").Find<ModItem>("VictideHeadSummon").UpdateArmorSet(player);
            ModLoader.GetMod("CalamityMod").Find<ModItem>("VictideHeadRogue").UpdateArmorSet(player);

            ModLoader.GetMod("CalamityMod").Find<ModItem>("OceanCrest").UpdateAccessory(player, hideVisual);
            //ModLoader.GetMod("CalamityMod").Find<ModItem>("DeepDiver").UpdateAccessory(player, hideVisual);
            //ModLoader.GetMod("CalamityMod").Find<ModItem>("TheTransformer").UpdateAccessory(player, hideVisual);
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.LuxorGift))
                ModLoader.GetMod("CalamityMod").Find<ModItem>("LuxorsGift").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddRecipeGroup("FargoCalamity:AnyVictideHelmet");
            recipe.AddIngredient(ModContent.ItemType<VictideBreastplate>());
            recipe.AddIngredient(ModContent.ItemType<VictideGreaves>());
            recipe.AddIngredient(ModContent.ItemType<OceanCrest>());
            recipe.AddIngredient(ModContent.ItemType<LuxorsGift>());
            recipe.AddIngredient(ModContent.ItemType<TeardropCleaver>());
            
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }
    }
}
