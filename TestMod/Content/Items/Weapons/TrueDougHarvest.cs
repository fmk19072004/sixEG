using Microsoft.Xna.Framework;
using rail;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TestMod.Content.Items.Weapons
{
    public class TrueDougHarvest : ModProjectile
    {
        
        public override void SetDefaults()
        {
          
            Projectile.width = 150;
            Projectile.height = 150;
            Projectile.friendly = true;
            Projectile.maxPenetrate = 500;
            Projectile.tileCollide = false;
            Projectile.damage = 20;
            Projectile.ArmorPenetration = 999;
            Projectile.CritChance = 10;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.timeLeft = 60;
            Projectile.penetrate = -1;
            Projectile.stopsDealingDamageAfterPenetrateHits = true;
            
        }
        public override void AI()
        {
            base.AI();
            Projectile.rotation += 0.3f * (float)Projectile.direction;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            base.OnHitNPC(target, hit, damageDone);
            Player owner = Main.player[Projectile.owner];
            owner.statMana += 10;
            owner.ManaEffect(10);

        }


    }
}
