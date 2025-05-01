using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework;
using sixEG.Content.Buffs;

public class RapidHealingPlayer : ModPlayer
{
    public int healingPower = 0;
    public int counter = 0;
    public bool isBuffDivine = false;
    public override void ResetEffects()
    {
        healingPower = 0; // Reset each tick, buffs re-apply their value on update anyways
        isBuffDivine = false;
    }

    public override void PostUpdate()
    {
        if (counter > 11)  //5 times per second (every 12th frame)
        {
            Player.statLife += healingPower;
            if (healingPower >  0) {
                Player.HealEffect(healingPower);
            }

            counter = 0;
            if (isBuffDivine) 
            {
                Player.wingTime = Player.wingTimeMax;
            }
        } else {
            counter++;
        }
    }
}
