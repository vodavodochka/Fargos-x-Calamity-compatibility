using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using CalamityMod.CalPlayer;
using Terraria.Localization;
using System.Collections.Generic;
using CalamityMod.Items.Armor.OmegaBlue;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Weapons.Summon;

namespace FargoCalamity.Calamity.Enchantments
{
    public class OmegaBlueEnchant : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public virtual bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Omega Blue Enchantment");
            /* Tooltip.SetDefault(
@"'The darkness of the Abyss has overwhelmed you...'
Increases armor penetration by 100
Short-ranged tentacles heal you by sucking enemy life
Press Y to activate abyssal madness for 5 seconds
Abyssal madness increases damage, critical strike chance, and tentacle aggression/range
This effect has a 30 second cooldown
Effects of the Abyssal Diving Suit and Mutated Truffle"); */
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            Item.rare = 13;
            Item.value = 1000000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.OmegaTentacles))
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("OmegaBlueHelmet").UpdateArmorSet(player);
            }
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.DivingSuit))
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("AbyssalDivingSuit").UpdateAccessory(player, hideVisual);
            }

            if (SoulConfig.Instance.calamityToggles.ReaperToothNecklace)
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("ReaperToothNecklace").UpdateAccessory(player, hideVisual);
            }

            if (SoulConfig.Instance.calamityToggles.MutatedTruffle)
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("MutatedTruffle").UpdateAccessory(player, hideVisual);
            }

            //ModLoader.GetMod("CalamityMod").Find<ModItem>("DukeScales").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ModContent.ItemType<OmegaBlueHelmet>());
            recipe.AddIngredient(ModContent.ItemType<OmegaBlueChestplate>());
            recipe.AddIngredient(ModContent.ItemType<OmegaBlueTentacles>());

            recipe.AddIngredient(ModContent.ItemType<AbyssalDivingSuit>());
            recipe.AddIngredient(ModContent.ItemType<ReaperToothNecklace>());
            recipe.AddIngredient(ModContent.ItemType<MutatedTruffle>());
            
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
    }
}
