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

namespace sixEG.Content.Projectiles.EnemyProjectiles
{
    public class GlitchingLaser : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 34;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.penetrate = 1; 
            Projectile.timeLeft = 150; 
            Projectile.tileCollide = true; 
            Projectile.ignoreWater = false; 
            Projectile.aiStyle = 0;
        }

        public override void OnSpawn(IEntitySource source)
        {
            base.OnSpawn(source);
            Vector2 directionVector = Projectile.velocity;
            directionVector.Normalize();
            Projectile.velocity = directionVector * 15f;
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() - MathHelper.PiOver2;
        }
    }
}
