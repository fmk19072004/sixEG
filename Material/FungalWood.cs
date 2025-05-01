using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace sixEG.Content.Items.Material
{
public class FungalWood: ModItem
	{
		public override void SetStaticDefaults() {

			Item.ResearchUnlockCount = 100;
		}

		public override void SetDefaults() {
			Item.width = 40; 
			Item.height = 40; 
			Item.maxStack = 9999;

			Item.value = Item.buyPrice(copper: 5); 
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(10);
            recipe.AddIngredient(ItemID.Wood, 10);
            recipe.AddIngredient(ModContent.ItemType<Items.ProgressionItems.ProgressionDrops.EvilSpores>(), 1);
            recipe.AddTile(ModContent.TileType<Tiles.CraftingStationTile>());

            recipe.Register();
        }

    }
}