using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using FargoCalamity.Calamity.Enchantments;

namespace FargoCalamity.Calamity.Forces
{
    public class ExaltationForce : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public virtual bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Force of Exaltation");
            /* Tooltip.SetDefault(
@"''
All armor bonuses from Tarragon, Bloodflare, and Brimflame
All armor bonuses from God Slayer, Silva, and Auric
Effects of Blazing Core, Dark Sun Ring, and Core of the Blood God
Effects of Nebulous Core and Draedon's Heart
Effects of the The Amalgam and Godly Soul Artifact
Effects of Yharim's Gift, Heart of the Elements, and The Sponge"); */

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

            ModLoader.GetMod("FargoCalamity").Find<ModItem>("TarragonEnchant").UpdateAccessory(player, hideVisual);
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("BloodflareEnchant").UpdateAccessory(player, hideVisual);
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("GodSlayerEnchant").UpdateAccessory(player, hideVisual);
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("SilvaEnchant").UpdateAccessory(player, hideVisual);
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("AuricEnchant").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(null, "TarragonEnchant");
            recipe.AddIngredient(null, "BloodflareEnchant");
            recipe.AddIngredient(null, "GodSlayerEnchant");
            recipe.AddIngredient(null, "SilvaEnchant");
            recipe.AddIngredient(null, "AuricEnchant");

            recipe.AddTile(ModLoader.GetMod("Fargowiltas").Find<ModTile>("CrucibleCosmosSheet").Type);
            recipe.Register();
        }
    }
}
