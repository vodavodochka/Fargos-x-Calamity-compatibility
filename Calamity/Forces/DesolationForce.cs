using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using FargoCalamity.Calamity.Enchantments;

namespace FargoCalamity.Calamity.Forces
{
    public class DesolationForce : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public virtual bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Force of Desolation");
            /* Tooltip.SetDefault(
@"'When the world is barren and cold, you will be all that remains'
All armor bonuses from Daedalus, Snow Ruffian, Umbraphile, and Astral
All armor bonuses from Omega Blue, Mollusk, Victide, Fathom Swarmer, and Sulphurous
Effects of Scuttler's Jewel, Permafrost's Concoction, and Regenator
Effects of Thief's Dime, Vampiric Talisman, and Momentum Capacitor
Effects of the Astral Arcanum and Gravistar Sabaton
Effects of the Abyssal Diving Suit and Mutated Truffle
Effects of Giant Pearl and Amidias' Pendant
Effects of Aquatic Emblem and Enchanted Pearl
Effects of Ocean's Crest and Luxor's Gift
Effects of Corrosive Spine and Lumenous Amulet
Effects of Sand Cloak and Alluring Bait"); */
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            Item.rare = 11;
            Item.value = 600000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            ModLoader.GetMod("FargoCalamity").Find<ModItem>("MolluskEnchant").UpdateAccessory(player, hideVisual);
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("FathomSwarmerEnchant").UpdateAccessory(player, hideVisual);
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("DaedalusEnchant").UpdateAccessory(player, hideVisual);
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("UmbraphileEnchant").UpdateAccessory(player, hideVisual);
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("AstralEnchant").UpdateAccessory(player, hideVisual);
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("OmegaBlueEnchant").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ModContent.ItemType<MolluskEnchant>());
            recipe.AddIngredient(ModContent.ItemType<FathomSwarmerEnchant>());
            recipe.AddIngredient(null, "DaedalusEnchant");
            recipe.AddIngredient(null, "UmbraphileEnchant");
            recipe.AddIngredient(null, "AstralEnchant");
            recipe.AddIngredient(null, "OmegaBlueEnchant");

            recipe.AddTile(ModLoader.GetMod("Fargowiltas").Find<ModTile>("CrucibleCosmosSheet").Type);
            recipe.Register();
        }
    }
}
