using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace sixEG.Content.Buffs
{
	public class DoreoBuffBad : ModBuff
	{
		public const int BuffDuration = 35 * 60; //35 sekunden

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            Main.debuff[Type] = true;
        }

		public override void Update(Player player, ref int buffIndex) {
            player.wingTime = 0; //disables wings for duration  
            player.lifeRegen = 0;
            player.lifeRegenTime = 0;

            player.GetModPlayer<DoreoCursePlayer>().witherPower = 1;
		}
	}
}
