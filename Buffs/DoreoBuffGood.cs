using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace sixEG.Content.Buffs
{
	public class DoreoBuffGood : ModBuff
	{
		public const int BuffDuration = 70 * 60; //70 sekunden


		public override void Update(Player player, ref int buffIndex) {
			player.statDefense += 4; //grant a +4 defense boost to the player while the buff is active.
			player.statDefense *= 1.1f; //10% extra defence
			if (player.endurance < 0.4f) { 
				player.endurance = 0.4f;  // reduces all incoming damage by 40%
			} else {
				player.endurance += 0.15f; // if the endurance was already bigger than 40%, just add 15% extra
			}
			player.statMana += 5; //restore 5 mana points every frame, effective infinite mana
		}
	}
}
