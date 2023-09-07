using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.Localization;
using CalamityMod.Items.Armor.Silva;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Pets;
using CalamityMod.Items.Weapons.Magic;

namespace FargoCalamity.Calamity.Enchantments
{
    public class SilvaEnchant : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");
        public int dragonTimer = 60;

        public virtual bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Silva Enchantment");
            /* Tooltip.SetDefault(
@"'Boundless life energy cascades from you...'
You are immune to almost all debuffs
Reduces all damage taken by 5%, this is calculated separately from damage reduction
All projectiles spawn healing leaf orbs on enemy hits
Max run speed and acceleration boosted by 5%
If you are reduced to 0 HP you will not die from any further damage for 10 seconds
If you get reduced to 0 HP again while this effect is active you will lose 100 max life
This effect only triggers once per life
Your max life will return to normal if you die
True melee strikes have a 25% chance to do five times damage
Melee projectiles have a 25% chance to stun enemies for a very brief moment
Increases your rate of fire with all ranged weapons
Magic projectiles have a 10% chance to cause a massive explosion on enemy hits
Summons an ancient leaf prism to blast your enemies with life energy
Rogue weapons have a faster throwing rate while you are above 90% life
Effects of the The Amalgam, Godly Soul Artifact, and Yharim's Gift"); */
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            Item.rare = 10;
            Item.value = 20000000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.SilvaEffects))
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("SilvaHeadMagic").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("SilvaHeadSummon").UpdateArmorSet(player);
            }

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.FungalMinion))
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("TheAmalgam").UpdateAccessory(player, hideVisual);
            }

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.GodlySoulArtifact))
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("GodlySoulArtifact").UpdateAccessory(player, hideVisual);
            }

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.YharimGift))
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("YharimsGift").UpdateAccessory(player, hideVisual);
            }

            ModLoader.GetMod("CalamityMod").Find<ModItem>("DynamoStemCells").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddRecipeGroup("FargoCalamity:AnySilvaHelmet");
            recipe.AddIngredient(ModContent.ItemType<SilvaArmor>());
            recipe.AddIngredient(ModContent.ItemType<SilvaLeggings>());
            recipe.AddIngredient(ModContent.ItemType<TheAmalgam>());
            recipe.AddIngredient(ModContent.ItemType<GodlySoulArtifact>());
            recipe.AddIngredient(ModContent.ItemType<YharimsGift>());

            recipe.AddTile(calamity, "DraedonsForge");
            recipe.Register();
        }
    }
}
