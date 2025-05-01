using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using sixEG.Content.Buffs;

namespace sixEG.Content.Buffs
{
	public class PerfectMirror : ModBuff
	{
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
        }
	}
}
