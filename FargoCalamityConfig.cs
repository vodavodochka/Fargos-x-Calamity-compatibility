using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using System.ComponentModel;
using FargowiltasSouls;
using FargowiltasSouls.Core.ModPlayers;
using FargowiltasSouls.Content.Buffs.Boss;

namespace FargoCalamity
{
    class SoulConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;
        public static SoulConfig Instance;

        private void SetAll(bool val)
        {
            IEnumerable<FieldInfo> configs = typeof(SoulConfig).GetFields(BindingFlags.Public | BindingFlags.Instance).Where(i => i.FieldType == true.GetType());
            foreach (FieldInfo config in configs)
            {
                config.SetValue(this, val);
            }
            IEnumerable<FieldInfo> calamityConfigs = typeof(CalamityToggles).GetFields(BindingFlags.Public | BindingFlags.Instance).Where(i => i.FieldType == true.GetType());
            foreach (FieldInfo calamityConfig in calamityConfigs)
            {
                calamityConfig.SetValue(calamityToggles, val);
            }
        }

        [Label("Toggle All On")]
        public bool PresetA
        {
            get => false;
            set
            {
                if (value)
                {
                    SetAll(true);
                }
            }
        }

        [Label("Toggle All Off")]
        public bool PresetB
        {
            get => false;
            set
            {
                if (value)
                {
                    SetAll(false);
                }
            }
        }

        [Label("$Mods.FargoCalamity.CalamityHeader")]
        public CalamityToggles calamityToggles = new CalamityToggles();

        //soa soon tm

        public override void OnLoaded()
        {
            Instance = this;
        }

        public bool GetValue(bool toggle, bool checkForMutantPresence = true)
        {
            Player player = Main.player[Main.myPlayer];
            return checkForMutantPresence && player.GetModPlayer<FargoSoulsPlayer>().MutantPresence ? false : toggle;
        }
    }

    public class CalamityToggles
    {
        //[Label("$Mods.FargoCalamity.CalamityElementalQuiverConfig")]
        //[DefaultValue(true)]
        //public bool ElementalQuiver;

        //aerospec
        [Header("$Mods.FargoCalamity.AnnihilationForce")]
        [Label("$Mods.FargoCalamity.CalamityValkyrieMinionConfig")]
        [DefaultValue(true)]
        public bool ValkyrieMinion;

        [Label("$Mods.FargoCalamity.CalamityGladiatorLocketConfig")]
        [DefaultValue(true)]
        public bool GladiatorLocket;

        [Label("$Mods.FargoCalamity.CalamityUnstablePrismConfig")]
        [DefaultValue(true)]
        public bool UnstablePrism;

        //statigel
        [Label("$Mods.FargoCalamity.CalamityFungalSymbiote")]
        [DefaultValue(true)]
        public bool FungalSymbiote;

        //hydrothermic
        [Label("$Mods.FargoCalamity.CalamityAtaxiaEffectsConfig")]
        [DefaultValue(true)]
        public bool AtaxiaEffects;

        [Label("$Mods.FargoCalamity.CalamityChaosMinionConfig")]
        [DefaultValue(true)]
        public bool ChaosMinion;

        [Label("$Mods.FargoCalamity.CalamityHallowedRuneConfig")]
        [DefaultValue(true)]
        public bool HallowedRune;

        [Label("$Mods.FargoCalamity.CalamityEtherealExtorterConfig")]
        [DefaultValue(true)]
        public bool EtherealExtorter;

        //xeroc
        [Label("$Mods.FargoCalamity.CalamityXerocEffectsConfig")]
        [DefaultValue(true)]
        public bool XerocEffects;

        //fearmonger

        [Label("$Mods.FargoCalamity.CalamityStatisBeltOfCursesConfig")]
        [DefaultValue(true)]
        public bool StatisBeltOfCurses;

        //reaver
        [Header("$Mods.FargoCalamity.DevastationForce")]
        [Label("$Mods.FargoCalamity.CalamityReaverEffectsConfig")]
        [DefaultValue(true)]
        public bool ReaverEffects;

        [Label("$Mods.FargoCalamity.CalamityReaverMinionConfig")]
        [DefaultValue(true)]
        public bool ReaverMinion;

        //plague reaper
        [Label("$Mods.FargoCalamity.CalamityPlagueHiveConfig")]
        [DefaultValue(true)]
        public bool PlagueHive;

        [Label("$Mods.FargoCalamity.CalamityPlaguedFuelPackConfig")]
        [DefaultValue(true)]
        public bool PlaguedFuelPack;

        [Label("$Mods.FargoCalamity.CalamityTheCamperConfig")]
        [DefaultValue(false)]
        public bool TheCamper;

        //demonshade
        [Label("$Mods.FargoCalamity.CalamityDevilMinionConfig")]
        [DefaultValue(true)]
        public bool RedDevilMinion;

        [Label("$Mods.FargoCalamity.CalamityProfanedSoulConfig")]
        [DefaultValue(true)]
        public bool ProfanedSoulCrystal;

        //snow ruffian
        [Header("$Mods.FargoCalamity.DesolationForce")]
        [Label("$Mods.FargoCalamity.CalamitySnowRuffianWingsConfig")]
        [DefaultValue(true)]
        public bool SnowRuffianWings;

        //daedalus
        [Label("$Mods.FargoCalamity.CalamityDaedalusEffectsConfig")]
        [DefaultValue(true)]
        public bool DaedalusEffects;

        [Label("$Mods.FargoCalamity.CalamityDaedalusMinionConfig")]
        [DefaultValue(true)]
        public bool DaedalusMinion;

        [Label("$Mods.FargoCalamity.CalamityPermafrostPotionConfig")]
        [DefaultValue(true)]
        public bool PermafrostPotion;


        //astral
        [Label("$Mods.FargoCalamity.CalamityAstralStarsConfig")]
        [DefaultValue(true)]
        public bool AstralStars;

        [Label("$Mods.FargoCalamity.CalamityGravistarSabatonConfig")]
        [DefaultValue(true)]
        public bool GravistarSabaton;

        //omega blue
        [Label("$Mods.FargoCalamity.CalamityOmegaTentaclesConfig")]
        [DefaultValue(true)]
        public bool OmegaTentacles;

        [Label("$Mods.FargoCalamity.CalamityDivingSuitConfig")]
        [DefaultValue(false)]
        public bool DivingSuit;

        [Label("$Mods.FargoCalamity.CalamityReaperToothNecklaceConfig")]
        [DefaultValue(false)]
        public bool ReaperToothNecklace;

        [Label("$Mods.FargoCalamity.CalamityMutatedTruffleConfig")]
        [DefaultValue(true)]
        public bool MutatedTruffle;

        //victide
        [Label("$Mods.FargoCalamity.CalamityUrchinConfig")]
        [DefaultValue(true)]
        public bool UrchinMinion;

        [Label("$Mods.FargoCalamity.CalamityLuxorGiftConfig")]
        [DefaultValue(true)]
        public bool LuxorGift;





        //organize more later ech


        [Label("$Mods.FargoCalamity.CalamityBloodflareEffectsConfig")]
        [DefaultValue(true)]
        public bool BloodflareEffects;

        [Label("$Mods.FargoCalamity.CalamityPolterMinesConfig")]
        [DefaultValue(true)]
        public bool PolterMines;

        [Label("$Mods.FargoCalamity.CalamitySilvaEffectsConfig")]
        [DefaultValue(true)]
        public bool SilvaEffects;

        [Label("$Mods.FargoCalamity.CalamitySilvaMinionConfig")]
        [DefaultValue(true)]
        public bool SilvaMinion;

        [Label("$Mods.FargoCalamity.CalamityGodlyArtifactConfig")]
        [DefaultValue(true)]
        public bool GodlySoulArtifact;

        [Label("$Mods.FargoCalamity.CalamityYharimGiftConfig")]
        [DefaultValue(true)]
        public bool YharimGift;

        [Label("$Mods.FargoCalamity.CalamityFungalMinionConfig")]
        [DefaultValue(true)]
        public bool FungalMinion;

        [Label("$Mods.FargoCalamity.CalamityPoisonSeawaterConfig")]
        [DefaultValue(true)]
        public bool PoisonSeawater;


        [Label("$Mods.FargoCalamity.CalamityGodSlayerEffectsConfig")]
        [DefaultValue(true)]
        public bool GodSlayerEffects;

        [Label("$Mods.FargoCalamity.CalamityMechwormMinionConfig")]
        [DefaultValue(true)]
        public bool MechwormMinion;

        [Label("$Mods.FargoCalamity.CalamityNebulousCoreConfig")]
        [DefaultValue(true)]
        public bool NebulousCore;


        [Label("$Mods.FargoCalamity.CalamityAuricEffectsConfig")]
        [DefaultValue(true)]
        public bool AuricEffects;

        [Label("$Mods.FargoCalamity.CalamityWaifuMinionsConfig")]
        [DefaultValue(true)]
        public bool WaifuMinions;

        [Label("$Mods.FargoCalamity.CalamityShellfishMinionConfig")]
        [DefaultValue(true)]
        public bool ShellfishMinion;

        [Label("$Mods.FargoCalamity.CalamityAmidiasPendantConfig")]
        [DefaultValue(true)]
        public bool AmidiasPendant;

        [Label("$Mods.FargoCalamity.CalamityGiantPearlConfig")]
        [DefaultValue(true)]
        public bool GiantPearl;

        [Label("$Mods.FargoCalamity.CalamityTarragonEffectsConfig")]
        [DefaultValue(true)]
        public bool TarragonEffects;
    }
}
