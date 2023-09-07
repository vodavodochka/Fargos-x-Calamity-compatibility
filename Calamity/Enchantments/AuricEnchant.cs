using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalamityMod.CalPlayer;
using System;
using Terraria.Localization;
using CalamityMod.Items.Armor.Auric;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Summon;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Weapons.Magic;

namespace FargoCalamity.Calamity.Enchantments
{
    public class AuricEnchant : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public virtual bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Auric Tesla Enchantment");
            /* Tooltip.SetDefault(
@"'Your strength rivals that of the Jungle Tyrant...'
All effects from Tarragon, Bloodflare, Godslayer and Silva armor
All attacks spawn healing auric orbs
Effects of Heart of the Elements and The Sponge"); */
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            Item.rare = 10;
            Item.value = 10000000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.AuricEffects))
            {
                //auric
                ModLoader.GetMod("CalamityMod").Find<ModItem>("AuricTeslaRoyalHelm").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("AuricTeslaHoodedFacemask").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("AuricTeslaWireHemmedVisage").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("AuricTeslaSpaceHelmet").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("AuricTeslaPlumedHelm").UpdateArmorSet(player);
                //tarragaon
                ModLoader.GetMod("CalamityMod").Find<ModItem>("TarragonHeadMelee").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("TarragonHeadRanged").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("TarragonHeadSummon").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("TarragonHeadMagic").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("TarragonHeadRogue").UpdateArmorSet(player);
                //bloodflare
                ModLoader.GetMod("CalamityMod").Find<ModItem>("BloodflareHeadMelee").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("BloodflareHeadMagic").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("BloodflareHeadRanged").UpdateArmorSet(player);
                //ModLoader.GetMod("CalamityMod").Find<ModItem>("BloodflareHeadSummon").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("BloodflareHeadRogue").UpdateArmorSet(player);
                //godslayer
                ModLoader.GetMod("CalamityMod").Find<ModItem>("GodSlayerHeadMelee").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("GodSlayerHeadRogue").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("GodSlayerHeadRanged").UpdateArmorSet(player);
                //silva
                ModLoader.GetMod("CalamityMod").Find<ModItem>("SilvaHeadMagic").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("SilvaHeadSummon").UpdateArmorSet(player);
            }

            //summon head
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.PolterMines))
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("BloodflareHeadSummon").UpdateArmorSet(player);
            }

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.WaifuMinions))
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("HeartoftheElements").UpdateAccessory(player, hideVisual);
            }
            //the sponge
            ModLoader.GetMod("CalamityMod").Find<ModItem>("TheSponge").UpdateAccessory(player, hideVisual);
        }



        public override void AddRecipes()
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddRecipeGroup("FargoCalamity:AnyAuricHelmet");
            recipe.AddIngredient(ModContent.ItemType<AuricTeslaBodyArmor>());
            recipe.AddIngredient(ModContent.ItemType<AuricTeslaCuisses>());
            recipe.AddIngredient(ModContent.ItemType<HeartoftheElements>());
            recipe.AddIngredient(ModContent.ItemType<TheSponge>());
            recipe.AddIngredient(ModContent.ItemType<ArkoftheCosmos>());

            recipe.AddTile(calamity, "DraedonsForge");
            recipe.Register();
        }
    }
}
