using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using Terraria.DataStructures;

namespace sixEG.Content.Items.Weapons
{
    public class ArtilleryCommand : ModItem
    {
        private int shotsFired = 0; 
        private int cooldownTime = 0;
        private int reloadTimer = 60; 
        public override void SetDefaults()
        {
            Item.damage = 0;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 48;
            Item.height = 48;
            Item.useTime = 15; 
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.noMelee = true;
            Item.value = Item.buyPrice(0, 0, 20, 7);
            Item.rare = ItemRarityID.LightRed;
            Item.autoReuse = true;
        }

        public override bool CanUseItem(Player player)
        {
            if (cooldownTime > 0)
            {
                return false;
            }

            return true; 
        }

        public override void HoldItem(Player player)
        {
            if (cooldownTime > 0)
            {
                cooldownTime--; 
            }

            if (reloadTimer > 0)
            {
                reloadTimer--;
            } else {
                if (shotsFired > 0)
                {
                    shotsFired--;
                }

                reloadTimer = 90;
            }
        }

        public override bool? UseItem(Player player)
        {
            
            Vector2 mousePosition = Main.MouseWorld; 

            CreateExplosion(mousePosition, 175, 2f, player);

            shotsFired++;  

            if (shotsFired >= 15)
            {
                cooldownTime = 700; 
                shotsFired = 0; 
            }

            return true; 
        }

        private void CreateExplosion(Vector2 position, int damage, float knockBack, Player player)
        {
            float explosionRadius = 120f; 

            SoundEngine.PlaySound(SoundID.Item14, position);

            for (int i = 0; i < 150; i++)
            {
                Vector2 dustPos = position + Main.rand.NextVector2Circular(explosionRadius, explosionRadius);
                Dust dust = Dust.NewDustDirect(dustPos, 10, 10, DustID.Torch, 0, 0, 100, default, 2f);
                dust.velocity *= 2;
                dust.noGravity = true;

                Dust dust2 = Dust.NewDustDirect(dustPos, 10, 10, DustID.Smoke, 0, 0, 100, default, 2f);
                dust2.velocity *= 2;
                dust2.noGravity = true;
            }
            

            foreach (NPC npc in Main.npc)
            {
                if (npc.active && !npc.friendly)
                {
                    float distance = Vector2.Distance(npc.Center, position);
                    if (distance < explosionRadius)
                    {
                        float damageMultiplier = 1f - (distance / explosionRadius);
                        int finalDamage = (int)(damage * damageMultiplier);

                    NPC.HitInfo hitInfo = new NPC.HitInfo()
                    {
                        Damage = finalDamage,
                        Knockback = knockBack
                    };

                    bool direction = (npc.Center.X > position.X);

                npc.StrikeNPC(hitInfo, direction);
                    }
                }
            }
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 1);
			recipe.Register();
		}
    }
}
