using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.UI;
using System;
using Terraria.GameContent.ItemDropRules;


namespace sixEG.Content.NPCs
{
    public class StragglerFungus : ModNPC
    
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 1; // No animation frames needed
        }

        public override void SetDefaults()
        {
            NPC.width = 240;
            NPC.height = 255;                  
            NPC.damage = 32;
            NPC.defense = 14;  // eoc is 12
            NPC.lifeMax = 3450;
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

            // Attack logic: Fire projectiles at the player
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                NPC.ai[1]++;
                if (NPC.ai[1] >= 30) //attck rate
                {
                    Vector2 targetPosition = player.Center;
                    Vector2 direction = targetPosition - NPC.Center;
                    direction.Normalize();
                    direction *= 10f; //proj speed

                    Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, direction, 
                        ProjectileID.Fireball, NPC.damage/4, 1f, Main.myPlayer); // we give damage/4 as arg so we get damage/2 as real damage -> 16d (eoc is 15)

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

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            //important items for progression
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.ProgressionItems.ProgressionDrops.EvilSpores>(), 1, 5, 5));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.ProgressionItems.ProgressionDrops.InfestedFlesh>(), 1));  
            //the for fun goodies
            npcLoot.Add(ItemDropRule.Common(ItemID.GoldCoin, 1, 3, 7)); //syntax here sucks so much, I think it's 1 (100% chance), 3(min), 7(max)
            npcLoot.Add(ItemDropRule.Common(ItemID.Mushroom, 1, 7, 15));
            npcLoot.Add(ItemDropRule.Common(ItemID.ViciousMushroom, 1, 5, 9));
        }
    }
}