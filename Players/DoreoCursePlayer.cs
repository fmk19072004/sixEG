using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework;
using sixEG.Content.Buffs;
using Terraria.DataStructures;
using Terraria.Localization;

public class DoreoCursePlayer : ModPlayer
{
    public int witherPower = 0;
    public int counter = 0;
    public override void ResetEffects()
    {
        witherPower = 0; // Reset each tick, buffs re-apply their value
    }

    public override void PostUpdate()
    {
        if (counter > 11)  //5 times per second (every 12th frame)
        {
            Player.statLife -= witherPower;
            counter = 0;

            if (Player.statLife <= 0) {
                Player.KillMe(PlayerDeathReason.ByCustomReason(NetworkText.FromLiteral($"{Player.name} was killed by a bad Doreo")), 1, 0);
            }
        } else {
            counter++;
        }
    }
}
