using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace sixEG.Content.Players
{
    public class KnockbackResistPlayer : ModPlayer
    {
        public float knockbackReduction = 0f;

        public override void ResetEffects()
        {
            knockbackReduction = 0f; 
        }

        public override void ModifyHurt(ref Player.HurtModifiers modifiers)
        {
            modifiers.Knockback *= 1f - knockbackReduction;
        }
    }
}