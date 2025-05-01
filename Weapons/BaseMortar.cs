using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using sixEG.Content.Projectiles;

namespace sixEG.Content.Items.Weapons
{ 

	public class BaseMortar : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 35;  
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 60;
			Item.useAnimation = 60;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(silver: 12);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;

			Item.shoot = ModContent.ProjectileType<Projectiles.MortarProjectileBasic>(); 
        	Item.shootSpeed = 15f; 
        	Item.noMelee = true; 
		}


		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup(RecipeGroupID.IronBar, 14);
			recipe.AddIngredient(ItemID.Bomb, 1);
			recipe.AddTile(ModContent.TileType<Tiles.CraftingStationTile>());
			recipe.Register();
		}
	}
}
