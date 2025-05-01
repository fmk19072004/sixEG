using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.DataStructures;
using System;
using Terraria.Audio;
using sixEG.Content.Projectiles;

namespace sixEG.Content.Projectiles
{
    public class RecursiveClusterBombParent : ModProjectile
    {
        private int shotCycle = 0;
        public override void SetDefaults()
        {
            Projectile.width = 21;
            Projectile.height = 27;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged; 
            Projectile.penetrate = 1; 
            Projectile.timeLeft = 100; 
            Projectile.tileCollide = true; 
            Projectile.ignoreWater = true; 
            Projectile.scale = 1.2f;

            //Projectile.damage = 21;
        }

        public override void AI()
        {
            Projectile.velocity.Y += 0.09f;
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            modifiers.FinalDamage.Base = 0; //no impact damage, only explosion can deal damage
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Explode(); 
        }

        public override void OnKill(int timeLeft)
        {
            Explode();
        }

        private void Explode()
        {
            Vector2 position = Projectile.Center;
            int explosionRadius = 75; 

            SoundEngine.PlaySound(SoundID.Item14, position);

            // Create explosion visual effects
            for (int i = 0; i < 50; i++)
            {
                Vector2 dustPos = position + Main.rand.NextVector2Circular(explosionRadius, explosionRadius);
                Dust dust = Dust.NewDustDirect(dustPos, 10, 10, DustID.Smoke, 0, 0, 100, default, 1f);
                dust.velocity *= 2;
                dust.noGravity = true;
            }

            // Damage nearby NPCs
            foreach (NPC npc in Main.npc)
            {
                if (npc.active && !npc.friendly)
                {
                    float distance = Vector2.Distance(npc.Center, position);
                    if (distance < explosionRadius)
                    {
                        float damageMultiplier = 1f - (distance / explosionRadius);
                        int finalDamage = (int)(Projectile.damage * damageMultiplier);

                        NPC.HitInfo hitInfo = new NPC.HitInfo()
                        {
                            Damage = finalDamage,
                            Knockback = 2f
                        };

                        bool direction = (npc.Center.X > position.X);
                        npc.StrikeNPC(hitInfo, direction);
                    }
                }
            }

            // Summon new projectiles from explosion

            
                int childrenCount = 4;
                for (int i = 0; i < childrenCount; i++)
                {
                    float angle = MathHelper.ToRadians(360f / childrenCount * i);
                    Vector2 spawnVelocity = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * 5f; 
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, spawnVelocity, ModContent.ProjectileType<ClusterBombParent>(), Projectile.damage, 1f, Projectile.owner);
                }
            }
            

            //Projectile.Kill(); this crashes the game whe projectilehits smth or xpires 
        }
    }
