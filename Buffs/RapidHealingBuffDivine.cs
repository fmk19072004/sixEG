using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace sixEG.Content.Buffs
{
	public class RapidHealingBuffDivine : ModBuff
	{
		public override void Update(Player player, ref int buffIndex) {
            player.GetModPlayer<RapidHealingPlayer>().healingPower = 50;
            player.GetModPlayer<RapidHealingPlayer>().isBuffDivine = true;    
		}
	}

}
