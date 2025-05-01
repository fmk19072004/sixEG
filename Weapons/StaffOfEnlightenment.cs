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

	public class StaffOfEnlightenment : ModItem
	{
		// The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.sixEG.hjson' file.
		public override void SetDefaults()
		{
			Item.damage = 0;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 45;
			Item.useAnimation = 45;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(silver: 12);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;

            Item.shoot = ModContent.ProjectileType<GlowProjectile>();
        	Item.noMelee = true; 
		}

        public override bool? UseItem(Player player)
        {
            int numNewProjectiles = 24;
            for (int i = 0; i < numNewProjectiles; i++)
            {
                float angle = MathHelper.ToRadians(360f / numNewProjectiles * i);
                Vector2 spawnVelocity = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * 2f; 
                Projectile.NewProjectile(player.GetSource_FromThis(), player.position, spawnVelocity, ModContent.ProjectileType<GlowProjectile>(), 0, 1f);

				player.AddBuff(BuffID.Shine, 9000);
				player.AddBuff(BuffID.NightOwl, 9000);
            }
            return base.UseItem(player);
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
