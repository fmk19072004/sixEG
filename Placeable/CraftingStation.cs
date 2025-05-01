using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using sixEG.Content.Items.ProgressionItems.ProgressionDrops;

namespace sixEG.Content.Items.Placeable
{
    public class CraftingStation : ModItem
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

            Item.createTile = ModContent.TileType<Tiles.CraftingStationTile>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

                recipe.AddIngredient(ItemID.Wood, 12);
                recipe.AddRecipeGroup(RecipeGroupID.IronBar, 2);
                recipe.AddIngredient(ModContent.ItemType<EvilSpores>(), 1);
                recipe.AddTile(TileID.Solidifier);  // make the research station obtained from the solidifer to lock it behind slime king
                recipe.Register();
        }
    }
}
