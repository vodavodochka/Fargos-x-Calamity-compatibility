using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using FargoCalamity.Calamity.Enchantments;

namespace FargoCalamity.Calamity.Forces
{
    public class DevastationForce : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public virtual bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Force of Devastation");
            /* Tooltip.SetDefault(
@"'Rain hell down on those who resist your power'
All armor bonuses from Wulfrum, Reaver, Plague Reaper, and Demonshade
Effects of Trinket of Chi and Plague Hive
Effects of Plagued Fuel Pack, The Camper, and Profaned Soul Crystal"); */
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

            ModLoader.GetMod("FargoCalamity").Find<ModItem>("WulfrumEnchant").UpdateAccessory(player, hideVisual);
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("ReaverEnchant").UpdateAccessory(player, hideVisual);
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("PlagueReaperEnchant").UpdateAccessory(player, hideVisual);
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("DemonShadeEnchant").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(null, "WulfrumEnchant");
            recipe.AddIngredient(null, "ReaverEnchant");
            recipe.AddIngredient(null, "PlagueReaperEnchant");
            recipe.AddIngredient(null, "DemonShadeEnchant");

            recipe.AddTile(ModLoader.GetMod("Fargowiltas").Find<ModTile>("CrucibleCosmosSheet").Type);
            recipe.Register();
        }
    }
}
