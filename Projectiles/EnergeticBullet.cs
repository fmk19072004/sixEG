using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.DataStructures;
using System;
using Terraria.Audio;
using sixEG.Content.Projectiles;
using Microsoft.Build.Evaluation;

namespace sixEG.Content.Projectiles
{
    public class EnergeticBullet : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged; 
            Projectile.penetrate = 1; 
            Projectile.timeLeft = 80; 
            Projectile.tileCollide = true; 
            Projectile.ignoreWater = false; 
            Projectile.aiStyle = 0;
        }

        public override void OnSpawn(IEntitySource source)
        {
            base.OnSpawn(source);
            Vector2 directionVector = Projectile.velocity;
            directionVector.Normalize();
            Projectile.velocity = directionVector * 30f;
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() - MathHelper.PiOver2;
        }
    }
}
