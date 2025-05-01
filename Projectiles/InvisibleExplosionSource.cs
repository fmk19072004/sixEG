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
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace sixEG.Content.Projectiles
{
    public class InvisibleExplosionSource : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 1;
            Projectile.height = 1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged; 
            Projectile.penetrate = -1; 
            Projectile.timeLeft = 1; 
            Projectile.tileCollide = false; 
            Projectile.ignoreWater = true; 
            Projectile.aiStyle = 0;
            Projectile.hide = true;
        }

        public override void OnSpawn(IEntitySource source)
        {
            float explosionRadius = Projectile.ai[0]; //passed through when projectile is created
            Vector2 position = Projectile.position;

            SoundEngine.PlaySound(SoundID.Item14, position);

            for (int i = 0; i < 150; i++)
            {
                Vector2 dustPos = position + Main.rand.NextVector2Circular(explosionRadius, explosionRadius);
                Dust dust = Dust.NewDustDirect(dustPos, 10, 10, DustID.Torch, 0, 0, 100, default, 2f);
                dust.velocity *= 2;
                dust.noGravity = true;

                Dust dust2 = Dust.NewDustDirect(dustPos, 10, 10, DustID.Smoke, 0, 0, 100, default, 2f);
                dust2.velocity *= 2;
                dust2.noGravity = true;
            }
            

            foreach (NPC npc in Main.npc)
            {
                if (npc.active && !npc.friendly)
                {
                    float distance = Vector2.Distance(npc.Center, position);
                    if (distance < explosionRadius)
                    {
                        float damageMultiplier = 1f - (distance / explosionRadius);
                        int finalDamage = (int)(Projectile.damage * damageMultiplier);
                        int direction = (npc.Center.X > position.X) ? 1 : -1;

                        NPC.HitInfo hitInfo = new NPC.HitInfo
                        {
                            Damage = finalDamage,
                            Knockback = Projectile.knockBack,
                        };

                        npc.StrikeNPC(hitInfo);
                    }
                }
            }


            Projectile.Kill();
        }
        }
}
