using Microsoft.Build.Evaluation;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TestMod.Content.Items.Weapons
{
    public class TrueDougProj : ModProjectile
    {       
        public override void SetDefaults()
        {

            Projectile.CloneDefaults(ProjectileID.EnchantedBoomerang);            
            AIType = ProjectileID.EnchantedBoomerang;
            Projectile.height = 30;
            Projectile.width = 30;
            
            

        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {         
            base.OnHitNPC(target, hit, damageDone);
            if (Projectile.owner == Main.myPlayer)
            {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, 0f, 0f, ModContent.ProjectileType<Weapons.TrueDougHarvest>(), 20, 0.4f, Projectile.owner, 0f, 0f);
            }
            Player owner = Main.player[Projectile.owner];
            owner.statLife += 4;
            owner.HealEffect(4);

        }


    }
}
