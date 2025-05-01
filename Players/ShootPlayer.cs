using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework;
using sixEG.Content.Buffs;
using Terraria.DataStructures;

namespace sixEG.Content.Players
{
    public class ShootPlayer : ModPlayer
    {
        public override bool Shoot(Item item, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            return base.Shoot(item, source, position, velocity, type, damage, knockback);
        }
    }
}