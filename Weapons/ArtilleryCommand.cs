using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using Terraria.DataStructures;
using sixEG.Content.Players;

namespace sixEG.Content.Items.Weapons
{
    public class ArtilleryCommand : ModItem
    {

        int explosionRadius = 120;
        public override void SetDefaults()
        {
            Item.damage = 0;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 48;
            Item.height = 48;
            Item.useTime = 15; 
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.noMelee = true;
            Item.value = Item.buyPrice(0, 0, 20, 7);
            Item.rare = ItemRarityID.LightRed;
            Item.autoReuse = true;
        }

        public override bool CanUseItem(Player player)
        {
            var artilleryPlayer = player.GetModPlayer<ArtilleryCommandPlayer>();
            return artilleryPlayer.cooldownTime <= 0;
        }

        public override bool? UseItem(Player player)
        {
            var artilleryPlayer = player.GetModPlayer<ArtilleryCommandPlayer>();

            if (Main.myPlayer == player.whoAmI) {
                Vector2 mousePosition = Main.MouseWorld; 
                Projectile.NewProjectile(
                    player.GetSource_ItemUse(Item),
                    mousePosition,
                    Vector2.Zero,
                    ModContent.ProjectileType<Projectiles.InvisibleExplosionSource>(),
                    175, //damage
                    2f, //kb
                    player.whoAmI,
                    ai0: explosionRadius // passing through the radius
                );
            }            

            artilleryPlayer.shotsFired++; 

            if (artilleryPlayer.shotsFired >= 15)
            {
                artilleryPlayer.cooldownTime = 700; 
                artilleryPlayer.shotsFired = 0; 
            }

            return true; 
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.AddTile(ModContent.TileType<Tiles.CraftingStationTile>());
			recipe.Register();
		}
    }
}
