using Microsoft.Xna.Framework;
using rail;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TestMod.Content.Items.Weapons
{
    public class GreenDougHarvest : ModProjectile
    {
        
        public override void SetDefaults()
        {
          
            Projectile.width = 150;
            Projectile.height = 150;
            Projectile.friendly = true;
            Projectile.maxPenetrate = 500;
            Projectile.tileCollide = false;
            Projectile.damage = 8;
            Projectile.ArmorPenetration = 999;
            Projectile.CritChance = 0;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.timeLeft = 45;
            Projectile.penetrate = -1;
            Projectile.stopsDealingDamageAfterPenetrateHits = true;
            
        }
        public override void AI()
        {
            base.AI();
            Projectile.rotation += 0.25f * (float)Projectile.direction;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            base.OnHitNPC(target, hit, damageDone);
            Player owner = Main.player[Projectile.owner];
            owner.statMana += 5;
            owner.ManaEffect(5);

        }


    }
}
