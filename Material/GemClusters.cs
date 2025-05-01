using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace sixEG.Content.Items.Material
{
public class AmethystCluster: ModItem
	{
		public override void SetStaticDefaults() {

			Item.ResearchUnlockCount = 25;
		}

		public override void SetDefaults() {
			Item.width = 40; 
			Item.height = 40; 
			Item.maxStack = 9999;

			Item.value = Item.buyPrice(silver: 216); 
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.LargeAmethyst, 3);
			recipe.AddIngredient(ItemID.Amethyst, 3);
			recipe.AddIngredient(ItemID.CrystalShard, 1);

			recipe.Register();
        }

    }

public class RubyCluster: ModItem
	{
		public override void SetStaticDefaults() {

			Item.ResearchUnlockCount = 25;
		}

		public override void SetDefaults() {
			Item.width = 40; 
			Item.height = 40; 
			Item.maxStack = 9999;

			Item.value = Item.buyPrice(gold: 10, silver: 12); 
		}

		public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.LargeRuby, 3);
			recipe.AddIngredient(ItemID.Ruby, 3);
			recipe.AddIngredient(ItemID.CrystalShard, 1);

			recipe.Register();
        }

    }

public class EmeraldCluster: ModItem
	{
		public override void SetStaticDefaults() {

			Item.ResearchUnlockCount = 25;
		}

		public override void SetDefaults() {
			Item.width = 40; 
			Item.height = 40; 
			Item.maxStack = 9999;

			Item.value = Item.buyPrice(gold: 7, silver: 72); 
		}

		public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.LargeEmerald, 3);
			recipe.AddIngredient(ItemID.Emerald, 3);
			recipe.AddIngredient(ItemID.CrystalShard, 1);

			recipe.Register();
        }

    }

	public class SapphireCluster: ModItem
	{
		public override void SetStaticDefaults() {

			Item.ResearchUnlockCount = 25;
		}

		public override void SetDefaults() {
			Item.width = 40; 
			Item.height = 40; 
			Item.maxStack = 9999;

			Item.value = Item.buyPrice(gold: 5, silver: 95); 
		}

		public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.LargeSapphire, 3);
			recipe.AddIngredient(ItemID.Sapphire, 3);
			recipe.AddIngredient(ItemID.CrystalShard, 1);

			recipe.Register();
        }

    }

	public class DiamondCluster: ModItem
	{
		public override void SetStaticDefaults() {

			Item.ResearchUnlockCount = 25;
		}

		public override void SetDefaults() {
			Item.width = 40; 
			Item.height = 40; 
			Item.maxStack = 9999;

			Item.value = Item.buyPrice(gold: 15, silver: 70); 
		}

		public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.LargeDiamond, 3);
			recipe.AddIngredient(ItemID.Diamond, 3);
			recipe.AddIngredient(ItemID.CrystalShard, 1);

			recipe.Register();
        }

    }

	public class AmberCluster: ModItem
	{
		public override void SetStaticDefaults() {

			Item.ResearchUnlockCount = 25;
		}

		public override void SetDefaults() {
			Item.width = 40; 
			Item.height = 40; 
			Item.maxStack = 9999;

			Item.value = Item.buyPrice(gold: 15, silver: 70); 
		}

		public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.LargeAmber, 3);
			recipe.AddIngredient(ItemID.Amber, 3);
			recipe.AddIngredient(ItemID.CrystalShard, 1);

			recipe.Register();
        }

    }

	public class TopazCluster: ModItem
	{
		public override void SetStaticDefaults() {

			Item.ResearchUnlockCount = 25;
		}

		public override void SetDefaults() {
			Item.width = 40; 
			Item.height = 40; 
			Item.maxStack = 9999;

			Item.value = Item.buyPrice(gold: 4, silver: 7); 
		}

		public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.LargeDiamond, 3);
			recipe.AddIngredient(ItemID.Diamond, 3);
			recipe.AddIngredient(ItemID.CrystalShard, 1);

			recipe.Register();
        }

    }
}