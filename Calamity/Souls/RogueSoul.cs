using Terraria;
using Microsoft.Xna.Framework;
using System.Collections.ObjectModel;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI.Chat;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Rogue;
using FargoCalamity.Calamity.Essences;

namespace FargoCalamity.Calamity.Souls
{
    public class RogueSoul : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public virtual bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
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
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            Item.value = 1000000;
            Item.rare = 11;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            calamity.Call("AddRogueDamage", player, 0.3f);
            calamity.Call("AddRogueCrit", player, 15);
            calamity.Call("AddRogueVelocity", player, 0.15f);

            ModLoader.GetMod("CalamityMod").Find<ModItem>("EclipseMirror").UpdateAccessory(player, hideVisual);
            ModLoader.GetMod("CalamityMod").Find<ModItem>("Nanotech").UpdateAccessory(player, hideVisual);
            ModLoader.GetMod("CalamityMod").Find<ModItem>("VeneratedLocket").UpdateAccessory(player, hideVisual);
            ModLoader.GetMod("CalamityMod").Find<ModItem>("DragonScales").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargoCalamity.Instance.CalamityLoaded) return;

            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<RogueEssence>());
            recipe.AddIngredient(ModContent.ItemType<EclipseMirror>());
            recipe.AddIngredient(ModContent.ItemType<Nanotech>());
            recipe.AddIngredient(ModContent.ItemType<VeneratedLocket>());
            recipe.AddIngredient(ModContent.ItemType<DragonScales>());
            recipe.AddIngredient(ModContent.ItemType<HellsSun>(), 10);
            //recipe.AddIngredient(ModContent.ItemType<SylvanSlasher>());
            recipe.AddIngredient(ModContent.ItemType<JawsOfOblivion>());
            recipe.AddIngredient(ModContent.ItemType<DeepSeaDumbbell>());
            recipe.AddIngredient(ModContent.ItemType<TimeBolt>());
            recipe.AddIngredient(ModContent.ItemType<Eradicator>());
            recipe.AddIngredient(ModContent.ItemType<EclipsesFall>());
            recipe.AddIngredient(ModContent.ItemType<Celestus>());
            recipe.AddIngredient(ModContent.ItemType<ScarletDevil>());

            recipe.AddTile(ModLoader.GetMod("Fargowiltas").Find<ModTile>("CrucibleCosmosSheet").Type);
            recipe.Register();
        }
    }
}
