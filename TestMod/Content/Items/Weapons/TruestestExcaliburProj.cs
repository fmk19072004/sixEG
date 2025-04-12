using Microsoft.Build.Evaluation;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TestMod.Content.Items.Weapons
{
    public class TruestestExcaliburProj : ModProjectile
    {       
        public override void SetDefaults()
        {

            Projectile.CloneDefaults(ProjectileID.EnchantedBoomerang);            
            AIType = ProjectileID.EnchantedBoomerang;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.height = 200;
            Projectile.width = 200;
            Projectile.rotation += 25f * (float)Projectile.direction;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 240;
            
        }
        public override void EmitEnchantmentVisualsAt(Vector2 boxPosition, int boxWidth, int boxHeight)
        {
            base.EmitEnchantmentVisualsAt(boxPosition, boxWidth, boxHeight);
            Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.EnchantedNightcrawler, 0, 0, 50);          
            Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.AncientLight, 0, 0, 50);
            
        }
        


    }
}
