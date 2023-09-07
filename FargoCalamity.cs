using CalamityMod.Items.Armor;
using CalamityMod.Items.Placeables.Furniture;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using CalamityMod.Items.Armor.Aerospec;
using CalamityMod.Items.Armor.Hydrothermic;
using CalamityMod.Items.Armor.Auric;
using CalamityMod.Items.Armor.Bloodflare;
using CalamityMod.Items.Armor.GodSlayer;
using CalamityMod.Items.Armor.Reaver;
using CalamityMod.Items.Armor.Silva;
using CalamityMod.Items.Armor.Statigel;
using CalamityMod.Items.Armor.Tarragon;
using CalamityMod.Items.Armor.Victide;
using CalamityMod.Items.Armor.Wulfrum;
using CalamityMod.Items.Placeables.Furniture;
using FargowiltasSouls;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargoCalamity.Calamity.Souls;
using FargowiltasSouls.Core.ModPlayers;

namespace FargoCalamity
{
    public class FargoCalamity : Mod
    {
        internal static FargoCalamity Instance;
        internal bool CalamityLoaded;

        public override void Load()
        {
            Instance = this;
            if (ModLoader.GetMod("CalamityMod") != null)
            {
                AddToggle("CalamityHeader", "Calamity Toggles", "CalamitySoul", "ffffff");
                //AddToggle("CalamityElementalQuiverConfig", "Elemental Quiver", "SnipersSoul", "ffffff");

                AddToggle("AnnihilationForce", "Force of Annihilation", "AnnihilationForce", "ffffff");
                AddToggle("CalamityValkyrieMinionConfig", "Valkyrie Minion", "AerospecEnchant", "ffffff");
                AddToggle("CalamityGladiatorLocketConfig", "Gladiator's Locket", "AerospecEnchant", "ffffff");
                AddToggle("CalamityUnstablePrismConfig", "Unstable Prism", "AerospecEnchant", "ffffff");
                AddToggle("CalamityFungalSymbiote", "Fungal Symbiote", "StatigelEnchant", "ffffff");
                AddToggle("CalamityAtaxiaEffectsConfig", "Ataxia Effects", "AtaxiaEnchant", "ffffff");
                AddToggle("CalamityChaosMinionConfig", "Chaos Spirit Minion", "AtaxiaEnchant", "ffffff");
                AddToggle("CalamityHallowedRuneConfig", "Hallowed Rune", "AtaxiaEnchant", "ffffff");
                AddToggle("CalamityEtherealExtorterConfig", "Ethereal Extorter", "AtaxiaEnchant", "ffffff");
                AddToggle("CalamityXerocEffectsConfig", "Xeroc Effects", "XerocEnchant", "ffffff");

                AddToggle("CalamityStatisBeltOfCursesConfig", "Statis' Void Sash", "FearmongerEnchant", "ffffff");

                AddToggle("DevastationForce", "Force of Devastation", "DevastationForce", "ffffff");
                AddToggle("CalamityReaverEffectsConfig", "Reaver Effects", "ReaverEnchant", "ffffff");
                AddToggle("CalamityReaverMinionConfig", "Reaver Orb Minion", "ReaverEnchant", "ffffff");
                AddToggle("CalamityPlagueHiveConfig", "Plague Hive", "PlagueReaperEnchant", "ffffff");
                AddToggle("CalamityPlaguedFuelPackConfig", "Plague Fuel Pack", "PlagueReaperEnchant", "ffffff");
                AddToggle("CalamityTheCamperConfig", "The Camper", "PlagueReaperEnchant", "ffffff");
                AddToggle("CalamityDevilMinionConfig", "Red Devil Minion", "DemonShadeEnchant", "ffffff");
                AddToggle("CalamityProfanedSoulConfig", "Profaned Soul Crystal", "DemonShadeEnchant", "ffffff");


                AddToggle("DesolationForce", "Force of Desolation", "DesolationForce", "ffffff");
                AddToggle("CalamitySnowRuffianWingsConfig", "Snow Ruffian Wings", "SnowRuffianEnchant", "ffffff");
                AddToggle("CalamityDaedalusEffectsConfig", "Daedalus Effects", "DaedalusEnchant", "ffffff");
                AddToggle("CalamityDaedalusMinionConfig", "Daedalus Crystal Minion", "DaedalusEnchant", "ffffff");
                AddToggle("CalamityPermafrostPotionConfig", "Permafrost's Concoction", "DaedalusEnchant", "ffffff");

                AddToggle("CalamityAstralStarsConfig", "Astral Stars", "AstralEnchant", "ffffff");
                AddToggle("CalamityGravistarSabatonConfig", "GravistarSabaton", "AstralEnchant", "ffffff");

                AddToggle("CalamityOmegaTentaclesConfig", "Omega Blue Tentacles", "OmegaBlueEnchant", "ffffff");
                AddToggle("CalamityDivingSuitConfig", "Abyssal Diving Suit", "OmegaBlueEnchant", "ffffff");
                AddToggle("CalamityReaperToothNecklaceConfig", "Reaper Tooth Necklace", "OmegaBlueEnchant", "ffffff");
                AddToggle("CalamityMutatedTruffleConfig", "Mutated Truffle", "OmegaBlueEnchant", "ffffff");
                AddToggle("CalamityUrchinConfig", "Victide Sea Urchin", "VictideEnchant", "ffffff");
                AddToggle("CalamityLuxorGiftConfig", "Luxor's Gift", "VictideEnchant", "ffffff");

                AddToggle("CalamityBloodflareEffectsConfig", "Bloodflare Effects", "BloodflareEnchant", "ffffff");
                AddToggle("CalamityPolterMinesConfig", "Polterghast Mines", "BloodflareEnchant", "ffffff");

                AddToggle("CalamitySilvaEffectsConfig", "Silva Effects", "SilvaEnchant", "ffffff");
                AddToggle("CalamitySilvaMinionConfig", "Silva Crystal Minion", "SilvaEnchant", "ffffff");
                AddToggle("CalamityGodlyArtifactConfig", "Godly Soul Artifact", "SilvaEnchant", "ffffff");
                AddToggle("CalamityYharimGiftConfig", "Yharim's Gift", "SilvaEnchant", "ffffff");
                AddToggle("CalamityFungalMinionConfig", "Fungal Clump Minion", "SilvaEnchant", "ffffff");
                AddToggle("CalamityPoisonSeawaterConfig", "Poisonous Sea Water", "SilvaEnchant", "ffffff");

                AddToggle("CalamityGodSlayerEffectsConfig", "God Slayer Effects", "GodSlayerEnchant", "ffffff");
                AddToggle("CalamityMechwormMinionConfig", "Mechworm Minion", "GodSlayerEnchant", "ffffff");
                AddToggle("CalamityNebulousCoreConfig", "Nebulous Core", "GodSlayerEnchant", "ffffff");
                AddToggle("CalamityAuricEffectsConfig", "Auric Tesla Effects", "AuricEnchant", "ffffff");
                AddToggle("CalamityWaifuMinionsConfig", "Elemental Waifus", "AuricEnchant", "ffffff");

                AddToggle("CalamityShellfishMinionConfig", "Shellfish Minions", "MolluskEnchant", "ffffff");
                AddToggle("CalamityGiantPearlConfig", "Giant Pearl", "MolluskEnchant", "ffffff");

                AddToggle("CalamityTarragonEffectsConfig", "Tarragon Effects", "TarragonEnchant", "ffffff");

            }
            else
            {
                AddToggle("CalamityHeader", "Enable Calamity for these Toggles", "", "ffffff");
            }

        }

        public void AddToggle(String toggle, String name, String item, String color)
        {
            LocalizedText text = Language.GetOrRegister(toggle);
            // text.SetDefault("[i:" + item + "] [c/" + color + ":" + name + "]");
        }

        public override void PostSetupContent()
        {
            try
            {
                CalamityLoaded = ModLoader.GetMod("CalamityMod") != null;
            }
            catch (Exception e)
            {
                Logger.Error("FargoCalamity PostSetupContent Error: " + e.StackTrace + e.Message);
            }
        }

        public override void AddRecipes()/* tModPorter Note: Removed. Use ModSystem.AddRecipes */
        {
            if (CalamityLoaded)
            {
                CalamityRecipes();
            }
        }

        private void CalamityRecipes()
        {
            {
                //Aerospec
                RecipeGroup group = new RecipeGroup(() => Lang.misc[37] + " Aerospec Helmet", ModLoader.GetMod("CalamityMod").Find<ModItem>("AerospecHat").Type, ModLoader.GetMod("CalamityMod").Find<ModItem>("AerospecHelm").Type, ModLoader.GetMod("CalamityMod").Find<ModItem>("AerospecHood").Type, ModLoader.GetMod("CalamityMod").Find<ModItem>("AerospecHeadgear").Type, ModLoader.GetMod("CalamityMod").Find<ModItem>("AerospecHelmet").Type);
                RecipeGroup.RegisterGroup("FargoCalamity:AnyAerospecHelmet", group);

                //Ataxia
                group = new RecipeGroup(() => Lang.misc[37] + " Ataxia Helmet", ModLoader.GetMod("CalamityMod").Find<ModItem>("HydrothermicHeadMelee").Type, ModLoader.GetMod("CalamityMod").Find<ModItem>("HydrothermicHeadMagic").Type, ModLoader.GetMod("CalamityMod").Find<ModItem>("HydrothermicHeadRanged").Type, ModLoader.GetMod("CalamityMod").Find<ModItem>("HydrothermicHeadSummon").Type, ModLoader.GetMod("CalamityMod").Find<ModItem>("HydrothermicHeadRogue").Type);
                RecipeGroup.RegisterGroup("FargoCalamity:AnyAtaxiaHelmet", group);

                //Auric
                group = new RecipeGroup(() => Lang.misc[37] + " Auric Helmet", ModLoader.GetMod("CalamityMod").Find<ModItem>("AuricTeslaRoyalHelm").Type, ModLoader.GetMod("CalamityMod").Find<ModItem>("AuricTeslaHoodedFacemask").Type, ModLoader.GetMod("CalamityMod").Find<ModItem>("AuricTeslaWireHemmedVisage").Type, ModLoader.GetMod("CalamityMod").Find<ModItem>("AuricTeslaSpaceHelmet").Type, ModLoader.GetMod("CalamityMod").Find<ModItem>("AuricTeslaPlumedHelm").Type);
                RecipeGroup.RegisterGroup("FargoCalamity:AnyAuricHelmet", group);

                //Bloodflare
                group = new RecipeGroup(() => Lang.misc[37] + " Bloodflare Helmet", ModLoader.GetMod("CalamityMod").Find<ModItem>("BloodflareHeadMelee").Type, ModLoader.GetMod("CalamityMod").Find<ModItem>("BloodflareHeadMagic").Type, ModLoader.GetMod("CalamityMod").Find<ModItem>("BloodflareHeadRanged").Type, ModLoader.GetMod("CalamityMod").Find<ModItem>("BloodflareHeadSummon").Type, ModLoader.GetMod("CalamityMod").Find<ModItem>("BloodflareHeadRogue").Type);
                RecipeGroup.RegisterGroup("FargoCalamity:AnyBloodflareHelmet", group);

                //Daedalus
                group = new RecipeGroup(() => Lang.misc[37] + " Daedalus Helmet", ModLoader.GetMod("CalamityMod").Find<ModItem>("DaedalusHeadMelee").Type, ModLoader.GetMod("CalamityMod").Find<ModItem>("DaedalusHeadMagic").Type, ModLoader.GetMod("CalamityMod").Find<ModItem>("DaedalusHeadRanged").Type, ModLoader.GetMod("CalamityMod").Find<ModItem>("DaedalusHeadSummon").Type, ModLoader.GetMod("CalamityMod").Find<ModItem>("DaedalusHeadRogue").Type);
                RecipeGroup.RegisterGroup("FargoCalamity:AnyDaedalusHelmet", group);

                // Godslayer
                group = new RecipeGroup(() => Lang.misc[37] + " Godslayer Helmet", ModLoader.GetMod("CalamityMod").Find<ModItem>("GodSlayerHeadMelee").Type, ModLoader.GetMod("CalamityMod").Find<ModItem>("GodSlayerHeadRogue").Type, ModLoader.GetMod("CalamityMod").Find<ModItem>("GodSlayerHeadRanged").Type);
                RecipeGroup.RegisterGroup("FargoCalamity:AnyGodslayerHelmet", group);

                // Reaver
                group = new RecipeGroup(() => Lang.misc[37] + " Reaver Helmet", ModLoader.GetMod("CalamityMod").Find<ModItem>("ReaverHeadTank").Type, ModLoader.GetMod("CalamityMod").Find<ModItem>("ReaverHeadExplore").Type, ModLoader.GetMod("CalamityMod").Find<ModItem>("ReaverHeadMobility").Type);
                RecipeGroup.RegisterGroup("FargoCalamity:AnyReaverHelmet", group);

                //Silva
                group = new RecipeGroup(() => Lang.misc[37] + " Silva Helmet", ModLoader.GetMod("CalamityMod").Find<ModItem>("SilvaHeadMagic").Type, ModLoader.GetMod("CalamityMod").Find<ModItem>("SilvaHeadSummon").Type);
                RecipeGroup.RegisterGroup("FargoCalamity:AnySilvaHelmet", group);

                //Statigel
                group = new RecipeGroup(() => Lang.misc[37] + " Statigel Helmet", ModLoader.GetMod("CalamityMod").Find<ModItem>("StatigelHeadMelee").Type, ModLoader.GetMod("CalamityMod").Find<ModItem>("StatigelHeadMagic").Type, ModLoader.GetMod("CalamityMod").Find<ModItem>("StatigelHeadSummon").Type, ModLoader.GetMod("CalamityMod").Find<ModItem>("StatigelHeadRogue").Type, ModLoader.GetMod("CalamityMod").Find<ModItem>("StatigelHeadRanged").Type);
                RecipeGroup.RegisterGroup("FargoCalamity:AnyStatigelHelmet", group);
                //evil effigy
                group = new RecipeGroup(() => Lang.misc[37] + " Evil Effigy", ModLoader.GetMod("CalamityMod").Find<ModItem>("CorruptionEffigy").Type, ModLoader.GetMod("CalamityMod").Find<ModItem>("CrimsonEffigy").Type);
                RecipeGroup.RegisterGroup("FargoCalamity:AnyEvilEffigy", group);

                //Tarragon
                group = new RecipeGroup(() => Lang.misc[37] + " Tarragon Helmet", ModLoader.GetMod("CalamityMod").Find<ModItem>("TarragonHeadMelee").Type, ModLoader.GetMod("CalamityMod").Find<ModItem>("TarragonHeadRanged").Type, ModLoader.GetMod("CalamityMod").Find<ModItem>("TarragonHeadSummon").Type, ModLoader.GetMod("CalamityMod").Find<ModItem>("TarragonHeadMagic").Type, ModLoader.GetMod("CalamityMod").Find<ModItem>("TarragonHeadRogue").Type);
                RecipeGroup.RegisterGroup("FargoCalamity:AnyTarragonHelmet", group);

                //Victide
                group = new RecipeGroup(() => Lang.misc[37] + " Victide Helmet", ModLoader.GetMod("CalamityMod").Find<ModItem>("VictideHeadMelee").Type, ModLoader.GetMod("CalamityMod").Find<ModItem>("VictideHeadRanged").Type, ModLoader.GetMod("CalamityMod").Find<ModItem>("VictideHeadMagic").Type, ModLoader.GetMod("CalamityMod").Find<ModItem>("VictideHeadSummon").Type, ModLoader.GetMod("CalamityMod").Find<ModItem>("VictideHeadRogue").Type);
                RecipeGroup.RegisterGroup("FargoCalamity:AnyVictideHelmet", group);
            }
        }
        public override void PostAddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                // All recipes that require wood will now need 100% more
                if (recipe.createItem.type == ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("UniverseSoul").Type)
                {
                    recipe.DisableRecipe();
                }
                if (recipe.createItem.type == ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("EternitySoul").Type)
                {
                    recipe.RemoveIngredient(ModContent.ItemType<UniverseSoul>());
                    recipe.AddIngredient(ModContent.ItemType<universe>());
                }
            }
        }
    }
}