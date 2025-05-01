using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using sixEG.Content.Buffs;

namespace sixEG.Content.Buffs
{
	public class InstantRespawn : ModBuff
	{
        public override void Update(Player player, ref int buffIndex)
        {
            if (player.HasBuff(ModContent.BuffType<InstantRespawn>()) && player.buffTime[buffIndex] <= 10) //check if buff is less than 10 frames long, means we can't accidentally stack his shit to infinity
            {
                player.AddBuff(ModContent.BuffType<InstantRespawn>(), 10);  //reapply itself to never run out
            }
        }
	}
}
