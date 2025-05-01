using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace sixEG.Content.Items.Material
{
public class DefectDNASample: ModItem
	{
		public override void SetStaticDefaults() {

			Item.ResearchUnlockCount = 10;
		}

		public override void SetDefaults() {
			Item.width = 40; 
			Item.height = 40; 
			Item.maxStack = 9999;

			Item.value = Item.buyPrice(copper: 20); 
		}

        public override void AddRecipes()
        {
                Recipe recipe = CreateRecipe(5); //make 5 per craft
                recipe.AddIngredient(ModContent.ItemType<Items.ProgressionItems.ProgressionDrops.InfestedFlesh>());
                recipe.AddTile(ModContent.TileType<Tiles.ResearchStationTile>());
                recipe.Register();

				Recipe recipe1 = CreateRecipe();
				recipe1.AddIngredient(ModContent.ItemType<ParasiteFungus>(), 1);
				recipe1.AddTile(ModContent.TileType<Tiles.ResearchStationTile>());
				recipe1.Register();

        }

    }
}