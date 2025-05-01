using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using sixEG.Content.Projectiles;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace sixEG.Content.Items.Weapons.UpgradableWeapons.RecursiveClusterBombShooter
{ 

	public class RecursiveClusterBombShooterMK2 : ModItem
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
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(gold: 23);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<ClusterBombParent>();

        	Item.shootSpeed = 15f; 
        	Item.noMelee = true; 
			Item.damage = 37;  //MK1 damage is 21
		}

        public override bool? UseItem(Player player)
        {
            if (shotCycle == 0) 
            {
                Item.shoot = ModContent.ProjectileType<ClusterBombParent>(); // clusters halve the damage for the children
                shotCycle++;
            } else {
                Item.shoot = ModContent.ProjectileType<RecursiveClusterBombParent>(); //recursive cluster parents give the full damage to the cluster parent
                shotCycle = 0;
            }
            
            
            
            return true; 
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<RecursiveClusterBombShooterMK1>(), 1);
			recipe.AddIngredient(ModContent.ItemType<Items.ProgressionItems.UpgradeModules.UpgradeModuleOne>(), 1);
			recipe.AddTile(ModContent.TileType<Tiles.CraftingStationTile>());
			recipe.Register();
		}
	}
}
