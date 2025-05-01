using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework;
using sixEG.Content.Buffs;

public class ArtilleryCommandPlayer : ModPlayer
{
    public int cooldownTime = 0;
    public int shotsFired = 0;
    public int reloadTimer = 60;

    public override void PostUpdate()
    {
        if (cooldownTime > 0)
            cooldownTime--;

        if (reloadTimer > 0)
            reloadTimer--;
        else if (shotsFired > 0)
        {
            shotsFired--;
            reloadTimer = 90;
        }
    }
}
