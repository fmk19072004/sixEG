using Terraria;
using Terraria.ModLoader;

namespace sixEG.Content.Items.Summoners.TheTizard
{
	public class TizardBuff : ModBuff
	{
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
			Main.debuff[Type] = true;
        }

	}
}
