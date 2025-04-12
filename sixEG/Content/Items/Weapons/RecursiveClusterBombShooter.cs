using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using sixEG.Content.Projectiles;

namespace sixEG.Content.Items.Weapons
{ 

	public class RecursiveClusterBombShooter : ModItem
	{
        private int shotCycle = 0;
		public override void SetDefaults()
		{
			Item.damage = 21;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(silver: 72);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;

        	Item.shootSpeed = 15f; 
        	Item.noMelee = true; 
		}

        public override bool? UseItem(Player player)
        {
            if (shotCycle == 0) 
            {
                Item.shoot = ModContent.ProjectileType<ClusterBombParent>();
                shotCycle++;
            } else {
                Item.shoot = ModContent.ProjectileType<RecursiveClusterBombParent>();
                shotCycle = 0;
            }
            
            
            
            return true; 
        }


		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.IronBar, 14);
			recipe.AddIngredient(ItemID.TungstenBar, 14);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
