using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TestMod.Content.Items.Weapons
{
    public class BigEvil : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.autoReuse = true;
            Item.damage = 50;
            Item.DamageType = DamageClass.Melee;
            Item.knockBack = 7;
            Item.crit = 10;
            Item.value = Item.buyPrice(gold: 1);
            Item.rare = ItemRarityID.Cyan;
            Item.UseSound = SoundID.Item1;
            
        }
        public override void AddRecipes()
        {
            Recipe dirt = CreateRecipe();
            dirt.AddIngredient(ItemID.DirtBlock, 1);
            dirt.Register();
        }


    }
}
