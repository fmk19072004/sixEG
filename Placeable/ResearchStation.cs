using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace sixEG.Content.Items.Placeable
{
    public class ResearchStation : ModItem
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

            Item.createTile = ModContent.TileType<Tiles.ResearchStationTile>();
        }

        public override void AddRecipes()
        {
            Recipe recipe1 = CreateRecipe();

                recipe1.AddIngredient(ItemID.Wood, 12);
                recipe1.AddRecipeGroup(RecipeGroupID.IronBar, 3);
                recipe1.AddIngredient(ModContent.ItemType<ProgressionItems.ProgressionDrops.InfestedFlesh>(), 1);
                recipe1.AddTile(TileID.Solidifier);  // make the research station obtained from the solidifer to lock it behind slime king
                recipe1.Register();
            
            Recipe recipe2 = CreateRecipe();

                recipe2.AddIngredient(ItemID.Wood, 12);
                recipe2.AddRecipeGroup(RecipeGroupID.IronBar, 3);
                recipe1.AddIngredient(ModContent.ItemType<ProgressionItems.ProgressionDrops.InfestedFlesh>(), 1);
                recipe2.AddTile(ModContent.TileType<Tiles.CraftingStationTile>());  //crafting station is locked behind solidifier anyways
                recipe2.Register();
        }
    }
}
