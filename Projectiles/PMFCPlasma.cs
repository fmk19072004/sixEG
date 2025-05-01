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
    public class PMFCPlasma : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 26;
            Projectile.height = 26;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged; 
            Projectile.penetrate = 1; 
            Projectile.timeLeft = 900; 
            Projectile.ignoreWater = true; 
            Projectile.aiStyle = 0;
            Projectile.light = 0.25f;
        }
    }
}
