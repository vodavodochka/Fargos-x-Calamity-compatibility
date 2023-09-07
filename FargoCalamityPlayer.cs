using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace FargoCalamity
{
    public partial class FargoCalamityPlayer : ModPlayer
    {
        public bool PetsActive = true;


        public void AllDamageUp(float dmg)
        {
            Player.GetDamage(DamageClass.Magic) += dmg;
            Player.GetDamage(DamageClass.Melee) += dmg;
            Player.GetDamage(DamageClass.Ranged) += dmg;
            Player.GetDamage(DamageClass.Summon) += dmg;
        }

        public void AllCritUp(int crit)
        {
            Player.GetDamage(DamageClass.Magic) += crit;
            Player.GetDamage(DamageClass.Melee) += crit;
            Player.GetDamage(DamageClass.Ranged) += crit;
        }

        public void AddMinion(bool toggle, int proj, int damage, float knockback)
        {
            if (Player.ownedProjectileCounts[proj] < 1 && Player.whoAmI == Main.myPlayer && SoulConfig.Instance.GetValue(toggle))
                Projectile.NewProjectile(Player.GetSource_FromThis(), new Vector2(Player.Center.X), new Vector2(Player.Center.Y), 0, -1, proj, damage, knockback, Main.myPlayer);
        }
    }
}
