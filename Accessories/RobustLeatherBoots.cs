using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;


namespace sixEG.Content.Items.Accessories
{
    public class RobustLeatherBoots : ModItem
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
            player.moveSpeed += .05f; //base is 1 so this adds 5% of base
            player.statDefense += 1;
            player.GetModPlayer<Content.Players.KnockbackResistPlayer>().knockbackReduction += 0.2f;
        }

        public override void AddRecipes() 
        {
            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ModContent.ItemType<Accessories.SturdyLeatherBoots>(), 1);
            recipe1.AddIngredient(ItemID.Aglet, 1);
            recipe1.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ModContent.ItemType<Accessories.AgileLeatherBoots>(), 1);
            recipe2.AddIngredient(ItemID.Shackle, 1);
            recipe2.Register();
        }
    }
}
