using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using CalamityMod.Items.Armor.Empyrean;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Fishing;
using FargoCalamity;

namespace FargoCalamity.Calamity.Enchantments
{
    public class XerocEnchant : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public virtual bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Xeroc Enchantment");
            /* Tooltip.SetDefault(
@"'The power of an ancient god at your command…'
Rogue projectiles have special effects on enemy hits
Imbued with cosmic wrath and rage when you are damaged
Effects of The Community"); */
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            Item.rare = 9;
            Item.value = 1000000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.XerocEffects))
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("EmpyreanMask").UpdateArmorSet(player);
            }

            //the community
            ModLoader.GetMod("CalamityMod").Find<ModItem>("TheCommunity").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ModContent.ItemType<EmpyreanMask>());
            recipe.AddIngredient(ModContent.ItemType<EmpyreanCloak>());
            recipe.AddIngredient(ModContent.ItemType<EmpyreanCuisses>());
            recipe.AddIngredient(ModContent.ItemType<TheCommunity>());
            //recipe.AddIngredient(ModContent.ItemType<ElephantKiller>()); does not exist
            recipe.AddIngredient(ModContent.ItemType<ElementalBlaster>());

            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
    }
}
