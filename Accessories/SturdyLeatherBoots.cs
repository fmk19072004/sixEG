using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;


namespace sixEG.Content.Items.Accessories
{
    public class SturdyLeatherBoots : ModItem
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
            player.moveSpeed += .02f; //base is 1 so this adds 2% of base
            player.statDefense += 1;
            player.GetModPlayer<Content.Players.KnockbackResistPlayer>().knockbackReduction += 0.2f;
        }

        public override void AddRecipes() 
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Accessories.ToughLeatherBoots>(), 1);
            recipe.AddIngredient(ItemID.Shackle, 1);
            recipe.Register();
        }
    }
}
