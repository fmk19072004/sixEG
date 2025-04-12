using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.DataStructures;
using System;
using Terraria.Audio;

namespace sixEG.Content.Projectiles 
{
    public class ArcaneBlast : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 24; 
            Projectile.height = 30;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged; 
            Projectile.aiStyle = 1;  
            Projectile.penetrate = 6;
            Projectile.timeLeft = 70; 
            Projectile.light = 1f; 
            Projectile.ignoreWater = true; 
            Projectile.tileCollide = false;

            Projectile.extraUpdates = 3;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
        }
    }

}