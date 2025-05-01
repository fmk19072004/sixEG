using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework;
using sixEG.Content.Buffs;

namespace sixEG.Content.Players
{
    public class RespawnPlayer : ModPlayer
    {
        public bool instantRespawnCheatActive = false;

        public override void PostUpdateBuffs()
        {
            if (Player.HasBuff(ModContent.BuffType<InstantRespawn>()))
            {
                instantRespawnCheatActive = true;
            }
            else
            {
                instantRespawnCheatActive = false;
            }
        }

        public override void UpdateDead()
        {
            if (instantRespawnCheatActive)
            {
            Player.respawnTimer = 1;  
            }
        }

        public override void OnRespawn()
        {
            if (instantRespawnCheatActive)
            {
                Player.AddBuff(ModContent.BuffType<InstantRespawn>(), 10);
            }
        }
    }
}
