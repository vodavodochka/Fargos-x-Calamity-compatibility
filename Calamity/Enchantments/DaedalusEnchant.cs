using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using CalamityMod.Items.Armor.Daedalus;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Items.Pets;
using FargoCalamity.Calamity.Enchantments;

namespace FargoCalamity.Calamity.Enchantments
{
    public class DaedalusEnchant : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public virtual bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Daedalus Enchantment");
            /* Tooltip.SetDefault(
@"'Icy magic envelopes you...'
You have a 33% chance to reflect projectiles back at enemies
If you reflect a projectile you are also healed for 1/5 of that projectile's damage
Getting hit causes you to emit a blast of crystal shards
You have a 10% chance to absorb physical attacks and projectiles when hit
If you absorb an attack you are healed for 1/2 of that attack's damage
A daedalus crystal floats above you to protect you
Rogue projectiles throw out crystal shards as they travel
You can glide to negate fall damage
Effects of Scuttler's Jewel and Permafrost's Concoction"); */
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            Item.rare = 5;
            Item.value = 500000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.DaedalusEffects))
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("DaedalusHeadMelee").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("DaedalusHeadMagic").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("DaedalusHeadSummon").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("DaedalusHeadRanged").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("DaedalusHeadRogue").UpdateArmorSet(player);
            }
            
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.PermafrostPotion))
            {
                //permafrost concoction
                ModLoader.GetMod("CalamityMod").Find<ModItem>("PermafrostsConcoction").UpdateAccessory(player, hideVisual);
            }

            ModLoader.GetMod("FargoCalamity").Find<ModItem>("SnowRuffianEnchant").UpdateAccessory(player, hideVisual);            
        }

        public override void AddRecipes()
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddRecipeGroup("FargoCalamity:AnyDaedalusHelmet");
            recipe.AddIngredient(ModContent.ItemType<DaedalusBreastplate>());
            recipe.AddIngredient(ModContent.ItemType<DaedalusLeggings>());
            recipe.AddIngredient(ModContent.ItemType<SnowRuffianEnchant>());
            recipe.AddIngredient(ModContent.ItemType<PermafrostsConcoction>());
            //recipe.AddIngredient(ModContent.ItemType<CrystalBlade>());

            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();
        }
    }
}
