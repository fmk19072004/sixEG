using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace sixEG.Content.Buffs
{
	public class RapidHealingBuffWeak : ModBuff
	{
		public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
        }

		public override void Update(Player player, ref int buffIndex) {
            player.GetModPlayer<RapidHealingPlayer>().healingPower = 9;    
		}
	}

	public class RapidHealingBuffMedium : ModBuff
	{
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
        }

		public override void Update(Player player, ref int buffIndex) {
            player.GetModPlayer<RapidHealingPlayer>().healingPower = 17;    
		}
	}

	public class RapidHealingBuffStrong : ModBuff
	{
		public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
        }

		public override void Update(Player player, ref int buffIndex) {
            player.GetModPlayer<RapidHealingPlayer>().healingPower = 35;    
		}
	}
}
