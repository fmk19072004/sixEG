using Microsoft.Build.Evaluation;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace TestMod.Content.Items.Weapons
{
    public class ModGlobalNPCSP : GlobalNPC
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }
        
        public override void SetDefaults(NPC entity)
        {
            base.SetDefaults(entity);
            Random rand = new Random();
            int rng = rand.Next(1, 15);
            if (entity.aiStyle == 2 || entity.aiStyle == 44)
            {
            entity.aiStyle = 1;
            }
            if(entity.aiStyle == 1 && rng == 1)
            {
                entity.aiStyle = 2;
            }
            
        }
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            base.ModifyNPCLoot(npc, npcLoot);
            npcLoot.Add(ItemDropRule.Common(ItemID.Salmon, 100));
        }




    }
}
