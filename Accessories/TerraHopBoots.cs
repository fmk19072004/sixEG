using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;


namespace sixEG.Content.Items.Accessories
{
    public class TerraHopBoots : ModItem
    {
        public override void SetDefaults()
        {   
            Item.CloneDefaults(ItemID.TerrasparkBoots);
            Item.width = 40; 
            Item.height = 40;
            Item.accessory = true; // flag item ass accessory
            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.Purple; 
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //Terraspark section
            player.rocketBoots = 3;
            player.moveSpeed += 0.08f;
            player.accRunSpeed = 6.75f;
            player.iceSkate = true;
            player.lavaMax += 720;
            player.waterWalk = player.fireWalk = true;

            // the others
            player.moveSpeed += .04f;  //totals at +.12, with base being 1 this is 12%
            player.statDefense += 1;
            player.jumpSpeedBoost += 1.2f;
            player.GetModPlayer<Content.Players.KnockbackResistPlayer>().knockbackReduction += 0.35f;
        }

        public override void AddRecipes() 
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Accessories.EngineeredLeatherBoots>(), 1);
            recipe.AddIngredient(ItemID.TerrasparkBoots, 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}
