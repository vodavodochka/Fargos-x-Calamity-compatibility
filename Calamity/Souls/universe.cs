using Terraria;
using Microsoft.Xna.Framework;
using System.Collections.ObjectModel;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI.Chat;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Rogue;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Content.Items.Accessories.Expert;
using FargoCalamity.Calamity.Essences;
using FargoCalamity.Calamity.Souls;

namespace FargoCalamity.Calamity.Souls
{
    public class universe : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public virtual bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("UniverseSoul").SetStaticDefaults();
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
            // DisplayName.SetDefault("Vagabond's Soul");
            /*Tooltip.SetDefault(@"'They’ll never see it coming'
30% increased rogue damage
15% increased rogue velocity
15% increased rogue critical strike chance
Effects of Eclipse Mirror, Nanotech, Venerated Locket, and Dragon Scales");*/
        }

        /*public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color?(new Color(255, 30, 247));
                }
            }
        }*/

        public override void SetDefaults()
        {
            ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("UniverseSoul").SetDefaults();

            Item.accessory = true;
            Item.value = 5000000;
            Item.rare = -12;
            Item.expert = true;
            Item.defense = 4;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("RogueSoul").UpdateAccessory(player, hideVisual);
            ModLoader.GetMod("FargoCalamity").Find<ModItem>("CalamitySoul").UpdateAccessory(player, hideVisual);
            ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("UniverseSoul").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<UniverseCore>());
            recipe.AddIngredient(ModContent.ItemType<BerserkerSoul>());
            recipe.AddIngredient(ModContent.ItemType<SnipersSoul>());
            recipe.AddIngredient(ModContent.ItemType<ArchWizardsSoul>());
            recipe.AddIngredient(ModContent.ItemType<ConjuristsSoul>());
            recipe.AddIngredient(ModContent.ItemType<RogueSoul>());
            recipe.AddIngredient(ModContent.ItemType<CalamitySoul>());
            recipe.AddIngredient(ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("AbomEnergy").Type, 10);
            recipe.AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"));

            recipe.Register();
        }
    }
}
