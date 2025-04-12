using Microsoft.Build.Evaluation;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TestMod.Content.Items.Weapons
{
    public class TruesterExcalibur : ModItem
    {
        public override void SetDefaults()
        {

            Item.CloneDefaults(ItemID.TrueExcalibur);
            Item.SetNameOverride("Truester Excalibur");
            Item.damage = 200;
            Item.noMelee = false;

        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {


            Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.EnchantedNightcrawler, 0, 0, 50);
            Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.EnchantedNightcrawler, 0, 0, 50);
            Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.AncientLight, 0, 0, 50);
            Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.CorruptGibs, 0, 0, 50);


        }
        public override void AddRecipes()
        {
            Recipe TestSwordRecipe = CreateRecipe();
            TestSwordRecipe.AddIngredient(ModContent.ItemType<TruestExcalibur>(), 1);
            TestSwordRecipe.AddIngredient(ItemID.ChlorophyteBar, 25);
            TestSwordRecipe.Register();
            Recipe R2 = CreateRecipe();
            R2.AddIngredient(ModContent.ItemType<TruestExcalibur>(), 1);
            R2.AddIngredient(ItemID.BrokenHeroSword, 2);
            R2.Register();
            Recipe dirt = CreateRecipe();
            dirt.AddIngredient(ModContent.ItemType<TruestExcalibur>(), 1);
            dirt.Register();
        }

    }
}
