using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.UI;
using Terraria.GameContent.ItemDropRules;
using System;


namespace sixEG.Content.NPCs
{
    public class HoloFungusHologram : ModNPC  //the fungus but not
    {
        private int thresholdToDespawn = 700;

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 4; //The frames are plentiful on this one
        }

        public override void SetDefaults()
        {
            NPC.width = 240;
            NPC.height = 255;                  
            NPC.damage = 1;
            NPC.defense = 0;
            NPC.lifeMax = 9460;
            NPC.value = 0f;
            NPC.knockBackResist = 0f;
            NPC.aiStyle = -1; // Custom AI, no clue wtf the others even do
            NPC.boss = false;
            NPC.noGravity = false; 
            NPC.noTileCollide = false; // do not fall through world. Thanks: You.
            NPC.lavaImmune = true;
            Music = MusicID.Boss2;
        }

        public override void AI()
        {
            if (NPC.target >= 0 && NPC.target < Main.maxPlayers)
            {
                Player player = Main.player[NPC.target];

                // moven't
                if (NPC.ai[0] == 0)
                {
                    NPC.ai[0] = 1;

                    int tileX = (int)(NPC.position.X / 16); // Convert world X to tile X
                    int tileY = (int)(NPC.position.Y / 16); // Convert world Y to tile Y

    
                    while (tileY < Main.maxTilesY - 1 && !Main.tile[tileX, tileY].HasTile)
                    {
                        tileY++;
                    }

                    // Set boss position to be right above the solid tile idk if the code here is goofy or if the sprite is to bug but it still visually clips at least
                    NPC.position.Y = tileY * 16 - NPC.height;
                }

                //make pew pew at play play
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    NPC.ai[1]++;
                    if (NPC.ai[1] >= 90) //attck rate
                    {
                        Vector2 targetPosition = player.Center;
                        Vector2 direction = targetPosition - NPC.Center;
                        direction.Normalize();
                        direction *= 10f; //proj speed
                    
                        int numNewProjectiles = 32;
                        for (int i = 0; i < numNewProjectiles; i++)
                        {
                            float angle = MathHelper.ToRadians(360f / numNewProjectiles * i);
                            Vector2 spawnVelocity = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * 2f; 
                            //1d projectiles
                            Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, spawnVelocity, ModContent.ProjectileType<Projectiles.EnemyProjectiles.GlitchingLaser>(), 1, 1f);
                        }

                        NPC.ai[1] = 0; 
                    }


                    NPC.ai[2]++;
                    if (NPC.ai[2] >= 2400) //duration
                    {
                        NPC.active = false;
                    }
                
                    NPC.ai[3]++;
                    if (NPC.ai[3] >= 100)
                    {
                        Vector2 direction = player.Center - NPC.Center;
                        direction.Normalize();
                        Vector2 velocityVector = direction * 2f;
                        Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, velocityVector, ModContent.ProjectileType<Projectiles.EnemyProjectiles.EnergyBlast>(), (int)1, 1f);

                        NPC.ai[3] = 0;
                    }   
                }
            }else {
                NPC.TargetClosest();
            } 

            if (NPC.life < NPC.lifeMax - thresholdToDespawn)
            {
                NPC.active = false;
            }
        }



        //animation stiff
        private int frameCounter;

        public override void FindFrame(int frameHeight)
        {
            frameCounter++;
            if (frameCounter >= 10) //switch to next sprite in spritehseet every 10 frames (high level animation)
            {
                frameCounter = 0;
                NPC.frame.Y += frameHeight; //next sprite

                if (NPC.frame.Y >= Main.npcFrameCount[NPC.type] * frameHeight) //letzes erreicht, geh von vorne
                {
                    NPC.frame.Y = 0;
                }
            }
        }
    }
}