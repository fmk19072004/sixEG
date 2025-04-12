using Microsoft.Build.Evaluation;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TestMod.Content.Items.Weapons
{
    public class TruestestExcalibur : ModItem
    {
        public override void SetDefaults()
        {

            Item.damage = 250;
            Item.DamageType = DamageClass.Melee;
            Item.width = 200;
            Item.height = 200;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.noUseGraphic = false;
            Item.useStyle = 1;
            Item.knockBack = 60;
            Item.value = 10;
            Item.rare = 8;
            Item.shootSpeed = 14f;
            Item.shoot = ModContent.ProjectileType<Content.Items.Weapons.TruestestExcaliburProj>();
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;

        }
        
        public override void AddRecipes()
        {
            Recipe TestSwordRecipe = CreateRecipe();
            TestSwordRecipe.AddIngredient(ModContent.ItemType<TruesterExcalibur>(), 1);
            TestSwordRecipe.AddIngredient(ItemID.ChlorophyteBar, 5);
            TestSwordRecipe.Register();
            Recipe R2 = CreateRecipe();
            R2.AddIngredient(ModContent.ItemType<TruesterExcalibur>(), 1);
            R2.AddIngredient(ItemID.BrokenHeroSword, 1);
            R2.Register();
            Recipe dirt = CreateRecipe();
            dirt.AddIngredient(ModContent.ItemType<TruesterExcalibur>(), 1);
            dirt.Register();
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[Item.shoot] < 15;
        }

    }
}
