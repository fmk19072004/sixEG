using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using sixEG.Content.Projectiles;

namespace sixEG.Content.Items.Weapons
{ 

	public class BaseMortar : ModItem
	{
		// The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.sixEG.hjson' file.
		public override void SetDefaults()
		{
			Item.damage = 35;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 120;
			Item.useAnimation = 120;
			Item.useStyle = ItemUseStyleID.HoldUp;
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
			recipe.AddIngredient(ItemID.IronBar, 4);
			recipe.AddIngredient(ItemID.TinBar, 5);
			recipe.AddIngredient(ItemID.TungstenBar, 2);
			recipe.AddIngredient(ItemID.Bomb, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
