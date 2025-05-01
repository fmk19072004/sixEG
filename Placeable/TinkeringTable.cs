using sixEG.Content.Items.Material;
using sixEG.Content.Items.ProgressionItems.ProgressionDrops;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace sixEG.Content.Items.Placeable
{
    public class TinkeringTable : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.maxStack = 99;
            Item.value = Item.buyPrice(gold: 1);
            Item.rare = ItemRarityID.Green;
            
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 10;
            Item.useAnimation = 15;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.consumable = true;

            Item.createTile = ModContent.TileType<Tiles.TinkeringTableTile>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

                recipe.AddRecipeGroup(RecipeGroupID.IronBar, 27);
                recipe.AddIngredient(ModContent.ItemType<DefectDNASample>(), 3);
                recipe.AddIngredient(ModContent.ItemType<GlitchingProcessor>(), 1);
                recipe.AddTile(ModContent.TileType<Tiles.ResearchStationTile>()); 
                recipe.Register();
        }
    }
}
