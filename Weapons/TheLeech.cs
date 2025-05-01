using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.DataStructures;
using System;
using Terraria.Audio;
using sixEG.Content.Projectiles;
using Terraria.GameContent.Biomes.CaveHouse;
using sixEG.Content.Items.Material;
using sixEG.Content.Items.Placeable;

namespace sixEG.Content.Items.Weapons
{ 

	public class TheLeech : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 35;
            Item.DamageType = DamageClass.Magic;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 45;
			Item.useAnimation = 45;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(silver: 12);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
            Item.mana = 35;

            Item.shoot = ModContent.ProjectileType<LeechProjectile>(); //not shot bc shoot returns false 
            Item.shootSpeed = 13f;
        	Item.noMelee = true; 
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int leechedHP = player.statLife - 1;

            int effectiveDamage = Item.damage + (int)(leechedHP * 1.6f);
            player.statLife = 1;

            Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<LeechProjectile>(), effectiveDamage, knockback, player.whoAmI);

            return false;
        }  

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Wood, 7);
			recipe.AddIngredient(ModContent.ItemType<Items.Material.PrismaticGemstone>(), 1);
			recipe.AddTile(ModContent.TileType<Tiles.CraftingStationTile>());

			recipe.Register();
		}


	}
}
