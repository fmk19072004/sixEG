using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;


namespace sixEG.Content.Items.Accessories
{
    public class EngineeredLeatherBoots : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 40; 
            Item.height = 40;
            Item.accessory = true; // flag item ass accessory
            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.Purple; 
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.moveSpeed += .05f;  //base is 1 so this adds 5% of base
            player.statDefense += 1;
            player.jumpSpeedBoost += 1.2f;
            player.GetModPlayer<Content.Players.KnockbackResistPlayer>().knockbackReduction += 0.25f;
        }

        public override void AddRecipes() 
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Accessories.RobustLeatherBoots>(), 1);
            recipe.AddIngredient(ModContent.ItemType<HippityHopBoots>(), 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}
