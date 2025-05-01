using System;
using sixEG.Content.Buffs;
using sixEG.Content.Items.Material;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace sixEG.Content.Items.Consumables
{
    public class CookedMeat : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.maxStack = 9999;
            Item.value = Item.buyPrice(0, 0, 0, 15);
            Item.rare = ItemRarityID.White;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.consumable = true;
        }

        public override void SetStaticDefaults() {

			Item.ResearchUnlockCount = 100;
		}

        public override bool? UseItem(Player player)
        {
            player.AddBuff(BuffID.WellFed, 4 * 3600); 
            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<RawMeat>(), 1);
            recipe.AddTile(TileID.CookingPots);
            recipe.Register();
        }
    }
}
