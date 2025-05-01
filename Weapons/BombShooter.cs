using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using sixEG.Content.Projectiles;

namespace sixEG.Content.Items.Weapons
{ 

	public class BombShooter : ModItem
	{
		public override void SetDefaults()
		{
			//Item.damage = 0; //not needed since it will shoot: Bomb
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 34;
			Item.useTime = 50;
			Item.useAnimation = 50;
			Item.useStyle = ItemUseStyleID.Shoot;
			// Item.knockBack = 6; //not needed since it will shoot: Bomb
			Item.value = Item.buyPrice(gold: 1, silver: 3);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
	
			Item.shoot = ProjectileID.Bomb;
        	Item.shootSpeed = 15f; 
        	Item.noMelee = true; 
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup(RecipeGroupID.IronBar, 18);
			recipe.AddIngredient(ItemID.MeteoriteBar, 3);
			recipe.AddTile(ModContent.TileType<Tiles.CraftingStationTile>());
			recipe.Register();
		}
	}
}
