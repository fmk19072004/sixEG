using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using sixEG.Content.Buffs;

namespace sixEG.Content.Items.Accessories
{
    public class ArcaneMastery : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 40; 
            Item.height = 40;
            Item.accessory = true; // flag item ass accessory
            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.Lime; 
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.manaFlower = true;
            player.manaCost *= 0.9f;
            player.GetDamage(DamageClass.Magic) += 0.17f;
            player.statManaMax2 += 50;
        }

        public override void AddRecipes() 
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<TomeOfAmplification>(), 1);
            recipe.AddIngredient(ModContent.ItemType<ArcaneCatalyst>(), 1);
            recipe.AddIngredient(ItemID.BandofStarpower, 1);
            recipe.AddIngredient(ItemID.ManaFlower, 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}
