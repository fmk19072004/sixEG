using Microsoft.Build.Evaluation;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TestMod.Content.Items.Weapons
{
    public class GreenDoug : ModItem
    {
        public override void SetDefaults()
        {
            
            Item.damage = 30;
            Item.DamageType = DamageClass.Magic;
            Item.width = 30;
            Item.height = 30;            
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.noUseGraphic = true;
            Item.useStyle = 1;
            Item.knockBack = 3;
            Item.value = 8;
            Item.rare = 6;
            Item.shootSpeed = 12f;
            Item.shoot = ModContent.ProjectileType<Content.Items.Weapons.GreenDougProj>();
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            
        }
        public override void AddRecipes()
        {
            Recipe TestSwordRecipe = CreateRecipe();
            TestSwordRecipe.AddIngredient(ItemID.ShadowScale, 10);
            TestSwordRecipe.Register();
            Recipe TestSwordRecipe2 = CreateRecipe();
            TestSwordRecipe2.AddIngredient(ItemID.TissueSample, 10);
            TestSwordRecipe2.Register();
            Recipe dirt = CreateRecipe();
            dirt.AddIngredient(ItemID.DirtBlock, 1);
            dirt.Register();
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[Item.shoot] < 2;
        }

    }
}
