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
    public class MortarProjectileBasic : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 24; 
            Projectile.height = 30;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged; 
            Projectile.aiStyle = 1;  
            Projectile.penetrate = 1;
            Projectile.timeLeft = 300; 
            Projectile.light = 0.5f; 
            Projectile.ignoreWater = true; 
            Projectile.tileCollide = true; 
        }

        
        public override void AI()
        {
            Projectile.velocity.Y += 0.09f;
        }

        public override void OnKill(int timeLeft)
        {
            Explosion(Projectile.position, 200f, Projectile.damage, 20, 1, 2);
        }

        public void Explosion(Vector2 position, float radius, int damage, int knockBack, int type, int owner)
        {

            for (int i = 0; i < 100; i++) 
            {
                float angle = Main.rand.NextFloat(0f, MathHelper.TwoPi);

                float distance = (float)Math.Sqrt(Main.rand.NextFloat()) * radius;

                Vector2 spawnPosition = position + new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * distance;
                Dust dust = Dust.NewDustDirect(spawnPosition, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 3f);
				    dust.noGravity = true;
				    dust.velocity *= 5f;
				    dust = Dust.NewDustDirect(spawnPosition, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 2f);
				    dust.velocity *= 3f;

            }

            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);

            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC npc = Main.npc[i];

                if (!npc.active || npc.dontTakeDamage)
                    continue;

                float distance = Vector2.Distance(position, npc.Center);
                if (distance <= radius)
                {
                    int finalDamage = Projectile.damage;
                    if (distance > radius * 0.3f) 
                        finalDamage = (int)(Projectile.damage * (1-distance/radius));

                    NPC.HitInfo hitInfo = new NPC.HitInfo()
                    {
                        Damage = finalDamage,
                        Knockback = knockBack
                    };

                    bool direction = (npc.Center.X > position.X);

                // Apply the damage using the HitInfo object
                npc.StrikeNPC(hitInfo, direction);

                
                }
        }
    }

}}
