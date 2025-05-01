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
using System.Runtime.Serialization;

namespace sixEG.Content.Projectiles
{
    public class LeechProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 96;
            Projectile.height = 96;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Magic; 
            Projectile.penetrate = -1; 
            Projectile.timeLeft = 200; 
            Projectile.ignoreWater = true; 
            Projectile.tileCollide = false;
            Projectile.light = 0.25f;
            AIType = ProjectileID.ChlorophyteBullet;
        }

        public override void AI()
        {
            Projectile.rotation += 0.3f * (float)Projectile.direction;
        }
    }
}
