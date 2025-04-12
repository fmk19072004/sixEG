using Microsoft.Build.Evaluation;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TestMod.Content.Items.Weapons
{
    public class TrueDoug : ModItem
    {
        public override void SetDefaults()
        {
            
            Item.damage = 100;
            Item.DamageType = DamageClass.Magic;
            Item.width = 30;
            Item.height = 30;            
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.noUseGraphic = true;
            Item.useStyle = 1;
            Item.knockBack = 5;
            Item.value = 10;
            Item.rare = 8;
            Item.shootSpeed = 12f;
            Item.shoot = ModContent.ProjectileType<Content.Items.Weapons.TrueDougProj>();
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            
        }
        public override void AddRecipes()
        {
            Recipe TestSwordRecipe = CreateRecipe();
            TestSwordRecipe.AddIngredient(ModContent.ItemType<GreenDoug>(), 1);
            TestSwordRecipe.AddIngredient(ItemID.LightDisc, 1);
            TestSwordRecipe.Register();
            Recipe dirt = CreateRecipe();
            dirt.AddIngredient(ItemID.DirtBlock, 1);
            dirt.Register();
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[Item.shoot] < 4;
        }

    }
}
