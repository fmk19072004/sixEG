using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Mono.Cecil;
using sixEG.Content.Projectiles;
using Microsoft.Xna.Framework.Graphics;
using sixEG.Content.Items.Summoners.TheTizard;
using System.Security.Cryptography.X509Certificates;



namespace sixEG.Content.Items.Summoners.TheTizard
{
	public class TheTizard : ModProjectile
	{
        private NPC FindClosestEnemy(float range)
        {
            Player player = Main.player[Projectile.owner];
            NPC closestEnemy = null;
            float closestDistance = range;

            for (int i = 0; i < 200; i++) // Loop through all NPCs
            {
                NPC npc = Main.npc[i];
                if (npc.active && !npc.friendly && npc.lifeMax > 0)  // Check if the NPC is active, hostile, and alive
                {
                    float distance = Vector2.Distance(player.Center, npc.Center);  // Calculate distance to NPC
                    if (distance < closestDistance)
                    {
                        closestEnemy = npc;
                        closestDistance = distance;
                    }
                }
            }

            return closestEnemy;
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.ignoreWater = false; 
            Projectile.tileCollide = false;

        }
		public override void SetStaticDefaults() {
            Projectile.penetrate = -1;
            Projectile.damage = 3;
            Projectile.ignoreWater = false; 
            Projectile.tileCollide = false;
		}

        

        /*public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
        } */

		public override void AI() {
            Player player = Main.player[Projectile.owner];
            float speed = 12f;

            Lighting.AddLight(Projectile.Center, 0.6f, 0f, 1f); // make lil bro glow 

            NPC target = FindClosestEnemy(550);


            if (target != null) {

                Vector2 direction = target.Center - Projectile.Center;
                float distance = direction.Length();
                direction.Normalize();

                if (distance>120) {
                    Projectile.velocity = direction*speed;  // move to target
                } else {
                    Projectile.velocity = -direction*0; //stop.
                }

                int turnCount = (int)Projectile.ai[0];

                int effectiveDamage = Projectile.damage + turnCount;


                Projectile.ai[1]++;  //this counts frames for attack timing
                if (Projectile.ai[1] > 25) {
                Projectile.NewProjectile(
                    Projectile.GetSource_FromThis(),
                    Projectile.Center,
                    direction * 35f,
                    ModContent.ProjectileType<ArcaneBlast>(),
                    effectiveDamage,
                    0,
                    player.whoAmI
                );
                Projectile.ai[1] = 0;
                }
            } else {
                Vector2 displacement = new Vector2 (55,-75);
                Vector2 idlePosition = player.Center + displacement;

                Vector2 idleDirection = idlePosition - Projectile.Center;
                float idleDistance = idleDirection.Length();
                idleDirection.Normalize();

                if (idleDistance > 9f) {
                    if (idleDistance > 96f) { // if tizard is over 96 pixels (6 tiles) away it should move fast
                        Projectile.velocity = idleDirection * speed;  //move to idle spot
                    } else {
                        Projectile.velocity = idleDirection * speed/2.5f; //move much slower if close
                    }
                } else {
                    Projectile.velocity = Vector2.Zero;  //or stop if too close
                }
            } 

			if (!player.dead && !player.HasBuff(ModContent.BuffType<TizardBuff>())) {
				Projectile.Kill();
			}
		}
	}
}
