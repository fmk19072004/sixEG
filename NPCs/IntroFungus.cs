using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.UI;
using System;
using Terraria.GameContent.ItemDropRules;


namespace sixEG.Content.NPCs
{
    public class IntroFungus : ModNPC
    
    {

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 1; // No animation frames needed for now but maybe later
        }

        public override void SetDefaults()
        {
            NPC.width = 158;
            NPC.height = 160;                  
            NPC.damage = 18;
            NPC.defense = 2;
            NPC.lifeMax = 750;
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
                if (NPC.ai[1] >= 45) //attck rate
                {
                    Vector2 targetPosition = player.Center;
                    Vector2 direction = targetPosition - NPC.Center;
                    direction.Normalize();
                    direction *= 10f; //proj speed

                    Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, direction, ProjectileID.Fireball, 4, 1f, Main.myPlayer);

                    NPC.ai[1] = 0; 
                }

            }
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            //important items for fungus progression
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.ProgressionItems.ProgressionDrops.EvilSpores>(), 1, 1, 3)); 
            npcLoot.Add(ItemDropRule.OneFromOptions(1,
                ModContent.ItemType<Content.Items.Consumables.LootBags.IntroFungus.IntroFungusOreBag>(),
                ModContent.ItemType<Content.Items.Consumables.LootBags.IntroFungus.IntroFungusBotanicBag>(),
                ModContent.ItemType<Content.Items.Consumables.LootBags.IntroFungus.IntroFungusPotionBag>(),
                ModContent.ItemType<Content.Items.Consumables.LootBags.IntroFungus.IntroFungusSpecialBag>(),
                ModContent.ItemType<Content.Items.Consumables.LootBags.IntroFungus.IntroFungusFungalBag>()
                ));
            npcLoot.Add(ItemDropRule.Common(ItemID.Ruby, 1)); 
            //the for fun goodies
            npcLoot.Add(ItemDropRule.Common(ItemID.SilverCoin, 1, 120, 150));
            npcLoot.Add(ItemDropRule.Common(ItemID.ViciousMushroom, 2, 4, 6)); // one in 2 kills drops between 4 and 6 vicious mushrooms (helpful)
        }
    }
}