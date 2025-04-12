using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace sixEG.Content.NPCs
{
    public class PoisonMinion : ModNPC
    {
        public override void SetDefaults()
        {
            NPC.width = 32;
            NPC.height = 32;
            NPC.damage = 20;
            NPC.defense = 3;
            NPC.lifeMax = 50;
            NPC.value = 0f;
            NPC.knockBackResist = 0.5f;
            NPC.aiStyle = 14; // Flying AI
            NPC.noGravity = true;
        }

        public override void AI()
        {
            Player target = Main.player[NPC.target];

            if (!target.active || target.dead)
            {
                NPC.TargetClosest();
                target = Main.player[NPC.target];
                if (!target.active || target.dead)
                {
                    NPC.velocity.Y = 0.1f; //if there's no action to perform, perform: Gravity (yes + means down for some reason)
                    return;
                }
            }

            // Chase the player
            Vector2 direction = target.Center - NPC.Center;
            direction.Normalize();
            direction *= 4f; // Adjust speed

            NPC.velocity = (NPC.velocity * 9f + direction) / 10f;

            // Poisonous dust effect
            if (Main.rand.NextBool(3))
            {
                int dust = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Poisoned);
                Main.dust[dust].velocity *= 0.5f;
                Main.dust[dust].scale = 1.2f;
                Main.dust[dust].noGravity = true;
            }
        }

        public override void ModifyHitPlayer(Player target, ref Player.HurtModifiers modifiers)
        {
            target.AddBuff(BuffID.Poisoned, 180); // Poison for 3 seconds
        }
    }
}
