using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using sixEG.Content.Projectiles;


namespace sixEG.Content.Items.Weapons
{ 

	public class ClusterBombShooter : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 19;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(silver: 35);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;

			Item.shoot = ModContent.ProjectileType<ClusterBombParent>();
        	Item.shootSpeed = 15f; 
        	Item.noMelee = true; 
		}


		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.IronBar, 6);
			recipe.AddIngredient(ItemID.TungstenBar, 4);
			recipe.AddTile(TileID.Anvils);
			recipe.AddTile(ModContent.TileType<Tiles.CraftingStationTile>());
			recipe.Register();
		}
	}
}
