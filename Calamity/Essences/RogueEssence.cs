using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Rogue;

namespace FargoCalamity.Calamity.Essences
{
    public class RogueEssence : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public virtual bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Outlaw's Essence");
            /* Tooltip.SetDefault(
@"18% increased rogue damage
5% increased rogue velocity
5% increased rogue critical strike chance
'This is only the beginning..'"); */
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            Item.rare = 4;
            Item.value = 150000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            calamity.Call("AddRogueDamage", player, 0.18f);
            calamity.Call("AddRogueCrit", player, 5);
            calamity.Call("AddRogueVelocity", player, 0.05f);
        }

        public override void AddRecipes()
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<RogueEmblem>());
            recipe.AddIngredient(ModContent.ItemType<GildedDagger>());
            recipe.AddIngredient(ModContent.ItemType<WebBall>(), 300);
            recipe.AddIngredient(ModContent.ItemType<BouncingEyeball>());
            recipe.AddIngredient(ModContent.ItemType<InfestedClawmerang>());
            recipe.AddIngredient(ModContent.ItemType<MeteorFist>());
            recipe.AddIngredient(ModContent.ItemType<SludgeSplotch>(), 300);
            recipe.AddIngredient(ModContent.ItemType<SkyStabber>(), 4);
            recipe.AddIngredient(ModContent.ItemType<PoisonPack>(), 3);
            recipe.AddIngredient(ModContent.ItemType<HardenedHoneycomb>(), 300);
            recipe.AddIngredient(ModContent.ItemType<ShinobiBlade>());
            recipe.AddIngredient(ModContent.ItemType<InfernalKris>(), 300);
            recipe.AddIngredient(ModContent.ItemType<AshenStalactite>());
            recipe.AddIngredient(ItemID.HallowedBar, 5);

            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}
