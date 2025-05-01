using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using sixEG;
using sixEG.Content.Projectiles;

namespace sixEG.Content.Items.Tools
{ 

	public class LivingFungalPickaxe : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 12;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 4;
			Item.value = Item.buyPrice(silver: 44);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;

            Item.pick = 80; //more than brain/eater of worlds picks
		}


		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Items.Tools.FungalPickaxe>(), 1);
            recipe.AddIngredient(ItemID.TissueSample, 3);
			recipe.AddTile(ModContent.TileType<Tiles.CraftingStationTile>());
			recipe.Register();

			Recipe altrecipe = CreateRecipe();
			altrecipe.AddIngredient(ModContent.ItemType<Items.Material.FungalWood>(), 8);
            altrecipe.AddIngredient(ModContent.ItemType<Items.Material.DefectDNASample>(), 2);
            altrecipe.AddRecipeGroup("Pre-Boss Pickaxe"); // item group containing up to gold and candy cane, all that are weaker than fungus
            altrecipe.AddIngredient(ItemID.TissueSample, 3);
			altrecipe.AddTile(ModContent.TileType<Tiles.CraftingStationTile>());
			altrecipe.Register();
		}
	}
}
