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
    public class ClusterBombChild : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 21; 
            Projectile.height = 27;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged; 
            Projectile.aiStyle = 1;  
            Projectile.penetrate = 1;
            Projectile.timeLeft = 40; 
            Projectile.light = 0.5f; 
            Projectile.ignoreWater = true; 
            Projectile.tileCollide = true; 
            Projectile.scale = 0.6f;

            Projectile.damage = 15;
        }

        
        public override void AI()
        {
            Projectile.velocity.Y += 0.09f;
        }

        public override void OnKill(int timeLeft)
        {
            Explosion(Projectile.position, 40f, Projectile.damage, 20, 1, 2);
        }

        public void Explosion(Vector2 position, float radius, int damage, int knockBack, int type, int owner)
        {

            for (int i = 0; i < 10; i++) 
            {
                float angle = Main.rand.NextFloat(0f, MathHelper.TwoPi);

                float distance = (float)Math.Sqrt(Main.rand.NextFloat()) * radius;

                Vector2 spawnPosition = position + new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * distance;
                Dust dust = Dust.NewDustDirect(spawnPosition, Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, default, 3f);
				    dust.noGravity = true;
				    dust.velocity *= 5f;
				    dust = Dust.NewDustDirect(spawnPosition, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 2f);
				    dust.velocity *= 3f;

            }

            //SoundEngine.PlaySound(SoundID.Item14, Projectile.position);

            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC npc = Main.npc[i];

                if (!npc.active || npc.dontTakeDamage)
                    continue;


                float distanceToNpc = Vector2.Distance(npc.Center, position);
                if (distanceToNpc <= radius)
                {
                    NPC.HitInfo hitInfo = new NPC.HitInfo()
                    {
                        Damage = 15,
                        Knockback = knockBack
                    };

                    bool direction = (npc.Center.X > position.X);

                // Apply the damage using the HitInfo object
                npc.StrikeNPC(hitInfo, direction);

                
                }
        }
    }

}
}
