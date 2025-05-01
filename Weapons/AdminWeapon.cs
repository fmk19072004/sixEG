using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using Terraria.DataStructures;

namespace sixEG.Content.Items.Weapons
{
    public class AdminWeapon : ModItem
    {
        float explosionRadius = 360f;
        public override void SetDefaults()
        {
            Item.damage = 0;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 48;
            Item.height = 48;
            Item.useTime = 10; 
            Item.useAnimation = 10;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.noMelee = true;
            Item.value = Item.buyPrice(9999, 9999, 9999, 9999);
            Item.rare = ItemRarityID.LightRed;
            Item.autoReuse = true;
        }

        public override bool? UseItem(Player player)
        {
                if (Main.myPlayer == player.whoAmI) {
                Vector2 mousePosition = Main.MouseWorld; 
                Projectile.NewProjectile(
                    player.GetSource_ItemUse(Item),
                    mousePosition,
                    Vector2.Zero,
                    ModContent.ProjectileType<Projectiles.InvisibleExplosionSource>(),
                    175000, //damage
                    2f, //kb
                    player.whoAmI,
                    ai0: explosionRadius // passing through the radius
                );
            }   



            return true; 
        }
    }
}
