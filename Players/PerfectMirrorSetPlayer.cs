using Terraria.ModLoader;

namespace sixEG.Players
{
    public class PerfectMirrorSetPlayer : ModPlayer
    {
        public bool hasSetBonus = false; // self explanatory.

        public override void ResetEffects()
        {
            // importante. Reset the shit all the time so that when accessories are changed the buff is not retained
            hasSetBonus = false;
        }

        public override void PostUpdate()
        {
            if (hasSetBonus) {
                Player.AddBuff(ModContent.BuffType<Content.Buffs.PerfectMirror>(), 2);
            }
            
        }
    }
}
