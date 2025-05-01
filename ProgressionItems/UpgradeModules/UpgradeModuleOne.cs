using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace sixEG.Content.Items.ProgressionItems.UpgradeModules
{
public class UpgradeModuleOne : ModItem
	{
		public override void SetStaticDefaults() {

			Item.ResearchUnlockCount = 1;
		}

		public override void SetDefaults() {
			Item.width = 40; 
			Item.height = 40; 

			Item.maxStack = 25; 
			Item.value = Item.buyPrice(gold: 25); 
		}

        public override void AddRecipes()
        {
        	Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.IronBar, 6);
			// recipe.AddIngredient(ModContent.ItemType<Items.ProgressionItems.ProgressionDrops.MalfunctionedOrganism>(), 1);
			recipe.AddTile(ModContent.TileType<Tiles.CraftingStationTile>());
			recipe.Register();
        }

    }
}