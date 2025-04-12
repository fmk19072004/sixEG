using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.UI;
using Terraria.GameContent.ItemDropRules;

namespace sixEG.Content.NPCs
{
    public class HoloFungus : ModNPC  //the fungus but not
    {

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 3; //The frames are plentiful on this one
        }

        public override void SetDefaults()
        {
            NPC.width = 240;
            NPC.height = 255;                  
            NPC.damage = 110;
            NPC.defense = 19;
            NPC.lifeMax = 10260;
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
                if (NPC.ai[1] >= 20) //attck rate
                {
                    Vector2 targetPosition = player.Center;
                    Vector2 direction = targetPosition - NPC.Center;
                    direction.Normalize();
                    direction *= 10f; //proj speed

                    Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, direction, 
                        ProjectileID.Fireball, 30, 2f, Main.myPlayer);

                    NPC.ai[1] = 0; 
                }

                NPC.ai[2]++;
                if (NPC.ai[2] >= 180)
                {
                    int spawnX = (int)NPC.position.X + Main.rand.Next(-50, 50);
                    int spawnY = (int)NPC.position.Y + 50; 

                    int minionID = NPC.NewNPC(NPC.GetSource_FromAI(), spawnX, spawnY, ModContent.NPCType<PoisonMinion>());  //summon the several

                    Main.npc[minionID].target = NPC.target; //apparently this is how to target the player
                    Main.npc[minionID].velocity = new Vector2(Main.rand.NextFloat(-2f, 2f), -3f); //jump towards the player

                    NPC.ai[2] = 0;  // do not the forget this.
                }
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

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.ProgressionItems.MalfunctionedOrganism>(), 1)); //important item
            //the for fun goodies will come

        }
    }
}