using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using sixEG.Content.Buffs;

namespace sixEG.Content.Items.Accessories
{
    public class ArcaneCatalyst : ModItem
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
            player.GetDamage(DamageClass.Magic) += 0.10f;
            player.statManaMax2 += 20;
        }

        public override void AddRecipes() 
        {
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup("Any gem cluster");
            recipe.AddIngredient(ItemID.ArcaneCrystal, 1);
            recipe.AddIngredient(ItemID.UnicornHorn, 7);
            recipe.AddTile(TileID.TinkerersWorkbench);
            if (ModLoader.TryGetMod("SevenEG", out Mod jackMod) && jackMod.TryFind<ModItem>("WildShard", out ModItem wildshard))
            {
                recipe.AddIngredient(wildshard, 2);
                recipe.Register();
            }
        }
    }
}
