using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;
using Terraria.Localization;
using CalamityMod.Items.Armor.GodSlayer;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Pets;
using CalamityMod.Items.Weapons.Summon;
using CalamityMod.Items.Armor.Vanity;

namespace FargoCalamity.Calamity.Enchantments
{
    public class GodSlayerEnchant : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public virtual bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("God Slayer Enchantment");
            /* Tooltip.SetDefault(
@"'The power to slay gods resides within you...'
You will survive fatal damage and will be healed 150 HP if an attack would have killed you
This effect can only occur once every 45 seconds
Taking over 80 damage in one hit will cause you to release a swarm of high-damage god killer darts
An attack that would deal 80 damage or less will have its damage reduced to 1
Your ranged critical hits have a chance to critically hit, causing 4 times the damage
You have a chance to fire a god killer shrapnel round while firing ranged weapons
Enemies will release god slayer flames and healing flames when hit with magic attacks
Taking damage will cause you to release a magical god slayer explosion
Hitting enemies will summon god slayer phantoms
Summons a god-eating mechworm to fight for you
While at full HP all of your rogue stats are boosted by 10%
If you take over 80 damage in one hit you will be given extra immunity frames
Effects of the Nebulous Core and Draedon's Heart"); */
        }

        /*public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(100, 108, 156);
                }
            }
        }*/

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

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.GodSlayerEffects))
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("GodSlayerHeadMelee").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("GodSlayerHeadRogue").UpdateArmorSet(player);
                ModLoader.GetMod("CalamityMod").Find<ModItem>("GodSlayerHeadRanged").UpdateArmorSet(player);
            }
            
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.NebulousCore))
            {
                ModLoader.GetMod("CalamityMod").Find<ModItem>("NebulousCore").UpdateAccessory(player, hideVisual);
            }

            //draedons heart
            ModLoader.GetMod("CalamityMod").Find<ModItem>("DraedonsHeart").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();

            recipe.AddRecipeGroup("FargoCalamity:AnyGodslayerHelmet");
            recipe.AddIngredient(ModContent.ItemType<GodSlayerChestplate>());
            recipe.AddIngredient(ModContent.ItemType<GodSlayerLeggings>());
            recipe.AddIngredient(ModContent.ItemType<NebulousCore>());
            recipe.AddIngredient(ModContent.ItemType<DimensionalSoulArtifact>());
            recipe.AddIngredient(ModContent.ItemType<DraedonsHeart>());


            recipe.AddTile(calamity, "DraedonsForge");
            recipe.Register();
        }
    }
}
