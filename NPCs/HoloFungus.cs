using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.UI;
using Terraria.GameContent.ItemDropRules;
using System;
using sixEG.Content.Projectiles.EnemyProjectiles;

namespace sixEG.Content.NPCs
{
    public class HoloFungus : ModNPC  //the fungus but not
    {
        private bool secondPhaseTriggered = false;

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 3; //The frames are plentiful on this one
        }

        public override void SetDefaults()
        {
            NPC.width = 240;
            NPC.height = 255;                  
            NPC.damage = 110;
            NPC.defense = 16;
            NPC.lifeMax = 9460;
            NPC.value = 0f;
            NPC.knockBackResist = 0f;
            NPC.aiStyle = -1; // Custom AI, no clue wtf the others even do
            NPC.boss = true;
            NPC.noGravity = false; 
            NPC.noTileCollide = false; // do not fall through world. Thanks: You.
            NPC.lavaImmune = true;
            Music = MusicID.Boss2;
        }

        public override void AI()
        {
            NPC.TargetClosest();
            //keep track of phase
            if (!secondPhaseTriggered && NPC.life < NPC.lifeMax/2)
            {
                secondPhaseTriggered = true;  

                //surge of attacks immediately upon phase 2
                HolographyAttack(); 
                NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.position.X + 50, (int)NPC.position.Y + 90, ModContent.NPCType<HoloMinion>());
                NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.position.X - 50, (int)NPC.position.Y + 90, ModContent.NPCType<HoloMinion>());               
            }

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
                    
                        int numNewProjectiles = 36;
                        for (int i = 0; i < numNewProjectiles; i++)
                        {
                            float angle = MathHelper.ToRadians(360f / numNewProjectiles * i);
                            Vector2 spawnVelocity = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * 2f; 
                            //below is the projectile creation, typecasting will round down to 27
                            Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, spawnVelocity, ModContent.ProjectileType<Projectiles.EnemyProjectiles.GlitchingLaser>(), (int)NPC.damage/4, 1f);
                        }

                        NPC.ai[1] = 0; 
                    }

                    NPC.ai[2]++;
                    if (NPC.ai[2] >= 180)
                    {   
                        int spawnX = (int)NPC.position.X + Main.rand.Next(-50, 50);
                        int spawnY = (int)NPC.position.Y + 50; 

                        int minionID = NPC.NewNPC(NPC.GetSource_FromAI(), spawnX, spawnY, ModContent.NPCType<HoloMinion>());  //summon the several

                        Main.npc[minionID].target = NPC.target; //apparently this is how to target the player
                        Main.npc[minionID].velocity = new Vector2(Main.rand.NextFloat(-2f, 2f), -3f); //jump towards the player

                        NPC.ai[2] = 0;  // do not the forget this.
                    }

                    NPC.ai[3]++;
                    if (NPC.ai[3]%100 == 0 && secondPhaseTriggered)
                    {
                        Vector2 direction = player.Center - NPC.Center;
                        direction.Normalize();
                        Vector2 velocityVector = direction * 2f;
                        Projectile.NewProjectile(NPC.GetSource_FromAI(), player.Center, velocityVector, ModContent.ProjectileType<EnergyBlast>(), (int)NPC.damage/3, 1f);
                    }
                    if (NPC.ai[3] >= 3000 && NPC.life < NPC.lifeMax/2) // when below half we start 
                    {
                        HolographyAttack();
                    
                        NPC.ai[3] = 0;
                    }
                }
            } else {
                NPC.TargetClosest();
            }
        }

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

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.ProgressionItems.ProgressionDrops.GlitchingProcessor>(), 1)); //important item
            //the for fun goodies will come

        }

        //helpers
        int hologramCount = 4; //keep in mind that one extra hologram is created in initial position, so this makes a total of 5 holograms + 1 main boss
        int spread = 650; 
        private void HolographyAttack()
        {
            Vector2 originalPosition = NPC.Center;
            //move
            Vector2 newBossPosition = originalPosition + new Vector2(Main.rand.NextFloat(-400, 400), Main.rand.NextFloat(-400, 400));
            NPC.Center = newBossPosition;
            NPC.netUpdate = true;

            //make hologram in old position
            NPC.NewNPC(NPC.GetSource_FromAI(), (int)originalPosition.X, (int)originalPosition.Y, ModContent.NPCType<HoloFungusHologram>());

            //make more holograms for extra spice
            for (int i = 0; i < hologramCount; i++)
            {
                Vector2 spawnPos = originalPosition + new Vector2(Main.rand.NextFloat(-spread, spread), Main.rand.NextFloat(-spread, spread));
                bool projSpawned = false;
                while(!projSpawned)  // the following is just to not make them stuck inside the center fungus and the actual one at least
                {
                if ((spawnPos-originalPosition).Length() >= 222 && Math.Abs((spawnPos-newBossPosition).Length()) >= 185) {
                    NPC.NewNPC(NPC.GetSource_FromAI(), (int)spawnPos.X, (int)spawnPos.Y, ModContent.NPCType<HoloFungusHologram>());
                    projSpawned = true;
                } else {
                    spawnPos = originalPosition + new Vector2(Main.rand.NextFloat(-spread, spread), Main.rand.NextFloat(-spread, spread));
                }
                }
                
            }
        }
    }
}