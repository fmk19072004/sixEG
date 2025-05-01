using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using sixEG;
using sixEG.Content.Projectiles;

namespace sixEG.Content.Items.Tools
{ 

	public class FungalPickaxe : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 8;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 4;
			Item.value = Item.buyPrice(silver: 32);
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;

            Item.pick = 60; //more than gold/plat but can not mine hellstone
		}


		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Items.Material.FungalWood>(), 8);
            recipe.AddIngredient(ModContent.ItemType<Items.Material.DefectDNASample>(), 2);
            recipe.AddRecipeGroup("Pre-Boss Pickaxe"); // item group containing up to gold and candy cane, all that are weaker than fungus
			recipe.AddTile(ModContent.TileType<Tiles.CraftingStationTile>());
			recipe.Register();
		}
	}
}
